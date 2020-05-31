using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyValidation
{
    public static class ValidateStringsWithRegex
    {
        public static bool ForQuestions(string toCheck)
        {
            Regex rx = new Regex(@"^[a-zA-Z0-9 ]+[?]+$");
            if (toCheck.Length > 2 && rx.IsMatch(toCheck))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ForStatements(string toCheck)
        {
            Regex rx = new Regex(@"^[a-zA-Z0-9 ]+$");
            if (toCheck.Length > 2 && rx.IsMatch(toCheck))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
