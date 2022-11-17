using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNews.Authentication.Results
{
    public class AuthResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorList { get; set; }
    }
}
