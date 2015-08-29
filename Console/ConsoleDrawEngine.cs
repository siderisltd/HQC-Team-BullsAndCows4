namespace ConsoleUtills
{
    using System;
    using System.IO;

    public class ConsoleDrawEngine
    {
        public static void DrawSplashScreen(string pathToTxtSplashScreenFile)
        {
            StreamReader splashScreen = new StreamReader(pathToTxtSplashScreenFile);
            string line = string.Empty;
            using (splashScreen)
            {
                line = splashScreen.ReadLine();

                while (line != null)
                {
                    Console.WriteLine("{0}{1}", string.Empty.PadLeft(70), line);
                    line = splashScreen.ReadLine();
                }
            }
        }
    }
}
