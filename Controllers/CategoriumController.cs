using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using tcc_dbfyi.Domains;
using tcc_dbfyi.Interfaces;
using tcc_dbfyi.Repositories;

namespace tcc_dbfyi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriumsControllers : ControllerBase
    {
        private ICategoriumRepository _categoriaRepository { get; set; }

        public CategoriumsControllers()
        {
            _categoriaRepository = new CategoriumRepository();
        }

        // GET: api/CategoriumsControllers
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_categoriaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //[Authorize(Roles = "1")]
        // GET: api/CategoriumsControllers/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_categoriaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("Titulo")]
        public IActionResult GetByTitulo(string titulo)
        {
            try
            {
                return Ok(_categoriaRepository.BuscarPorTitulo(titulo));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Categorium novaCategoria)
        {
            try
            {
                // Faz a chamada para o método
                _categoriaRepository.Cadastrar(novaCategoria);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Categorium CategoriaAtualizada)
        {
            try
            {
                _categoriaRepository.Atualizar(id, CategoriaAtualizada);

                return StatusCode(200);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        //[Authorize(Roles = "1")]
        // DELETE: api/CategoriumsControllers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoriaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception x)
            {
                return BadRequest(x);

            }

        }
    }
}