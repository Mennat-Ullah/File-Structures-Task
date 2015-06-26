using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  FileTask
{
    class SeparatorRecord : recordStructure
    {
        protected override string FormatRecord(string record)
        {
            return record + "\n";
        }

        public override student Read(System.IO.StreamReader sr)
        {
            String record = sr.ReadLine();
            return this.GetFields(record);
        }
    }
}
