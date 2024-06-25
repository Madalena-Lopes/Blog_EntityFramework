using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Models
{
    //    CREATE TABLE[Post] (
    //    [Id] INT NOT NULL IDENTITY(1, 1),
    //    [CategoryId] INT NOT NULL,  
    //    [AuthorId] INT NOT NULL, --um post só tem 1 autor
    //    [Title] VARCHAR(160) NOT NULL,
    //    [Summary] VARCHAR(255) NOT NULL,
    //    [Body] TEXT NOT NULL,
    //    [Slug] VARCHAR(80) NOT NULL,
    //    [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    //    [LastUpdateDate] DATETIME NOT NULL DEFAULT(GETDATE()),

    //    CONSTRAINT[PK_Post] PRIMARY KEY([Id]),
    //    CONSTRAINT[FK_Post_Category] FOREIGN KEY([CategoryId]) REFERENCES[Category] ([Id]),
    //    CONSTRAINT[FK_Post_Author] FOREIGN KEY([AuthorId]) REFERENCES[User] ([Id]),
    //    CONSTRAINT[UQ_Post_Slug] UNIQUE([Slug])
    //)

    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("CategoryId")] //Category = Class e Id = Propriedade
        public int CategoryId { get; set; }
        public Category Category { get; set; } //(pelas 3 linhas) vai entender como sendo propriedade de navegação

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public User Author { get; set; }//vai entender como sendo propriedade de navegação (Navigation Properties)

        [Required]
        [MinLength(3)]
        [MaxLength(160)] 
        [Column("Title", TypeName = "VARCHAR")]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [Column("Summary", TypeName = "VARCHAR")]
        public string Summary { get; set; }

        [Required]
        [MinLength(3)]
        [Column("Body", TypeName = "TEXT")]
        public string Body { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }

        [Required]
        [Column("CreateDate", TypeName = "DATETIME")]
        public DateTime CreateDate { get; set; }

        [Required]
        [Column("LastUpdateDate", TypeName = "DATETIME")]
        public DateTime LastUpdateDate { get; set; }        
    }
}
