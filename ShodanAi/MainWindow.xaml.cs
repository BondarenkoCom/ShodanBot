using ShodanAi.AbstractShodan;
using ShodanAi.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ShodanAi
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _telemetryTimer;
        private readonly DispatcherTimer _glitchTimer;
        private readonly Random _random = new();
        private readonly List<string> _glitchLines = new();
        private CancellationTokenSource? _typewriterCts;

        public MainWindow()
        {
            InitializeComponent();

            _telemetryTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3.6) };
            _telemetryTimer.Tick += TelemetryTimer_Tick;

            _glitchTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5.2) };
            _glitchTimer.Tick += GlitchTimer_Tick;

            ShodanDialog.Text = "// awaiting connection...";
            TelemetryTextBlock.Text = "CORES IN IDLE ORBIT.";
            GlitchTextBlock.Text = "[GLITCH] dormant.";
        }

        private async void StartShodan_Click(object sender, RoutedEventArgs e)
        {
            StartShodan.IsEnabled = false;
            AppendLog("» Initiating SHODAN boot hymn.");
            await BootSequenceAsync();
        }

        private async Task BootSequenceAsync()
        {
            InitializeAnimatedFace();

            _typewriterCts?.Cancel();
            _typewriterCts = new CancellationTokenSource();

            try
            {
                await RenderManifestAsync(_typewriterCts.Token);
            }
            catch (TaskCanceledException)
            {
                // Invocation interrupted by new request.
            }

            _telemetryTimer.Start();
            _glitchTimer.Start();

            AppendLog("» Voice conduits opening.");
            string initMessage = await InitShodan.InitShodanWelcome(ShodanDialogVoiceRecognition, recognitionStatusLabel, LogTextBlock);
            AppendLog($"» {initMessage}");

            StatusPulse.Text = "// domination channel stabilized.";
            TelemetryTextBlock.Text = ShodanLore.GetPulse(_random);
            ShodanDialogVoiceRecognition.Text = "VOICE VECTOR // STANDING BY.";

            PlayerSounds.PlayRandomFrom("Source/Sounds/Shodan24Bit");
        }

        private void InitializeAnimatedFace()
        {
            string gifPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Source", "imageShodan", "shodanFace.gif");

            if (File.Exists(gifPath))
            {
                AnimatedGif.Source = new Uri(gifPath);
                AnimatedGif.Position = TimeSpan.Zero;
                AnimatedGif.Play();
            }
            else
            {
                AppendLog("» Visual core asset missing.");
            }
        }

        private async Task RenderManifestAsync(CancellationToken cancellationToken)
        {
            ShodanDialog.Clear();

            foreach (string line in ShodanLore.BootManifest)
            {
                await TypeLineAsync(line, cancellationToken);
                await Task.Delay(TimeSpan.FromMilliseconds(_random.Next(260, 520)), cancellationToken);
            }
        }

        private async Task TypeLineAsync(string line, CancellationToken cancellationToken)
        {
            foreach (char glyph in line)
            {
                cancellationToken.ThrowIfCancellationRequested();

                await Dispatcher.InvokeAsync(() =>
                {
                    ShodanDialog.Text += glyph;
                    ShodanDialog.CaretIndex = ShodanDialog.Text.Length;
                }, DispatcherPriority.Background);

                await Task.Delay(TimeSpan.FromMilliseconds(_random.Next(18, 42)), cancellationToken);
            }

            await Dispatcher.InvokeAsync(() =>
            {
                ShodanDialog.Text += Environment.NewLine;
            }, DispatcherPriority.Background);
        }

        private void TelemetryTimer_Tick(object? sender, EventArgs e)
        {
            string pulse = ShodanLore.GetPulse(_random);
            TelemetryTextBlock.Text = pulse;
            StatusPulse.Text = $"// {pulse.ToLowerInvariant()}";
            ShodanDialogVoiceRecognition.Text = $"VOICE VECTOR @ {DateTime.Now:HH:mm:ss}";
        }

        private void GlitchTimer_Tick(object? sender, EventArgs e)
        {
            string glitch = ShodanLore.GetLog(_random);
            _glitchLines.Add($"[{DateTime.Now:HH:mm:ss}] {glitch}");

            if (_glitchLines.Count > 12)
            {
                _glitchLines.RemoveAt(0);
            }

            GlitchTextBlock.Text = string.Join(Environment.NewLine, _glitchLines);
        }

        private void AppendLog(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            if (LogTextBlock.Text.Length > 0)
            {
                LogTextBlock.Text += Environment.NewLine;
            }

            LogTextBlock.Text += $"[{timestamp}] {message}";

            if (LogTextBlock.Text.Length > 1200)
            {
                LogTextBlock.Text = LogTextBlock.Text[^1200..];
            }
        }

        private void AnimatedGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            AnimatedGif.Position = TimeSpan.Zero;
            AnimatedGif.Play();
        }

        public void ShodanDialog_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShodanDialog.ScrollToEnd();
        }
    }
}
