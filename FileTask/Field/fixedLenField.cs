using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileTask
{
    class fixedLenField : FieldStructure
    {
        public override string WriteField(string Field)
        {
            if (Field.Length > 15)
            {
                Console.WriteLine("field lenght exceeded.\n");
                Field = "";
            }
            else if (Field.Length < 15)
                for (int i = Field.Length; i < 15; i++)
                    Field = Field + " ";
            return Field;
        }

        public override string ReadField(ref string Record)
        {
            if (Record.Length > 15)
            {
                string Result = Record.Substring(0, 15);
                Record.Substring(15);
                for (int i = Result.Length - 1; i >= 0; i--)
                    if (Result[i] == ' ')
                        Result.Substring(0, i);
                return Result;
            }
            return Record;
        }

        public override string writeField(string Field, string key)
        {
            return key + Field;
        }
    }
}
