using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HTTPRequests
{
    class Program
    {
        static void Main(string[] args)
        {

            Requests req = new Requests(new HttpClientHandler());
            string todoItem = req.GetData("https://jsonplaceholder.typicode.com/todos/1").Result;
            Console.WriteLine("Hello World! moo 123");
            Console.WriteLine(todoItem);
            List<TodoModel> todos = req.GetTodosByUserId("https://jsonplaceholder.typicode.com/todos", 1).Result;
            Console.WriteLine("list of todos");

            foreach (TodoModel todo in todos) {
                Console.WriteLine(todo.title);
            }

            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
