using System;
using log4net;

namespace Kliiko.Ui.Tests.Utils
{
    class Log
    {
        private static readonly ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void StartFeature(string feautureName)
        {
            Info("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
            Info(" ");
            Info("             " + feautureName);
            Info(" ");
            Info("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
        }
        public static void StartScenario (string scenarioName)
        {
            Info("*SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
            Info(" ");
            Info("             " + scenarioName );
            Info(" ");
            Info("*SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
        }
        
        public static void EndScenario(string scenarioName)
        {
            Info("XXXXXXXXXXXXXXXXXXXXXXX             " + "-E---N---D-" + "             XXXXXXXXXXXXXXXXXXXXXX");
            Info("X                                         scenarioName                                         ");
            Info("X");
            Info("X");
            Info("X");
        }

        public static void StartStep(string stepName)
        {
            Info("*STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP");
            Info(" ");
            Info(stepName);
            Info(" ");
            Info("*STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP STEP");
        }

        public static void Info(String message)
        {
            Logger.Info(message);

        }

        public static void Warn(String message)
        {
            Logger.Warn(message);

        }

        public static void Error(String message)
        {
            Logger.Error(message);

        }

    }
}
