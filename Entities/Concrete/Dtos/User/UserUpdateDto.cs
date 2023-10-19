using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.User
{
    public class UserUpdateDto:IDto
    {
        
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public int UserPhone { get; set; }
        public string UserAddress { get; set; }
        public int UserWallet { get; set; }
    }
}
