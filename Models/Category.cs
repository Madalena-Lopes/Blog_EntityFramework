using System.ComponentModel.DataAnnotations; //Key
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Models
{
    [Table("Category")] //pq senão ia pensar q a tabela se chamava Categories como tem na BlogDataContext.cs
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //indicar o + possível no código/app e deixar o - possível na BD.
        public int Id { get; set; }
        
        [Required] //NOT NULL
        [MinLength(3)]
        [MaxLength(80)] //senão colocava varchar(max)/nvarchar(max)
        [Column("Name",TypeName ="NVARCHAR")] //aqui não precisa de colocar NVARCHAR(80) pq já está indicado na linha de cima
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)] //senão colocava varchar(max)
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }
    }
}
