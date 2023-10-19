using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
