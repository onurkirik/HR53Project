﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Core.ViewModels.CompanyManagerArea
{
    public class AddEmployeeViewModel
    {
        public string Id { get; set; }
        public string? Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? SecondSurname { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Birthplace { get; set; }
        public string? IdentityCardNo { get; set; }
        public string? Profession { get; set; }
        public string? Department { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public IFormFile? Picture { get; set; }
        public string? CompanyId { get; set; }
    }
}