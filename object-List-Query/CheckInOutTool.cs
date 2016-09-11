using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    class CheckInOutTool : Resource
    {
        public override void CheckIn(List<Resource> allResources, List<Student> allStudents)
        {



            base.CheckIn(allResources, allStudents);
        }

        public override void CheckOut(List<Resource> allResources, List<Student> allStudents)
        {
            

            base.CheckOut(allResources, allStudents);
        }

        public CheckInOutTool()
        {

        }

        

    }
}
