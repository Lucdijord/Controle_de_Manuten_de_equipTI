using System.ComponentModel.DataAnnotations;

namespace ITMaintenanceManager.DTOs
{
    public record TicketCreateDTO(
        [Required(ErrorMessage = "O título do chamado é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O título deve ter no máximo 50 caracteres.")]
        string Title, 
        
        [Required(ErrorMessage = "A descrição do problema é obrigatória.")]
        [MinLength(10, ErrorMessage = "Forneça uma descrição mais detalhada (mínimo de 10 caracteres).")]
        string Description, 
        
        [Required(ErrorMessage = "É necessário informar o ID do equipamento.")]
        [Range(1, int.MaxValue, ErrorMessage = "ID de equipamento inválido.")]
        int EquipmentId
    );

    public record TicketResponseDTO(
        int Id, 
        string Title, 
        string Description, 
        string Status, 
        DateTime OpenDate, 
        DateTime Deadline, 
        string EquipmentName
    );
}