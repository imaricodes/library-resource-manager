using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace object_List_Query
{
    class Save
    {



        //save resource function saves resource to text and binary files
        public static void SaveResources(List<Resource> allResources, List<Student> allStudents)
        {

            //copy resource current resource titles to string list and save to txt file
            List<string> resourceTitleList = new List<string>();

            var resourceTitles =
                from things in allResources
                where things.Title != null
                select things.Title + "(" + things.ResourceType + ")";


            foreach (var item in resourceTitles)
            {

                resourceTitleList.Add(item);
            }


            StreamWriter writeResource = new StreamWriter("all-resources.txt");

            using (writeResource)
            {
                foreach (var item in resourceTitleList)
                {
                    writeResource.WriteLine(item);
                }

            }

            //save resource objects to bin

            WriteToBinaryFile("all-resources.bin", allResources, false);

            SaveResourcesToSeparateTextFiles(allResources, allStudents);

            SaveAllCurrentlyCheckedOutResourcesToTextFile(allResources, allStudents);
            

        }

        //save student function saves students to text and binary files
        public static void SaveStudents(List<Resource> allResources, List<Student> allStudents)
        {

            //copy resource current resource titles to string list and save to txt file
            List<string> studentNameList = new List<string>();

            var studentNameSelection =
                from things in allStudents
                where things.FirstName != null
                select things.LastName + ", " + things.FirstName;


            foreach (var item in studentNameSelection)
            {

                studentNameList.Add(item);
            }
            studentNameList.Sort();


            StreamWriter writeResource = new StreamWriter("students.txt");

            using (writeResource)
            {
                foreach (var item in studentNameList)
                {
                    writeResource.WriteLine(item);
                }

            }

            //save student object to bin

            WriteToBinaryFile("students.bin", allStudents, false);

            SaveAllStudentsToSepearateTextFile(allResources, allStudents);
        }


        private static void SaveAllStudentsToSepearateTextFile(List<Resource> allResources, List<Student> allStudents)
        {
            StreamWriter writeStudentsToSeparateTexts = new StreamWriter("all-Students-List.txt");
            using (writeStudentsToSeparateTexts)
            {
                var studentsToText =
               from things in allStudents
               where things.FirstName != null
               select things.FirstName + " " + things.LastName;

                foreach (var item in studentsToText)
                {
                    writeStudentsToSeparateTexts.WriteLine(item);

                }

            }
        }
        private static void SaveAllCurrentlyCheckedOutResourcesToTextFile(List<Resource> allResources, List<Student> allStudents)
        {
            StreamWriter writeCheckedOutResources = new StreamWriter("all-ResourcesCheckedOut-List.txt");
            using (writeCheckedOutResources)
            {
                var checkedOutResources =
               from things in allResources
               where things.Status == "Checked Out"
               select things.Title;

                foreach (var item in checkedOutResources)
                {
                    writeCheckedOutResources.WriteLine(item);

                }

            }

        }
        private static void SaveResourcesToSeparateTextFiles(List<Resource> allResources, List<Student> allStudents)
        {
            StreamWriter writeBook = new StreamWriter("all-Books-List.txt");
            using (writeBook)
            {
                var books =
               from things in allResources
               where things.ResourceType == "Book"
               select things.Title;

                foreach (var item in books)
                {
                    writeBook.WriteLine(item);

                }

            }

            StreamWriter writeDVD = new StreamWriter("all-DVDs-List.txt");
            using (writeDVD)
            {
                var dvds =
               from things in allResources
               where things.ResourceType == "DVD"
               select things.Title;

                foreach (var item in dvds)
                {
                    writeDVD.WriteLine(item);

                }

            }

            List<string> x = new List<string>();
            StreamWriter writeMagazine = new StreamWriter("all-Magazines-List.txt");
            using (writeMagazine)
            {
                var magazines =
               from things in allResources
               where things.ResourceType == "Magazine"
               select things.Title;

                foreach (var item in magazines)
                {
                    writeMagazine.WriteLine(item);

                }


            }

        }
        private static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

    }


}
