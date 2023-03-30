using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public class FacultyViewModel
    {
        [Key]
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
    }
}
