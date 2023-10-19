using Business.Abstract;
using Business.Concrete;
using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    internal class Program
    {
        public static  IUserProvider _userProvider;

        public  Program(IUserProvider userProvider)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider)); //var userId= _userProvider.GetUserId();
        }

        static void Main(string[] args)
        {
            var userId = _userProvider.GetUserId();
            Console.WriteLine(userId);

        }

    }
}
