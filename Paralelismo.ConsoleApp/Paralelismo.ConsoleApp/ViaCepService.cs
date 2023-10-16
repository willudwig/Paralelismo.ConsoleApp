﻿using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Paralelismo.Models;

namespace Paralelismo
{
    public class ViaCepService
    {
        public CepModel GetCep(string cep)
        {
            var client = new HttpClient();
            var response = client.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var cepResult = JsonSerializer.Deserialize<CepModel>(content);            

            return cepResult;
        }
    }
}