﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Service.Services
{
    public interface IMemberService
    {
        Task LogOutAsync();
        Task DeleteUserAsync(string id);
    }
}
