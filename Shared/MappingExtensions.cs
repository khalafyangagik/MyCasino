using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Models;
using Shared.DTOs;

namespace Shared
{
    public static class MappingExtensions
    {
        public static PlayerDto ToDto(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                Username = player.Username,
                Age = player.Age,
               
            };
        }
    }
}
