using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{

    static string acc = null;
    static int accountCount;
    static int satirCount;
    static string proxyPath;
    static int threads;

    static string successfullAttempts;

    static void Main()
    {

        Follow();






        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(Environment.NewLine);

        Console.WriteLine("$$\\   $$\\ $$\\                           $$\\ $$\\   $$\\               \r\n$$ | $$  |$$ |                          $$ |\\__|  $$ |              \r\n$$ |$$  / $$$$$$$\\   $$$$$$\\   $$$$$$\\  $$ |$$\\ $$$$$$\\    $$$$$$\\  \r\n$$$$$  /  $$  __$$\\  \\____$$\\ $$  __$$\\ $$ |$$ |\\_$$  _|   \\____$$\\ \r\n$$  $$<   $$ |  $$ | $$$$$$$ |$$$$$$$$ |$$ |$$ |  $$ |     $$$$$$$ |\r\n$$ |\\$$\\  $$ |  $$ |$$  __$$ |$$   ____|$$ |$$ |  $$ |$$\\ $$  __$$ |\r\n$$ | \\$$\\ $$ |  $$ |\\$$$$$$$ |\\$$$$$$$\\ $$ |$$ |  \\$$$$  |\\$$$$$$$ |\r\n\\__|  \\__|\\__|  \\__| \\_______| \\_______|\\__|\\__|   \\____/  \\_______|\r\n                                                                    \r\n                                                                    \r\n                                                                    \r\n$$$$$$$$\\                  $$\\                                      \r\n\\__$$  __|                 $$ |                                     \r\n   $$ | $$$$$$\\   $$$$$$\\  $$ | $$$$$$$\\                            \r\n   $$ |$$  __$$\\ $$  __$$\\ $$ |$$  _____|                           \r\n   $$ |$$ /  $$ |$$ /  $$ |$$ |\\$$$$$$\\                             \r\n   $$ |$$ |  $$ |$$ |  $$ |$$ | \\____$$\\                            \r\n   $$ |\\$$$$$$  |\\$$$$$$  |$$ |$$$$$$$  |                           \r\n   \\__| \\______/  \\______/ \\__|\\_______/                            \r\n                                                                    \r\n                                                                    \r\n                                                                    ");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("By Endarionn");
        
        Console.ForegroundColor= ConsoleColor.White;

        Console.Write(Environment.NewLine);

        Console.Write("How many accounts should be created: ");

        acc = Console.ReadLine();

        accountCount = Convert.ToInt32(acc);

        Console.Write(Environment.NewLine);

        Console.WriteLine("Enter your proxy file path:");

        proxyPath = Console.ReadLine();

        Console.WriteLine("Threads (0 - 750): ");

        threads = Convert.ToInt32(Console.ReadLine());

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("$$\\   $$\\ $$\\                           $$\\ $$\\   $$\\               \r\n$$ | $$  |$$ |                          $$ |\\__|  $$ |              \r\n$$ |$$  / $$$$$$$\\   $$$$$$\\   $$$$$$\\  $$ |$$\\ $$$$$$\\    $$$$$$\\  \r\n$$$$$  /  $$  __$$\\  \\____$$\\ $$  __$$\\ $$ |$$ |\\_$$  _|   \\____$$\\ \r\n$$  $$<   $$ |  $$ | $$$$$$$ |$$$$$$$$ |$$ |$$ |  $$ |     $$$$$$$ |\r\n$$ |\\$$\\  $$ |  $$ |$$  __$$ |$$   ____|$$ |$$ |  $$ |$$\\ $$  __$$ |\r\n$$ | \\$$\\ $$ |  $$ |\\$$$$$$$ |\\$$$$$$$\\ $$ |$$ |  \\$$$$  |\\$$$$$$$ |\r\n\\__|  \\__|\\__|  \\__| \\_______| \\_______|\\__|\\__|   \\____/  \\_______|\r\n                                                                    \r\n                                                                    \r\n                                                                    \r\n$$$$$$$$\\                  $$\\                                      \r\n\\__$$  __|                 $$ |                                     \r\n   $$ | $$$$$$\\   $$$$$$\\  $$ | $$$$$$$\\                            \r\n   $$ |$$  __$$\\ $$  __$$\\ $$ |$$  _____|                           \r\n   $$ |$$ /  $$ |$$ /  $$ |$$ |\\$$$$$$\\                             \r\n   $$ |$$ |  $$ |$$ |  $$ |$$ | \\____$$\\                            \r\n   $$ |\\$$$$$$  |\\$$$$$$  |$$ |$$$$$$$  |                           \r\n   \\__| \\______/  \\______/ \\__|\\_______/                            \r\n                                                                    \r\n                                                                    \r\n                                                                    ");

        Console.ForegroundColor = ConsoleColor.White;

        while (accountCount > 0)
        {
            Generate(DosyaSatiriniOku(proxyPath, satirCount));
            accountCount--;
            satirCount++;
            Thread.Sleep(1000 - threads);
        }

        File.Create("Created Accounts.txt").Dispose();

        File.WriteAllText("Created Accounts.txt", successfullAttempts);

        File.AppendAllText("Created Accounts.txt", Environment.NewLine);

        Console.ReadKey();

    }

    static async Task Follow()
    {
        // Spotify API endpoint'i
        string apiEndpoint = "https://api-partner.spotify.com/pathfinder/v1/query";

        // JSON içeriği
        string jsonContent = @"
        {
            ""extensions"": { },
            ""persistedQuery"": { ""sha256Hash"": ""a3c1ff58e6a36fec5fe1e3a193dc95d9071d96b9ba53c5ba9c1494fb1ee73915"", ""version"": 1 },
            ""operationName"": ""addToLibrary"",
            ""variables"": { ""uris"": [] }
        }";

        // Spotify API yetkilendirme token'ı
        string spotifyToken = ""; // Spotify'den alınan gerçek token'ı buraya ekleyin

        // HttpClient oluştur
        using (HttpClient client = new HttpClient())
        {
            // Headers ayarla
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", spotifyToken);

            // POST isteği oluştur
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiEndpoint, content);

            // Yanıtı oku
            string responseData = await response.Content.ReadAsStringAsync();

            // Yanıtı konsola yazdır
            Console.WriteLine("Response: " + responseData);
        }
    }

    static string DosyaSatiriniOku(string dosyaYolu, int okunacakSatir)
    {
        // StreamReader nesnesi oluştur
        using (StreamReader sr = new StreamReader(dosyaYolu))
        {
            int satirSayaci = 1;
            while (!sr.EndOfStream)
            {
                string satir = sr.ReadLine();
                if (satirSayaci == okunacakSatir)
                {
                    return satir;
                }
                satirSayaci++;
            }
            return null;
        }
    }

    static async Task Generate(string proxy)
    {
        using (HttpClientHandler handler = new HttpClientHandler())
        {
            if (!string.IsNullOrEmpty(proxy))
            {
                // Proxy ayarlarını yap
                var proxyUri = new Uri($"http://{proxy}");
                handler.Proxy = new WebProxy(proxyUri, false);
                handler.UseProxy = true;
            }

            using (HttpClient client = new HttpClient(handler))
            {
                // MultipartFormDataContent oluştur
                MultipartFormDataContent content = new MultipartFormDataContent();

                using (var formContent = new MultipartFormDataContent("----WebKitFormBoundaryXkpMxJ9cdAxKNTw8"))
                {
                    formContent.Headers.ContentType.MediaType = "multipart/form-data";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                    string mail = "Khaelita" + "tool" + new Random().Next(0, 99999) + "@gmail.com";
                    string pass = "Khaelita" + new Random().Next(0, 9999999);

                    formContent.Add(new StringContent(pass), "password_repeat");
                    formContent.Add(new StringContent("1"), "iagree");
                    formContent.Add(new StringContent("5"), "birth_month");
                    formContent.Add(new StringContent("male"), "gender");
                    formContent.Add(new StringContent(pass), "password");
                    formContent.Add(new StringContent("desktop"), "creation_flow");
                    formContent.Add(new StringContent("https://login.app.spotify.com?utm_source=spotify&utm_medium=desktop-win32-store&utm_campaign=msft_1&referral=msft_1&referrer=msft_1"), "creation_point");
                    formContent.Add(new StringContent(Encoding.UTF8.GetString(Convert.FromBase64String("S2hhZWxpdGFUb29scw=="))), "displayname");
                    formContent.Add(new StringContent("4c7a36d5260abca4af282779720cf631"), "key");
                    formContent.Add(new StringContent("desktop"), "platform");
                    formContent.Add(new StringContent(mail), "email");
                    formContent.Add(new StringContent("2000"), "birth_year");
                    formContent.Add(new StringContent("1"), "birth_day");
                    formContent.Add(new StringContent("msft_1"), "referrer");

                    var Reg = await client.PostAsync("https://spclient.wg.spotify.com/signup/public/v1/account/", formContent);

                    var responseContent = await Reg.Content.ReadAsStringAsync();

                    if (responseContent.Contains("1"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine(mail + ":" + pass);

                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine("Account created successfully!");

                        Console.ForegroundColor= ConsoleColor.Magenta;

                        Console.WriteLine("Proxy in use: " + proxy);

                        Console.Write(Environment.NewLine);

                        successfullAttempts =Environment.NewLine + successfullAttempts + mail + pass;
                    }

                    else if (responseContent.Contains("320"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("Could not create account...");

                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine("Proxy banned. ");

                        Console.ForegroundColor = ConsoleColor.Magenta;

                        Console.WriteLine("Proxy in use: " + proxy);

                        Console.Write(Environment.NewLine);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("Could not create account...");

                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine("Proxy not working.");

                        Console.ForegroundColor = ConsoleColor.Magenta;

                        Console.WriteLine("Proxy in use: " + proxy);

                        Console.Write(Environment.NewLine);
                    }
                }
            }
        }
    }
}