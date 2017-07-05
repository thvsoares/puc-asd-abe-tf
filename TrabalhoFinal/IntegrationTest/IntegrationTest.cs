using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationTest
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void TesteIntegracao()
        {
            var basePath = "http://localhost:50396";
            var programaPath = basePath + "/api/Produto";

            var client = new HttpClient();

            var produtoAtacadista1 = new Atacadista.Model.Produto() { Id = 1, Nome = "Teste1", Valor = 1 };
            var jsonProdutoAtacadista1 = JsonConvert.SerializeObject(produtoAtacadista1);

            client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Accept()

            client.PutAsync(programaPath + "/1", new StringContent(jsonProdutoAtacadista1)).Wait();

            var jsonProdutoGravado = client.GetStringAsync(programaPath).Result;
            var produtoGravado = JsonConvert.DeserializeObject<List<Atacadista.Model.Produto>>(jsonProdutoGravado).Single();

            Assert.AreEqual(1, produtoGravado.Id);
            Assert.AreEqual("Teste1", produtoGravado.Nome);
            Assert.AreEqual(1, produtoGravado.Valor);
        }
    }
}
