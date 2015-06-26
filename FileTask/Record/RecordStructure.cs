using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileTask
{
    public abstract class recordStructure
    {
        public FieldStructure id, name, address;
        public bool keyval, Indexed;
        public int IndexVal, CurrentIndexVal1, CurrentIndexVal2 ;
        protected abstract string FormatRecord( string rec );
        public abstract student Read( StreamReader sr);

        public virtual List<student> ReadAll(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            List<student> result = new List<student>();
            if (Indexed)
            {
                FileStream fs = new FileStream("Index.txt", FileMode.Open, FileAccess.Read);
                StreamReader Sr = new StreamReader(fs);
                if (Sr.Peek() != -1)
                    CurrentIndexVal1 = int.Parse(Sr.ReadLine());
                while (Sr.Peek() != -1)
                {
                    CurrentIndexVal2 = int.Parse(Sr.ReadLine());
                    student std = this.Read(sr);
                    result.Add(std);
                    CurrentIndexVal1 = CurrentIndexVal2;
                }
            }
            else
            {               
                while (sr.Peek() != -1)
                {
                    student std = this.Read(sr);
                    result.Add(std);
                }
            }
            sr.Close();
            return result;
        }

        public void Write(StreamWriter sw, student std)
        {
            string record = "";
            record += id.WriteField(std.id);
            record += name.WriteField(std.name);
            record += address.WriteField(std.address);
            string RecordToWrite = this.FormatRecord(record);
            sw.Write(RecordToWrite);
        }

        public void WriteWzKey(StreamWriter sw, student std)
        {
            string record = "";
            record += id.writeField(std.id, "ID=");
            record += name.writeField(std.name, "Name=");
            record += address.writeField(std.address, "Address=");
            string RecordToWrite = this.FormatRecord(record);
            sw.Write(RecordToWrite);
        }

        protected student GetFields(string record)
        {
            student std = new student();
            std.id = id.ReadField(ref record);
            std.name = name.ReadField(ref record);
            std.address = address.ReadField(ref record);
            return std;
        }

    }
}
