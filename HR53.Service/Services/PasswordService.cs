﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Service.Services
{
    public class PasswordService : IPasswordService
    {
        List<string> _password=new List<string>() { "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"};

        //string password=
        public Task GeneratePassword(string password)
        {
            throw new NotImplementedException();
        }


        //public Task GeneratePassword(int length)
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //    var random = new Random();
        //    return new string(Enumerable.Repeat(chars, length)
        //      .Select(s => s[random.Next(s.Length)]).ToArray());
        //}
    }
}
