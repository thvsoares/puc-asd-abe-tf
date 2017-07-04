using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Runtime.Serialization.Json;

namespace IntegrationTest
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void TesteIntegracao()
        {
            var client = new HttpClient();
            var serializerProdutoAtacadista = new DataContractJsonSerializer(typeof(Atacadista.Model.Produto));

            var produtoAtacadista1 = new Atacadista.Model.Produto() { Id = 1, Nome = "Teste1", Valor = 1 };
        }
    }
}
