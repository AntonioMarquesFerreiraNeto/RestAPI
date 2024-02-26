using Humanizer;
using Microsoft.AspNetCore.Mvc;
using RestAPI_TESTE.Models;
using RestAPI_TESTE.Models.Enums;
using RestAPI_TESTE.Repository.Interfaces;

namespace RestAPI_TESTE.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository) {
            _pessoaRepository = pessoaRepository;
        }

        [HttpPost]
        public ActionResult CreatePessoa([FromBody] Pessoa pessoa) {
            try {
                if (ModelState.IsValid) {
                    _pessoaRepository.CreatePessoa(pessoa);
                    return Ok(MsgSucessEnum.MSGS01.Humanize());
                }
                return BadRequest(pessoa);
            }
            catch (Exception error) {
                return StatusCode(500, error.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetPessoaById(int id) {
            try {
                Pessoa pessoa = _pessoaRepository.GetPessoaById(id);
                return Ok(pessoa);
            }
            catch (Exception error) {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePessoa([FromBody] Pessoa pessoa, int id) {
            try {
                if (ModelState.IsValid) {
                    _pessoaRepository.UpdatePessoa(pessoa, id);
                    return Ok(MsgSucessEnum.MSGS02.Humanize());
                }
                return BadRequest(pessoa);
            }
            catch (Exception error) {
                return StatusCode(500, error.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePessoa(int id) {
            try {
                _pessoaRepository.DeletePessoa(id);
                return Ok(MsgSucessEnum.MSGS03.Humanize());
            }
            catch (Exception error) {
                return StatusCode(500, error.Message);
            }
        }

        [HttpGet]
        public ActionResult GetAllPessoa() {
            var listPessoas = _pessoaRepository.GetAllPessoas();
            if (listPessoas.Any()) {
                return Ok(listPessoas);
            }
            else {
                return NotFound(MsgErrorEnum.MSGE01.Humanize());
            }
        }
    }
}
