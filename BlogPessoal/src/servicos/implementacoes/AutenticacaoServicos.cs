﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using BlogPessoal.src.repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace BlogPessoal.src.servicos.implementacoes
{
    public class AutenticacaoServicos : IAutenticacao
    {
        #region Atributos
        private readonly IUsuario _repositorio;
        public IConfiguration Configuracao { get; }
        #endregion
        
        #region Construtores
        public AutenticacaoServicos(IUsuario repositorio, IConfiguration configuration)
        {
            _repositorio = repositorio;
            Configuracao = configuration;
        }
        #endregion
       
        #region Métodos
        public string CodificarSenha(string senha)
        {
            var bytes = Encoding.UTF8.GetBytes(senha);
            return Convert.ToBase64String(bytes);
        }
        public async Task CriarUsuarioSemDuplicarAsync(NovoUsuarioDTO dto)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(dto.Email);
            if (usuario != null) throw new Exception("Este email já está sendo utilizado");
            dto.Senha = CodificarSenha(dto.Senha);
            await _repositorio.NovoUsuarioAsync(dto);
        }
        public string GerarToken(UsuarioModelo usuario)
        {
            var tokenManipulador = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(Configuracao["Settings:Secret"]);
            var tokenDescricao = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                   new Claim[]
                   {
                       new Claim(ClaimTypes.Email, usuario.Email.ToString()),
                       new Claim(ClaimTypes.Role, usuario.Tipo.ToString())
                   }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                   new SymmetricSecurityKey(chave),
                   SecurityAlgorithms.HmacSha256Signature
                  )
            };
            var token = tokenManipulador.CreateToken(tokenDescricao);
            return tokenManipulador.WriteToken(token);
        }
        public async Task<AutorizacaoDTO> PegarAutorizacaoAsync(AutenticarDTO autenticacao)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(autenticacao.Email);
            
            if (usuario == null) throw new Exception("Usuário não encontrado");
            
            if (usuario.Senha != CodificarSenha(autenticacao.Senha)) throw new Exception("Senha incorreta");

            return new AutorizacaoDTO(usuario.Id, usuario.Email, usuario.Tipo,GerarToken(usuario));


        }
        #endregion
    }
}





















