using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Context;
using tcc_dbfyi.Domains;
using tcc_dbfyi.Interfaces;
using tcc_dbfyi.Utils;

namespace tcc_dbfyi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        DBFYIContext ctx = new DBFYIContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (usuarioAtualizado.Nome != null)
            {
                usuarioBuscado.Nome = usuarioAtualizado.Nome;
            }

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmail(string Email)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == Email);
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);
            ctx.Usuarios.Remove(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            var user = ctx.Usuarios.FirstOrDefault(u => u.Email == email);


            if (user != null)
            {
                if (Criptografia.Validate(user.Senha) == true)
                {
                    bool IsEncrypted = Criptografia.Comparar(senha, user.Senha);
                    if (IsEncrypted)
                        return user;
                }
                else
                {
                    EncryptPassword(user);
                    bool IsEncrypted = Criptografia.Comparar(senha, user.Senha);
                    if (IsEncrypted)
                        return user;
                }
            }

            return null;
        }
        public async void EncryptPassword(Usuario _user)
        {
            _user.Senha = Criptografia.GerarHash(_user.Senha);
            ctx.Usuarios.Update(_user);
            await ctx.SaveChangesAsync();
        }
    }
}
