using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HTTPRequests
{
    public class Requests
    {
        private readonly IHttpClientHandler _httpClient;

        public Requests(IHttpClientHandler httpClient) {
            _httpClient = httpClient;
        }

        /* 
        * It's good practice to keep these requests asynchronous. .NET uses * async/await just like ES2017. 
        */
        public async Task<string> GetData(string baseUrl)
        {
            //The 'using' will help to prevent memory leaks
            //Create a new instance of HttpClient
            IHttpClientHandler client = _httpClient;

            //Setting up the response...         
            using (HttpResponseMessage res = await client.GetAsync(baseUrl))
            try
            {
                Console.WriteLine("Starting here before expection");
                using (HttpContent content = res.Content)
                {
                    string data = await content.ReadAsStringAsync();
                    if (data != null)
                    {
                        Console.WriteLine(data);
                        return data;
                    }
                    else
                    {
                        Console.WriteLine("no data");
                        return "err no data";
                    }
                }
            }
            catch (Exception e)
            {
                return "err no content";
            }

        }

        public async Task<List<TodoModel>> GetTodosByUserId(string url, int userId)
        {
            //The 'using' will help to prevent memory leaks
            //Create a new instance of HttpClient

            var task = GetData(url);

            List<TodoModel> todos = null;
            await task.ContinueWith((jsonString) =>
              {
                  todos = JsonConvert.DeserializeObject<List<TodoModel>>(jsonString.Result);
                  todos = todos.FindAll(x => x.userId == userId);
              });
            return todos;
        }
    }
}

