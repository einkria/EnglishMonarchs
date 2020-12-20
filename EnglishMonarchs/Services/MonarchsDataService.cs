using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EnglishMonarchs.Models;

namespace EnglishMonarchs.Services
{
    class MonarchsDataService : IMonarchsDataService
    {
        static System.Net.Http.HttpClient client;
        static String requestUrl = "https://localhost:5001/api/EnglishMonarchs";

        public async Task<IList<Monarch>> GetMonarchs()
        {
            return await GetEnglishMonarchs();
        }

        /*
         * Calls MonarchsApi to get a list of English Monarchs to present to user.
         */
        private async Task<IList<Monarch>> GetEnglishMonarchs()
        {
            IList<Monarch> monarchs = null;
            SetupClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    monarchs = await response.Content.ReadAsAsync<List<Monarch>>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred. Could not fetch data: " + ex);
            }

            return monarchs;
        }

        /*
         * Http client setup, including setting request headers.
         */
        private void SetupClient()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
