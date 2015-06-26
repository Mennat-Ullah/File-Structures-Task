using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileTask
{
    class lenIndField : FieldStructure
    {
        public override string WriteField(string Field)
        {
            char c = (char)(Field.Length + '0');
            return c + Field;
        }

        public override string ReadField(ref string Record)
        {
            int length = Record[0] - '0';
            string result = Record.Substring(1, length);
            Record = Record.Substring(length + 1);
            return result;
        }
        public override string writeField(string Field, string key)
        {
            return key + Field;
        }
    }
}
