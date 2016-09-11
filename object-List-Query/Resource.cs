using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace object_List_Query
{
    [Serializable]
    abstract class Resource
    {
        #region Fields

        private string title = null;
        private string isbn = null;
        private string lengthPages = null;
        private string duration = null;
        private string status = "Available";
        private string resourceType = null;
        private string dueDate = null;
        private string whoHasIt = null;
       

        //private string currentResource = null;
        //public static string currentResource = null; //TODO: Investigate... I want this to be available globally..is this correct permission?
        //public static string currentStudent = null;

        #endregion

        #region Properties
        public string Title
        {
            get { return title; }
            set { this.title = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { this.isbn = value; }
        }

        public string LengthPages
        {
            get { return lengthPages; }
            set { this.lengthPages = value; }
        }


        public string Duration
        {
            get { return duration; }
            set { this.duration = value; }
        }


        public string Status
        {
            get { return status; }
            set { this.status = value; }
        }

        public string DueDate
        {
            get { return dueDate; }
            set { this.dueDate = value; }
        }

        public string ResourceType
        {
            get { return resourceType; }
            set { this.resourceType = value; }
        }

        public string WhoHasIt //use student id
        {
            get { return whoHasIt; }
            set { this.whoHasIt = value; }
        }

    

        

        #endregion

        #region Methods

        public virtual void ViewTitle()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("ISBN: " + Isbn);
            Console.WriteLine("Length: " + LengthPages + " pages");
            Console.WriteLine("Status: " + Status);

            Console.Write("\nPress any key to continue ");
            Console.ReadKey();


        }


     

        public virtual void CheckOut(List<Resource> allResources, List<Student> allStudents)
        {

    

            Console.Clear();
            Menu.DrawTitle();
            CheckOutHeader();
            

            Console.Write("Would you like to check out " + allResources[myTools.CurrentResourceIndex].Title + "?  (y/n)");
            string input = Console.ReadLine().Trim().ToUpper();

            if (input == "Y")
            {
                
                Console.Clear();
                Menu.DrawTitle();
                CheckOutHeader();

                //reset resource properties
                allResources[myTools.CurrentResourceIndex].Status = "Checked Out";
                allResources[myTools.CurrentResourceIndex].WhoHasIt = allStudents[myTools.CurrentStudentIndex].StudentID;

                //reset student properties
                allStudents[myTools.CurrentStudentIndex].ItemsOutCount++;

                Console.WriteLine(allResources[myTools.CurrentResourceIndex].Title + " has been checked out.");

                //program writes changes to file
                Save.SaveResources(allResources, allStudents);
                Save.SaveStudents(allResources, allStudents);


                Console.Write("\nPress any key to continue ");
                

            }

        }

        public virtual void CheckIn(List<Resource> allResources, List<Student> allStudents)
        {
     
            string input =  null;
            bool good = false;
            while (input != "N")
            {
                Console.Clear();
                Menu.DrawTitle();
                CheckInHeader();
               
                Console.Write("Would you like to check in " +  allResources[myTools.CurrentResourceIndex].Title + "?  (y/n) ");
                input = Console.ReadLine().ToUpper();
                good = (input == "Y" || input == "N");
                if (good)
                {
                    switch (input) 
                    {
                        case "Y":

                            Console.Clear();
                            Menu.DrawTitle();
                            CheckInHeader();

                            //reset resource properties
                            allResources[myTools.CurrentResourceIndex].Status = "Available";
                            allResources[myTools.CurrentResourceIndex].WhoHasIt = null;

                            //reset student properties
                            allStudents[myTools.CurrentStudentIndex].ItemsOutCount--;

                            Console.WriteLine(allResources[myTools.CurrentResourceIndex].Title + " has been returned.");

                            //program writes changes to file
                            Save.SaveResources(allResources, allStudents);
                            Save.SaveStudents(allResources, allStudents);

                            Console.Write("\nPress any key to continue ");

                            Console.ReadKey();
                            Menu.MainMenu(allResources,allStudents);
                            break;
                        case "N":
                           
                            break;
                       
                        default:
                            if (input != "N")
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
        
        public virtual void EditResource(List<Resource> allResources, List<Student> allStudents)
        {
            Search editResourceSearch = new Search();
            editResourceSearch.FindResourceToEdit(allResources, allStudents);
            //resource id assigned       
        }

        public virtual List<Resource> AddResource(List<Resource> obj)
        {

            Book newBook = new Book();

            newBook.ResourceType = "BOOK";

            Console.Write("Title: ");
            newBook.Title = Console.ReadLine();

            Console.Write("ISBN number: ");
            newBook.Isbn = Console.ReadLine();

            Console.Write("Length (pages): ");
            newBook.LengthPages = Console.ReadLine() + " pages";

            obj.Add(newBook);

        
           

            return obj;

        }


        private static void CheckInHeader()
        {
            Console.WriteLine("Resource Check In");
        }
        private static void CheckOutHeader()
        {
            Console.WriteLine("Resource Check Out");
        }
        private static void ErrorMessage()
        {
            Console.Write("Typing error, press key to continue. ");
        }
        private static void DrawStarLine()
        {
            Console.WriteLine("************************");
        }
        private static void DrawTitle()
        {
            DrawStarLine();
            Console.WriteLine("+++   MYTITLE HERE   +++");
            DrawStarLine();
        }
        private static void DrawMenu(int maxitems)
        {
            DrawStarLine();
            Console.WriteLine(" 1. MenuItem One");
            Console.WriteLine(" 2. MenuItem Two");
            // more here
            Console.WriteLine(" 3. Exit program");
            DrawStarLine();
            Console.WriteLine("Make your choice: type 1, 2,... or {0} for exit", maxitems);
            DrawStarLine();
        }

    } //end class


        #endregion

        #region Constructors
        #endregion
    }


