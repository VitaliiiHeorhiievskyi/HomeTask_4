using HomeTask1;
using System;
using System.Collections.Generic;
using System.IO;

namespace HomeTask2
{

    class Program
    {
        static void Main(string[] args)
        {

            try
            {
            //D:/Users/vital/source/repos/HomeTask2/input.txt

             Storage storage = new Storage();

                var Input = new InputStorageFromConsole();

                Input.StartStorage(storage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nEnd program\n");
            }

        }
    }
}
