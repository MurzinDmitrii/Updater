using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json.Linq;
using Cifra.Classes.Logging;
using System.Reflection;

namespace Updater
{
    internal class Downloader
    {
        internal static async Task DownloadAllFilesFromRepo(Config config)
        {
            try
            {
                string apiUrl = $"https://api.github.com/repos/{config.RepoOwner}/{config.RepoName}/contents/";
                string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + config.AppName;
                EnsureDirectoryExists(appDirectory);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.Token);
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("HttpClient", "1.0"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();
                    JArray files = JArray.Parse(content);

                    foreach (var file in files)
                    {
                        string downloadUrl = file["download_url"].ToString();
                        string fileName = appDirectory + "\\" + file["name"].ToString();
                        await DownloadFile(client, downloadUrl, fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write("Ошибка в классе Downloader: " + ex.Message);
            }
        }

        private static async Task DownloadFile(HttpClient client, string url, string filePath)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(filePath, fileBytes);
        }

        private static void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
