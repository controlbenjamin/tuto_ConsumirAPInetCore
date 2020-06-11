using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using APIConsume.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIConsume.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
    
        [HttpGet]
        public async Task<string> Get()
        {

            string url = @"https://api.covid19api.com/countries";

            HttpClient client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                //Content = new StringContent()
            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);





            return responseBody;
            //var pais = new Countries();
            //pais.Country = "Argentina";
            //pais.ISO2 = "papa";
            //pais.Slug = "lungo";

            //var lista = new List<Countries>();

            //lista.Add(pais);

            //return lista;

        }
    }
}
