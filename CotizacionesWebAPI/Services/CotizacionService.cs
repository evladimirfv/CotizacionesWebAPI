using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;

using CotizacionesWebAPI.Models;
using Newtonsoft.Json;

namespace CotizacionesWebAPI.Services
{

  
    interface IStrategy
    {
        string ObtenerCotizacion(string id);
    }

    // Implementa el algoritmo usando el patron estrategia
    class CotizacionA : IStrategy   // ConcreteStrategy A
    {
        public string ObtenerCotizacion(string id)
        {
            //  "ARS", "USD", "EUR","BRL" 
            Dictionary<string, string> misMonedas = new Dictionary<string, string>()
            {
                { "dolar", "USD" },
                { "euro", "EUR" },
                { "real", "BRL" }
            };

            string sigla = misMonedas[id];

            var responseMessage = new HttpResponseMessage();
            var responseModel = new WelcomeModel();
        
            using (var cliente = new HttpClient())
            {
                responseMessage = cliente.GetAsync($"https://api.cambio.today/v1/quotes/" + sigla + $"/ARS/json?quantity=1&key=3068|kkQfQg08kWKsQciBEvLY8DcTipsa87dK").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string jsonResult = responseMessage.Content.ReadAsStringAsync().Result;
                    responseModel = JsonConvert.DeserializeObject<WelcomeModel>(jsonResult);

                  //  responseModel.Cotizaciones = responseModel..Where(m => misMonedas.Contains(m.Key)).ToDictionary(n => n.Key, n => n.Value);
                }
            }

            return JsonConvert.SerializeObject(responseModel);

            // Console.WriteLine("Called ConcreteStrategyA.Execute()");
        }
    }

    /*
    {

  "result": {

    "updated": "2020-03-05T15:00:17",

    "source": "USD",

    "target": "ARS",

    "value": 62.41,

    "quantity": 1.0,

    "amount": 62.41

  },

  "status": "OK"

}
*/


    class CotizacionB : IStrategy     // ConcreteStrategyB
    {
        public string ObtenerCotizacion(string id)
        {
            return "";
              //  Console.WriteLine("Called ConcreteStrategyB.Execute()");
        }
    }



    // Contiene un objeto ConcreteStrategy y mantiene una referencia a un objeto Strategy
    class ServiceContext
    {
        IStrategy strategy;

        // Constructor
        public ServiceContext(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public string ObtenerCotizacion(string id)
        {
            return strategy.ObtenerCotizacion(id);
        }
    }


}


