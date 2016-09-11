using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    class View
    {

        //find all objects, alphabetize by name and print to screen
        public static void ViewAllResources(List<Resource> allResources) //pass resource object list to method
        {

            //using Linq to sort resource list
            Console.Clear();
            allResources = allResources.OrderBy(o => o.Title).ToList();
            Menu.DrawTitle();
            ViewAllResourcesHeader();
            int count = 1;
            foreach (var item in allResources)
            {
                Console.WriteLine(count + ". " + item.Title + " (" + item.ResourceType + ")"); 
                count++;
            }

            Console.Write("\nPress any key to return to Main Menu ");
        }

        //find all objects with "Available" Status property and print to screen
        public static void ViewAvailableResources(List<Resource> allResources)
        {
            bool resourcesAreAvailable = allResources.Any((res => res.Status.Equals("Available", StringComparison.CurrentCultureIgnoreCase)));
            Console.Clear();
            Menu.DrawTitle();
            AvailalbleResourcesHeader();

            if (resourcesAreAvailable)
            {
                var allAvailResource =
                from things in allResources
                where things.Status == "Available"
                orderby things.Title ascending
                select things;
                int count = 1;
                foreach (var item in allAvailResource)
                {
                    Console.WriteLine(count + ". " + item.Title);
                    count++;
                }

                Console.Write("\nPress any key to continue ");
                

            }
            else
            {
                Console.WriteLine("\nAll resources are checked out");
                Console.Write("\nPress any key to continue ");
               

            }



        }

        public static void ViewAllStudents(List<Student> allStudents)
        {
            Console.Clear();
            Menu.DrawTitle();
            ViewAllStudentsHeader();
            allStudents = allStudents.OrderBy(o => o.LastName).ToList();
            Console.WriteLine("ID" + "    " + "STUDENT NAME");
            foreach (var item in allStudents)
            {
                Console.WriteLine(item.StudentID + "  " + item.FirstName + " " + item.LastName); 

            }
            Console.Write("\nPress any key to continue ");
        }

        public static void ViewStudentAccount(List<Resource> allResources, List<Student> allStudents)
        {
            Console.Clear();
            Menu.DrawTitle();
            ViewStudentAccountHeader(allStudents);

            if (allStudents[myTools.CurrentStudentIndex].ItemsOutCount == 0)
            {
                Console.WriteLine("Resources Checked Out: " + "0");
            }
            else if (allStudents[myTools.CurrentStudentIndex].ItemsOutCount > 0)
            {
                Console.WriteLine("\nResources Checked Out:\n");
                int count = 1;
                foreach (var item in Search.FindStudentResourcesCheckedOut(allResources, allStudents)) 
                {
                    Console.WriteLine(count + ". " + item.Title);
                    count++;
                }

                Console.Write("\nPress any key to continue ");

            }


        }


        private static void ViewStudentAccountHeader(List<Student> allStudents)
        {
            string lastNamefirstName =
                allStudents[myTools.CurrentStudentIndex].LastName
                + ", "
                + allStudents[myTools.CurrentStudentIndex].FirstName
                + " (" + allStudents[myTools.CurrentStudentIndex].StudentID + ")";
            Console.WriteLine("Currently Viewing: " + lastNamefirstName);
        }

        private static void ViewAllResourcesHeader()
        {
            Console.WriteLine("All Resources\n");
        }

        private static void AvailalbleResourcesHeader()
        {
            Console.WriteLine("Available Resources\n");
        }

        private static void ViewAllStudentsHeader()
        {
            Console.WriteLine("All Students\n");
        }
    }
}
