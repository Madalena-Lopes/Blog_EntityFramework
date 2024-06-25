using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Key
using System.ComponentModel.DataAnnotations.Schema; //table
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    [Table("Tag")]
    public class Tag
    {
        [Key] //atributo para saber q esta é chave primária
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
