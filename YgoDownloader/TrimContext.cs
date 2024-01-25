using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace YgoDownloader
{
    [JsonSerializable(typeof(Deck))]
    [JsonSerializable(typeof(Format))]
    [JsonSerializable(typeof(Player))]
    [JsonSerializable(typeof(Main))]
    [JsonSerializable(typeof(Extra))]
    [JsonSerializable(typeof(Side))]
    public partial class TrimContext : JsonSerializerContext
    {

    }
}
