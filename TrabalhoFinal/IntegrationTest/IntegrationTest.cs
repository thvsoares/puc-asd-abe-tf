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
        [TestMethod]
        public void TesteIntegracao()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var caminhoAtacadista = "http://localhost:50396";
                var caminhoProdutoAtacadista = caminhoAtacadista + "/api/Produto";

                var caminhoLojista = "http://localhost:50404/";
                var caminhoProdutoLojista = caminhoLojista + "/api/Produto";

                var produto = new Atacadista.Model.Produto() { Id = 1, Nome = "Teste1", Valor = 1 };
                var jsonProduto = JsonConvert.SerializeObject(produto);

                client.PutAsync(caminhoProdutoAtacadista + "/1", new StringContent(jsonProduto, Encoding.UTF8, "application/json")).Wait();

                var jsonProdutoGravado = client.GetStringAsync(caminhoProdutoAtacadista).Result;
                var produtoGravado = JsonConvert.DeserializeObject<List<Atacadista.Model.Produto>>(jsonProdutoGravado).Single();

                Assert.AreEqual(1, produtoGravado.Id);
                Assert.AreEqual("Teste1", produtoGravado.Nome);
                Assert.AreEqual(1, produtoGravado.Valor);
            }
        }
    }
}
