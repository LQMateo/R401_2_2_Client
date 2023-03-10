using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Services
{
    /// <summary>
    /// WSService est une classe générique qui implémente une API Web pour les services REST.
    /// </summary>
    /// <typeparam name="T">Le type générique des données à retourner pour les différentes méthodes.</typeparam>
    public class WSService<T> : IWSService<T>
    {
        System.Net.Http.HttpClient client;
        System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();   

        /// <summary>
        /// Récupère les données de l'API à l'aide d'une requête GET.
        /// </summary>
        /// <param name="nomControleur">Le nom du contrôleur à interroger.</param>
        /// <returns>Retourne une liste des données de type T, ou null en cas d'erreur.</returns>
        public async Task<List<T>> GetAsync(string nomControleur)
        {
           try
           {
                return await client.GetFromJsonAsync<List<T>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Envoie les données à l'API à l'aide d'une requête PUT.
        /// </summary>
        /// <param name="nomControleur">Le nom du contrôleur à interroger.</param>
        /// <returns>Retourne une liste vide des données de type T.</returns>
        public async Task<System.Net.Http.HttpResponseMessage> PutAsync(string nomControleur, T objet)
        {
            try
            {
                var json = JsonSerializer.Serialize(objet);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");            
                using var response4 = await httpClient.PutAsync(client.BaseAddress + "/" + nomControleur, stringContent);
                Console.WriteLine(response4);
                return response4.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Envoie les données à l'API à l'aide d'une requête POST.
        /// </summary>
        /// <param name="nomControleur">Le nom du contrôleur à interroger.</param>
        /// <returns>Retourne une liste vide des données de type T.</returns>
        public async Task<System.Net.Http.HttpResponseMessage> PostAsync(string nomControleur, T objet)
        {
            try
            {
                var json = JsonSerializer.Serialize(objet);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                using var response4 = await httpClient.PostAsync(client.BaseAddress + "/" + nomControleur, stringContent);
                return response4.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        /// <summary>
        /// Supprime les données de l'API à l'aide d'une requête DELETE.
        /// </summary>
        /// <param name="nomControleur">Le nom du contrôleur à interroger.</param>
        /// <returns>Retourne une liste vide des données de type T.</returns>
        public async Task<System.Net.Http.HttpResponseMessage> DeleteAsync(string nomControleur)
        {
            try
            {
                using var response4 = await httpClient.DeleteAsync(client.BaseAddress + "/" + nomControleur);
                return response4.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Récupère une série de données de l'API.
        /// </summary>
        /// <param name="nomControleur">Le nom du contrôleur à interroger.</param>
        /// <returns>Retourne une liste vide des données de type T</returns>
        public async Task<List<T>> GetSerieAsync(string nomControleur)
        {
            return null;
        }

        /// <summary>
        /// Construct a webService
        /// </summary>        
        /// <param name="nameURI">Name of URI for this service</param>
        public WSService()
        {
            client = new System.Net.Http.HttpClient();
            //client.BaseAddress = new Uri("https://localhost:" + PORT + "/api/" + nameUri);
            client.BaseAddress = new Uri("https://r40122.azurewebsites.net/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
