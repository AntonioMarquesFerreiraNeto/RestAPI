using Humanizer;
using Microsoft.AspNetCore.Mvc;
using RestAPI_TESTE.CustomExceptions;
using RestAPI_TESTE.Models;
using RestAPI_TESTE.Models.Enums;
using RestAPI_TESTE.Repository.Interfaces;
using RestAPI_TESTE.Services;

namespace RestAPI_TESTE.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService) {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        public async Task<IActionResult> CreatePessoa([FromBody] Pessoa pessoa) {
            try {
                await _pessoaService.CreatePessoa(pessoa);
                return Ok(MsgSucessEnum.MSGS01.Humanize());
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaById(int id) {
            try {
                Pessoa pessoa = await _pessoaService.GetPessoaById(id);
                return Ok(pessoa);
            }
            catch (NotFoundException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePessoa(int id, [FromBody] Pessoa pessoa) {
            try {
                await _pessoaService.UpdatePessoa(pessoa, id);
                return Ok(MsgSucessEnum.MSGS02.Humanize());
            }
            catch (NotFoundException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id) {
            try {
                await _pessoaService.DeletePessoa(id);
                return Ok(MsgSucessEnum.MSGS03.Humanize());
            }
            catch (NotFoundException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPessoas() {
            try {
                var listPessoas = await _pessoaService.GetAllPessoas();
                return Ok(listPessoas);
            }
            catch (NotFoundException ex) {
                return NotFound(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
