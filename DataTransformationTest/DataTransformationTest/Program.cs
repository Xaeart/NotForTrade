// ConnectWise Interview:
// Hands-On Test
// Hosted at: https://github.com/Xaeart/ConnectWise.git

// 1. Populate a string with the following input data (in this exact multi-line format):
// regex or streamreader...
// Streamreader seems simpler to execute atm:
using System;
using System.IO;

class Test
{
    public static void Main()
    {
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("SampleInputFile.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}
    // At this point, `myInteger` and `path` contain the values we want
    // for the current line. We can then store those values or print them,
    // or anything else we like.
