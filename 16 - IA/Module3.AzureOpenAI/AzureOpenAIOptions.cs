using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3.AzureOpenAI
{
    public class AzureOpenAIOptions
    {
        public string Endpoint { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public string DeploymentChat { get; set; } = "gpt-4o";
        public string DeploymentEmbedding { get; set; } = "text-embedding-3-small";
    }
}
