using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Lesson_7_Delegates;

namespace Advanced_Lesson_7_Delegates.Extantions
{
    public delegate string StringOperation(string item);
    public static class StringExtantions
    {

        public static List<string> StringModification(this List<string> array, StringOperation operation)
        {
            List<string> result = new List<string>();
            foreach (var item in array)
            {
                result.Add(operation?.Invoke(item));
            }
            return result;
        }

    }
}
