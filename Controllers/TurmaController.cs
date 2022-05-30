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
    public class TurmasControllers : ControllerBase
    {
        private ITurmaRepository _turmaRepository { get; set; }

        public TurmasControllers()
        {
            _turmaRepository = new TurmaRepository();
        }

        //[Authorize(Roles = "1,2")]
        // GET: api/TurmasControllers
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_turmaRepository.Listar());
            }

            catch (Exception Erro)
            {
                return BadRequest(Erro);
            }
        }

        //[Authorize(Roles = "1,2")]
        // GET: api/TurmasControllers/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_turmaRepository.BuscarPorId(id));
            }

            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

       // [Authorize(Roles = "1,2")]
        [HttpGet("Curso{idc}")]
        public IActionResult GetByIdc(int idCategoria)
        {
            try
            {
                return Ok(_turmaRepository.BuscarPorCurso(idCategoria));
            }

            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        //[Authorize(Roles = "1,2")]
        // PUT: api/TurmasControllers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(int id, Turma turmaAtualizada)
        {
            try
            {
                _turmaRepository.Atualizar(id, turmaAtualizada);

                return StatusCode(204);
            }

            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        //[Authorize(Roles = "1,2")]
        // POST: api/TurmasControllers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post(Turma novaTurma)
        {
            try
            {
                _turmaRepository.Cadastrar(novaTurma);

                return StatusCode(201);
            }

            catch (Exception x)
            {
                return BadRequest(x);
            }
        }

        //[Authorize(Roles = "1,2")]
        // DELETE: api/TurmasControllers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _turmaRepository.Deletar(id);

                return StatusCode(204);
            }

            catch (Exception x)
            {
                return BadRequest(x);
            }
        }
    }
}