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
        /// <summary>
        /// Realiza o fluxo completo descrito no trabalho final
        /// </summary>
        [TestMethod]
        public void TesteIntegracao()
        {
                var caminhoAtacadista = "http://localhost:50396";
                var caminhoProdutoAtacadista = caminhoAtacadista + "/api/Produto";

                var caminhoLojista = "http://localhost:50404/";
                var caminhoProdutoLojista = caminhoLojista + "/api/Produto";

                var produto = new Atacadista.Model.Produto() { Id = 1, Nome = "Teste1", Valor = 1 };

                // Grava o produto no atacadista
                Put(caminhoProdutoAtacadista + "/1", produto);

                // Recupera os produtos do atacadista e chama single que retorna apenas e existir apenas um produto
                // Abortaria com uma excption caso contrário
                var produtoGravado = Get<List<Atacadista.Model.Produto>>(caminhoProdutoAtacadista).Single();

                // Verifica se os dados do produto do atacadista continuam os mesmos
                Assert.AreEqual(1, produtoGravado.Id);
                Assert.AreEqual("Teste1", produtoGravado.Nome);
                Assert.AreEqual(1, produtoGravado.Valor);
        }

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
        /// <param name="uri">Camiho do recurso a ser gravado</param>
        /// <param name="obj">Recurso a ser gravado</param>
        /// <returns>Resultado da gravação</returns>
        private HttpResponseMessage Post(string uri, object obj)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return client.PostAsync(uri, content).Result;
            }
        }
    }
}
