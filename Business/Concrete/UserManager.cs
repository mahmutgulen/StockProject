using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IUserRoleDal _userRoleDal;

        public UserManager(IUserDal userDal, IUserRoleDal userRoleDal)
        {
            _userDal = userDal;
            _userRoleDal = userRoleDal;
        }

        public IResult Add(UserAddDto userAddDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                UserEmail = userAddDto.UserEmail,
                UserName = userAddDto.UserName,
                UserSurname = userAddDto.UserSurname,
                UserPasswordHash = passwordHash,
                UserPasswordSalt = passwordSalt,
                Status = true,
                UserPhone = userAddDto.UserPhone,
                UserAddress = userAddDto.UserAddress,
                UserWallet = userAddDto.UserWallet
            };

            _userDal.Add(user);
            //Role atama
            var userRole = new UserRole
            {
                RoleId = 2,
                UserId = user.UserId
            };
            _userRoleDal.Add(userRole);
            //Role atama

            return new SuccessResult(Messages.UserAdded);
        }
        
        public IResult Delete(int userId)
        {
            var user = _userDal.Get(u => u.UserId == userId);
            if (user!=null)
            {
                _userDal.Delete(user);

                return new SuccessResult(Messages.UserDeleted);
            }
                return new ErrorResult(Messages.UserNotFound);
            
        }

        public IDataResult<User> GetById(int userId)
        {
            var user = _userDal.Get(u => u.UserId == userId);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var user = _userDal.Get(u => u.UserEmail == email);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList().ToList());
        }

        public IDataResult<List<Role>> GetRoles(User user)
        {
            return new SuccessDataResult<List<Role>>(_userDal.GetRoles(user));
        }

        public IResult Update(UserUpdateDto userUpdateDto,string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                UserId= userUpdateDto.UserId,
                UserEmail = userUpdateDto.UserEmail,
                UserName = userUpdateDto.UserName,
                UserSurname = userUpdateDto.UserSurname,
                Status = true,
                UserPhone = userUpdateDto.UserPhone,
                UserAddress = userUpdateDto.UserAddress,
                UserWallet = userUpdateDto.UserWallet,
                UserPasswordHash = passwordHash,
                UserPasswordSalt = passwordSalt
            };

            _userDal.Update(user);

            return new SuccessResult(Messages.UserUpdated);
        }


    }
}
