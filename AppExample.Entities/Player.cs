using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace AppExample.Entities
{
    public class Player
    {

        #region Constructor 
        public Player()
        {
            this.PlayerID = ExtensionUtility.GenerateID();
        }
        #endregion

        [JsonProperty("id")]
        [BsonId]
        public ObjectId PlayerID { get; set; }

        [JsonProperty("name")]
        [BsonElement("name")]
        public string Name { get; set; }

        [JsonProperty("team")]
        [BsonElement("team")]
        public string Team { get; set; }

        [JsonProperty("dorsal")]
        [BsonElement("dorsal")]
        public int Dorsal { get; set; }

        [JsonProperty("nationality")]
        [BsonElement("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("position")]
        [BsonElement("position")]
        public string Position { get; set; }

        [JsonProperty("photo")]
        [BsonElement("photo")]
        public string PhotoURL { get; set; }

    }
}
