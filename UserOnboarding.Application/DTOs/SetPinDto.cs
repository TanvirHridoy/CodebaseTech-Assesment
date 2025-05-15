using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOnboarding.Application.DTOs
{
    public class SetPinDto
    {
        public string ICNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Pin { get; set; } = string.Empty;

        [Required]
        [Compare("Pin")]
        public string ConfirmPin { get; set; } = string.Empty;
    }

}
