using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    // Last Modified: 3/28/2021
    // Last Modified: 3/24/2021
    //
    // **************************************************

    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPERTURE,
        GETLIGHTLEVEL,
        GETTEMPLIGHT,
        NOTEON,
        NOTEOFF,
        LEDNOTEON,
        LEDNOTEOFF,
        DONE
    }

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
            DataDisplaySetTheme();
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
                Console.WriteLine("\tf) Change Theme");
                Console.WriteLine("\tg) Disconnect Finch Robot");
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
                        LightAlarmDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DataDisplaySetTheme();
                        break;

                    case "g":
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
                lightArray[index] = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor()) / 2;
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

        #region ALARM SYSTEM
        /// <summary>
        /// *****************************************************************
        /// *                     Alarm System Menu                         *
        /// *****************************************************************
        /// </summary>
        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool exit = false;
            string menuChoice;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThreshold = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Minimum/Maximum Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = AlarmSystemDisplayGetSensors();
                        break;

                    case "b":
                        rangeType = AlarmSystemDisplayGetRangeType();
                        break;

                    case "c":
                        minMaxThreshold = AlarmSystemDisplayGetThresholdValue(sensorsToMonitor, rangeType, finchRobot);
                        break;

                    case "d":
                        timeToMonitor = AlarmSystemDisplayGetTimeToMonitor();
                        break;

                    case "e":
                        AlarmSystemDisplaySetAlarm(finchRobot, rangeType, sensorsToMonitor, minMaxThreshold, timeToMonitor);
                        break;

                    case "q":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!exit);
        }

        static string AlarmSystemDisplayGetSensors()
        {
            string sensorsToMonitor = "";

            DisplayScreenHeader("Sensors to Monitor");

            Console.Write("\tEnter Which Sensor the Finch Should Monitor [left, right, both, temp, all]: ");
            sensorsToMonitor = Console.ReadLine();
            Console.Write($"\tThe Finch will monitor (the) {sensorsToMonitor} sensor(s).");

            DisplayMenuPrompt("Alarm System");
            return sensorsToMonitor;
        }

        static string AlarmSystemDisplayGetRangeType()
        {
            string rangeType = "";

            DisplayScreenHeader("Range Type");

            Console.Write("\tEnter Which Range Type to Set [minimum, maximum]: ");
            rangeType = Console.ReadLine();
            Console.Write($"\tThe Finch will stop recording once the {rangeType} threshold has been reached.");

            DisplayMenuPrompt("Alarm System");
            return rangeType;
        }

        static int AlarmSystemDisplayGetThresholdValue(string sensorsToMonitor, string rangeType, Finch finchRobot)
        {
            int thresholdValue = 0;

            int currentLeftSensorValue = finchRobot.getLeftLightSensor();
            int currentRightSensorValue = finchRobot.getRightLightSensor();
            double currentTempValue = finchRobot.getTemperature();

            DisplayScreenHeader("Threshold Value");

            switch (sensorsToMonitor)
            {
                case "left":
                    Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {currentLeftSensorValue}");
                    break;

                case "right":
                    Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {currentRightSensorValue}");
                    break;

                case "both":
                    Console.WriteLine($"\tLeft Sensor Value: {currentLeftSensorValue}");
                    Console.WriteLine($"\tRight Sensor Value: {currentRightSensorValue}");
                    break;

                case "temp":
                    Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {currentTempValue}");
                    break;

                case "all":
                    Console.WriteLine($"\tLeft Sensor Value: {currentLeftSensorValue}");
                    Console.WriteLine($"\tRight Sensor Value: {currentRightSensorValue}");
                    Console.WriteLine($"\tTemperature Sensor Value: {currentTempValue}");
                    break;

                default:
                    Console.WriteLine("\tUnknown Sensor Reference");
                    break;
            }

            Console.Write("\tEnter Threshold: ");
            int.TryParse(Console.ReadLine(), out thresholdValue);
            Console.Write($"\tThe Finch {rangeType} threshold has been set to {thresholdValue}.");

            DisplayMenuPrompt("Alarm System");
            return thresholdValue;
        }

        static int AlarmSystemDisplayGetTimeToMonitor()
        {
            int timeToMonitor = 0;

            DisplayScreenHeader("Time to Monitor");

            Console.Write("\tEnter How Long the Finch Should Be Monitoring For: ");
            int.TryParse(Console.ReadLine(), out timeToMonitor);
            Console.Write($"\tThe Finch will try to retrieve information {timeToMonitor} times.");

            DisplayMenuPrompt("Alarm System");
            return timeToMonitor;
        }

        private static void AlarmSystemDisplaySetAlarm(Finch finchRobot, string rangeType, string sensorsToMonitor, int minMaxThreshold, int timeToMonitor)
        {
            bool thresholdExceeded = false;
            bool tempThresExceeded = false;
            int secondsElapsed = 1;
            int leftLightSensorValue;
            int rightLightSensorValue;
            double tempSensorValue; ;

            DisplayScreenHeader("Set Alarm");
            Console.WriteLine("\tStart");
            Console.ReadKey();

            do
            {

                leftLightSensorValue = finchRobot.getLeftLightSensor();
                rightLightSensorValue = finchRobot.getRightLightSensor();
                tempSensorValue = finchRobot.getTemperature();
                switch (sensorsToMonitor)
                {
                    case "left":
                        Console.WriteLine($"\tCurrent Left{sensorsToMonitor} Sensor Value: {leftLightSensorValue}");
                        break;

                    case "right":
                        Console.WriteLine($"\tCurrent Right{sensorsToMonitor} Sensor Value: {rightLightSensorValue}");
                        break;

                    case "both":
                        Console.WriteLine($"\tCurrent Left {sensorsToMonitor} Sensor Value: {leftLightSensorValue}");
                        Console.WriteLine($"\tCurrent Right {sensorsToMonitor} Sensor Value: {rightLightSensorValue}");
                        break;

                    case "temp":
                        Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {tempSensorValue}");
                        break;

                    case "all":
                        Console.WriteLine($"\tCurrent Left {sensorsToMonitor} Sensor Value: {leftLightSensorValue}");
                        Console.WriteLine($"\tCurrent Right {sensorsToMonitor} Sensor Value: {rightLightSensorValue}");
                        Console.WriteLine($"\tCurrent {sensorsToMonitor} Sensor Value: {tempSensorValue}");
                        break;

                    default:
                        Console.WriteLine("\tUnknown Sensor Reference");
                        break;
                }

                finchRobot.wait(1000);
                secondsElapsed++;

                switch (sensorsToMonitor)
                {
                    case "left":
                        if (rangeType == "minimum")
                        {
                            thresholdExceeded = (leftLightSensorValue < minMaxThreshold);
                        }
                        else
                        {
                            thresholdExceeded = (leftLightSensorValue > minMaxThreshold);
                        }
                        break;

                    case "right":
                        if (rangeType == "minimum")
                        {
                            thresholdExceeded = (rightLightSensorValue < minMaxThreshold);
                        }
                        else
                        {
                            thresholdExceeded = (rightLightSensorValue > minMaxThreshold);
                        }
                        break;

                    case "both":
                        if (rangeType == "minimum")
                        {
                            if ((rightLightSensorValue < minMaxThreshold) || (leftLightSensorValue < minMaxThreshold))
                            {
                                thresholdExceeded = true;
                            }
                        }
                        else
                        {
                            if ((rightLightSensorValue > minMaxThreshold) || (leftLightSensorValue > minMaxThreshold))
                            {
                                thresholdExceeded = true;
                            }
                        }
                        break;

                    case "temp":
                        if (rangeType == "minimum")
                        {
                            tempThresExceeded = (tempSensorValue < minMaxThreshold);
                        }
                        else
                        {
                            tempThresExceeded = (tempSensorValue > minMaxThreshold);
                        }
                        break;

                    case "all":
                        if (rangeType == "minimum")
                        {
                            if ((rightLightSensorValue < minMaxThreshold) || (leftLightSensorValue < minMaxThreshold))
                            {
                                thresholdExceeded = true;
                            }
                            else if (tempSensorValue < minMaxThreshold)
                            {
                                tempThresExceeded = true;
                            }
                        }
                        else
                        {
                            if ((rightLightSensorValue > minMaxThreshold) || (leftLightSensorValue > minMaxThreshold))
                            {
                                thresholdExceeded = true;
                            }
                            else if (tempSensorValue > minMaxThreshold)
                            {
                                tempThresExceeded = true;
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("\tUnknown Sensor Reference");
                        break;
                }

            } while (!thresholdExceeded && !tempThresExceeded && (secondsElapsed <= timeToMonitor));

            Console.WriteLine();

            if (thresholdExceeded)
            {
                Console.WriteLine("\tLight Threshold Exceeded");
            }
            else if (tempThresExceeded)
            {
                Console.WriteLine("\tTemperature Threshold Exceeded");
            }
            else
            {
                Console.WriteLine("\tThreshold Not Exceeded - Time limit exceeded");
            }
            DisplayMenuPrompt("Alarm System");
        }

        #endregion

        #region USER PROGRAMMING

        /// <summary>
        /// *****************************************************************
        /// *                   User Programming Menu                       *
        /// *****************************************************************
        /// </summary>
        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool exit = false;
            string menuChoice;

            (int motorSpeed, int ledBrightness, int notePitch, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.notePitch = 0;
            commandParameters.waitSeconds = 0;
            List<(Command command, int duration)> commands = new List<(Command command, int duration)>();

            do
            {
                DisplayScreenHeader("User Programming Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        commandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "b":
                        commands = UserProgrammingDisplayGetFinchCommands();
                        break;

                    case "c":
                        UserProgrammingDisplayViewCommands(commands);
                        break;

                    case "d":
                        UserProgrammingDisplayExecuteCommands(finchRobot, commands, commandParameters);
                        break;

                    case "q":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!exit);
        }

        static (int motorSpeed, int ledBrightness, int notePitch, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
            (int motorSpeed, int ledBrightness, int notePitch, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.notePitch = 0;
            commandParameters.waitSeconds = 0;
            int num;
            bool valid = false;
            DisplayScreenHeader("Command Parameters");
            Console.WriteLine("All values have been reset to zero.");
            do
            {
                Console.Write("Motor Speed: ");
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tYou have entered: {num} For the Motor Speed.");
                    commandParameters.motorSpeed = num;
                    valid = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter an integer for the Motor Speed.");
                    Program.DisplayContinuePrompt();
                }

            } while (valid == false);
            valid = false;
            do
            {
                Console.Write("LED Brightness: ");
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tYou have entered: {num} For the LED Brightness.");
                    commandParameters.ledBrightness = num;
                    valid = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter an integer for the LED Brightness.");
                    Program.DisplayContinuePrompt();
                }

            } while (valid == false);
            valid = false;
            do
            {
                Console.Write("Note Pitch: ");
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tYou have entered: {num} For the Note Pitch.");
                    commandParameters.notePitch = num;
                    valid = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter an integer for the Note Pitch.");
                    Program.DisplayContinuePrompt();
                }

            } while (valid == false);
            valid = false;
            do
            {
                Console.Write("Wait Time: ");
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine();
                    Console.WriteLine($"\tYou have entered: {num} For the Wait Time.");
                    commandParameters.waitSeconds = num;
                    valid = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter an integer for the Wait Time.");
                    Program.DisplayContinuePrompt();
                }

            } while (valid == false);
            return commandParameters;
        }

        static List<(Command command, int duration)> UserProgrammingDisplayGetFinchCommands()
        {
            List<(Command command, int duration)> commands = new List<(Command command, int duration)>();
            bool isDone = false;
            string userResponse;
            string userDuration;

            DisplayScreenHeader("User Commands");

            foreach (var enumValue in Enum.GetValues(typeof(Command)))
            {
                Console.WriteLine(enumValue);
            }

            do
            {
                Console.WriteLine();
                Console.Write("Command: ");
                userResponse = Console.ReadLine();
                Console.Write("Duration: ");
                userDuration = Console.ReadLine();
                if (userResponse != "DONE")
                {
                    if (Enum.TryParse(userResponse.ToUpper(), out Command command) && int.TryParse(userDuration, out int duration))
                    {
                        commands.Add((command, duration));

                    }
                    else
                    {
                        Console.WriteLine("\tPlease enter a proper command and proper interval for duration.");
                    }
                }
                else
                {
                    isDone = true;
                }

            } while (!isDone);

            DisplayContinuePrompt();

            return commands;
        }

        static void UserProgrammingDisplayViewCommands(List<(Command command, int duration)> commands)
        {
            DisplayScreenHeader("View Commands");

            Console.WriteLine("\tCommand List");
            Console.WriteLine("\t------------");

            foreach ((Command command, int duration) in commands)
            {
                Console.WriteLine("\t" + command + " for " + duration);
            }

            DisplayContinuePrompt();
        }

        private static void UserProgrammingDisplayExecuteCommands(Finch finchRobot, List<(Command command, int duration)> commands, (int motorSpeed, int ledBrightness, int notePitch, double waitSeconds) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int notePitch = commandParameters.notePitch = 0;
            double waitSeconds = commandParameters.waitSeconds;
            int waitMilliseconds = (int)(waitSeconds * 1000);
            int waitDuration;
            DisplayScreenHeader("Execute Commands");

            Console.WriteLine("\tThe Finch robot will not execute all commands.");
            foreach ((Command command, int duration) in commands)
            {
                waitDuration = (int)(duration * 1000);
                switch (command)
                {
                    case Command.NONE:
                        Console.WriteLine();
                        Console.WriteLine("\tDefault Value Error");
                        Console.WriteLine();
                        break;
                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        break;
                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        break;
                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        break;
                    case Command.WAIT:
                        finchRobot.wait(waitMilliseconds);
                        break;
                    case Command.TURNRIGHT:
                        finchRobot.setMotors(-motorSpeed, motorSpeed);
                        break;
                    case Command.TURNLEFT:
                        finchRobot.setMotors(motorSpeed, -motorSpeed);
                        break;
                    case Command.LEDON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        break;
                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        break;
                    case Command.GETTEMPERTURE:
                        Console.WriteLine($"\tTemperture: {finchRobot.getTemperature()}");
                        break;
                    case Command.GETLIGHTLEVEL:
                        Console.WriteLine($"\tLight Level: {(finchRobot.getLeftLightSensor() + finchRobot.getLeftLightSensor()) / 2}");
                        break;
                    case Command.GETTEMPLIGHT:
                        Console.WriteLine($"\tTemperture: {finchRobot.getTemperature()}");
                        Console.WriteLine($"\tLight Level: {(finchRobot.getLeftLightSensor() + finchRobot.getLeftLightSensor()) / 2}");
                        break;
                    case Command.NOTEON:
                        finchRobot.noteOn(notePitch * 100);
                        break;
                    case Command.NOTEOFF:
                        finchRobot.noteOff();
                        break;
                    case Command.LEDNOTEON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        finchRobot.noteOn(notePitch * 100);
                        break;
                    case Command.LEDNOTEOFF:
                        finchRobot.setLED(0, 0, 0);
                        finchRobot.noteOff();
                        break;
                    case Command.DONE:
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tUnknown Command Error");
                        Console.WriteLine();
                        break;
                }
                finchRobot.wait(waitDuration);
                Console.WriteLine($"\tCommand; {command}");
            }
            DisplayContinuePrompt();
        }

        #endregion

        #region File I/O

        /// <summary>
        /// *****************************************************************
        /// *               File I/O Menu (Console Color)                   *
        /// *****************************************************************
        /// </summary>

        static (ConsoleColor foregroundColor, ConsoleColor backgroundColor) ReadThemeData()
        {
            string dataPath = @"Data/Theme.txt";
            string[] themeColors;

            ConsoleColor foregroundColor;
            ConsoleColor backgroundColor;

            themeColors = File.ReadAllLines(dataPath);

            Enum.TryParse(themeColors[0], true, out foregroundColor);
            Enum.TryParse(themeColors[1], true, out backgroundColor);

            return (foregroundColor, backgroundColor);
        }

        static void WriteThemeData(ConsoleColor foreground, ConsoleColor background)
        {
            string dataPath = @"Data/Theme.txt";

            File.WriteAllText(dataPath, foreground.ToString() + "\n");
            File.AppendAllText(dataPath, background.ToString());
        }

        static ConsoleColor GetConsoleColorFromUser(string property)
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;
            do
            {
                Console.Write($"\tEnter a value for the {property}:");
                validConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine(), true, out consoleColor);

                if (!validConsoleColor)
                {
                    Console.WriteLine("\n\t*** It would seem that you did not provide a valid console color. Please try again. ***\n");
                }
                else
                {
                    validConsoleColor = true;
                }
            } while (!validConsoleColor);

            return consoleColor;
        }

        static void DataDisplaySetTheme()
        {
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            bool themeChosen = false;

            themeColors = ReadThemeData();
            Console.ForegroundColor = themeColors.foregroundColor;
            Console.BackgroundColor = themeColors.backgroundColor;
            Console.Clear();
            DisplayScreenHeader("Set Application Theme");

            Console.WriteLine($"\tCurrent foreground color: {Console.ForegroundColor}");
            Console.WriteLine($"\tCurrent background color: {Console.BackgroundColor}");
            Console.WriteLine();

            Console.Write("\tWould you like to change the current theme (yes/no)?: ");
            if (Console.ReadLine().ToLower() == "yes")
            {
                do
                {
                    themeColors.foregroundColor = GetConsoleColorFromUser("foreground");
                    themeColors.backgroundColor = GetConsoleColorFromUser("background");

                    Console.ForegroundColor = themeColors.foregroundColor;
                    Console.BackgroundColor = themeColors.backgroundColor;
                    Console.Clear();
                    DisplayScreenHeader("Set Application Theme");
                    Console.WriteLine($"\tNew foreground color: {Console.ForegroundColor}");
                    Console.WriteLine($"\tNew background color: {Console.BackgroundColor}");

                    Console.WriteLine();
                    Console.Write("\tIs this how you would like your theme (yes/no)?: ");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        themeChosen = true;
                        WriteThemeData(themeColors.foregroundColor, themeColors.backgroundColor);
                    }

                } while (!themeChosen);
            }
            DisplayContinuePrompt();
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

