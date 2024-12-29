using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{
    internal class Config
    {
        [JsonProperty("RepoOwner")]
        internal string RepoOwner { get; set; }

        [JsonProperty("RepoName")]
        internal string RepoName { get; set; }

        [JsonProperty("Token")]
        internal string Token { get; set; }

        [JsonProperty("AppName")]
        internal string AppName { get; set; }
    }

}
