using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    //--relação post tag: relação de 1 para 1
    //--1 post pode ter mts tags
    //--1 tag pode estar em mts pots(postagens)
    //CREATE TABLE[PostTag] (
    //    [PostId] INT NOT NULL,
    //    [TagId] INT NOT NULL,

    //    CONSTRAINT PK_PostTag PRIMARY KEY([PostId], [TagId])
    //)
    public class PostTag
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
