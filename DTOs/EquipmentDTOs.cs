using System.ComponentModel.DataAnnotations;

namespace ITMaintenanceManager.DTOs
{
    public record EquipmentCreateDTO(
        [Required(ErrorMessage = "O nome do equipamento é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        string Name, 
        
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        [RegularExpression("^(Servidor|Desktop|Notebook|Periferico)$", ErrorMessage = "Categoria inválida. Use: Servidor, Desktop, Notebook ou Periferico.")]
        string Category, 
        
        [Required(ErrorMessage = "A data de compra é obrigatória.")]
        DateTime PurchaseDate
    );

    public record EquipmentResponseDTO(int Id, string Name, string Category, DateTime PurchaseDate, bool IsActive);
}