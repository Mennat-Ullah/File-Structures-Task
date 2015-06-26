using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileTask
{
    class separatorField : FieldStructure
    {
        public override string WriteField(string Field)
        {           
            return  Field + "*";
        }

        public override string ReadField(ref string Record)
        {
            if (Record.IndexOf('*') != -1)
            {
                int length = Record.IndexOf('*');
                string result = Record.Substring(0, length);
                Record = Record.Substring(length + 1);
                return result;
            }
            return Record;
        }
        public override string writeField(string Field, string key)
        {
            return key + Field;
        }
    }
}
