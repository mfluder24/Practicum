using System;

namespace PracticalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter a number to convert to currency:");
                string amount = Console.ReadLine();
                amount = Convert.ToDecimal(amount).ToString();

                Console.WriteLine(DecimalToWords(amount));

                Console.ReadKey();

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

        }

        private static String DecimalToWords(string amount)
        {
            string dollars = amount, cents = "";
            int decimalPlace = amount.IndexOf(".");
            if (decimalPlace > 0 && Convert.ToDecimal(dollars) >= 2)
            {
                dollars = amount.Substring(0, decimalPlace);
                cents = amount.Substring(decimalPlace + 1);
                string msg = TranslateNumber(dollars) + " Dollars and " + TranslateNumber(cents) + " Cents.";
                return msg;
            }
            else if (decimalPlace > 0)
            {
                dollars = amount.Substring(0, decimalPlace);
                cents = amount.Substring(decimalPlace + 1);
                string msg = TranslateNumber(dollars) + " Dollar and " + TranslateNumber(cents) + " Cents.";
                return msg;
            }
            else if (Convert.ToDecimal(dollars) > 1)
            {
                string msg = TranslateNumber(dollars) + " Dollars.";
                return msg;
            }
            else
            {
                string msg = TranslateNumber(dollars) + " Dollar.";
                return msg;
            }
        }

        private static String TranslateNumber(string number)
        {
            string english = "";
            bool isDone = false;
            decimal decNum = Convert.ToDecimal(number);
            int digits = number.Length;
            int position = 0;
            string place = "";
            switch (digits)
            {
                case 1:
                    english = Ones(number);
                    isDone = true;
                    break;
                case 2:
                    english = Tens(number);
                    isDone = true;
                    break;
                case 3:
                    position = (digits % 3) + 1;
                    place = " Hundred ";
                    break;
                case 4:
                case 5:
                case 6:
                    position = (digits % 4) + 1;
                    place = " Thousand ";
                    break;
                default:
                    isDone = true;
                    break;
            }
            if (!isDone)
            {
                english = TranslateNumber(number.Substring(0, position)) + place + TranslateNumber(number.Substring(position));
            }
            return english.Trim();
        }

        private static String Ones(string number)
        {
            int digit = Convert.ToInt32(number);
            string word = "";
            switch (digit)
            {
                case 1:
                    word = "One";
                    break;
                case 2:
                    word = "Two";
                    break;
                case 3:
                    word = "Three";
                    break;
                case 4:
                    word = "Four";
                    break;
                case 5:
                    word = "Five";
                    break;
                case 6:
                    word = "Six";
                    break;
                case 7:
                    word = "Seven";
                    break;
                case 8:
                    word = "Eight";
                    break;
                case 9:
                    word = "Nine";
                    break;
            }
            return word;
        }

        private static String Tens(string number)
        {
            int digit = Convert.ToInt32(number);
            string word = "";
            switch (digit)
            {
                case 10:
                    word = "Ten";
                    break;
                case 11:
                    word = "Eleven";
                    break;
                case 12:
                    word = "Twelve";
                    break;
                case 13:
                    word = "Thirteen";
                    break;
                case 14:
                    word = "Fourteen";
                    break;
                case 15:
                    word = "Fifteen";
                    break;
                case 16:
                    word = "Sixteen";
                    break;
                case 17:
                    word = "Seventeen";
                    break;
                case 18:
                    word = "Eighteen";
                    break;
                case 19:
                    word = "Nineteen";
                    break;
                case 20:
                    word = "Twenty";
                    break;
                case 30:
                    word = "Thirty";
                    break;
                case 40:
                    word = "Forty";
                    break;
                case 50:
                    word = "Fifty";
                    break;
                case 60:
                    word = "Sixty";
                    break;
                case 70:
                    word = "Seventy";
                    break;
                case 80:
                    word = "Eighty";
                    break;
                case 90:
                    word = "Ninety";
                    break;
                default:
                    if (digit > 0)
                    {
                        word = Tens(number.Substring(0, 1) + "0") + " " + Ones(number.Substring(1));
                    }
                    break;
            }
            return word;
        }
    }
}
