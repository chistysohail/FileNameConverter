using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Regular expression patterns to match various possible date formats
        string[] patterns = {
            @"\d{4}-\d{2}-\d{2}-\d{2}-\d{2}-\d{2}", // matches YYYY-MM-DD-HH-MM-SS
            @"\d{8}", // matches YYYYMMDD
            @"\d{4}"  // matches MMDD
        };

        string fileName1 = "frog hop long today (2023-04-20-22-45-09).csv";
        string fileName2 = "frog20230909.csv";
        string fileName3 = "frog0918";

        fileName1 = ReplaceDateWithAsterisk(fileName1, patterns);
        fileName2 = ReplaceDateWithAsterisk(fileName2, patterns);
        fileName3 = ReplaceDateWithAsterisk(fileName3, patterns);

        Console.WriteLine(fileName1); // Output will be: frog hop long today (*).csv
        Console.WriteLine(fileName2); // Output will be: frog*.csv
        Console.WriteLine(fileName3); // Output will be: frog*.csv
    }

    static string ReplaceDateWithAsterisk(string fileName, string[] patterns)
    {
        foreach (var pattern in patterns)
        {
            if (Regex.IsMatch(fileName, pattern))
            {
                fileName = Regex.Replace(fileName, pattern, "*");
                break; // exit the loop after the first successful replacement
            }
        }
        return fileName;
    }
}
