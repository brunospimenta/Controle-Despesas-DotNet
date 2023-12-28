using AutoMapper;
using ControleDeDespesas.Data;
using ControleDeDespesas.Data.Dtos.Despesa;
using ControleDeDespesas.Data.Dtos.Planejamento;
using ControleDeDespesas.Models;
using ControleDeDespesas.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeDespesas.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    [ApiController]
    public class PlanejamentoController : ControllerBase
    {

        public IMapper _mapper;
        public ControleDbContext _context;

        public PlanejamentoController(IMapper mapper, ControleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpPost]
        public IActionResult CreatePlanejamento(CreatePlanejamentoDto dto)
        {
            try
            {
                Planejamento planejamento = _mapper.Map<Planejamento>(dto);
                _context.Planejamentos.Add(planejamento);
                _context.SaveChanges();

                //Logger.CreateLog($"Planejamento criado com sucesso", Enums.LogType.SUCESS, "ControllerLogs");
                return CreatedAtAction(nameof(GetPlanejamentoById), new { id = planejamento.Id }, planejamento);

            }
            catch (Exception ex)
            {
                //Logger.CreateLog($"Erro ao criar Planejamento: {ex.Message} Exception: {ex.StackTrace}", Enums.LogType.ERROR, "ControllerLogs");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IEnumerable<ReadPlanejamentoDto> GetPlanejamentos([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadPlanejamentoDto>>(_context.Planejamentos.Skip(skip).Take(take).ToList()) ;
        }

        [HttpGet("{id}")]
        public IActionResult GetPlanejamentoById(int id)
        {
            Planejamento planejamento = _context.Planejamentos.FirstOrDefault(d => d.Id == id);

            if (planejamento == null)
            {
                //Logger.CreateLog("Planejamento especificado não encontrado", Enums.LogType.INFO, "ControllerLogs");
                return NotFound();
            }

            ReadPlanejamentoDto ReadDto = _mapper.Map<ReadPlanejamentoDto>(planejamento);
            return Ok(ReadDto);
        }
    }
}
