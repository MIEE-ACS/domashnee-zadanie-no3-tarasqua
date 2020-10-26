using System;
using System.Windows;
using System.Drawing;
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
            switch (key)
            {
                case 1:
                    tb_sw1.Text = $"1.  {x + y}";
                    tb_sw2.Text = $"2.  {x + y - rand.Next(1, 10)}";
                    tb_sw3.Text = $"3.  {x + y + rand.Next(1, 10)}";
                    tb_sw4.Text = $"4.  {x + y - rand.Next(1, 10)}";
                    break;
                case 2:
                    tb_sw1.Text = $"1.  {x + y - rand.Next(1, 10)}";
                    tb_sw2.Text = $"2.  {x + y}";
                    tb_sw3.Text = $"3.  {x + y + rand.Next(1, 10)}";
                    tb_sw4.Text = $"4.  {x + y - rand.Next(1, 10)}";
                    break;
                case 3:
                    tb_sw1.Text = $"1.  {x + y + rand.Next(1, 10)}";
                    tb_sw2.Text = $"2.  {x + y - rand.Next(1, 10)}";
                    tb_sw3.Text = $"3.  {x + y}";
                    tb_sw4.Text = $"4.  {x + y - rand.Next(1, 10)}";
                    break;
                case 4:
                    tb_sw1.Text = $"1.  {x + y + rand.Next(1, 10)}";
                    tb_sw2.Text = $"2.  {x + y - rand.Next(1, 10)}";
                    tb_sw3.Text = $"3.  {x + y + rand.Next(1, 10)}";
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
            if (y < 0) { tb_sum.Text = $"{x}{y} = ?"; }
            else { tb_sum.Text = $"{x}+{y} = ?"; }
            key = rand.Next(1, 4);
            switchCases(key);
            startBtn.IsEnabled = false;
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {

            if (key == 1 && switch1.IsChecked == true)
            {
                counterOfTrueAns++;
                tb_countOfCorrectAns.Text = $"{counterOfTrueAns}";
                label_correct.Content = "Верно!";
                label_trueAnswer.Visibility = Visibility.Hidden;

            }
            else if (key == 2 && switch2.IsChecked == true)
            {
                counterOfTrueAns++;
                tb_countOfCorrectAns.Text = $"{counterOfTrueAns}";
                label_correct.Content = "Верно!";
                label_trueAnswer.Visibility = Visibility.Hidden;
            }
            else if (key == 3 && switch3.IsChecked == true)
            {
                counterOfTrueAns++;
                tb_countOfCorrectAns.Text = $"{counterOfTrueAns}";
                label_correct.Content = "Верно!";
                label_trueAnswer.Visibility = Visibility.Hidden;
            }
            else if (key == 4 && switch4.IsChecked == true)
            {
                counterOfTrueAns++;
                tb_countOfCorrectAns.Text = $"{counterOfTrueAns}";
                label_correct.Content = "Верно!";
                label_trueAnswer.Visibility = Visibility.Hidden;
            }
            else
            {
                counterOfFalseAns++;
                tb_countOfFalseAns.Text = $"{counterOfFalseAns}";
                label_correct.Content = "Ошибка!";
                if (y < 0) { label_trueAnswer.Content = $"Правильный ответ: {key}. {x}{y} = {x + y}"; }
                else { label_trueAnswer.Content = $"Правильный ответ: {key}. {x}+{y} = {x + y}"; }
                label_trueAnswer.Visibility = Visibility.Visible;
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
                        mainMenu.Background = Brushes.Red;
                        MessageBox.Show($"Твоя оценка: 0 \nПопробуй еще раз!");
                        break;
                    case 1:
                        mainMenu.Background = Brushes.OrangeRed;
                        MessageBox.Show($"Твоя оценка: 1 \nТы можешь лучше!");
                        break;
                    case 2:
                        mainMenu.Background = Brushes.Orange;
                        MessageBox.Show($"Твоя оценка: 2 \n2 - тоже оценка!");
                        break;
                    case 3:
                        mainMenu.Background = Brushes.Yellow;
                        MessageBox.Show($"Твоя оценка: 3 \nНе так уж и плохо!");
                        break;
                    case 4:
                        mainMenu.Background = Brushes.YellowGreen;
                        MessageBox.Show($"Твоя оценка: 4 \nЭто хорошо!");
                        break;
                    case 5:
                                                mainMenu.Background = Brushes.Green;
                        MessageBox.Show($"Твоя оценка: 5 \nМолодец!");
                        break;
                }
            }
        }
    }
}
