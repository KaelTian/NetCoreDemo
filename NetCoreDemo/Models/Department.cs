﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name= "部门名称")]
        public string Name { get; set; }
        [Display(Name ="位置")]
        public string Location { get; set; }

        public int EmployeeCount { get; set; }
    }
}