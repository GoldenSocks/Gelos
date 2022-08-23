using Gelos.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Gelos.API.Models
{
    public class CreateEmployeeRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Role { get; set; } = string.Empty;

    }
}
