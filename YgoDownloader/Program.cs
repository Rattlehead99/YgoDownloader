using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YgoDownloader
{
    public class Program
    {   //https://www.formatlibrary.com/api/decks/?filter=type:eq:Blackwing&limit=1000&page=1 <- Get deck by Type instead of Number url.
        public static async Task Main(string[] args)
        {
            var deckNumber = Console.ReadLine();

            while (deckNumber != "E")
            {
                var deck = await CreateDeck(deckNumber);
                if (deck.Ydk == "Deck Not Found")
                {
                    Console.WriteLine("Deck Not found");
                }
                else
                {
                    //Console.WriteLine(String.Concat(deck.Builder, "-", deck.Type, "-", deckNumber) ?? deckNumber);
                    //Console.WriteLine(deck.Ydk);
                    Console.WriteLine("Deck Downloaded!");
                }
                deckNumber = Console.ReadLine();
            }
        }

        public static async Task<Deck?> CreateDeck(string deckNumber)
        {
            //string url = $"https://www.formatlibrary.com/api/decks/download/{deckNumber}";
            //string pathReflection = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string? pathReflection = Process.GetCurrentProcess().MainModule?.FileName;
            string? path = System.IO.Path.GetDirectoryName(pathReflection);
            Deck? deck = await GetDeck(deckNumber);

            if (path != null && deck != null && !String.IsNullOrEmpty(deck.Ydk) && deck.Ydk != "Deck Not Found")
            {
                await using StreamWriter sw = File.CreateText(Path.Combine(path, String.Concat(deck.Builder,"-", deck.Type,"-", deckNumber,".ydk") ?? deckNumber));
                await sw.WriteAsync(deck.Ydk);
                await sw.DisposeAsync();
            }

            return deck;
        }

        private static async Task<Deck?> GetDeck(string deckNumber)
        {
            Deck? deck = new Deck();
            HttpResponseMessage? response;
            using HttpClient client = new HttpClient();

            string url = $"https://www.formatlibrary.com/api/decks/{deckNumber}";

            response = await client.GetAsync(url);

            if (String.IsNullOrEmpty(await response.Content.ReadAsStringAsync()) || response.StatusCode == HttpStatusCode.NotFound)
            {
                return new Deck(){Ydk = "Deck Not Found"};
            }

            string deckJson = await response.Content.ReadAsStringAsync();

            deck = JsonSerializer.Deserialize<Deck>(deckJson, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                TypeInfoResolver = TrimContext.Default
            });

            deck.Ydk = deck.Ydk.Replace($"created", "");
            deck.Ydk = deck.Ydk.Replace("by...", "");
            deck.Ydk = deck.Ydk.Trim();

            return deck;
        }
    }
}
