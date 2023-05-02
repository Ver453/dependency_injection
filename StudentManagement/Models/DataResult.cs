﻿using StudentManagement.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{

    public class DataResult<T> where T : class
    {
        public ResultType ResultType { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public class DataResult
    {
        public ResultType ResultType { get; set; }
        public string Message { get; set; }
        public int ReturnId { get; set; }
    }

}
