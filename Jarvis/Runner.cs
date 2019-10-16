using System;

namespace Jarvis
{
    public class Runner
    {

        public static void WhatTime()
        {
            Speaker.Speak(DateTime.Now.ToShortTimeString());
        }

        public static void WhatDate()
        {
            Speaker.Speak(DateTime.Now.DayOfWeek.ToString());
            Speaker.Speak(DateTime.Now.ToShortDateString());
        }
    }
}
