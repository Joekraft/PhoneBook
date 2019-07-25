﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhoneBook.Web.Services
{
    public static class PhoneBookRequestService
    {
        static string apiUrl = "https://localhost:44323/api";

        public static async Task<IEnumerable<Model.PhoneBook>> GetPhoneBooksAsync()
        {
            IEnumerable<Model.PhoneBook> phonebooks = Enumerable.Empty<Model.PhoneBook>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl + "/PhoneBooks");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    phonebooks = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Model.PhoneBook>>(data);                  
                }
            }
            return phonebooks;
        }

        public static async Task<Model.PhoneBook> GetPhoneBookAsync(int? Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl + "/PhoneBooks/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Model.PhoneBook phonebook = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.PhoneBook>(data);
                    return phonebook;
                }
            }
            return null;
        }

        public static async Task<Model.PhoneBook> PutPhoneBookAsync(Model.PhoneBook phoneBook)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync(apiUrl + "/PhoneBooks/" + phoneBook.Id, phoneBook);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Model.PhoneBook phonebook = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.PhoneBook>(data);
                    return phonebook;
                }
            }
            return null;
        }

        public static async Task PostPhoneBookAsync(Model.PhoneBook phoneBook)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl + "/PhoneBooks/", phoneBook);
            }
        }

        public static async Task DeletePhoneBookAsync(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync(apiUrl + "/PhoneBooks/" + Id);
            }
        }

        public static async Task<bool> PhoneBookExistsAsync(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl + "/PhoneBooks/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

    }
}