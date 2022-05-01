using System.ComponentModel.DataAnnotations;


namespace Gelos.API.Models
{
    public class GetCalculationIssueRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
