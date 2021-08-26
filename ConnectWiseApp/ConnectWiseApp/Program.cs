// ConnectWise Interview:
// Hands-On Test
// Hosted at: https://github.com/Xaeart/ConnectWise.git

// 1. Populate a string with the following input data (in this exact multi-line format):
// regex or streamreader...
// Streamreader seems simpler to execute atm:
using ConnectWiseApp;
using System;
using System.IO;
using System.Text.RegularExpressions;


class Test
{
    public static void Main()
    {
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            // endline regex 
            Regex rx = new Regex("[^\r\n]+");

            string path = @"C:\Users\Xaear\source\repos\ConnectWiseApp\ConnectWiseApp\Data\SampleInputFile.txt";
            string[] files = File.ReadAllLines(path);
            char[] delimiters = {' '};
            user user = new user();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                int i = 0;
                //Scan for empty lines, collecting previous lines
                while ((line = sr.ReadLine()) != null)
                {
                    while ((line = sr.ReadLine()) != "")
                    {
                        string[] words = line.Split(delimiters);
                        var user1 = parser(words, user);
                    }
                    

                }
                //Whenever I hit an empty line, parse everything collected up to that line
                //store info into user struct.
                //display user struct in proper output.
                //clear array
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        } 
    }

    private static object parser(string[] words, user user)
    {
        foreach(var word in words)
        {
            int i = 0;
            switch (word)
            {
                case "Age":
                    user.age = word[i+1];
                    break;
                case "Name":
                    user.age = word[i + 1];
                    break;
                case "Flags":
                    user.age = word[i + 1];
                    break;
            }
            
        }
        return user;
    }
}
