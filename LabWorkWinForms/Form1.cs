using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWorkWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int CalculateDigitSum(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }

        private (int max, int min) FindMaxMinDigits(int n)
        {
            int max = n % 10;
            int min = n % 10;
            n /= 10;

            while (n != 0)
            {
                int a = n % 10;

                if (a > max)
                    max = a;
                else if (a < min)
                    min = a;

                n /= 10;
            }

            return (max, min);
        }
        private int[] GetPrimeNumbersInRange(int start, int end)
        {
            var primes = new System.Collections.Generic.List<int>();

            for (int x = start; x <= end; x++)
            {
                bool isPrime = true;

                for (int del = 2; del * del <= x; del++)
                {
                    if (x % del == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(x);
                }
            }

            return primes.ToArray();
        }

        private string SolveRebus()
        {
            for (int M = 1; M <= 9; M++)
                for (int U = 0; U <= 9; U++)
                    for (int H = 0; H <= 9; H++)
                        for (int A = 1; A <= 9; A++)
                            for (int S = 3; S <= 9; S++)
                                for (int L = 0; L <= 9; L++)
                                    for (int O = 0; O <= 9; O++)
                                        for (int N = 0; N <= 9; N++)
                                        {
                                            int[] digits = { M, U, H, A, S, L, O, N };
                                            if (digits.Distinct().Count() == digits.Length)
                                            {
                                                int MUHA = 1000 * M + 100 * U + 10 * H + A;
                                                int SLON = 1000 * S + 100 * L + 10 * O + N;

                                                if (3 * MUHA == SLON)
                                                {
                                                    return $"Решение найдено:МУХА = {MUHA}, СЛОН = {SLON}, " +
                                                           $"М = {M}, У = {U}, Х = {H}, А = {A}, С = {S}, Л = {L}, О = {O}, Н = {N}";
                                                }
                                            }
                                        }

            return "Решение не найдено.";
        }

        public static List<Tuple<int, int>> FindCombinations()
        {
            List<Tuple<int, int>> combinations = new List<Tuple<int, int>>();

            for (int y = 0; y <= 16; y++)
            {
                int x = 32 - 2 * y;

                if (x >= 0)
                {
                    combinations.Add(new Tuple<int, int>(x, y));
                }
            }

            return combinations;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox1.Text, out int number) && number >= 0)
            {
                int sum = CalculateDigitSum(number);
                textBox2.Text = $"Сумма цифр: {sum}";
            }
            else
            {
                MessageBox.Show("Введите корректное натуральное число.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox3.Text, out int number) && number > 0)
            {
                (int max, int min) = FindMaxMinDigits(number);
                textBox4.Text = $"Наибольшая: {max}, Наименьшая: {min}";
            }
            else
            {
                MessageBox.Show("Введите корректное натуральное число.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int n) && n > 2)
            {
                int[] primes = GetPrimeNumbersInRange(2, n);

                if (primes.Length > 0)
                {
                    textBox6.Text = "[" + string.Join(", ", primes) + "]";
                }
                else
                {
                    textBox6.Text = "Простых чисел в этом диапазоне нет.";
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное число больше 2.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = SolveRebus();

            textBox7.Text = result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var combinations = FindCombinations();
            textBox8.Clear();

            foreach (var combination in combinations)
            {
                textBox8.AppendText($"Гусей: {combination.Item1}, Кроликов: {combination.Item2}\r\n");
            }
        }
    }
}
