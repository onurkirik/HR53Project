﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Service.Services
{
    public class PasswordService : IPasswordService
    {
        public async Task<string> GeneratePasswordAsync(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string chars1 = "abcdefghijklmnopqrstuvwxyz";
            const string chars2 = "0123456789";
            var random = new Random();
            var password1 = await Task.Run(() => new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray()));
            var password2 = await Task.Run(() => new string(Enumerable.Repeat(chars1, length)
                .Select(s => s[random.Next(s.Length)]).ToArray()));
            var password3 = await Task.Run(() => new string(Enumerable.Repeat(chars2, length)
    .Select(s => s[random.Next(s.Length)]).ToArray()));

            var password = password1 + password2 + password3;

            return password;

        }

    }
}
