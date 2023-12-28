using AutoMapper;
using ControleDeDespesas.Data;
using ControleDeDespesas.Data.Dtos.Role;
using ControleDeDespesas.Models;
using ControleDeDespesas.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace ControleDeDespesas.Controllers
{
    [EnableCors("AllowOrigin")]
    //[Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class RoleController : ControllerBase
    {
        public ControleDbContext _context;
        public IMapper _mapper;

        public RoleController(IMapper mapper, ControleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateRole(CreateRoleDto dto)
        {

            try
            {
                Role role = _mapper.Map<Role>(dto);
                _context.Roles.Add(role);
                _context.SaveChanges();
                //Logger.CreateLog($"Role {role.Name} criada com sucesso", Enums.LogType.SUCESS, "ControllerLogs");

                return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);

            } catch (Exception ex) 
            {
                //Logger.CreateLog($"Não foi possivel criar a Role: {ex.Message}", Enums.LogType.ERROR, "ControllerLogs");

                return BadRequest(ex.Message);
            }   
        }

        [HttpGet]
        public IEnumerable<ReadRoleDto> GetRoles([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadRoleDto>>(_context.Roles.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            Role role = _context.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null) 
            {
                //Logger.CreateLog("Role especificada não encontrada", Enums.LogType.INFO, "ControllerLogs");
                return NotFound();
            }

            ReadRoleDto roleDto = _mapper.Map<ReadRoleDto>(role);
            return Ok(roleDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == id);

            if (role == null) 
            {
                //Logger.CreateLog("Role especificada não encontrada", Enums.LogType.INFO, "ControllerLogs");
                return NotFound();
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();

            //Logger.CreateLog($"Role {role.Name} excluida com sucesso", Enums.LogType.SUCESS, "ControllerLogs");
            return NoContent();
        }
    }
}
