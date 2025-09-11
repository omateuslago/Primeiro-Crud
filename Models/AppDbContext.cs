using Microsoft.EntityFrameworkCore;

namespace cruudd.Models
{
    //public AppDbContext: Construtor q recebe as configurações e passa para a classe Pai(DbContext)
    //DbContextOptions: Classe do EF q carrega as configurações do banco de dados.
    //<AppDbContext>: Diz que essas opções são para a classe AppDbContext.
    //options: É o nome da variável que receba essas configurações.

    //: base: está herdando a classe "base" q é a classe Pai(DbContext) no AppDbContext
    //(options): Está enviando as configurações de (options) para a classe Pai, pq ela sabe oq fazer com essas configurações.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }

        public DbSet<Cadastro> Cadastros { get; set; }
    }
}
