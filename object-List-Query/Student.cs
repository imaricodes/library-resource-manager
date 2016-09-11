using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    [Serializable]
    class Student
    {
        #region Fields

        private string firstName = null;
        private string lastName = null;
        private string studentID = null;
        private int itemsOutCount = 0;
        //private string firstLastName = null;

        #endregion

        #region Properties

        public string FirstName
        {
            get { return firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { this.lastName = value; }
        }

        public string StudentID
        {
            get { return studentID; }
            set { this.studentID = value; }
        }

        public int ItemsOutCount
        {
            get { return itemsOutCount; }
            set { this.itemsOutCount = value; }
        }

        //public string FirstLastName
        //{
        //    get { return firstLastName; }
        //    set { this.firstLastName = value; }
        //}

        #endregion

        #region Methods

        public void ViewStudentAccount()
        {

            Console.WriteLine("STUDENT INFORMATION\n");
            Console.WriteLine("Name: " + FirstName + LastName);
            Console.WriteLine("ISBN: " + StudentID);
            Console.WriteLine("Length: " + ItemsOutCount);

            Console.Write("\nPress any key to continue ");
            Console.ReadKey();

        }


        #endregion

        #region Constructors
        public Student()
        {
            //this.FirstLastName = this.LastName + ", " + this.FirstName;

        }

        #endregion
    }
}
