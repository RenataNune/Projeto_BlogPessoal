using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de tema</para>
    /// <para>Criado por: Renata Nunes</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public interface ITema
    {
        Task NovoTemaAsync(NovoTemaDTO Usuario);
        Task AtualizarTemaAsync(AtualizarTemaDTO usuario);
        Task DeletarTemaAsync(int id);
        Task <TemaModelo> PegarTemaPeloIdAsync(int id);
        Task <List<TemaModelo>> PegarTodosTemasAsync();
        Task <List<TemaModelo>> PegarTemaPelaDescricaoAsync(string descricao);
    }
}
