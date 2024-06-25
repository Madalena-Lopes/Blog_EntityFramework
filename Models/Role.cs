using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    //    CREATE TABLE[Role] (
    //    [Id] INT NOT NULL IDENTITY(1, 1),
    //    [Name] VARCHAR(80) NOT NULL,  --estes nomes vão ser + simples por isso não está NVARCHAR(80)
    //    [Slug] VARCHAR(80) NOT NULL,

    //    CONSTRAINT[PK_Role] PRIMARY KEY([Id]),
    //    CONSTRAINT[UQ_Role_Slug] UNIQUE([Slug])
    //)
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
