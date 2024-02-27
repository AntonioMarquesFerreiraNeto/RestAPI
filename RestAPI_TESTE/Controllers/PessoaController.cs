using Humanizer;
using Microsoft.AspNetCore.Mvc;
using RestAPI_TESTE.Models;
using RestAPI_TESTE.Models.Enums;
using RestAPI_TESTE.Repository.Interfaces;

namespace RestAPI_TESTE.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePessoa([FromBody] Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _pessoaRepository.CreatePessoa(pessoa);
                    return Ok(MsgSucessEnum.MSGS01.Humanize());
                }
                return BadRequest(pessoa);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaById(int id)
        {
            try
            {
                Pessoa pessoa = await _pessoaRepository.GetPessoaById(id);
                return Ok(pessoa);
            }
            catch (Exception error)
            {
                return NotFound(error.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePessoa(int id, [FromBody] Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _pessoaRepository.UpdatePessoa(pessoa, id);
                    return Ok(MsgSucessEnum.MSGS02.Humanize());
                }
                return BadRequest(pessoa);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            try
            {
                await _pessoaRepository.DeletePessoa(id);
                return Ok(MsgSucessEnum.MSGS03.Humanize());
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPessoas()
        {
            try
            {
                var listPessoas = await _pessoaRepository.GetAllPessoas();
                if (listPessoas.Count != 0)
                {
                    return Ok(listPessoas);
                }
                else
                {
                    return NotFound(MsgErrorEnum.MSGE01.Humanize());
                }
            }
            catch (Exception)
            {
                return StatusCode(500, MsgErrorEnum.MSGE01.Humanize());
            }
        }
    }
}
