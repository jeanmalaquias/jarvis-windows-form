using System;
using System.Speech.Synthesis;

namespace Jarvis
{
    public class Speaker
    {
        private static SpeechSynthesizer sp = new SpeechSynthesizer();
        public static void Speak(string text)
        {
            if (sp.State == SynthesizerState.Speaking)
            {
                sp.SpeakAsyncCancelAll();
            }

            sp.SpeakAsync(text);
        }

        public static void Speak(params string[] texts)
        {
            Random rd = new Random();
            Speak(texts[rd.Next(0, texts.Length)]);
        }
    }
}
