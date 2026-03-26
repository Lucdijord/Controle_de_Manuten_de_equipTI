using ITMaintenanceManager.Data;
using ITMaintenanceManager.DTOs;
using ITMaintenanceManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITMaintenanceManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly AppDbContext _context;

      
        public EquipmentController(AppDbContext context)
        {
            _context = context;
        }

      
        [HttpPost]
        public async Task<IActionResult> Create(EquipmentCreateDTO dto)
        {
            var equipment = new Equipment
            {
                Name = dto.Name,
                Category = dto.Category,
                PurchaseDate = dto.PurchaseDate,
                IsActive = true
            };

            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync(); 

            var response = new EquipmentResponseDTO(
                equipment.Id, equipment.Name, equipment.Category, equipment.PurchaseDate, equipment.IsActive);

            return CreatedAtAction(nameof(GetAll), new { id = equipment.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipments = await _context.Equipments
                .Select(e => new EquipmentResponseDTO(e.Id, e.Name, e.Category, e.PurchaseDate, e.IsActive))
                .ToListAsync();

            return Ok(equipments);
        }
    }
}