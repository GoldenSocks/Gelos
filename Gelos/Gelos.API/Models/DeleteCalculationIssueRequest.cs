using System.ComponentModel.DataAnnotations;


namespace Gelos.API.Models
{
    public class DeleteCalculationIssueRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
