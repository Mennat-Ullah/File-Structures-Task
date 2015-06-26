using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileTask
{
    class keyvalueField : FieldStructure
    {
        public override string writeField(string Field, string value)
        {
            return value + Field;
        }

        public override string ReadField(ref string Record)
        {
            if (Record.IndexOf('=') != -1)
                Record.Substring(Record.IndexOf('=') + 1, Record.Length - Record.IndexOf('=') - 1);
            if (Record.IndexOf('=') != -1)
            {
                string result = Record.Substring(0, Record.IndexOf('='));
                Record = Record.Substring(Record.IndexOf('=') + 1);
                return result;
            }
            return Record;
        }
        public override string WriteField(string Field)
        {
            return Field + "*";
        }
    }
}

