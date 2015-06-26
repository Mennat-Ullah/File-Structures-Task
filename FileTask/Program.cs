using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileTask
{
    class Program
    {
        static void Main(string[] args)
        {
            recordStructure rd = GetRecordStructureFromUser();
            Console.WriteLine("What do you want to do");
            Console.WriteLine("1-Enter a new student");
            Console.WriteLine("2-Display File");
            Console.WriteLine("3-Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    student std = new student();
                    std.getData();
                    Console.WriteLine("Enter file name");
                    FileStream fs = new FileStream(Console.ReadLine(), FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    if (rd.keyval)
                        rd.WriteWzKey(sw, std);
                    else
                        rd.Write(sw, std);
                    sw.Close();
                    fs.Close();
                    break;
                case 2:
                    Console.WriteLine("Enter file name");
                    List<student> allStudents = rd.ReadAll(Console.ReadLine());
                    for (int i = 0; i < allStudents.Count; i++)
                    {
                        allStudents[i].display();
                    }
                    break;
                default:
                    break;
            }
        }

        private static recordStructure GetRecordStructureFromUser()
        {
            Console.WriteLine("Press :\n1) For Fixed Lenght Record.\n2) For Length indicator Record.\n3) For Seprator Records.\n4) For Indexed Record.\n5) For Fixed number of fields.\n");
            String s = Console.ReadLine();
            recordStructure rd;
            if (s == "1")
            {
                rd = new fixedLenRecord();
                rd.Indexed = false;
            }
            else if (s == "2")
            {
                rd = new lenIndRecord();
                rd.Indexed = false;
            }
            else if (s == "3")
            {
                rd = new SeparatorRecord();
                rd.Indexed = false;
            }
            else if (s == "4")
            {
                rd = new IndexedRecord();
                rd.Indexed = true;
            }
            else
            {
                rd = new fixedNofieldRecord();
                rd.Indexed = false;
            }
            Console.WriteLine("Press :\n1) For Fixed Lenght Field.\n2) For Length indicator Field.\n3) For Seprator Field.\n4) For keyvalue Field.\n");
            s = Console.ReadLine();
            if (s == "1")
            {
                rd.id = new fixedLenField();
                rd.name = new fixedLenField();
                rd.address = new fixedLenField();
                rd.keyval = false;
            }
            else if (s == "2")
            {
                rd.id = new lenIndField();
                rd.name = new lenIndField();
                rd.address = new lenIndField();
                rd.keyval = false;
            }
            else if (s == "3")
            {
                rd.id = new separatorField();
                rd.name = new separatorField();
                rd.address = new separatorField();
                rd.keyval = false;
            }
            else
            {
                rd.id = new keyvalueField();
                rd.name = new keyvalueField();
                rd.address = new keyvalueField();
                rd.keyval = true;
            }
            return rd;
        }
    }
}
