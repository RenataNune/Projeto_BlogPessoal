using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;

namespace BlogPessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de usuario</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public interface IUsuario
    {
        void NovoUsuario(NovoUsuarioDTO Usuario);
        void AtualizarUsuario(AtualizarUsuarioDTO usuario);
        void DeletarUsuario(int id);
        Usuariomodelo PegarUsuarioPeloId(int id);
        Usuariomodelo PegarUsuarioEmail(string email);
        Usuariomodelo PegarUsuarioPeloNome(string nome);
    }
}
