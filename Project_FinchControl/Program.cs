using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Olszewski, James
    // Dated Created: 2/17/2021
    // Last Modified: 2/28/2021
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing it up");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayDance(finchRobot);
                        break;

                    case "c":
                        TalentShowDisplayMixingItUp(finchRobot);
                        break;

                    case "d":

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>

        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                    Talent Show > Dance                        *
        /// *****************************************************************
        /// </summary>

        static void TalentShowDisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch robot will now show off its sweet moves!");
            DisplayContinuePrompt();

            finchRobot.setMotors(200, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 200);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, -200);
            finchRobot.wait(1000);
            finchRobot.setMotors(-200, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(200, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 200);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, -200);
            finchRobot.wait(1000);
            finchRobot.setMotors(-200, 0);
            finchRobot.wait(1000);

            // reset finch robot
            finchRobot.setMotors(0, 0);



            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// ****************************************************************
        /// *                Talent Show > Mixing it up                    *
        /// ****************************************************************
        /// </summary>

        static void TalentShowDisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing it Up");

            Console.WriteLine("\tThe Finch robot will now show off its sweet moves and glowing talent!");
            DisplayContinuePrompt();
            int motorSpeed;
            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                motorSpeed = lightSoundLevel - 128;
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
                finchRobot.setMotors(motorSpeed, -motorSpeed);
            }

            // reset finch robot
            finchRobot.setMotors(0, -0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        #endregion

        #region DATA RECORDER

        /// *****************************************************************
        /// *                    Data Recorder Menu                         *
        /// *****************************************************************

        private static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            finchRobot.connect();
            int numberOfDataPoints = 5;
            double dataPointFrequency = 1;
            double[] temperatures = new double[12];
            double[] lights = new double[12];
            Console.CursorVisible = true;
            bool exit = false;
            do
            {
                // get user menu choice

                Program.DisplayScreenHeader("Data Recorder Menu");
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Temperature Data");
                Console.WriteLine("\td) Get Light Data");
                Console.WriteLine("\te) Show Data");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\tEnter Choice:");
                string menuChoice = Console.ReadLine().ToLower();

                // process user menu choice

                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = Program.DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = Program.DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = Program.DataRecorderDisplayGetTempData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        lights = Program.DataRecorderDisplayGetLightData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "e":
                        Program.DataRecorderDisplayData(temperatures, lights);
                        break;

                    case "q":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        Program.DisplayContinuePrompt();
                        break;
                }
            }
            while (!exit);
        }

        /// ***************************************************************
        /// *          Data Recorder > Amount of Data Points              *
        /// ***************************************************************

        private static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int num;
            bool valid;
            do
            {
                Program.DisplayScreenHeader("Number of Data Points");
                Console.Write("\tEnter the number of data points to record:");
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tYou have entered: {num} Data Points");
                    valid = true;
                    Program.DisplayMenuPrompt("Data Recorder");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter an integer for the number of data points.");
                    valid = false;
                    Program.DisplayContinuePrompt();
                }

            }
            while (!valid);
            return num;
        }

        /// ****************************************************************
        /// *         Data Recorder > Frequency of Data Points             *
        /// ****************************************************************

        private static double DataRecorderDisplayGetDataPointFrequency()
        {
            double freq;
            bool valid;
            do
            {
                Program.DisplayScreenHeader("Data Point Frequency");
                Console.Write("\tEnter the number of seconds between recordings:");
                if (double.TryParse(Console.ReadLine(), out freq))
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tYou have entered: {freq} Dp/s");
                    valid = true;
                    Program.DisplayMenuPrompt("Data Recorder");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter an number for the number of seconds between recording.");
                    valid = false;
                    Program.DisplayContinuePrompt();
                }

            }
            while (!valid);
            return freq;
        }

        /// ****************************************************************
        /// *           Data Recorder > Get Temperature Data               *
        /// ****************************************************************

        private static double[] DataRecorderDisplayGetTempData(
          int numberOfDataPoints,
          double dataPointFrequency,
          Finch finchRobot)
        {
            double[] numArray = new double[numberOfDataPoints];
            Program.DisplayScreenHeader("GetTemperatures");
            Console.WriteLine(string.Format($"\tData Points: {(object)numberOfDataPoints}"));
            Console.WriteLine(string.Format($"\tFrequency: {(object)dataPointFrequency}"));
            Console.WriteLine();
            Console.WriteLine("\tThe Finch robot is now ready to gather the temperature data.");
            Program.DisplayContinuePrompt();
            Console.WriteLine("\tNow reading the Temperature...");
            for (int index = 0; index < numberOfDataPoints; ++index)
            {
                numArray[index] = DataRecorderConvertToFarenheit(finchRobot.getTemperature());
                int ms = (int)(dataPointFrequency * 1000.0);
                finchRobot.wait(ms);
                Console.WriteLine(string.Format($"\t{(object)(index + 1)}").PadLeft(10) + numArray[index].ToString("n2").PadLeft(10));
            }
            Program.DisplayMenuPrompt("Data Recorder");
            return numArray;
        }

        /// ****************************************************************
        /// *              Data Recorder > Get Light Data                  *
        /// ****************************************************************

        private static double[] DataRecorderDisplayGetLightData(
          int numberOfDataPoints,
          double dataPointFrequency,
          Finch finchRobot)
        {
            double[] lightArray = new double[numberOfDataPoints];
            Program.DisplayScreenHeader("Get Light Values");
            Console.WriteLine(string.Format($"\tData Points: {(object)numberOfDataPoints}"));
            Console.WriteLine(string.Format($"\tFrequency: {(object)dataPointFrequency}"));
            Console.WriteLine();
            Console.WriteLine("\tThe Finch robot is now ready to gather the light data.");
            Program.DisplayContinuePrompt();
            Console.WriteLine("\tNow detecting light levels...");
            for (int index = 0; index < numberOfDataPoints; ++index)
            {
                lightArray[index] = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor())/2;
                int ms = (int)(dataPointFrequency * 1000.0);
                finchRobot.wait(ms);
                Console.WriteLine(string.Format($"\t{(object)(index + 1)}").PadLeft(10) + lightArray[index].ToString("n2").PadLeft(10));
            }
            Program.DisplayMenuPrompt("Data Recorder");
            return lightArray;
        }
        /// ****************************************************************
        /// *                Data Recorder > Show Data                    *
        /// ****************************************************************

        private static void DataRecorderDisplayData(double[] temperatures, double[] lights)
        {
            Program.DisplayScreenHeader("Data");
            Program.DataRecorderDisplayDataTable(temperatures, lights);
            Program.DisplayMenuPrompt("Data Recorder");
        }

        /// ****************************************************************
        /// *             Data Recorder > Show Data > Table                *
        /// ****************************************************************

        private static void DataRecorderDisplayDataTable(double[] temperatures, double[] lights)
        {
            Program.DisplayScreenHeader("Light Levels and Temps");
            Console.WriteLine("\tReading #".PadLeft(10) + "Temp".PadLeft(10) + "Light".PadLeft(10));
            Console.WriteLine("\t---------".PadLeft(10) + "---------".PadLeft(10) + "---------".PadLeft(10));
            for (int index = 0; index < temperatures.Length; ++index)
                Console.WriteLine(string.Format("\t{0}", (object)(index + 1)).PadLeft(10) + temperatures[index].ToString("n2").PadLeft(10) + lights[index].ToString("n2").PadLeft(10));
        }

        /// *****************************************************************
        /// *            Data Recorder > Convert to Farenheit               *
        /// *****************************************************************

        private static double DataRecorderConvertToFarenheit(double temp)
        {
            temp = (temp * 9) / 5 + 32;
            return temp;
        }
        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}

