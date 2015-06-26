using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileTask
{
    class fixedLenRecord : recordStructure
    {
        protected override string FormatRecord(string record)
        {
            if ( record.Length > 45)
            {
                Console.WriteLine("record lenght exceeded.\n");
                record = "";
            }
            else if ( record.Length < 45)
                for (int i = record.Length; i < 15; i++)
                    record = record + " ";
            return record;
        }

        public override student Read(System.IO.StreamReader sr)
        {
            char[] c = new char[ 45 ];
            sr.Read(c, 0, 45);
            String record = new String(c);
            return this.GetFields(record);
        }
    }
}
