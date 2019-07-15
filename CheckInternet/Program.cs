using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckInternet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Internet checker");
            
            await CheckInternet();
        }

        private static async Task CheckInternet()
        {
            using (var httpClient = new HttpClient())
            {
                while (true)
                {
                    try
                    {
                        var httpResponseMessage = await httpClient.GetAsync("https://google.com");

                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            Console.WriteLine("WooHoo internet!");

                            Console.Beep(2000, (int)TimeSpan.FromSeconds(5).TotalMilliseconds);

                            return;
                        }
                        
                    }
                    catch
                    {
                        // ignored
                    }

                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
        }
    }
}
