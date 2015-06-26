using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileTask
{
    public abstract class FieldStructure
    {
        public abstract string WriteField(string Field);

        public abstract string writeField(string Field, string keyvalue);

        public abstract string ReadField(ref string Record);
    }
}
