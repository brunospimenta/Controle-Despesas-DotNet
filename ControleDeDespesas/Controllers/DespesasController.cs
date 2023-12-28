using AutoMapper;
using ControleDeDespesas.Data;
using ControleDeDespesas.Data.Dtos.Despesa;
using ControleDeDespesas.Models;
using ControleDeDespesas.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace ControleDeDespesas.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        public IMapper _mapper { get; set; }
        public ControleDbContext _context { get; set; }

        public DespesasController(IMapper mapper, ControleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateDespesa(CreateDespesaDto dto)
        {
            try
            {
                Despesa despesa = _mapper.Map<Despesa>(dto);
                _context.Despesas.Add(despesa);
                _context.SaveChanges();

                //Logger.CreateLog($"Despesa '{dto.Titulo}' criada com sucesso", Enums.LogType.SUCESS, "ControllerLogs");
                return CreatedAtAction(nameof(GetDespesaById), new { id = despesa.Id }, despesa);

            } catch (Exception ex)
            {
                //Logger.CreateLog($"Erro ao criar despesa: {ex.Message} Exception: {ex.StackTrace}", Enums.LogType.ERROR, "ControllerLogs");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IEnumerable<ReadDespesaDto> GetDespesas([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadDespesaDto>>(_context.Despesas.Skip(skip).Take(take).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetDespesaById(int id)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(d => d.Id == id);

            if (despesa == null)
            {
                //Logger.CreateLog("Despesa especificada não encontrada", Enums.LogType.ERROR, "ControllerLogs");
                return NotFound();
            }

            ReadDespesaDto ReadDto = _mapper.Map<ReadDespesaDto>(despesa);
            return Ok(ReadDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDespesa(int id)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(d => d.Id == id);

            if (despesa == null)
            {
                //Logger.CreateLog("Despesa especificada não encontrada", Enums.LogType.ERROR, "ControllerLogs");
                return NotFound();
            }

            _context.Despesas.Remove(despesa);
            _context.SaveChanges();

            //Logger.CreateLog("Despesa deletada com sucesso", Enums.LogType.SUCESS, "ControllerLogs");
            return Ok($"Despesa {despesa.Id} deletada com sucesso");
        }

        [HttpPut("{id}")]
        public IActionResult atualizaDespesa()
        {
            return BadRequest();
        }


    }
}
