using EduUp.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Verify
{
    public class SendCodeToEmailDto
    {
        [Required, Email]
        public string Email { get; set; } = string.Empty;
    }
}
