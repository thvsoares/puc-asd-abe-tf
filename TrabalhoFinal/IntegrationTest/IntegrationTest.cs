using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationTest
{
    [TestClass]
    public class IntegrationTest
    {
        public const string CAMINHO_ATACADISTA = "http://localhost:50396";
        public const string CAMINHO_PRODUTO_ATACADISTA = CAMINHO_ATACADISTA + "/api/Produto";

        public const string CAMINHO_LOJISTA = "http://localhost:50404/";
        public const string CAMINHO_LOJISTA_PRODUTO = CAMINHO_LOJISTA + "/api/Produto";
        public const string CAMINHO_LOJISTA_ESTOQUE = CAMINHO_LOJISTA + "/api/Estoque";
        public const string CAMINHO_LOJISTA_PEDIDO = CAMINHO_LOJISTA + "/api/Pedido";

        /// <summary>
        /// Inicializa os repositórios e configura os serviços
        /// </summary>
        [TestInitialize]
        public void Configuracao()
        {
            var produtoAtacadista = new Atacadista.Model.Produto() { Id = 1, Nome = "Teste1", Valor = 1 };

            // Grava o produto no atacadista
            Put(CAMINHO_PRODUTO_ATACADISTA + "/1", produtoAtacadista);

            // Grava o produto no lojista
            var produtoLojista = new Lojista.Model.Produto() { Id = 1, Nome = "Teste1" };
            Put(CAMINHO_LOJISTA_PRODUTO + "/1", produtoLojista);
            var produtoGravadoLojista = Get<List<Lojista.Model.Produto>>(CAMINHO_LOJISTA_PRODUTO).Single(s => s.Id == 1);

            // Grava o estoque do produto do lojista
            var estoqueP1 = new Lojista.Model.Estoque() { Produto = produtoGravadoLojista, Quantidade = 2 };
            Put(CAMINHO_LOJISTA_ESTOQUE + "/1", estoqueP1);
        }

        /// <summary>
        /// Realiza o fluxo completo descrito no trabalho final
        /// </summary>
        [TestMethod]
        public void TesteIntegracao()
        {
        }

        [TestMethod]
        public void ValidacaoProdutoAtacadista()
        {
            // Recupera os produtos do atacadista e chama single que retorna apenas e existir apenas um produto
            // Abortaria com uma excption caso contrário
            var produtoGravadoAtacadista = Get<List<Atacadista.Model.Produto>>(CAMINHO_PRODUTO_ATACADISTA).Single(s => s.Id == 1);

            // Verifica se os dados do produto do atacadista continuam os mesmos
            Assert.AreEqual(1, produtoGravadoAtacadista.Id);
            Assert.AreEqual("Teste1", produtoGravadoAtacadista.Nome);
            Assert.AreEqual(1, produtoGravadoAtacadista.Valor);
        }

        [TestMethod]
        public void ValidacaoProdutoLojista()
        {
            var produtoGravadoLojista = Get<List<Lojista.Model.Produto>>(CAMINHO_LOJISTA_PRODUTO).Single(s => s.Id == 1);
            Assert.AreEqual(1, produtoGravadoLojista.Id);
            Assert.AreEqual("Teste1", produtoGravadoLojista.Nome);
        }

        [TestMethod]
        public void ValidacaoEstoqueLojista()
        {
            var estoqueLojista = Get<List<Lojista.Model.Estoque>>(CAMINHO_LOJISTA_ESTOQUE).Single(s => s.Produto.Id == 1);
            Assert.AreEqual(1, estoqueLojista.Produto.Id);
            Assert.AreEqual(2, estoqueLojista.Quantidade);
        }

        #region [ Helpers ]
        /// <summary>
        /// Recupera um recurso com get numa uri
        /// </summary>
        /// <typeparam name="T">Tipo do recurso a ser recuperado</typeparam>
        /// <param name="uri">Caminho do recurso a ser recuperado</param>
        /// <returns>Recurso recuperado no formado informado</returns>
        private T Get<T>(string uri)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var json = client.GetStringAsync(uri).Result;
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        /// <summary>
        /// Grava um recurso com put numa uri
        /// </summary>
        /// <param name="uri">Camiho do recurso a ser gravado</param>
        /// <param name="obj">Recurso a ser gravado</param>
        /// <returns>Resultado da gravação</returns>
        private HttpResponseMessage Put(string uri, object obj)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return client.PutAsync(uri, content).Result;
            }
        }

        /// <summary>
        /// Grava um recurso com post numa uri
        /// </summary>
        /// <typeparam name="T">Tipo para desserializar o conteúdo do retorno</typeparam>
        /// <param name="uri">Camiho do recurso a ser gravado</param>
        /// <param name="obj">Recurso a ser gravado</param>
        /// <returns>Conteúro da resposta transformada no tipo T</returns>
        private T Post<T>(string uri, object obj)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var jsonRequest = JsonConvert.SerializeObject(obj);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var httpResult = client.PostAsync(uri, content).Result;
                var jsonResult = httpResult.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }
        }
        #endregion
    }
}
