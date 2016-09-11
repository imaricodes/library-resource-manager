using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    [Serializable]
    class DVD:Resource
    {
        #region Methods


        public override void ViewTitle()
        {
            base.ViewTitle();
        }

        public override List<Resource> AddResource(List<Resource> obj)
        {

            Console.WriteLine("\n");

            Magazine newDVD = new Magazine();

            newDVD.ResourceType = "DVD";

            Console.Write("Title: ");
            newDVD.Title = Console.ReadLine();

            Console.Write("ISBN number: ");
            newDVD.Isbn = Console.ReadLine();

            Console.Write("Duration (minutes): ");
            newDVD.Duration = Console.ReadLine() + " minutes";

            obj.Add(newDVD);

            return obj;

        }

        public override void EditResource(List<Resource> allResources, List<Student> allStudents)
        {
            base.EditResource(allResources, allStudents);
        }



        public override string ToString()
        {

            return
                "Resource Type: " + ResourceType + "\n" +
                "Title: " + Title + "\n" +
                "ISBN: " + Isbn + "\n" +
                "Duration: " + Duration + " minutes\n" +
                "Status: " + Status + "\n" +
                "\n\n";
        }

        #endregion

        #region Constructors
        public DVD()
        {

            ResourceType = GetType().Name;

        }

        #endregion
    }
}
