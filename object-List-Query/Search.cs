using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    class Search
    {

        /*
        public void FindResource(List<Resource> allResourceList, List<Student> allStudentsList)
        {

            bool x = true;
            while (x)
            {
                Console.Clear();
                Menu.DrawTitle();
                TitleSearchHeader();
                Console.Write("Enter title: ");
                string input = Console.ReadLine().Trim().ToString();
                bool has = allResourceList.Any(res => res.Title.Equals(input, StringComparison.CurrentCultureIgnoreCase));
                if (!has)
                {
                    Console.Clear();
                    Menu.DrawTitle();
                    TitleSearchHeader();
                    Console.Write("No results for your search\n\n");
                    while (true)
                    {
                        Console.Write("Enter S to search again or M to return to Main Menu: ");
                        input = Console.ReadLine().Trim().ToUpper();

                        switch (input)
                        {
                            case "S":
                                FindResource(allResourceList, allStudentsList);
                                break;
                            case "M":
                                Menu.MainMenu(allResourceList, allStudentsList);
                                break;
                            default:
                                Console.Clear();
                                Menu.DrawTitle();
                                TitleSearchHeader();
                                Menu.ErrorMessage();
                                Console.ReadKey();
                                Console.Clear();
                                Menu.DrawTitle();
                                TitleSearchHeader();
                                continue;
                        }
                    }
                }
                else if (has)
                {
                    //find index of matching student ...this index will change if list is sorted? ..keep item selection "in time"
                    //This CurrentStudent index is used later to check out, check in, set student's properties, etc, until all transactions complete
                    myTools.CurrentResourceIndex = allResourceList.FindIndex(item => item.Title.Equals(input, StringComparison.CurrentCultureIgnoreCase));
                    myTools.CurrentResource = input; //TODO: replace occurrences of myTools.CurrentResource with property of object at current index
                    x = false; //exit FindResource method
                }

            }
        }
        */

        public void FindResource(List<Resource> allResourceList, List<Student> allStudentsList)
        {

            bool x = true;
            while (x)
            {

                string input = null;
                bool y = true;
                while (y)
                {
                    Console.Clear();
                    Menu.DrawTitle();
                    TitleSearchHeader();
                    Console.Write("Enter Title (enter L for list of all available resources): ");
                    input = Console.ReadLine().Trim(); 
                    switch (input.ToUpper())
                    {
                        case "L":
                            Console.Clear();
                            Menu.DrawTitle();
                            TitleSearchHeader();
                            View.ViewAvailableResources(allResourceList);
                            Console.WriteLine("\nPress any key to return to previous screen ");
                            Console.ReadKey();
                            break;
                        default:
                            y = false;
                            break;
                    }

                }

                //does title exist in catalog?
                bool titleIsFound = allResourceList.Any((res => res.Title.Equals(input, StringComparison.CurrentCultureIgnoreCase)));


                if (!titleIsFound)
                {
                    Console.Clear();
                    Menu.DrawTitle();
                    TitleSearchHeader();
                    Console.Write("No results for your search\n\n");
                    while (true)
                    {
                        Console.Write("Enter S to search again or M to return to Main Menu: ");
                        input = Console.ReadLine().Trim().ToUpper();

                        switch (input)
                        {
                            case "S":
                                FindResource(allResourceList, allStudentsList);
                                break;
                            case "M":
                                Menu.MainMenu(allResourceList, allStudentsList);
                                break;
                            default:
                                Console.Clear();
                                Menu.DrawTitle();
                                TitleSearchHeader();
                                Menu.ErrorMessage();
                                Console.ReadKey();
                                Console.Clear();
                                Menu.DrawTitle();
                                TitleSearchHeader();
                                continue;
                        }
                    }
                }

                else if (titleIsFound)
                {
                    //is item available for checkout?
                    bool itemIsAvailable = CheckResourceAvailability(input, allResourceList);

                    if (itemIsAvailable)
                    {
                        myTools.CurrentResourceIndex = allResourceList.FindIndex(item => item.Title.Equals(input, StringComparison.CurrentCultureIgnoreCase));
                        x = false; //exit FindResource method
                    }
                    else if (!itemIsAvailable)
                    {
                        Console.Clear();
                        Menu.DrawTitle();
                        TitleSearchHeader();
                        Console.WriteLine("{0} is currently checked out", input);
                        while (true)
                        {
                            Console.Write("\nEnter S to search again or M to return to Main Menu: ");
                            input = Console.ReadLine().Trim().ToUpper();

                            switch (input)
                            {
                                case "S":
                                    FindResource(allResourceList, allStudentsList);
                                    break;
                                case "M":
                                    Menu.MainMenu(allResourceList, allStudentsList);
                                    break;
                                default:
                                    Console.Clear();
                                    Menu.DrawTitle();
                                    TitleSearchHeader();
                                    Menu.ErrorMessage();
                                    Console.ReadKey();
                                    Console.Clear();
                                    Menu.DrawTitle();
                                    TitleSearchHeader();
                                    continue;
                            }
                        }

                    }
                    
                }
   

            }
        }

        public void FindResourceToEdit(List<Resource> allResourceList, List<Student> allStudentsList)
        {

            bool x = true;
            while (x)
            {

                string input = null;
                bool y = true;
                while (y)
                {
                    Console.Clear();
                    Menu.DrawTitle();
                    Menu.EditResourceHeader();
                    Console.Write("\nEnter Title to edit (enter L for list of all resources): ");
                    input = Console.ReadLine().Trim(); 
                    switch (input.ToUpper())
                    {
                        case "L":
                            Console.Clear();
                            Menu.DrawTitle();
                            TitleSearchHeader();
                            View.ViewAllResources(allResourceList);
                            Console.Write("\nPress any key to return to previous screen ");
                            Console.ReadKey();
                            break;
                        default:
                            y = false;
                            break;
                    }

                }

                //does title exist in catalog?
                bool titleIsFound = allResourceList.Any((res => res.Title.Equals(input, StringComparison.CurrentCultureIgnoreCase)));


                if (!titleIsFound)
                {
                    Console.Clear();
                    Menu.DrawTitle();
                    TitleSearchHeader();
                    Console.Write("No results for your search\n\n");
                    while (true)
                    {
                        Console.Write("Enter S to search again or M to return to Main Menu: ");
                        input = Console.ReadLine().Trim().ToUpper();

                        switch (input)
                        {
                            case "S":
                                FindResourceToEdit(allResourceList, allStudentsList);
                                break;
                            case "M":
                                Menu.MainMenu(allResourceList, allStudentsList);
                                break;
                            default:
                                Console.Clear();
                                Menu.DrawTitle();
                                Menu.EditResourceHeader();
                                Menu.ErrorMessage();
                                Console.ReadKey();
                                Console.Clear();
                                Menu.DrawTitle();
                                Menu.EditResourceHeader();
                                continue;
                        }
                    }
                }

                else if (titleIsFound)
                {
                    myTools.CurrentResourceIndex = allResourceList.FindIndex(item => item.Title.Equals(input, StringComparison.CurrentCultureIgnoreCase));
                    x = false; //exit FindResource method            

                }


            }
        }

        private bool CheckResourceAvailability(string input, List<Resource> allResources) //returns true or false
        {

            bool titleIsFoundAndAvailalbe = allResources.Any(o => o.Title.Equals(input, StringComparison.CurrentCultureIgnoreCase) && o.Status == "Available");

            return titleIsFoundAndAvailalbe;
        }

        public void FindStudent(List<Resource> allResourceList, List<Student> allStudentsList)
        {

            bool x = true;
            while (x)
            {

                string input = null;
                bool y = true;
                while (y)
                {
                    Console.Clear();
                    Menu.DrawTitle();
                    StudentSearchHeader();
                    Console.Write("Enter Student ID (enter L for list of all student IDs): ");
                    input = Console.ReadLine().Trim().ToUpper();
                    switch (input)
                    {
                        case "L":
                            Console.Clear();
                            Menu.DrawTitle();
                            StudentSearchHeader();
                            View.ViewAllStudents(allStudentsList);
                            Console.WriteLine("\nPress any key to return to previous screen ");
                            Console.ReadKey();
                            break;
                        default:
                            y = false;
                            break;
                    }

                }


                bool has = allStudentsList.Any(res => res.StudentID.Equals(input, StringComparison.CurrentCultureIgnoreCase));

                
                if (!has)
                {
                    Console.Clear();
                    Menu.DrawTitle();
                    StudentSearchHeader();
                    Console.Write("No results for your search\n\n");
                    while (true)
                    {
                        Console.Write("Enter S to search again or M to return to Main Menu: ");
                        input = Console.ReadLine().Trim().ToUpper();

                        switch (input)
                        {
                            case "S":
                                FindStudent(allResourceList, allStudentsList);
                                break;
                            case "M":
                                Menu.MainMenu(allResourceList, allStudentsList);
                                break;
                            default:
                                Console.Clear();
                                Menu.DrawTitle();
                                StudentSearchHeader();
                                Menu.ErrorMessage();
                                Console.ReadKey();
                                Console.Clear();
                                Menu.DrawTitle();
                                StudentSearchHeader();
                                continue;
                        }
                    }
                }
                else if (has)
                {
                    //find index of matching student ...this index will change if list is sorted? ..keep item selection "in time"
                    //This CurrentStudent index is used later to check out, check in, set student's properties, etc, until all transactions complete
                    myTools.CurrentStudentIndex = allStudentsList.FindIndex(item => item.StudentID.Equals(input, StringComparison.CurrentCultureIgnoreCase));

                    

                    x = false; //exit FindStudent method
                }

            }
        }

        public static IEnumerable<Resource> FindStudentResourcesCheckedOut(List<Resource> allResources, List<Student> allStudents)
        {
            var resourceQuery =
                   from things in allResources
                   where things.WhoHasIt == allStudents[myTools.CurrentStudentIndex].StudentID
                   select things;

            return resourceQuery;
        }

       

        private void TitleSearchHeader()
        {
            Console.WriteLine("TITLE SEARCH\n");
        }

        private void StudentSearchHeader()
        {
            Console.WriteLine("Student Search\n");
        }
    }
}
