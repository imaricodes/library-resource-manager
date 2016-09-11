using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    class Menu
    {

        public static void MainMenu(List<Resource> allResources, List<Student> allStudents)
        {
          
            const int maxMenuItems = 9;
            int selector = 0;
            bool good = false;
            while (selector != maxMenuItems)
            {
                Console.Clear();
                DrawTitle();
                DrawMainMenu();
                good = int.TryParse(Console.ReadLine(), out selector);
                if (good)
                {
                    switch (selector)
                    {
                        case 1: //view all resources
                            View.ViewAllResources(allResources);

                            break;
                        case 2: //view all available resources
                            View.ViewAvailableResources(allResources);
                            break;
                        case 3: //edit 
                            Console.Clear();
                            DrawTitle();
                            EditResourceMenu(allResources, allStudents);

                            Search findResourceToEdit = new Search();
                            findResourceToEdit.FindResourceToEdit(allResources, allStudents);

                            //user enters new title for resource
                            Console.Write("Enter new title for {0}: ", allResources[myTools.CurrentResourceIndex].Title);
                            string input = Console.ReadLine();

                            //program changes title of resource
                            allResources[myTools.CurrentResourceIndex].Title = input;

                            //program writes resource title changes to file
                            Save.SaveResources(allResources, allStudents);


                            break;
                        case 4: //view student accounts
                            Search studentSearch = new Search();
                            studentSearch.FindStudent(allResources, allStudents);
                            View.ViewStudentAccount(allResources, allStudents);

                            break;
                        case 5: //view all student acounts
                            View.ViewAllStudents(allStudents);
                            break;
                        case 6: //check in resource
                            Console.Clear();
                            DrawTitle();

                            //find resource to check in, if found, set CurrentResource var 
                            Search findStudent = new Search();
                            findStudent.FindStudent(allResources, allStudents); //this will update current student value

                            Console.Clear();
                            DrawTitle();

                            //confirm student has any items checked out
                            if (allStudents[myTools.CurrentStudentIndex].ItemsOutCount == 0)
                            {
                                Console.WriteLine("Student has no items checked out");
                                Console.Write("Press any key to return to main menu ");
                                Console.ReadKey();
                                break;
                            }

                            //create list of resources student has checked out
                            CheckInHeader();
                            int count = 1;
                            List<string> returnChoices = new List<string>();

                            //write resources student has checked out to screen
                            Console.WriteLine("\nResources Checked out by student:");
                            foreach (var item in Search.FindStudentResourcesCheckedOut(allResources, allStudents)) 
                            {
                                Console.WriteLine(count + ". " + item.Title);
                                returnChoices.Add(item.Isbn);
                                count++;
                            }

                            
                            bool x = true;
                            int inputAsInt = 0;
                            while (x)
                            {
                                Console.Write("\nChoose item to return for {0} ", allStudents[myTools.CurrentStudentIndex].FirstName); 
                                input = Console.ReadLine();
                                try
                                {
                                    //bool result = int.TryParse(input, out inputAsInt);

                                    inputAsInt = int.Parse(input);
                                }
                                catch (Exception)
                                {
                                    ErrorMessage();
                                }


                                if (inputAsInt < 1 || inputAsInt > count)
                                {
                                    ErrorMessage();
                                }
                                else
                                {
                                    x = false;
                                }

                            }

                            //after user choice, update value of myTools.currentResourceindex to match choice
                            myTools.CurrentResourceIndex = allResources.FindIndex(a => a.Isbn == returnChoices[inputAsInt - 1]);

                            //find corresponding item in resource list and change "who has it" property. while loop will handle input                    
                            allResources[myTools.CurrentResourceIndex].WhoHasIt = null;

                            //find corresponding item in resource list and chang "Status" to Available
                            allResources[myTools.CurrentResourceIndex].Status = "Available";

                            //change current student's items checked out... -1
                            allStudents[myTools.CurrentStudentIndex].ItemsOutCount--;

                            CheckInOutTool checkintool = new CheckInOutTool();
                            checkintool.CheckIn(allResources, allStudents);

                            break;
                        case 7: //check out resource
                            //identify student
                            Search findStudentCheckOut = new Search();
                            findStudentCheckOut.FindStudent(allResources, allStudents);

                            //are max # of items allowed checked out?
                            if (allStudents[myTools.CurrentStudentIndex].ItemsOutCount > 3)
                            {
                                int itemsOut = allStudents[myTools.CurrentStudentIndex].ItemsOutCount;
                                string name = allStudents[myTools.CurrentStudentIndex].FirstName;
                                Console.WriteLine("{0} has the maximum number of resources checked out. Return item to check out", name);
                                Console.Write("Press any key to continue ");
                                Console.ReadKey();
                                break;
                            }

                            //will set currentResourceIndex if item found
                            Search findResourceCheckout = new Search();
                            findResourceCheckout.FindResource(allResources, allStudents);

                            //finally, check out book
                            CheckInOutTool checkOutResource = new CheckInOutTool();
                            checkOutResource.CheckOut(allResources, allStudents);

                            // Console.ReadKey();


                            break;
                        case 8: //add resource
                            Menu.AddResourceMenu(allResources, allStudents);
                            Console.WriteLine("New Resource Created!");

                            break;

                        case 9: //exit
                            Console.Clear();
                            DrawTitle();
                            Console.WriteLine("\nGood Bye");
                            System.Threading.Thread.Sleep(2500);
                            Environment.Exit(0);

                            break;


                        default:
                            if (selector != maxMenuItems)
                            {
                                ErrorMessage();
                            }
                            break;
                    }
                }
                else
                {
                    ErrorMessage();
                }
                Console.ReadKey();
            }
        }

        public static void AddResourceMenu(List<Resource> allResources, List<Student> allStudents)
        {
            const int maxMenuItems = 4;
            int selector = 0;
            bool good = false;
            //string input = null;
            while (selector != maxMenuItems)
            {
                Console.Clear();
                DrawTitle();
                DrawAddResourceMenu();
                Console.Write("\nMake your selection or 4 to return to Main Menu ");

                string input = Console.ReadLine().Trim();
                good = int.TryParse(input, out selector);
                if (good)
                {
                    switch (selector)
                    {
                        case 1:
                            Console.Clear();
                            DrawTitle();
                            AddResourceHeader();
                            Book addBook = new Book();
                            addBook.AddResource(allResources);

                            //write resource changes to file
                            Save.SaveResources(allResources, allStudents);
                            Console.WriteLine("\nNew Resource Created!");

                            Console.WriteLine("\nPress any key to continue: ");
                            Console.ReadKey();
                            AddResourceMenu(allResources, allStudents);



                            break;
                        case 2: 
                            Console.Clear();
                            DrawTitle();
                            AddResourceHeader();
                            Magazine addMagazine = new Magazine();
                            addMagazine.AddResource(allResources);

                            //write resource changes to file
                            Save.SaveResources(allResources, allStudents);
                            Console.WriteLine("\nNew Resource Created!");

                            Console.WriteLine("\nPress any key to continue: ");
                            Console.ReadKey();
                            AddResourceMenu(allResources, allStudents);
                            break;
                        case 3: 
                            Console.Clear();
                            DrawTitle();
                            AddResourceHeader();
                            DVD addDVD = new DVD();
                            addDVD.AddResource(allResources);

                            //write resource changes to file
                            Save.SaveResources(allResources, allStudents);

                            Console.WriteLine("\nNew Resource Created!");
                            Console.WriteLine("\nPress any key to continue: ");
                            Console.ReadKey();
                            AddResourceMenu(allResources, allStudents);
                            break;

                        case 4:
                            MainMenu(allResources, allStudents);
                            break;


                        default:

                            ErrorMessage();

                            break;
                    }
                }
                else
                {
                    ErrorMessage();
                }
                Console.ReadKey();
            }
        }

        public static void EditResourceMenu(List<Resource> allResources, List<Student> allStudents) 
        {

            const int maxMenuItems = 4;
            int selector = 0;
            bool good = false;
            //string input = null;
            while (selector != maxMenuItems)
            {
                Console.Clear();
                DrawTitle();
                DrawEditMenu();
                Console.Write("\nMake your selection or 4 to return to Main Menu ");

                string input = Console.ReadLine().Trim();
                good = int.TryParse(input, out selector);

                if (good)
                {
                    switch (selector)
                    {
                        case 1: //edit book
                            Console.Clear();
                            DrawTitle();
                            EditResourceHeader();
                            Console.WriteLine("Press enter to search for resources to edit ");

                            Search findResourceToEditBook = new Search();
                            findResourceToEditBook.FindResourceToEdit(allResources, allStudents); //set CurrentResrouceIndex value
                            Console.Write("Enter new title for {0}: ", allResources[myTools.CurrentResourceIndex].Title);

                            string input1 = Console.ReadLine();

                            allResources[myTools.CurrentResourceIndex].Title = input1;
                            View.ViewAllResources(allResources);
                            Console.WriteLine("Edit Complete");

                            break;
                        case 2: //edit magazine
                            Console.Clear();
                            DrawTitle();
                            EditResourceHeader();
                            Console.WriteLine("Press enter to search for resources to edit ");

                            Search findResourceToEditDVD = new Search();
                            findResourceToEditDVD.FindResourceToEdit(allResources, allStudents);
                            Console.Write("Enter new title for {0}: ", allResources[myTools.CurrentResourceIndex].Title);

                            string input2 = Console.ReadLine();

                            allResources[myTools.CurrentResourceIndex].Title = input2;
                            View.ViewAllResources(allResources);
                            Console.WriteLine("Edit Complete");

                            break;
                        case 3: //edit DVD
                            Console.Clear();
                            DrawTitle();
                            EditResourceHeader();
                            Console.WriteLine("Press enter to search for resources to edit ");

                            Search findResourceToEditMag = new Search();
                            findResourceToEditMag.FindResourceToEdit(allResources, allStudents);
                            Console.Write("Enter new title for {0}: ", allResources[myTools.CurrentResourceIndex].Title);

                            string input3 = Console.ReadLine();

                            allResources[myTools.CurrentResourceIndex].Title = input3;
                            View.ViewAllResources(allResources);
                            Console.WriteLine("New resource title is: " + allResources[myTools.CurrentResourceIndex].Title);
                            Console.Write("Press any key to continue: ");

                            break;

                        case 4: //return to main menu

                            MainMenu(allResources, allStudents);
                            break;


                        default:
                            if (selector != maxMenuItems)
                            {
                                ErrorMessage();
                            }
                            break;
                    }
                }
                else
                {
                    ErrorMessage();
                }
                Console.ReadKey();
            }
        }






        //DRAW MENU FUNCTIONS
        private static void DrawMainMenu()
        {

            Console.WriteLine(" 1. View All Resources");
            Console.WriteLine(" 2. View Available Resources");
            Console.WriteLine(" 3. Edit Resource    ");
            Console.WriteLine(" 4. View Student Account");
            Console.WriteLine(" 5. View All Students");
            Console.WriteLine(" 6. Check In Resource");
            Console.WriteLine(" 7. Check Out Resource");
            Console.WriteLine(" 8. Add Resource");
            Console.WriteLine(" 9. Exit");

            Console.Write("\nMake your selection or enter 9 to exit ");

        }
        private static void DrawEditMenu()
        {

            EditResourceHeader();
            Console.WriteLine(" 1. Book");
            Console.WriteLine(" 2. DVD");
            Console.WriteLine(" 3. Magazine");
            Console.WriteLine(" 4. Return To Main Menu");

        }
        private static void DrawAddResourceMenu()
        {

            AddResourceHeader();
            Console.WriteLine("\nWhat Type of resource would you like to add?\n");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Magazine");
            Console.WriteLine("3. DVD");
            Console.WriteLine("4. Return To Main Menu");



        }

        //HEADERS & PAGE TITLES
        private static void CheckInHeader()
        {
            Console.WriteLine("Resource Check In");
        }
        public static void EditResourceHeader()
        {
            Console.WriteLine("Edit Resource");
        }
        public static void AddResourceHeader()
        {
            Console.WriteLine("Add Resource");
        }

        public static void DrawStarLine()
        {
            Console.WriteLine("************************");
        }
        public static void DrawTitle()
        {
            //DrawStarLine();
            Console.WriteLine("+++ Bootcamp Resource System +++\n");

        }

        //USER MESSAGES
        public static void ErrorMessage()
        {
            Console.Write("Invalid input, press key to continue ");
        }


    }
}
