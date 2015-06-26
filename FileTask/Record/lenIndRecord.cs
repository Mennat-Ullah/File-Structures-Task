using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileTask
{
    class lenIndRecord : recordStructure
    {
        protected override string FormatRecord(string record)
        {
            char c = (char)(record.Length + '0');
            return c + record;
        }

        public override student Read(System.IO.StreamReader sr)
        {
            String record = sr.ReadLine();
            int length = record[0] - '0';
            string result = record.Substring(1, length);
            record = record.Substring(length + 1);
            return this.GetFields(result);
        }
    }
}
