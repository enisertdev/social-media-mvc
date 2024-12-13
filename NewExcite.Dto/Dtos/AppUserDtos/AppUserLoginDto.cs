using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Dto.Dtos.AppUserDtos
{
    public class AppUserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<AuthenticationScheme> Schemes { get; set; }

    }
}
