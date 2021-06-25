using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndPreguntas.Domain.Models
{
    public class Notas
    {
        [Key]
        [JsonProperty("idnotas")]
        public int Id { get; set; }

        [JsonProperty("title")]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [JsonProperty("content")]
        [Column(TypeName = "varchar(500)")]
        public string Content { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("datecreation")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("dateupdate")]
        public DateTime UpdateDate { get; set; }
    }
}
