using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Taj_Plazza.Core.Interface;
using Taj_Plazza.Core.Interfaces;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.ServicesProviders
{
    public class ClientServices : IclientServicesCore
    {
        private static string RequestUri = "api/Client";

        private readonly HttpClient httpClient;
        public ClientServices( HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task AddClient(Client client)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            IEnumerable<Client> clients = new List<Client>();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(RequestUri);
                string responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            clients =  JsonConvert.DeserializeObject<IEnumerable<Client>>(responseString);
                            break;
                        default:
                            Console.WriteLine("Code de statut inattendu :" + response.StatusCode);
                            break;
                    }
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.NotFound:
                            Console.WriteLine("Clients non trouves.");
                            break;

                        case System.Net.HttpStatusCode.BadRequest:
                            Console.WriteLine("Requete incorrecte.");
                            break;
                        case System.Net.HttpStatusCode.Unauthorized:
                            Console.WriteLine("vous devez etre connecte pour acceder a cette ressource.");
                            break;
                        case System.Net.HttpStatusCode.InternalServerError:
                            Console.WriteLine("Erreur interne du Serveur.");
                            break;
                        default:
                            Console.WriteLine("Erreur inattendue:" + response.StatusCode);
                            break;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Erreur lors de l appel HTTP :" + e.Message);
            }
            return clients;
        
        }

        public Task<Client> GetClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
