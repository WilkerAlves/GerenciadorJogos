using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence
{
    public class XGameContext : DbContext
    {
        public XGameContext() :base("XGameConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Jogador> Jogadores { get; set; }
        public IDbSet<Jogo> Jogos { get; set; }
        public IDbSet<Plataforma> Plataformas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removendo pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //removendo deleção em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            //forçar a utilização do varchar, caso não faça isso será utilizado nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //caso esqueça de definir o tamanho da string será 100 caracteres
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //mapeia as entidades
            //modelBuilder.Configurations.Add(new JogadorMap());
            //modelBuilder.Configurations.Add(new JogoMap());
            //modelBuilder.Configurations.Add(new PlataformaMap());

            //adicionando mapeamentos atravez do assembly
            #region Adicionar Entidades Mapeadas - Automaticamente via assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGameContext).Assembly);
            #endregion

        }
    }
}
