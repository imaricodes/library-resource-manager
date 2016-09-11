    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    [Serializable]
    class Book:Resource
    {

        #region Methods


        public override void ViewTitle()
        {
            base.ViewTitle();
        }

        public override List<Resource> AddResource(List<Resource> obj)
        {

            Console.WriteLine("\n");

            Book newBook = new Book();

            newBook.ResourceType = "Book";

            Console.Write("Title: ");
            newBook.Title = Console.ReadLine();

            Console.Write("ISBN number: ");
            newBook.Isbn = Console.ReadLine();

            Console.Write("Length (pages): ");
            newBook.LengthPages = Console.ReadLine() + " pages";

            obj.Add(newBook);

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
        public Book()
        {

            ResourceType = GetType().Name;

        }

        #endregion
    }
}
