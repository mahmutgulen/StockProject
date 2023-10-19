using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Order
{
    public class OrderAddDto:IDto
    {
        public int UserId { get; set; }
        public int OrderNumber { get; set; }
        public SqlMoney TotalPrice { get; set; }
    }
}
