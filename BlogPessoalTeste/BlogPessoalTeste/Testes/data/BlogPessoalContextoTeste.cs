using Microsoft.EntityFrameworkCore;
using BlogPessoal.src.data;
using BlogPessoal.src.modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogPessoalTeste.Testes.data
{
    [TestClass]
    public class BlogPessoalContextoTeste
    {
        private BlogPessoalContexto _contexto;

        [TestInitialize]
        public void Inicio()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal")
                .Options;

            _contexto = new BlogPessoalContexto(opt);
        }

        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornaUsuario()
        {
            Usuariomodelo usuario = new Usuariomodelo();

            usuario.Nome = "Renata nunes";
            usuario.Email = "renatan.sil97@gmail.com";
            usuario.Senha = "123456";
            usuario.Foto = "aquitaolinkdafoto";

            _contexto.Usuarios.Add(usuario);

            _contexto.SaveChanges();


            Assert.IsNotNull(_contexto.Usuarios.FirstOrDefault(u => u.Email == "renatan.sil97@gmail.com"));

        }
    }
}
