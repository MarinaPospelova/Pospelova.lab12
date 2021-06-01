using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб12
{
    public partial class Form1 : Form
    {
        List<Label> firstRound = new List<Label>();
        List<Label> quarterFinal = new List<Label>();
        List<Label> semiFinal = new List<Label>();
        List<Label> finale = new List<Label>();
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            firstRound.Add(label1);
            firstRound.Add(label2);
            firstRound.Add(label3);
            firstRound.Add(label4);
            firstRound.Add(label5);
            firstRound.Add(label6);
            firstRound.Add(label7);
            firstRound.Add(label8);
            firstRound.Add(label9);
            firstRound.Add(label10);
            firstRound.Add(label11);
            firstRound.Add(label12);
            firstRound.Add(label13);
            firstRound.Add(label14);
            firstRound.Add(label15);
            firstRound.Add(label16);
            quarterFinal.Add(label17);
            quarterFinal.Add(label18);
            quarterFinal.Add(label19);
            quarterFinal.Add(label20);
            quarterFinal.Add(label21);
            quarterFinal.Add(label22);
            quarterFinal.Add(label23);
            quarterFinal.Add(label24);
            semiFinal.Add(label25);
            semiFinal.Add(label26);
            semiFinal.Add(label27);
            semiFinal.Add(label28);
            finale.Add(label29);
            finale.Add(label30);

            for (int i = 0; i < firstRound.Count; i++)
            {
                firstRound[i].Text = teams[i];
            }
        }
        string[] teams = new string[] { "Томь", "Реал", "Барселона", "Милан", "Ювентус", "Арсенал", "Бавария", "Челси", "Спартак", "Зенит", "ЦСКА", "Динамо", "Интер", "Лион", "Аякс", "Гамбург" };
        Dictionary<string, double> lambda = new Dictionary<string, double>
            {
                {"Томь", 7},
                {"Реал", 5},
                {"Барселона", 4},
                {"Милан", 2},
                {"Ювентус", 1},
                {"Арсенал", 3 },
                {"Бавария", 7 },
                {"Челси", 5 },
                {"Спартак", 4 },
                {"Зенит", 1 },
                {"ЦСКА", 2},
                {"Динамо", 3 },
                {"Интер", 1 },
                {"Лион", 4 },
                {"Аякс", 2 },
                {"Гамбург", 5 }
            };
        
        public double Win(double lambda)
        {
            double alpha = 0;
            double S = 0;
            double m = 0;

            while (S >= -1 * lambda)
            {
                alpha = rnd.NextDouble();
                S += S + Math.Log(alpha);

                if (S >= -1 * lambda)
                {
                    m += 1;
                }
            }

            return m;
        }
        double n = 0;
        List<String> firstRoundResults = new List<String>();
        List<String> quarterFinalResults = new List<String>();
        List<String> semiFinalResults = new List<String>();

        private void final8_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    double value1 = Win(lambda[teams[2 * i]]);
                    double value2 = Win(lambda[teams[2 * i + 1]]);

                    firstRound[2 * i].Text += " " + value1.ToString();
                    firstRound[2 * i + 1].Text += " " + value2.ToString();
                    if (value1 > value2)
                    {
                        firstRoundResults.Add(teams[2 * i]);
                    }
                    else
                    {
                        if (value2 > value1)
                        {
                            firstRoundResults.Add(teams[2 * i + 1]);
                        }
                        else
                        {
                            value1 += Win(lambda[teams[2 * i]] * 1 / 6);
                            value2 += Win(lambda[teams[2 * i + 1]] * 1 / 6);
                        }
                        firstRound[2 * i].Text = teams[2 * i] + " " + value1.ToString();
                        firstRound[2 * i + 1].Text = teams[2 * i + 1] + " " + value2.ToString();
                        if (value1 > value2)
                        {
                            firstRoundResults.Add(teams[2 * i]);
                        }
                        else
                        {
                            if (value2 > value1)
                            {
                                firstRoundResults.Add(teams[2 * i + 1]);
                            }
                            if (value1 == value2)
                            {
                                int penalty = rnd.Next(0, 1);

                                if (penalty == 0)
                                {
                                    firstRoundResults.Add(teams[2 * i]);
                                    firstRound[2 * i].Text += " пенальти";
                                }
                            }
                            else
                            {
                                firstRoundResults.Add(teams[2 * i + 1]);
                                firstRound[2 * i + 1].Text += " пенальти";
                            }
                        }
                    }
                }
                for (int i = 0; i< 8; i++)
                    {
                    quarterFinal[i].Text = firstRoundResults[i];
                    }
            }
            final8.Enabled = false;
        }

        private void final4_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    double value1 = Win(lambda[firstRoundResults[2 * i]]);
                    double value2 = Win(lambda[firstRoundResults[2 * i + 1]]);

                    quarterFinal[2 * i].Text += " " + value1.ToString();
                    quarterFinal[2 * i + 1].Text += " " + value2.ToString();
                    if (value1 > value2)
                    {
                        quarterFinalResults.Add(firstRoundResults[2 * i]);
                    }
                    else
                    {
                        if (value2 > value1)
                        {
                            quarterFinalResults.Add(firstRoundResults[2 * i + 1]);
                        }
                        else
                        {
                            value1 += Win(lambda[firstRoundResults[2 * i]] * 1 / 6);
                            value2 += Win(lambda[firstRoundResults[2 * i + 1]] * 1 / 6);
                            quarterFinal[2 * i].Text = firstRoundResults[2 * i] + " " + value1.ToString();
                            quarterFinal[2 * i + 1].Text = firstRoundResults[2 * i + 1] + " " + value2.ToString();
                            if (value1 > value2)
                            {
                                quarterFinalResults.Add(firstRoundResults[2 * i]);
                            }
                            else
                            {
                                if (value2 > value1)
                                {
                                    quarterFinalResults.Add(firstRoundResults[2 * i + 1]);
                                }
                                if (value1 == value2)
                                {
                                    int penalty = rnd.Next(0, 1);

                                    if (penalty == 0)
                                    {
                                        quarterFinalResults.Add(firstRoundResults[2 * i]);
                                        quarterFinal[2 * i].Text += " п";
                                    }
                                    else
                                    {
                                        quarterFinalResults.Add(firstRoundResults[2 * i + 1]);
                                        quarterFinal[2 * i + 1].Text += " п";
                                    }
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    semiFinal[i].Text = quarterFinalResults[i];
                }
            }

            final4.Enabled = false;
        }

        private void half_of_final_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    double value1 = Win(lambda[quarterFinalResults[2 * i]]);
                    double value2 = Win(lambda[quarterFinalResults[2 * i + 1]]);

                    semiFinal[2 * i].Text += " " + value1.ToString();
                    semiFinal[2 * i + 1].Text += " " + value2.ToString();
                    if (value1 > value2)
                    {
                        semiFinalResults.Add(quarterFinalResults[2 * i]);
                    }
                    else
                    {
                        if (value2 > value1)
                        {
                            semiFinalResults.Add(quarterFinalResults[2 * i + 1]);
                        }
                        else
                        {
                            value1 += Win(lambda[quarterFinalResults[2 * i]] * 1 / 6);
                            value2 += Win(lambda[quarterFinalResults[2 * i + 1]] * 1 / 6);

                            semiFinal[2 * i].Text = quarterFinalResults[2 * i] + " " + value1.ToString();
                            semiFinal[2 * i + 1].Text = quarterFinalResults[2 * i + 1] + " " + value2.ToString();
                            if (value1 > value2)
                            {
                                semiFinalResults.Add(quarterFinalResults[2 * i]);
                            }
                            else
                            {
                                if (value2 > value1)
                                {
                                    semiFinalResults.Add(quarterFinalResults[2 * i + 1]);
                                }
                                if (value1 == value2)
                                {
                                    int penalty = rnd.Next(0, 1);

                                    if (penalty == 0)
                                    {
                                        semiFinalResults.Add(quarterFinalResults[2 * i]);
                                        semiFinal[2 * i].Text += " пенальти";
                                    }
                                    else
                                    {
                                        semiFinalResults.Add(quarterFinalResults[2 * i + 1]);
                                        semiFinal[2 * i + 1].Text += " пенальти";
                                    }
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < 2; i++)
                {
                    finale[i].Text = semiFinalResults[i];
                }
            }

            half_of_final.Enabled = false;
        }

        private void final_Click(object sender, EventArgs e)
        {
            if (n == 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    double value1 = Win(lambda[semiFinalResults[2 * i]]);
                    double value2 = Win(lambda[semiFinalResults[2 * i + 1]]);

                    finale[2 * i].Text += " " + value1.ToString();
                    finale[2 * i + 1].Text += " " + value2.ToString();
                    if (value1 > value2)
                    {
                        label31.Text = semiFinalResults[2 * i] + " выиграл!!!";
                    }
                    else
                    {
                        if (value2 > value1)
                        {
                            label31.Text = semiFinalResults[2 * i + 1] + " выиграл!!!";
                        }
                        else
                        {
                            value1 += Win(lambda[semiFinalResults[2 * i]] * 1 / 6);
                            value2 += Win(lambda[semiFinalResults[2 * i + 1]] * 1 / 6);

                            finale[2 * i].Text = semiFinalResults[2 * i] + " " + value1.ToString();
                            finale[2 * i + 1].Text = semiFinalResults[2 * i + 1] + " " + value2.ToString();
                            if (value1 > value2)
                            {
                                label31.Text = semiFinalResults[2 * i] + " выиграл!!!";
                            }
                            else
                            {
                                if (value2 > value1)
                                {
                                    label31.Text = semiFinalResults[2 * i + 1] + " выиграл!!!";
                                }
                                if (value1 == value2)
                                {
                                    int penalty = rnd.Next(0, 1);

                                    if (penalty == 0)
                                    {
                                        label31.Text = semiFinalResults[2 * i] + " выиграл!!!";
                                        finale[2 * i].Text += " пенальти";
                                    }
                                    else
                                    {
                                        label31.Text = semiFinalResults[2 * i + 1] + " выиграл!!!";
                                        finale[2 * i + 1].Text += " пенальти";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            final.Enabled = false;
        }
    }
}