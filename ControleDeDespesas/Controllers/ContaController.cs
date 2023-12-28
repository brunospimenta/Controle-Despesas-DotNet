using AutoMapper;
using ControleDeDespesas.Data;
using ControleDeDespesas.Data.Dtos.Conta;
using ControleDeDespesas.Models;
using ControleDeDespesas.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeDespesas.Controllers
{

    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        public IMapper _mapper { get; set; }

        public ControleDbContext _context { get; set; }


        public ContaController(IMapper mapper, ControleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateConta(CreateContaDto dto)
        {
            try
            {
                Conta conta = _mapper.Map<Conta>(dto);
                _context.Contas.Add(conta);
                _context.SaveChanges();

                //Logger.CreateLog($"Conta criada com sucesso", Enums.LogType.SUCESS, "ControllerLogs");
                return CreatedAtAction(nameof(GetContaById), new { id = conta.Id }, conta);

            }
            catch (Exception ex)
            {
                //Logger.CreateLog($"Erro ao criar Conta: {ex.Message} Exception: {ex.StackTrace}", Enums.LogType.ERROR, "ControllerLogs");
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetContaById(int id)
        {
            Conta conta = _context.Contas.FirstOrDefault(d => d.Id == id);

            if (conta == null)
            {
                //Logger.CreateLog("Conta especificada não encontrada", Enums.LogType.ERROR, "ControllerLogs");
                return NotFound();
            }

            ReadContaDto ReadDto = _mapper.Map<ReadContaDto>(conta);
            return Ok(ReadDto);
        }
    }
}
