using Gastosv4.Entidades;
using Newtonsoft.Json;

namespace Gastosv4.services
{
    public class DuckBankServicio
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _url;

        public DuckBankServicio(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _url = configuration.GetValue<string>("DuckBankMs");
        }

        public async Task<List<Ahorro>> ObtenerAsync()
        {
            HttpResponseMessage response;
            List<Ahorro> ahorros;

            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, _url + "/Ahorros/Todos");
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
                ahorros = JsonConvert.DeserializeObject<List<Ahorro>>(await response.Content.ReadAsStringAsync());
            else
                ahorros = new List<Ahorro>();

            return ahorros;
        }

        public async Task<int> AgregarAsycn(Ahorro ahorro)
        {
            HttpResponseMessage response;            

            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _url + "/Ahorros");
            var content = new StringContent(JsonConvert.SerializeObject(ahorro), null, "application/json");
            request.Content = content;
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync();
            }

            return 0;
        }

        public async Task<Ahorro> ObtenerAsync(string id)
        {
            HttpResponseMessage response;
            Ahorro ahorro;

            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, _url + "/Ahorros/" + id);
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
                ahorro = JsonConvert.DeserializeObject<Ahorro>(await response.Content.ReadAsStringAsync());
            else
                ahorro = null;

            return ahorro;
        }

        public async Task DepositarAsync(string id, Movimiento movimiento)
        {
            HttpResponseMessage response;

            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _url + $"/Ahorros/{id}/Depositos");
            var content = new StringContent(JsonConvert.SerializeObject(movimiento), null, "application/json");
            request.Content = content;
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
            }
            string mensaje = await response.Content.ReadAsStringAsync();
        }

        public async Task RetirarAsync(string id, Movimiento movimiento)
        {
            HttpResponseMessage response;

            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _url + $"/Ahorros/{id}/Retiros");
            var content = new StringContent(JsonConvert.SerializeObject(movimiento), null, "application/json");
            request.Content = content;
            response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
            }
            string mensaje = await response.Content.ReadAsStringAsync();
        }
    }
}