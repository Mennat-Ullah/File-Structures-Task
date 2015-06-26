using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileTask
{
    class IndexedRecord : recordStructure
    {
        protected override string FormatRecord(string record)
        {
            FileStream fs = new FileStream("Index.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            if (this.IndexVal <= 0)
                sw.WriteLine(this.IndexVal);
            int len = record.Length;
            this.IndexVal += len;
            sw.WriteLine(this.IndexVal);
            return record;
        }

        public override student Read(System.IO.StreamReader sr)
        {
            char[] C = new char[this.CurrentIndexVal2 - this.CurrentIndexVal1];
            sr.Read(C, 0, this.CurrentIndexVal2 - this.CurrentIndexVal1);
            String result = new String(C);
            return this.GetFields(result);
        }
    }
}
