using System;
using System.Collections.Generic;
using System.Text;

namespace expensess.MODEL
{
    internal class AuthenticationResponse
    {
        public Boolean ok { get; set; }
        public string id { get; set; }
        public string nombre { get; set; }

        public string telefono { get; set; }
        public string email { get; set; }

        public string token { get; set; }
    }
}
