using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Atacadista.Model
{
    public class LojistaRepository : ILojistaRepository
    {
        private static string _urlLojista;
        public string UrlLojista { get => _urlLojista; set => _urlLojista = value; }

        public void NotificarMudancaPedido(int id, EstadoPedido estado)
        {
            Put($"{UrlLojista}/Pedido/AtualizarEstado/{id}/{estado}", null);
        }

        public void PropostaOrcamento(Orcamento orcamento)
        {
            Put($"{UrlLojista}/Orcamento/{orcamento.IdPedido}", null);
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
