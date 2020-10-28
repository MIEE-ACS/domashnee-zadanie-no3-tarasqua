using System;
using System.Windows;
using System.Windows.Media;

namespace HomeWork_3
{
    public partial class MainWindow : Window
    {
        static Random rand = new Random();
        public int x = rand.Next(-50, 50);
        public int y = rand.Next(-50, 50);
        public int counterOfTrueAns = 0;
        public int counterOfAns = 0;
        public int counterOfFalseAns = 0;
        public int key = 0;

        public void switchCases(int key)
        {
            int x1 = x + y - rand.Next(1, 20);
            int x2 = x + y + rand.Next(1, 20);
            int x3 = x + y - rand.Next(1, 20);

            if (x1 == x2)
            {
                x2 = x + y - rand.Next(1, 20);
            }
            else if (x2 == x3)
            {
                x3 = x + y + rand.Next(1, 20);
            }
            else if (x1 == x3)
            {
                x1 = x + y + rand.Next(1, 20);
            }
            else if (x1 == x2 && x2 == x3)
            {
                x1 = x + y + rand.Next(1, 20);
                x2 = x + y - rand.Next(1, 20);
            }

            switch (key)
            {
                case 1:
                    tb_sw1.Text = $"1.  {x + y}";
                    tb_sw2.Text = $"2.  {x1}";
                    tb_sw3.Text = $"3.  {x2}";
                    tb_sw4.Text = $"4.  {x3}";
                    break;
                case 2:
                    tb_sw1.Text = $"1.  {x1}";
                    tb_sw2.Text = $"2.  {x + y}";
                    tb_sw3.Text = $"3.  {x2}";
                    tb_sw4.Text = $"4.  {x3}";
                    break;
                case 3:
                    tb_sw1.Text = $"1.  {x1}";
                    tb_sw2.Text = $"2.  {x2}";
                    tb_sw3.Text = $"3.  {x + y}";
                    tb_sw4.Text = $"4.  {x3}";
                    break;
                case 4:
                    tb_sw1.Text = $"1.  {x1}";
                    tb_sw2.Text = $"2.  {x2}";
                    tb_sw3.Text = $"3.  {x3}";
                    tb_sw4.Text = $"4.  {x + y}";
                    break;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startBtn_Click_1(object sender, RoutedEventArgs e)
        {
            label_correct.Content = "";
            label_trueAnswer.Content = "";

            checkBtn.IsEnabled = true;
            mainMenu.Background = new LinearGradientBrush(Colors.LightBlue, Colors.SlateBlue, 90);
            tb_countOfCorrectAns.Visibility = Visibility.Visible;
            tb_countOfFalseAns.Visibility = Visibility.Visible;
            tb_countOfCorrectAns.Text = $"{counterOfTrueAns}";
            tb_countOfFalseAns.Text = $"{counterOfFalseAns}";
            tb_countOfFalseAns.Background = Brushes.DarkOrange;
            tb_countOfCorrectAns.Background = Brushes.LightGreen;

            if (y < 0) { tb_sum.Text = $"{x}{y} = ?"; }
            else { tb_sum.Text = $"{x}+{y} = ?"; }
            key = rand.Next(1, 4);
            switchCases(key);

            startBtn.IsEnabled = false;
            startBtn.Visibility = Visibility.Hidden;
            label_click.Visibility = Visibility.Hidden;

            checkBtn.Visibility = Visibility.Visible;
            tb_sum.Visibility = Visibility.Visible;
            label_chooseTrueAns.Visibility = Visibility.Visible;
            switch1.Visibility = Visibility.Visible;
            tb_sw1.Visibility = Visibility.Visible;
            switch2.Visibility = Visibility.Visible;
            tb_sw2.Visibility = Visibility.Visible;
            switch3.Visibility = Visibility.Visible;
            tb_sw3.Visibility = Visibility.Visible;
            switch4.Visibility = Visibility.Visible;
            tb_sw4.Visibility = Visibility.Visible;
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {

            if (key == 1 && switch1.IsChecked == true)
            {
                counterOfTrueAns++;
                tb_countOfCorrectAns.Text = $"{counterOfTrueAns}";
                label_correct.Content = "Верно!";
                label_trueAnswer.Visibility = Visibility.Hidden;
                switch1.IsChecked = false;

            }
            else if (key == 2 && switch2.IsChecked == true)
            {
                counterOfTrueAns++;
                tb_countOfCorrectAns.Text = $"{counterOfTrueAns}";
                label_correct.Content = "Верно!";
                label_trueAnswer.Visibility = Visibility.Hidden;
                switch2.IsChecked = false;
            }
            else if (key == 3 && switch3.IsChecked == true)
            {
                counterOfTrueAns++;
                tb_countOfCorrectAns.Text = $"{counterOfTrueAns}";
                label_correct.Content = "Верно!";
                label_trueAnswer.Visibility = Visibility.Hidden;
                switch3.IsChecked = false;
            }
            else if (key == 4 && switch4.IsChecked == true)
            {
                counterOfTrueAns++;
                tb_countOfCorrectAns.Text = $"{counterOfTrueAns}";
                label_correct.Content = "Верно!";
                label_trueAnswer.Visibility = Visibility.Hidden;
                switch4.IsChecked = false;
            }
            else
            {
                counterOfFalseAns++;
                tb_countOfFalseAns.Text = $"{counterOfFalseAns}";
                label_correct.Content = "Ошибка!";
                if (y < 0) { label_trueAnswer.Content = $"Правильный ответ: {key}. {x}{y} = {x + y}"; }
                else { label_trueAnswer.Content = $"Правильный ответ: {key}. {x}+{y} = {x + y}"; }
                label_trueAnswer.Visibility = Visibility.Visible;

                switch1.IsChecked = false;
                switch2.IsChecked = false;
                switch3.IsChecked = false;
                switch4.IsChecked = false;
            }
            counterOfAns++;

            x = rand.Next(-50, 50);
            y = rand.Next(-50, 50);
            if (y < 0) { tb_sum.Text = $"{x}{y} = ?"; }
            else { tb_sum.Text = $"{x}+{y} = ?"; }
            key = rand.Next(1, 4);
            switchCases(key);

            if (counterOfAns == 5)
            {
                checkBtn.IsEnabled = false;
                switch (counterOfTrueAns)
                {
                    case 0:
                        mainMenu.Background = new LinearGradientBrush(Colors.Red, Colors.DarkRed, 90);
                        MessageBox.Show($"Твоя оценка: 0 \nПопробуй еще раз!");
                        break;
                    case 1:
                        mainMenu.Background = new LinearGradientBrush(Colors.OrangeRed, Colors.DarkOrange, 90);
                        MessageBox.Show($"Твоя оценка: 1 \nТы можешь лучше!");
                        break;
                    case 2:
                        mainMenu.Background = new LinearGradientBrush(Colors.Orange, Colors.DarkOrange, 90);
                        MessageBox.Show($"Твоя оценка: 2 \n2 - тоже оценка!");
                        break;
                    case 3:
                        mainMenu.Background = new LinearGradientBrush(Colors.LightYellow, Colors.Yellow, 90);
                        MessageBox.Show($"Твоя оценка: 3 \nНе так уж и плохо!");
                        break;
                    case 4:
                        mainMenu.Background = new LinearGradientBrush(Colors.YellowGreen, Colors.Green, 90);
                        MessageBox.Show($"Твоя оценка: 4 \nЭто хорошо!");
                        break;
                    case 5:
                        mainMenu.Background = new LinearGradientBrush(Colors.LightGreen, Colors.Green, 90);
                        MessageBox.Show($"Твоя оценка: 5 \nМолодец!");
                        break;
                }

                startBtn.Content = "Новый тест";
                startBtn.IsEnabled = true;
                startBtn.Visibility = Visibility.Visible;

                counterOfAns = 0;
                counterOfTrueAns = 0;
                counterOfFalseAns = 0;
            }
        }
    }
}
