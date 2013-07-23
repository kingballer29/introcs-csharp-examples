using System;
using System.Text;
using System.Text.RegularExpressions;

namespace uifnt
{
   public class UIFNT
   {
      public static int PromptUnsignedInt(string prompt)
      {

         var digits = new StringBuilder(10, 100);
         Console.Write(prompt);
         // read digits only 
         while (true) {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
               break;

            if (key.Key == ConsoleKey.Backspace && digits.Length > 0) {
                  digits.Remove(digits.Length - 1, 1);
                  Console.Write("\b");
            }

            if (key.KeyChar >= '0' && key.KeyChar <= '9') {
               Console.Write(key.KeyChar);
               digits.Append(key.KeyChar);
            }
         }
         Console.WriteLine("Parsing " + digits.ToString());
         return int.Parse(digits.ToString());
      }

      public static String AcceptInput(Regex accept, Regex validate) {
         var inputChars = new StringBuilder(10, 100);
         while (true) {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter) {
               if (validate.IsMatch(inputChars.ToString()))
                  break;
            }
            else if (key.Key == ConsoleKey.Backspace) {
               if (inputChars.Length > 0) {
                  inputChars.Remove(inputChars.Length - 1, 1);
                  Console.Write("\b \b");
               }
            }
            else {
               inputChars.Append(key.KeyChar);
               if (accept.IsMatch(inputChars.ToString())) 
                  Console.Write(key.KeyChar);
               else
                  inputChars.Remove(inputChars.Length - 1, 1);
            } 
         }
         return inputChars.ToString();
      }

      public static int PromptInt(string prompt)
      {
         Console.Write(prompt);
         return int.Parse(AcceptInput(new Regex(@"^[\+-]?\d*$"), new Regex(@"^[\+-]?\d+$")));
      }

      public static decimal PromptDecimal(string prompt) {
         Console.Write(prompt);
         return decimal.Parse(AcceptInput(new Regex(@"^[\+-]?\d*(\.)?\d*$"), new Regex(@"^[\+-]?((\d*(\.)?\d+)|(\d+(\.)?\d*))$")));
      }
   }
}
