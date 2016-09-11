using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    [Serializable]
    class Magazine : Resource
    {

        #region Methods


        public override void ViewTitle()
        {
            base.ViewTitle();
        }

        public override List<Resource> AddResource(List<Resource> obj)
        {

            Console.WriteLine("\n");

            Magazine newMagazine = new Magazine();

            newMagazine.ResourceType = "Magazine";

            Console.Write("Title: ");
            newMagazine.Title = Console.ReadLine();

            Console.Write("ISBN number: ");
            newMagazine.Isbn = Console.ReadLine();

            Console.Write("Length (pages): ");
            newMagazine.LengthPages = Console.ReadLine() + " pages";

            obj.Add(newMagazine);

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
                "Length: " + LengthPages + "\n" +
                "Status: " + Status + "\n" +
                "\n\n";
        }

        #endregion

        #region Constructors
        public Magazine()
        {

            ResourceType = GetType().Name;

        }

        #endregion
    }
}
