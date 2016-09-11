using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    class Program : Resource
    {


        static void Main(string[] args)
        {

            //create instances of resource and student search objects..
            Search resourceSearch = new Search(); 
            Search studentSearch = new Search(); 


            //create list of objects to query (for development only. Comment out for final version)

            //List<Resource> allResources = new List<Resource>()
            //{
            //    new Book {Title = "Java for Gents", Isbn = "rb925", LengthPages = "120", //List is type base class, but can add objects of derived classes..yes!
            //        Status = "Available", WhoHasIt = null},
            //     new Book {Title = "C# Guide", Isbn = "rb628", LengthPages = "300",
            //        Status = "Available", WhoHasIt = null },
            //      new DVD {Title = "History of Computers", Isbn = "rdvd412", Duration = "100",
            //        Status = "Available", WhoHasIt = null},
            //       new DVD {Title = "Practical Architecture", Isbn = "rdvd555", Duration = "100",
            //        Status = "Available", WhoHasIt = null},
            //        new Magazine {Title = "PC Magazine", Isbn = "rmag847", LengthPages = "63",
            //        Status = "Available", WhoHasIt = null},
            //         new Magazine {Title = "Coder Quarterly", Isbn = "rmag685", LengthPages = "50",
            //        Status = "Available", WhoHasIt = null}
            //};

            //List<Student> allStudents = new List<Student>()
            //{
            //    new Student {FirstName = "Lawrence", LastName = "Welk", StudentID = "s111", ItemsOutCount = 0},
            //    new Student {FirstName = "Mary", LastName = "Carey", StudentID = "s222", ItemsOutCount = 0,},
            //    new Student {FirstName = "Jacob", LastName = "Jacoby", StudentID = "s444", ItemsOutCount = 0,},
            //    new Student {FirstName = "Krista", LastName = "Allen", StudentID = "s555", ItemsOutCount = 0,},
            //    new Student {FirstName = "Quinn", LastName = "Kimberley", StudentID = "s666", ItemsOutCount = 0,}

            //};

            List<string> allResourcesStringList = new List<string>();
            List<string> allStudentsStringList = new List<string>();


            ////Load Resources and students from BIN
            List<Resource> allResources = Load.ReadFromBinaryFile<List<Resource>>("all-resources.bin");
            List<Student> allStudents = Load.ReadFromBinaryFile <List<Student>>("students.bin");


            Menu Main = new Menu();
            Menu.MainMenu(allResources, allStudents);

           


            Console.ReadKey();

        }
    }
}
