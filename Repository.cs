using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Field_Service_Toolkit
{
    public record class Repository(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("html_url")] Uri GitHubHomeUrl,
        [property: JsonPropertyName("homepage")] Uri Homepage,
        [property: JsonPropertyName("watchers")] int Watchers,
        [property: JsonPropertyName("pushed_at")] DateTime LastPushUtc)
        {
            public DateTime LastPush => LastPushUtc.ToLocalTime();
        }
}
