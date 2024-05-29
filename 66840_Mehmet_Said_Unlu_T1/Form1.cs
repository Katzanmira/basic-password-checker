using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _66840_Mehmet_Said_Unlu_T1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            int passwordStrength = CalculatePasswordStrength(password);
            string passwordStrengthLabel = GetPasswordStrengthLabel(passwordStrength);

            label4.Text = $"Password strength: {passwordStrengthLabel}";
            string issues = GetPasswordIssues(password);
            textBox2.Text = issues;
        }

        private int CalculatePasswordStrength(string password)
        {
            int strength = 0;

            if (password.Length >= 15)
            {
                strength += 75;
            }
            else if (password.Length >= 10 && password.Length <= 14)
            {
                strength += 60;
            }
            else if (password.Length >= 7 && password.Length <= 9)
            {
                strength += 40;
            }
            else if (password.Length > 4)
            {
                strength += 20;
            }

            if (ContainsLetters(password))
            {
                strength += 15;
            }

            if (ContainsNumbers(password))
            {
                strength += 10;
            }

            if (ContainsSymbolsOrPunctuation(password))
            {
                strength += 15;
            }

            return strength;
        }

        private bool ContainsLetters(string password)
        {
            foreach (char c in password)
            {
                if (char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ContainsNumbers(string password)
        {
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ContainsSymbolsOrPunctuation(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        private string GetPasswordStrengthLabel(int strength)
        {
            if (strength >= 90)
            {
                return "Very Strong";
            }
            else if (strength >= 75)
            {
                return "Strong";
            }
            else if (strength >= 50)
            {
                return "Medium";
            }
            else if (strength >= 25)
            {
                return "Weak";
            }
            else
            {
                return "Very Weak";
            }
        }

        private string GetPasswordIssues(string password)
        {
            string issues = "";

            if (password.Length < 5)
            {
                issues += "Password is too short" + Environment.NewLine;
            }

            if (!ContainsLetters(password))
            {
                issues += "Password does not contain letters" + Environment.NewLine;
            }

            if (!ContainsNumbers(password))
            {
                issues += "Password does not contain numbers" + Environment.NewLine;
            }

            if (!ContainsSymbolsOrPunctuation(password))
            {
                issues += "Password does not contain symbols or punctuation" + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(issues))
            {
                issues = "No problem has been found";
            }

            return issues.Trim();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
