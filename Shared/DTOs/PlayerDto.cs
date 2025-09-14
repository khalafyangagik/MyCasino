using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int Age { get; set; }

    }
}
