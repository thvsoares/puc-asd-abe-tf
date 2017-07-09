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
        public const string CAMINHO_ATACADISTA_CONFIGURACAO = CAMINHO_ATACADISTA + "/api/Configuracao";
        public const string CAMINHO_ATACADISTA_PEDIDO = CAMINHO_ATACADISTA + "/api/Pedido";
        public const string CAMINHO_ATACADISTA_PRODUTO = CAMINHO_ATACADISTA + "/api/Produto";
        public const string CAMINHO_ATACADISTA_ORCAMENTO = CAMINHO_ATACADISTA + "/api/Orcamento";

        public const string CAMINHO_LOJISTA = "http://localhost:50404/";
        public const string CAMINHO_LOJISTA_CONFIGURACAO = CAMINHO_LOJISTA + "/api/Configuracao";
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
            Put(CAMINHO_ATACADISTA_PRODUTO + "/1", produtoAtacadista);

            // Grava o produto no lojista
            var produtoLojista = new Lojista.Model.Produto() { Id = 1, Nome = "Teste1" };
            Put(CAMINHO_LOJISTA_PRODUTO + "/1", produtoLojista);
            var produtoGravadoLojista = Get<List<Lojista.Model.Produto>>(CAMINHO_LOJISTA_PRODUTO).Single(s => s.Id == 1);

            // Grava o estoque do produto do lojista
            var estoqueP1 = new Lojista.Model.Estoque() { Produto = produtoGravadoLojista, Quantidade = 2 };
            Put(CAMINHO_LOJISTA_ESTOQUE + "/1", estoqueP1);

            // Configura os caminhos de comunicação
            Put(CAMINHO_ATACADISTA_CONFIGURACAO, new KeyValuePair<string, string>("UrlLojista", CAMINHO_LOJISTA));
            Put(CAMINHO_LOJISTA_CONFIGURACAO, new KeyValuePair<string, string>("UrlAtacadista", CAMINHO_ATACADISTA));
        }

        /// <summary>
        /// Realiza o fluxo completo descrito no trabalho final
        /// </summary>
        [TestMethod]
        public void TesteIntegracao()
        {
            // Passo 1 verificação do estoque baixo do lojista
            var estoqueLojista = Get<List<Lojista.Model.Estoque>>(CAMINHO_LOJISTA_ESTOQUE).Single(s => s.Produto.Id == 1);
            Assert.IsTrue(estoqueLojista.Quantidade < 10);

            // Passo 2 logista solicita o primeiro orçamento
            var pedidoMaiorLojista = new Lojista.Model.Pedido()
            {
                Itens = new List<Lojista.Model.PedidoItem>(new Lojista.Model.PedidoItem[] {
                    new Lojista.Model.PedidoItem(){ IdProduto = 1, Quantidade = 10, Observacao="Pedido maior" }
                })
            };
            var idPedidoMaior = Post<int>(CAMINHO_LOJISTA_PEDIDO, pedidoMaiorLojista);
            var pedidoMaiorGravadoLojista = Get<Lojista.Model.Pedido>($"{CAMINHO_LOJISTA_PEDIDO}/{idPedidoMaior}");
            Assert.AreEqual(Lojista.Model.EstadoPedido.Solicitado, pedidoMaiorGravadoLojista.Estado);
            Assert.AreEqual(1, pedidoMaiorGravadoLojista.Itens.Single().IdProduto);
            Assert.AreEqual(10, pedidoMaiorGravadoLojista.Itens.Single().Quantidade);
            Assert.AreEqual("Pedido maior", pedidoMaiorGravadoLojista.Itens.Single().Observacao);
            Assert.IsNull(pedidoMaiorGravadoLojista.Orcamento);

            // Passo 3 o atacadista recebe o pedido
            var pedidoMaiorAtacadista = Get<List<Atacadista.Model.Pedido>>(CAMINHO_ATACADISTA_PEDIDO).Single(s => s.Id == idPedidoMaior);
            Assert.AreEqual(Atacadista.Model.EstadoPedido.Solicitado, pedidoMaiorAtacadista.Estado);
            Assert.AreEqual(1, pedidoMaiorAtacadista.Itens.Single().IdProduto);
            Assert.AreEqual(10, pedidoMaiorAtacadista.Itens.Single().Quantidade);
            Assert.AreEqual("Pedido maior", pedidoMaiorAtacadista.Itens.Single().Observacao);

            // Passo 4 criação orçamento atacadista
            var orcamentoMaiorAtacadista = new Atacadista.Model.Orcamento()
            {
                IdPedido = idPedidoMaior,
                PrevisaoEntrega = DateTime.Today.AddDays(10),
                Valor = 20
            };
            var idOrcamentoMaior = Post<int>(CAMINHO_ATACADISTA_ORCAMENTO, orcamentoMaiorAtacadista);
            var orcamentoMaiorGravadoAtacadista = Get<List<Atacadista.Model.Orcamento>>(CAMINHO_ATACADISTA_ORCAMENTO).Single(s => s.Id == idOrcamentoMaior);
            Assert.AreEqual(idPedidoMaior, orcamentoMaiorGravadoAtacadista.IdPedido);
            Assert.AreEqual(DateTime.Today.AddDays(10), orcamentoMaiorGravadoAtacadista.PrevisaoEntrega);
            Assert.AreEqual(20, orcamentoMaiorGravadoAtacadista.Valor);

            // Passo 5 receber proposta oraçamento
            var orcamentoMaiorGravadoLojista = Get<List<Atacadista.Model.Pedido>>(CAMINHO_ATACADISTA_PEDIDO)
                .Single(s => s.Id == idPedidoMaior)
                .Orcamento;
            Assert.AreEqual(DateTime.Today.AddDays(10), orcamentoMaiorGravadoLojista.PrevisaoEntrega);
            Assert.AreEqual(20, orcamentoMaiorGravadoLojista.Valor);
        }

        [TestMethod]
        public void ValidacaoProdutoAtacadista()
        {
            // Recupera os produtos do atacadista e chama single que retorna apenas e existir apenas um produto
            // Abortaria com uma excption caso contrário
            var produtoGravadoAtacadista = Get<List<Atacadista.Model.Produto>>(CAMINHO_ATACADISTA_PRODUTO).Single(s => s.Id == 1);

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

        //[TestMethod]
        //public void GravacaoPedidoAtacadista()
        //{
        //    var pedido = new Atacadista.Model.Pedido()
        //    {
        //        Itens = new List<Atacadista.Model.PedidoItem>(new Atacadista.Model.PedidoItem[] {
        //            new Atacadista.Model.PedidoItem()
        //            {
        //                IdProduto=1,
        //                Quantidade= 2,
        //                Observacao="Teste crud"
        //            }
        //        })
        //    };

        //    var idPedido = Post<int>(CAMINHO_ATACADISTA_PEDIDO, pedido);
        //    var pedidoGravado = Get<List<Atacadista.Model.Pedido>>(CAMINHO_ATACADISTA_PEDIDO).Single(s => s.Id == idPedido);

        //    Assert.AreEqual(1, pedido.Itens.Single().IdProduto);
        //    Assert.AreEqual(2, pedido.Itens.Single().Quantidade);
        //    Assert.AreEqual("Teste crud", pedido.Itens.Single().Observacao);
        //}

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
