using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, StockContext>, IUserDal
    {
        public List<Role> GetRoles(User user)
        {
            using (var context = new StockContext())
            {
                var result = from role in context.Roles
                             join userrole in context.UserRoles
                             on role.Id equals userrole.RoleId
                             where userrole.UserId == user.UserId
                             select new Role { Id = role.Id, Name = role.Name };
                return result.ToList();


            }
        }
    }
}
