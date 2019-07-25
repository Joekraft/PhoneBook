using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PhoneBook.Model;

namespace PhoneBook.Web.Services
{
    public static class EntriesRequestService
    {
        static string apiUrl = "https://localhost:44323/api";

        public static async Task<IEnumerable<Model.Entry>> GetEntriesAsync(int phoneBookId)
        {
            IEnumerable<Model.Entry> entries = Enumerable.Empty<Model.Entry>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl + "/Entries?phoneBookId=" + phoneBookId);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    entries = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Model.Entry>>(data);
                }
            }
            return entries;
        }

        public static async Task<IEnumerable<Model.Entry>>  SearchEntriesAsync(int phoneBookId, string searchString)
        {
            IEnumerable<Model.Entry> entries = Enumerable.Empty<Model.Entry>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl + "/Entries?phoneBookId=" + phoneBookId + "&searchString=" + searchString);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    entries = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Model.Entry>>(data);
                }
            }
            return entries;
        }

        public static async Task<Model.Entry> GetEntryAsync(int? Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl + "/Entries/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Model.Entry entry = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.Entry>(data);
                    return entry;
                }
                return null;
            }
        }

        public static async Task<Model.Entry> PostEntryAsync(Entry entry)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl + "/Entries/", entry);
            }
            return null;
        }

        public static async Task PutEntryAsync(Entry entry)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsJsonAsync(apiUrl + "/Entries/" + entry.Id, entry);
            }
        }

        public static async Task<bool> EntryExistsAsync(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl + "/Entries/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public static async Task DeleteEntryAsync(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(apiUrl + "/Entries/" + Id);
            }
        }
    }

}
