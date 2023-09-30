using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Alias
{
    public partial class AliasGameWindow : Window
    {
        int score = 0;
        int questionNumber = 1;

        List<string> words = new List<string>();
        Random rand = new Random();

        DispatcherTimer _timer;
        TimeSpan _time;

        public AliasGameWindow()
        {
            _time = TimeSpan.FromSeconds(60);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = "0" + _time.Minutes + ":";
                tbTime.Text += _time.Seconds > 9 ? string.Empty : "0";
                tbTime.Text += _time.Seconds;
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    MessageBox.Show($"You've got {score} score. Thanks for the game.");
                    var window = new MainWindow();
                    window.Show();
                    Close();
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
            InitializeComponent();

            quiz.Content = "WORD #" + questionNumber;
            FillList(words);

            int id = rand.Next(0, words.Count);
            question.Content = words[id];
            words.Remove(words[id]);
        }

        private void LossButton_Click(object sender, RoutedEventArgs e)
        {
            score = score > 0 ? score - 1 : score;
            WordGeneration();
        }

        private void WinButton_Click(object sender, RoutedEventArgs e)
        {
            score++;
            WordGeneration();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            Close();
            window.Show();
        }
        private void FillList(List<string> words)
        {
            words.Add("Reflection");
            words.Add("Success");
            words.Add("Air");
            words.Add("Mile");
            words.Add("System");
            words.Add("Half");
            words.Add("Reason");
            words.Add("Position");
            words.Add("Time");
            words.Add("Heat");
            words.Add("Break");
            words.Add("End");
            words.Add("Sun");
            words.Add("General");
            words.Add("Give");
            words.Add("Site");
            words.Add("Fact");
            words.Add("Tommorow");
            words.Add("Mind");
            words.Add("Student");
            words.Add("Mouth");
            words.Add("Contact");
            words.Add("Button");
            words.Add("Die");
            words.Add("Part");
            words.Add("Warm");
            words.Add("Education");
            words.Add("Second");
        }
        private void WordGeneration()
        {
            int id = rand.Next(0, words.Count);
            question.Content = words[id];
            words.Remove(words[id]);
            quiz.Content = "WORD #" + ++questionNumber;
            scoreText.Content = "SCORE: " + score;
        }
    }
}
