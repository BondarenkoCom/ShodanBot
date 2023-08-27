using ShodanAi.Settings;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ShodanAi.AbstractShodan
{
    internal class InitShodan
    {
        public static async Task InitShodanWelcome(TextBox debugTextBox, Label recognitionStatusLabel, TextBlock logTextBlock)
        {
            VoiceRecognitionBase voiceRecognition = new VoiceRecognitionBase(debugTextBox, recognitionStatusLabel, logTextBlock);
            await voiceRecognition.CheckerVoiceAsync();
        }
    }
}
