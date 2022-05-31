using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using tcc_dbfyi.Domains;
using tcc_dbfyi.Interfaces;
using tcc_dbfyi.Repositories;
using tcc_dbfyi.Utils;

namespace tcc_dbfyi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository Usuario { get; set; }

        public UsuarioController()
        {
            Usuario = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpGet("Listar")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(Usuario.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca os usuarios pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(Usuario.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpGet("Email")]
        public IActionResult GetByEmail(string Email)
        {
            try
            {
                return Ok(Usuario.BuscarPorEmail(Email));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="NovoUser"></param>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastro(Usuario novoUsuario)
        {
            try
            {
                novoUsuario.Senha = Criptografia.ConstruirHash(novoUsuario.Senha);

                Usuario.Cadastrar(novoUsuario);

                return Ok(Usuario.Listar().Last());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Usuario.Deletar(id);
                return Ok("Usuario Deletado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        /// <summary>
        /// Atualiza informações do usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="NovoUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario NovoUser)
        {
            try
            {
                Usuario.Atualizar(id, NovoUser);
                return Ok("Usuario Atualizado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
