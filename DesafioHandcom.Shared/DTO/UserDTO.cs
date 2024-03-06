using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioHandcom.Shared.DTO
{
    public class UserDTO
    {
        //DTO PARA RETORNAR APENAS INFORMAÇÕES NECESSÁRIAS
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
