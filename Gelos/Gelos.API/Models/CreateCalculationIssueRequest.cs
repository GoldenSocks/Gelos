using System.ComponentModel.DataAnnotations;


namespace Gelos.API.Models
{
    public class CreateCalculationIssueRequest
    {
        [Required]
        [StringLength(500)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }
    }
}