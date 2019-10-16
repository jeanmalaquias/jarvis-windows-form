using System.Collections.Generic;

namespace Jarvis
{
    public class GrammarRules
    {
        public static IList<string> WhatTime = new List<string>()
        {
            "Jarvis, What time is it?",
            "Jarvis, What time?",
            "Jarvis, what is the time?",
            "What time is it?",
            "Jarvis, what time is now?"
        };

        public static IList<string> WhatDate = new List<string>()
        {
            "Jarvis, what day is today?",
             "What day is today?",
            "Jarvis, Today is?",
            "Jarvis, what day?",
            "Jarvis, which day is today?"
        };

        public static IList<string> JarvisStopListening = new List<string>()
        {
            "Jarvis, stop",
            "Jarvis, please stop",
            "Jarvis, mute",
            "Jarvis, silence"
        };

        public static IList<string> JarvisStartListening = new List<string>()
        {
            "Jarvis, start",
           "Jarvis"
        };

        public static IList<string> MinimizeWindow = new List<string>()
        {
            "Jarvis, bye bye",
             "Jarvis, go to your bed",
            "Jarvis, It's time to sleep",
            "Good night Jervis",
            "Jarvis, close your window",
            "bye bye",
            "bye bye jervis"
        };

        public static IList<string> MaximizeWindow = new List<string>()
        {
            "Jarvis, wake",
             "Jarvis, wake up",
            "Jarvis, are you there?",
            "Jarvis, are you alive?",
            "Jarvis, come back"
        };
    }
}
