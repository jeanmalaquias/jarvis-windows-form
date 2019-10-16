using System;
using System.Linq;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace Jarvis
{
    public partial class Jarvis : Form
    {
        private SpeechRecognitionEngine engine;
        private bool isJarvisListening;
        public Jarvis()
        {
            InitializeComponent();
        }

        private void LoadSpeech()
        {
            try
            {
                engine = new SpeechRecognitionEngine();
                engine.SetInputToDefaultAudioDevice();

                Rules();

                string[] words = { "Hello", "Good Night" };
                engine.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(words))));
                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);
                engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(Level);

                engine.RecognizeAsync(RecognizeMode.Multiple);

                //Speaker.Speak("Hello Doctor Thomas, How can I help you today?");
                Speaker.Speak("Welcome to DeepHob");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error found LoadSpeech: " + ex.Message);
            }
        }
        private void Jarvis_Load(object sender, EventArgs e)
        {
            LoadSpeech();
        }

        private void rec(object obj, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            float config = e.Result.Confidence;

            if (GrammarRules.JarvisStopListening.Any(x => x == speech))
            {
                isJarvisListening = false;
            }
            else if (GrammarRules.JarvisStartListening.Any(x => x == speech))
            {
                isJarvisListening = true;
                Speaker.Speak("Hello Doctor", "Hello", "How Can I help you Doctor?", "What?");
            }

            if (isJarvisListening)
            {
                if (config > 0.35f)
                {
                    switch (e.Result.Grammar.Name)
                    {
                        case "Sys":
                            if (GrammarRules.WhatTime.Any(x => x == speech))
                            {
                                Runner.WhatTime();
                            }
                            else if (GrammarRules.WhatDate.Any(x => x == speech))
                            {
                                Runner.WhatDate();
                            }
                            else if (GrammarRules.MinimizeWindow.Any(x => x == speech))
                            {
                                MinimizeWindow();
                            }
                            else if (GrammarRules.MaximizeWindow.Any(x => x == speech))
                            {
                                MaximizeWindow();
                            }
                            break;
                        case "Calc":
                            Speaker.Speak(Calc.Solve(speech));
                            break;
                    }
                }
            }

        }

        private void Level(object obj, AudioLevelUpdatedEventArgs e)
        {
            AudioBar.Maximum = 100;
            AudioBar.Value = e.AudioLevel;
        }

        private void Rules()
        {

            Choices c_number = new Choices();
            for (int i = 0; i <= 100;)
            {
                c_number.Add(i.ToString());
                i++;
            }

            Choices c_commands = new Choices();
            c_commands.Add(GrammarRules.WhatTime.ToArray());
            c_commands.Add(GrammarRules.WhatDate.ToArray());
            c_commands.Add(GrammarRules.JarvisStartListening.ToArray());
            c_commands.Add(GrammarRules.JarvisStopListening.ToArray());
            c_commands.Add(GrammarRules.MinimizeWindow.ToArray());
            c_commands.Add(GrammarRules.MaximizeWindow.ToArray());


            GrammarBuilder gb_commands = new GrammarBuilder();
            gb_commands.Append(c_commands);

            GrammarBuilder gb_number = new GrammarBuilder();
            gb_number.Append(c_number);
            gb_number.Append(new Choices("times", "less", "plus", "divided"));
            gb_number.Append(c_number);

            Grammar g_command = new Grammar(gb_commands)
            {
                Name = "Sys"
            };

            Grammar g_number = new Grammar(gb_number)
            {
                Name = "Calc"
            };

            engine.LoadGrammar(g_command);
            engine.LoadGrammar(g_number);
        }

        private void MinimizeWindow()
        {
            if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
                Speaker.Speak("Minimizing", "That's ok", "Ok", "No problem", "Done", "See you");
            }
            else
            {
                Speaker.Speak("I'm sleeping", "I'm not here", "I've closed");
            }
        }

        private void MaximizeWindow()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                Speaker.Speak("Maximizing", "I'm back", "Hello Doctor", "I'm here", "How Can I help you Doctor?", "Do you need something?");
            }
            else
            {
                Speaker.Speak("I'm here already", "I'm here, can you see me?", "Hello Doctor, I'm here!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
