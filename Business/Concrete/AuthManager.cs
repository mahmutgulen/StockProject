using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos.User;
using FluentValidation.Validators;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private IUserDal _userDal;
        ITokenHelper _tokenHelper;
        private readonly IUserRoleDal _userRoleDal;
        private readonly ICartDal _cartDal;
        private readonly IProductDal _productDal;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserRoleDal userRoleDal, ICartDal cartDal, IProductDal productDal, IUserDal userDal)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userRoleDal = userRoleDal;
            _cartDal = cartDal;
            _productDal = productDal;
            _userDal = userDal;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var roles = _userService.GetRoles(user);
            var accessToken = _tokenHelper.CreateToken(user, roles.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }



        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var userToCheck = _userService.GetByMail(userLoginDto.UserEmail);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, userToCheck.Data.UserPasswordHash, userToCheck.Data.UserPasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserEmail = userRegisterDto.UserEmail,
                UserName = userRegisterDto.UserName,
                UserSurname = userRegisterDto.UserSurname,
                UserPasswordHash = passwordHash,
                UserPasswordSalt = passwordSalt,
                Status = true,
                UserPhone = userRegisterDto.UserPhone,
                UserAddress = userRegisterDto.UserAddress,
                UserWallet = userRegisterDto.UserWallet
            };
            //Bruuh!
            _userDal.Add(user);
            //-------------------------AYDINLANMA ÇAĞI-----------------------
            //otomatik rol ataması

            var userRole = new UserRole
            {
                RoleId = 2,
                UserId = user.UserId
            };
            _userRoleDal.Add(userRole);

            //------------------------AYDINLANMA ÇAĞI------------------------
            //cart olusumu
            var cart = new Cart
            {
                UserId = user.UserId
                
            };
            _cartDal.Add(cart);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var user = _userService.GetByMail(email);
            if (user.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

       
    }
}
