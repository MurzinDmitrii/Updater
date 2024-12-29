using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{
    internal class Checker
    {
        internal static async Task<bool> Check(Config config)
        {
            string url = $"https://raw.githubusercontent.com/{config.RepoOwner}/{config.RepoName}/master/Version.txt";
            string filePath = "Version.txt";
            string token = config.Token;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string versionString = File.ReadAllText(filePath);
                    Version oldVersion = new(versionString);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();
                    Version newVersion = new(content);
                    if (newVersion > oldVersion)
                    {
                        return true;
                    } 
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
