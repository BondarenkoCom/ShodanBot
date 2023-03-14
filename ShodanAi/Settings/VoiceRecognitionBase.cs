using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using ShodanAi.AbstractShodan;
using System.Windows.Controls;
using System.Windows;
using System.Threading;

namespace ShodanAi.Settings
{
    public class VoiceRecognitionBase
    {

        public static string CheckerVoice()
        {

            string mesAnswer = "Init Shodan Voice Recognition Module";

            using (
            SpeechRecognitionEngine recognizer =
            new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US")))
            {
                recognizer.LoadGrammar(new DictationGrammar());
            
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                recognizer.SetInputToDefaultAudioDevice();

                recognizer.RecognizeAsync(RecognizeMode.Multiple);

               while (true)
               {
                    //ShodanDialogVoiceRecognition.Text = "Init Shodan Voice Recognition Module";
                    Thread.Sleep(9000);
                    return mesAnswer;

                   //Console.ReadLine();
               }
            }

            static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {

                if (e.Result.Text == "hello" || e.Result.Text == "nice" || e.Result.Text == "hi" || e.Result.Text == "high")
                {

                    Shodan newHacker = new NewHacker("Edward Diego", @"..\..\..\Sounds\Shodan24Bit\ShodanBit.wav");

                    newHacker.WelcomeHacker();
                }

               // Console.WriteLine("Recognized text: " + e.Result.Text);
            }
        }
    }
}

