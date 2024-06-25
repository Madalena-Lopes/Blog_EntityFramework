// See https://aka.ms/new-console-template for more information
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
/*using (var context = new BlogDataContext())
{*/
    //CREATE
    /*
    var tag = new Tag { Name = ".NET", Slug = "dotnet" };
    context.Tags.Add(tag);

    var tag2 = new Tag { Name = "ASP.NET", Slug = "aspnet" };
    context.Tags.Add(tag2);
    context.SaveChanges(); //enquanto não fizer isto não vai para a BD. Grava tudo o q tiver feito no context. Trabalha em memória e no fim grava-se na BD
    */

    //UPDATE: não usar o new pq se o fizer não vai entender como sendo um update e não vai funcionar
    //aqui o q se deve fazer é ler a versão + atual da BD, atualizar e no fim de tudo guardar na BD
    /*var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    tag.Name = ".NET";
    tag.Slug = "dotnet";
    //METADADOS OU dados adicionais: tem sempre o antigo e o novo para comparar e ver o q mudou - o q tem q atualizar na BD e só atualiza o q mudou.
    context.Update(tag);
    context.SaveChanges();
    */

    //DELETE:   não usar o new tb aqui
    //se tiver algum item filho daria erro e então deve-se usar o try catch
    /*var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    context.Remove(tag);
    context.SaveChanges();
    */

    //ToList
    /*var tags = context.Tags; //Não executou na BD

    foreach (var tag in tags) //apenas executa na BD aqui
    {
        Console.WriteLine(tag.Name);
    }*/


    /*var tags = context
        .Tags
        .ToList() //indica para executar a query na BD, mas aqui é mau pq estou a dizer para fazer o select * em todas as tags da BD e filtrar depois pelo nome ".NET"
        .Where(x => x.Name.Contains(".NET"));

        2 problemas:
        - Faz select * de todos os campos da tabela
        - Coloca todos os campos na memoria e se tiver 1 milhão de registos coloca isso tudo na memória do servidor 
           -> bloqueando tanto a memória do servidor como a BD.
    */

    //NOTA: .ToList() É SEMPRE A ÚLTIMA COISA!!!! 
    /*var tags = context
        .Tags
        .Where(x => x.Name.Contains(".NET"))
        .ToList(); //indica para executar a query na BD já filtrando pelo nome ".NET"
    
    foreach (var tag in tags) 
    {
        Console.WriteLine(tag.Name);
    }*/

    //RESUMO: .AsNoTracking()
    //          - não usar no update ou delete
    //          - mas usar sempre nas leituras - fica + rápido porque não vai fazer tracking 
    /*var tag = context
        .Tags
        .AsNoTracking() //REMOVER!! funcionou, pq neste caso não havia outras chaves, mas não usar no update ou delete
        .FirstOrDefault(x => x.Id == 1005);
    tag.Name = "Ponto NET";
    tag.Slug = "dotnet";
    //METADADOS OU dados adicionais: tem sempre o antigo e o novo para comparar e ver o q mudou - o q tem q atualizar na BD e só atualiza o q mudou.
    context.Update(tag);
    context.SaveChanges();
    */

    /*
    var tag = context
        .Tags
        .AsNoTracking() //pq é uma leitura. Optimiza!
        .SingleOrDefault(x => x.Id == 1005); //=FirstOrDefault, nas no single se tiver +q 1 item com o mesmo id dava erro. No nosso caso nõa dará pq é chave.
    Console.WriteLine(tag?.Name);
    */   
//}



using var context = new BlogDataContext();//vai fazer o dispose automatico lá para baixo

#region Adicionar 1 Post com Sub Conjuntos
/*
 var user = new User
{
    Name = "André Baltieri",
    Slug = "andrebaltieri",
    Email = "andre@balta.io",
    Bio = "11x Microsoft MVP",
    Image = "https: //balta.io",
    PasswordHash = "123098457"
};

var category = new Category
{
    Name = "Backend",
    Slug = "backend"
};

var post = new Post
{   //EF é inteligente e vai usar o SCOPE_IDENTITY para fazer a atribuição AuthorId e CategoryId!!
    Author = user,
    Category = category,
    Body = "<p>Hello world</p>",
    Slug = "comecando-com-ef-core",
    Summary = "Neste artigo vamos aprender EF core",
    Title = "Começando com EF Core ",
    CreateDate = DateTime.Now,
    LastUpdateDate = DateTime.Now,
};

context.Posts.Add(post);
context.SaveChanges();//aqui grava tudo de forma automática com a ORM, atribuindo as chaves (AuthorId e CategoryId) de forma automática. Gaande vantagem das ORMs.
*/
#endregion

#region Listar (read) objectos no ecrã
/*
var posts = context
    .Posts
    .AsNoTracking()
    .Include(x => x.Author) //EF por padrão não preenche os objetos automaticamente (pq precisava de executar um join). Para incluir o Author. É como um inner join/left join/full alter join.
    .Include(x => x.Category)
        //.ThenInclude(x => x.) //SUBSELECT - A EVITAR.
    //.Where (x => x.AuthorId == 3003) //Todos os pots de um author pelo Id do author
    //.Where(x => x.Author.Slug == "andrebaltieri") //esta obriga a fazer join com a tabela User. Ter mais cuidado! Mais pesado.
    .OrderByDescending(x => x.LastUpdateDate)
    .ToList();

foreach (var post in posts)
    Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}"); //post.Author? -> Null Safe pq este subconjunto pode vir nulo. Só com ? já deixa de dar erro. Depois preciso de indicar include (1 join).
*/
#endregion

#region Alterar um SubConjunto
var post = context
    .Posts  //vai buscar 1 post
    //.AsNoTracking() PRECISA DO TRACKING para saber q só vou alterar o Name - no update e delete
    .Include(x => x.Author)     //EF para incluir o Author - join.
    .Include(x => x.Category)   //Chamar estas funçoes pela mesma ordem de uma query SQL
    .OrderBy(x => x.LastUpdateDate)
    .FirstOrDefault();  //1º item - TOP 1. Mas podia colocar (x => x.Id == 1002) e neste caso já fazia no registo com o id = 1002.

post.Author.Name = "Teste";
context.Posts.Update(post); //faz update no first item q calhou
context.SaveChanges();
#endregion