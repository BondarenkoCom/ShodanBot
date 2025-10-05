using System;
using System.Threading.Tasks;
using System.Speech.Recognition;
using ShodanAi.AbstractShodan;
using System.Windows.Controls;

namespace ShodanAi.Settings
{
    public class VoiceRecognitionBase
    {
        private TextBox debugTextBox;
        private Label recognitionStatusLabel;
        private TextBlock logTextBlock;
        private SpeechRecognitionEngine recognizer;

        public VoiceRecognitionBase(TextBox debugTextBox, Label recognitionStatusLabel, TextBlock logTextBlock)
        {
            this.debugTextBox = debugTextBox;
            this.recognitionStatusLabel = recognitionStatusLabel;
            this.logTextBlock = logTextBlock;

            // Initialize the SpeechRecognitionEngine
            recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            recognizer.LoadGrammar(new DictationGrammar());
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognizer_SpeechDetected);
            recognizer.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(recognizer_SpeechRecognitionRejected);
            recognizer.AudioStateChanged += new EventHandler<AudioStateChangedEventArgs>(recognizer_AudioStateChanged);
            recognizer.SetInputToDefaultAudioDevice();
        }

        public async Task<string> CheckerVoiceAsync()
        {
            string mesAnswer = "VOICE CONDUITS ONLINE // awaiting worship.";
            await Task.Run(() =>
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                debugTextBox.Dispatcher.Invoke(() =>
                {
                    debugTextBox.Text = mesAnswer;
                });
            });
            return mesAnswer;
        }

        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            debugTextBox.Dispatcher.Invoke(() =>
            {
                debugTextBox.Text = "Recognized text: " + e.Result.Text;
            });

            string normalized = e.Result.Text.ToLowerInvariant();

            if (normalized == "hello" || normalized == "nice" || normalized == "hi" || normalized == "high" || normalized.Contains("shodan"))
            {
                Shodan newHacker = new NewHacker("Edward Diego", "Source/Sounds/Shodan24Bit/ShodanBit.wav");

                newHacker.WelcomeHacker();
                newHacker.WelcomeHacker_Text();

                PlayerSounds.PlayRandomFrom("Source/Sounds/Shodan");
            }

            recognitionStatusLabel.Dispatcher.Invoke(() =>
            {
                recognitionStatusLabel.Content = "Recognition Status: Speech Recognized";
            });

            logTextBlock.Dispatcher.Invoke(() =>
            {
                logTextBlock.Text += $"Recognized text: {e.Result.Text}\n";
                if (logTextBlock.Text.Length > 600)
                {
                    logTextBlock.Text = logTextBlock.Text[^600..];
                }
            });
        }

        private void recognizer_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            recognitionStatusLabel.Dispatcher.Invoke(() =>
            {
                recognitionStatusLabel.Content = "Recognition Status: Speech Detected";
            });
        }

        private void recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            recognitionStatusLabel.Dispatcher.Invoke(() =>
            {
                recognitionStatusLabel.Content = "Recognition Status: Speech Rejected";
            });
        }

        private void recognizer_AudioStateChanged(object sender, AudioStateChangedEventArgs e)
        {
            recognitionStatusLabel.Dispatcher.Invoke(() =>
            {
                recognitionStatusLabel.Content = $"Audio State: {e.AudioState}";
                if (e.AudioState == AudioState.Stopped)
                {
                    // Действия при остановке распознавания
                }
            });
        }
    }
}
