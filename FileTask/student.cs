using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileTask
{
    public class student
    {
        private string Id;
        private string Name;
        private string Address;

        public string id
        {
            get { return Id; }
            set { Id = value; }
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string address
        {
            get { return Address; }
            set { Address = value; }
        }

        public void display()
        {
            Console.WriteLine("Id:");
            Console.WriteLine(this.Id);
            Console.WriteLine("Name:");
            Console.WriteLine(this.Name);
            Console.WriteLine("Address:");
            Console.WriteLine(this.Address);
        }
        public void getData()
        {
            Console.WriteLine("Enter your id:");
            this.Id = Console.ReadLine();
            Console.WriteLine("Enter your name:");
            this.Name = Console.ReadLine();
            Console.WriteLine("Enter your address:");
            this.Address = Console.ReadLine();
        }
    }
}
