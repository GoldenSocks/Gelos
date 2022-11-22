using System.ComponentModel.DataAnnotations;

namespace Gelos.API.Contracts
{
    public class CreateEmployeeRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Role { get; set; } = string.Empty;

    }
}
