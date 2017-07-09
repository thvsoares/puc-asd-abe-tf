using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lojista.Model
{
    public class AtacadistaRepository : IAtacadistaRepository
    {
        private static string _urlAtacadista;
        public string UrlAtacadista { get => _urlAtacadista; set => _urlAtacadista = value; }

        public void AceitarOrcamento(int id)
        {
            Put($"{UrlAtacadista}/api/orcamento/aceitar/{id}", null);
        }

        public void RejeitarOrcamento(int id)
        {
            Put($"{UrlAtacadista}/api/orcamento/rejeitar/{id}", null);
        }

        public int SolicitacaoPedido(Pedido pedido)
        {
            return Post<int>($"{UrlAtacadista}/api/pedido", pedido);
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
    }
}
