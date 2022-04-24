using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Gelos.API.Controllers
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