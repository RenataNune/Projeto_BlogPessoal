using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.src.data
{
    public class BlogPessoalContexto : DbContext 
    {
        public DbSet<Usuariomodelo> Usuarios { get; set; }

        public DbSet<Temamodelo> Temas { get; set; }

        public DbSet<Temamodelo> Postagens { get; set; }

        public BlogPessoalContexto(DbContextOptions<BlogPessoalContexto> opt) : base(opt)
        {

        }
    }
}
