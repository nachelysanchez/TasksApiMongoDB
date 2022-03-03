using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TasksAPI.Models
{
    public record Tareas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TareaId { get; set; }
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        public string Descripcion { get; set; }
    }
}
