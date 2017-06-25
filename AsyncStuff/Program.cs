using System;
using System.Net.Http;

namespace AsyncStuff
{
    class MainClass
    {
        public async static void Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                var requestTask = await client.GetAsync(@"https://www.filipekberg.se/rss/");

                var readTask = await requestTask.Content.ReadAsStringAsync();

                Console.WriteLine(readTask.Substring(0, 100));
            }
        }


    }
}
