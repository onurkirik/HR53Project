﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Service.Services
{
    public interface IPasswordService
    {
        Task<string>  GeneratePasswordAsync(int length);

       
    }
}