using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndPreguntas.Domain.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string name { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string lastname { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string password { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string username { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string mail { get; set; }
    }
}
