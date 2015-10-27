using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infotron.Parsing;

namespace Zeruda
{
    public class LinkAnalysis
    {

        public static int NumberOfParameters(string formula)
        {
            var fa = new FormulaAnalyzerExtension(formula);
            return fa.NParameters();
        }

        public static bool TypeofFinalParameter(string formula)
        {
            bool Has4 = LinkAnalysis.NumberOfParameters(formula) == 4;

            if (Has4)
            {
                var fa = new FormulaAnalyzerExtension(formula);
                return fa.TypeOfFinal();
            }
            else
            {
                throw new InvalidOperationException(formula + " does not have 4 parameters");
            }

        }

        public static List<string> ReturnLookups(string formula)
        {
            var fa = new FormulaAnalyzerExtension(formula);
            return fa.ReturnLookups();
        }
    }


    class App
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Felienne\Dropbox\TU Delft\Papers\2015\Link Paper\Lookups.csv");
            string file = @"C:\Users\Felienne\Dropbox\TU Delft\Papers\2015\Link Paper\Lookups-result.csv";
            File.WriteAllText(file, ""); //this empties the default file

            string fileError = @"C:\Users\Felienne\Dropbox\TU Delft\Papers\2015\Link Paper\Lookups-errors.csv";
            File.WriteAllText(fileError, ""); //this empties the errors file

            foreach (string line in lines)
            {
                string formula = line.Substring(3);
                formula = formula.Substring(0, formula.Length - 3);

                try
                {

                    int numParam = LinkAnalysis.NumberOfParameters(formula);
                    string type = "-";

                    if (numParam == 4)
                    {
                        type = LinkAnalysis.TypeofFinalParameter(formula).ToString();
                    }

                    using (StreamWriter sw = File.AppendText(file))
                    {
                        sw.WriteLine("\"" + formula + "\"," + numParam + "," + type);
                    }

                    Console.WriteLine(type);
                }
                catch (Exception E)
                {

                    using (StreamWriter sw = File.AppendText(fileError))
                    {
                        sw.WriteLine("\"" + formula + "\"," + E.Message + "," + E.InnerException);
                    }

                }

            }

            Console.WriteLine("Links analyzed");
            Console.ReadLine();
        }
    }
}
