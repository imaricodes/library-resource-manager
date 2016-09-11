using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    public sealed class myTools
    {
        private static string currentResource = null; 
        private static int currentResourceIndex;
        private static string currentStudent = null;
        private static int currentStudentIndex;


        public static string CurrentResource
        {
            get { return currentResource; }
            set { currentResource = value; }
        }

        public static int CurrentResourceIndex
        {
            get { return currentResourceIndex; }
            set { currentResourceIndex = value; }
        }

        public static string CurrentStudent
        {
            get { return currentStudent; }
            set { currentStudent = value; }
        }

        public static int CurrentStudentIndex
        {
            get { return currentStudentIndex; }
            set { currentStudentIndex = value; }
        }

  

    }
}
