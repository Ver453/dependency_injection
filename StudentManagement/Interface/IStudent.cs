using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Interface
{
   public interface IStudent
    {
        StudentViewModel GetData(int Id);
        List<StudentViewModel> GetIndexData();
        StudentViewModel GetCreateData();
        int PostCreateData(StudentViewModel student);
        int PostEditData(StudentViewModel student);
        int PostDeleteData(StudentViewModel student);
    }
}
