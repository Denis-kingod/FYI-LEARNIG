using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Domains;
using tcc_dbfyi.Interfaces;
using tcc_dbfyi.Repositories;

namespace tcc_dbfyi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class CursosControllers : ControllerBase
    {
        private ICursoRepository _cursoRepository { get; set; }

        public CursosControllers()
        {
            _cursoRepository = new CursoRepository();
        }

        // GET: api/CursosControllers
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_cursoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        // GET: api/CursosControllers/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_cursoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("Categoria{idcat}")]
        public IActionResult GetByCategoria(int idCategoria)
        {
            try
            {
                return Ok(_cursoRepository.BuscarPorCategoria(idCategoria));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Curso novoCurso)
        {
            try
            {
                _cursoRepository.Cadastrar(novoCurso);

                return StatusCode(201);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Curso CursoAtualizado)
        {
            try
            {
                _cursoRepository.Atualizar(id, CursoAtualizado);

                return StatusCode(200);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        [Authorize(Roles = "1")]
        // DELETE: api/CursosControllers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _cursoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception x)
            {
                return BadRequest(x);

            }
        }
    }
}