using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        //aqui indico o q quero permitir q seja feito (ou não) na BD. Se por exemplo não quisesse q fizessem CRUD em cima de Roles era só retirar a linha [public DbSet<Role> Roles { get; set; }]
        public DbSet<Category> Categories { get; set; } //indica q quero mapear as categorias
        public DbSet<Post> Posts { get; set; }
        //public DbSet<PostTag> PostTags { get; set; } //comentado para já pq não tem chave primária, mas uma chave composta.
        /* não vai fazer estas para já
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        */
        //public DbSet<UserRole> UserRoles { get; set; } //comentado para já pq não tem chave primária, mas uma chave composta.

        //connectionString e para podermos fazer CRUDs básicos
        //override - sobreescrita de método
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");
            options.LogTo(Console.WriteLine); //LOG que me indica as querys q o EF está a fazer
        }
        
    }
}
