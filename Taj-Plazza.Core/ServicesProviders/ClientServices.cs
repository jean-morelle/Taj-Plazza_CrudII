using Azure;
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

        public async Task AddClient(Client newClient)
        {
            
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(newClient), Encoding.UTF8, "application/json");

                HttpResponseMessage responses = await httpClient.PostAsync(RequestUri, content);

                string responseString = await responses.Content.ReadAsStringAsync();

                if (responses.IsSuccessStatusCode)
                {
                    switch (responses.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            newClient = JsonConvert.DeserializeObject<Client>(responseString);

                            Console.WriteLine("Client cree avec success");

                            break;

                        default:
                            Console.WriteLine("Code de statut inattendu :" + responses.StatusCode);
                            break;
                    }
                }
                else
                {
                    switch (responses.StatusCode)
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
                            Console.WriteLine("Erreur inattendue:" + responses.StatusCode);
                            break;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Erreur lors de l'appel HTTP :" + e.Message);
            }
            catch (TaskCanceledException e)
            {
                Console.WriteLine("La requête a expiré : " + e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Opération invalide : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur générale : " + e.Message);
            }
            
        }

        public async Task DeleteClient(int clientId)
        {
           
                var responses = await httpClient.GetAsync($"{RequestUri}/clients/ {clientId}");
                responses.EnsureSuccessStatusCode();
                Console.WriteLine($"Client avec ID {clientId} a été supprimé.");
            
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            List<Client> clients = new List<Client>();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(RequestUri);
                string responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            clients =  JsonConvert.DeserializeObject<List<Client>>(responseString);
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

        public async Task<Client> GetClient(int clientId)
        {
            Client client = null;
            try
            {
                HttpResponseMessage responses = await httpClient.GetAsync($"{RequestUri}/{clientId}");
                string responseString = await responses.Content.ReadAsStringAsync();
                if (responses.IsSuccessStatusCode)
                {
                    switch (responses.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            client = JsonConvert.DeserializeObject<Client>(responseString);
                            break;
                        default:
                            Console.WriteLine("Code de statut inattendu :" + responses.StatusCode);
                            break;
                    }
                }
                else
                {
                    switch (responses.StatusCode)
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
                            Console.WriteLine("Erreur inattendue:" + responses.StatusCode);
                            break;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Erreur lors de l appel HTTP :" + e.Message);
            }
            return client;

        }
        public async Task UpdateClient(int clientId, Client UpdateClient)
        {
            Client client = null;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(UpdateClient), Encoding.UTF8, "application/json");
                HttpResponseMessage responses = await httpClient.PutAsync($"{RequestUri}/{clientId}", content);
                string responseString = await responses.Content.ReadAsStringAsync();

                if (responses.IsSuccessStatusCode)
                {
                    switch (responses.StatusCode) {
                        case System.Net.HttpStatusCode.OK:
                        case System.Net.HttpStatusCode.NoContent:
                            client = JsonConvert.DeserializeObject<Client>(responseString);
                            break;
                        default:
                            Console.WriteLine("Code de statut inattendu" + responses.StatusCode);
                            break;
                    }
                
                }
                else
                {
                    switch (responses.StatusCode)
                    {
                        case System.Net.HttpStatusCode.NotFound:
                            Console.WriteLine("Client non trouvé.");
                            break;
                        case System.Net.HttpStatusCode.BadRequest:
                            Console.WriteLine("Requête incorrecte.");
                            break;
                        case System.Net.HttpStatusCode.Unauthorized:
                            Console.WriteLine("Vous devez être connecté pour accéder à cette ressource.");
                            break;
                        case System.Net.HttpStatusCode.InternalServerError:
                            Console.WriteLine("Erreur interne du serveur.");
                            break;
                        default:
                            Console.WriteLine("Erreur inattendue : " + responses.StatusCode);
                            break;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Erreur lors de l'appel HTTP : " + e.Message);
            }
            catch (TaskCanceledException e) 
            { Console.WriteLine("La requête a expiré : " + e.Message);
            
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Opération invalide : " + e.Message);
            }
            catch(Exception e) 
            { 
                Console.WriteLine("Erreur générale : " + e.Message);
            }
        }
    }
}
