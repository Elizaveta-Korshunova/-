using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Баскетбол
{
    public partial class Form1 : Form
    {
        int НомерГр, НомерТекСбор, КолСборГр;

        public Form1()
        {
            InitializeComponent();
        }

        private void ВводНазванияСтраны_button_Click(object sender, EventArgs e)
        {
            string inName = НазваниеСтраны_textBox.Text.Trim();
            if (inName != "")
            {
                ВведенныйСписокСтран_listBox.Items.Add(inName);
                НазваниеСтраны_textBox.Clear();
                НазваниеСтраны_textBox.Focus();
            }
            if (ВведенныйСписокСтран_listBox.Items.Count == Program.КолСборных)
            {
                НазваниеСтраны_textBox.Enabled = false;
                ВводНазванияСтраны_button.Enabled = false;
                РаспределитьПоГр_button.Visible = true;
            }
        }

        private void НазваниеСтраны_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                ВводНазванияСтраны_button_Click(sender, e);
        }

        private void РаспределитьПоГр_button_Click(object sender, EventArgs e)
        {
            КолСборГр = ВведенныйСписокСтран_listBox.Items.Count/2;
            Program.Группа1 = new Сборные[КолСборГр];
            Program.Группа2 = new Сборные[ВведенныйСписокСтран_listBox.Items.Count - КолСборГр];
            for (int i = 0; i < Program.Группа1.Length; i++)
            {
                Program.Группа1[i] = new Сборные();
                Program.Группа1[i].ЗаброшенныеМячи = new int[6];
                Program.Группа1[i].ПропущенныеМячи = new int[6];
                Program.Группа1[i].РазницаЗабИПроп = new int[6];
                Program.Группа1[i].ИндексРезультатов = i;
                Program.Группа1[i].Страна = ВведенныйСписокСтран_listBox.Items[i].ToString();
            }
            for (int i = 0; i < Program.Группа2.Length; i++)
            {
                Program.Группа2[i] = new Сборные();
                Program.Группа2[i].ЗаброшенныеМячи = new int[6];
                Program.Группа2[i].ПропущенныеМячи = new int[6];
                Program.Группа2[i].РазницаЗабИПроп = new int[6];
                Program.Группа2[i].ИндексРезультатов = i;
                Program.Группа2[i].Страна = ВведенныйСписокСтран_listBox.Items[КолСборГр + i].ToString();
            }
           

            Вкладки.SelectedIndex++;
            РаспределитьПоГр_button.Enabled = false;
            СледПараСборн.Visible = true;
            НомерГр = НомерТекСбор = 0;
            ИмяСборной1_label.Text = Program.Группа1[0].Страна;
            ИмяСборной2_label.Text = Program.Группа1[1].Страна;
        }
        int а = 0;
        int б = 1;

        private void РезультатСб1_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб1_numericUpDown.Value == РезультатСб2_numericUpDown.Value)
                СледПараСборн.Enabled = false;
            else
                СледПараСборн.Enabled = true;
        }

        private void РезультатСб2_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб1_numericUpDown.Value == РезультатСб2_numericUpDown.Value)
                СледПараСборн.Enabled = false;
            else
                СледПараСборн.Enabled = true;
        }

        private void РезИгрГр_button_Click(object sender, EventArgs e)
        {
            Результаты1группы форма2 = new Результаты1группы();
            if (sender == РезИгрГр1_button)
                форма2.Вывод(Program.Группа1); // 1 группа
            else
                форма2.Вывод(Program.Группа2); // 2 группа
        }

        private void ДалееНа3Вк_button_Click(object sender, EventArgs e)
        {
            Вкладки.SelectedIndex++;

        }

        private void РезультатСб11ЧФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб11ЧФ_numericUpDown.Value == РезультатСб24ЧФ_numericUpDown.Value)
                ПримРезЧФ1_button.Enabled = false;
            else
                ПримРезЧФ1_button.Enabled = true;
        }

        private void РезультатСб24ЧФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб11ЧФ_numericUpDown.Value == РезультатСб24ЧФ_numericUpDown.Value)
                ПримРезЧФ1_button.Enabled = false;
            else
                ПримРезЧФ2_button.Enabled = true;
        }

        private void РезультатСб12ЧФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб12ЧФ_numericUpDown.Value == РезультатСб23ЧФ_numericUpDown.Value)
                ПримРезЧФ2_button.Enabled = false;
            else
                ПримРезЧФ2_button.Enabled = true;
        }

        private void РезультатСб23ЧФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб12ЧФ_numericUpDown.Value == РезультатСб23ЧФ_numericUpDown.Value)
                ПримРезЧФ2_button.Enabled = false;
            else
                ПримРезЧФ2_button.Enabled = true;
        }

        private void РезультатСб13ЧФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб13ЧФ_numericUpDown.Value == РезультатСб22ЧФ_numericUpDown.Value)
                ПримРезЧФ3_button.Enabled = false;
            else
                ПримРезЧФ3_button.Enabled = true;
        }

        private void РезультатСб22ЧФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб13ЧФ_numericUpDown.Value == РезультатСб22ЧФ_numericUpDown.Value)
                ПримРезЧФ3_button.Enabled = false;
            else
                ПримРезЧФ3_button.Enabled = true;
        }

        private void РезультатСб14ЧФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб14ЧФ_numericUpDown.Value == РезультатСб21ЧФ_numericUpDown.Value)
                ПримРезЧФ4_button.Enabled = false;
            else
                ПримРезЧФ4_button.Enabled = true;
        }

        private void РезультатСб21ЧФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб14ЧФ_numericUpDown.Value == РезультатСб21ЧФ_numericUpDown.Value)
                ПримРезЧФ4_button.Enabled = false;
            else
                ПримРезЧФ4_button.Enabled = true;
        }

       

        private void РасчетЧФ_button_Click(object sender, EventArgs e)
        {
           
            if (Program.Четвертьфинал[0].Результат == 1)
            {
                Program.Полуфинал[0].Страна = Program.Четвертьфинал[0].Страна;
            }
            else
            {
                Program.Полуфинал[0].Страна = Program.Четвертьфинал[7].Страна;
            }
            if (Program.Четвертьфинал[1].Результат == 1)
            {
                Program.Полуфинал[1].Страна = Program.Четвертьфинал[1].Страна;
            }
            else
            {
                Program.Полуфинал[1].Страна = Program.Четвертьфинал[6].Страна;
            }
            if (Program.Четвертьфинал[2].Результат == 1)
            {
                Program.Полуфинал[2].Страна = Program.Четвертьфинал[2].Страна;
            }
            else
            {
                Program.Полуфинал[2].Страна = Program.Четвертьфинал[5].Страна;
            }
            if (Program.Четвертьфинал[3].Результат == 1)
            {
                Program.Полуфинал[3].Страна = Program.Четвертьфинал[3].Страна;
            }
            else
            {
                Program.Полуфинал[3].Страна = Program.Четвертьфинал[4].Страна;
            }
            var Рандом1 = new Random();


            ИмяСборнойПФ1_label.Text = Program.Полуфинал[Рандом1.Next(4)].Страна;
            if (ИмяСборнойПФ1_label.Text == Program.Полуфинал[0].Страна)
            {
                ИмяСборнойПФ2_label.Text = Program.Полуфинал[1].Страна;
                ИмяСборнойПФ3_label.Text = Program.Полуфинал[2].Страна;
                ИмяСборнойПФ4_label.Text = Program.Полуфинал[3].Страна;
            }
            if (ИмяСборнойПФ1_label.Text == Program.Полуфинал[1].Страна)
            {
                ИмяСборнойПФ2_label.Text = Program.Полуфинал[0].Страна;
                ИмяСборнойПФ3_label.Text = Program.Полуфинал[2].Страна;
                ИмяСборнойПФ4_label.Text = Program.Полуфинал[3].Страна;
            }
            if (ИмяСборнойПФ1_label.Text == Program.Полуфинал[2].Страна)
            {
                ИмяСборнойПФ2_label.Text = Program.Полуфинал[0].Страна;
                ИмяСборнойПФ3_label.Text = Program.Полуфинал[1].Страна;
                ИмяСборнойПФ4_label.Text = Program.Полуфинал[3].Страна;
            }
            if (ИмяСборнойПФ1_label.Text == Program.Полуфинал[3].Страна)
            {
                ИмяСборнойПФ2_label.Text = Program.Полуфинал[0].Страна;
                ИмяСборнойПФ3_label.Text = Program.Полуфинал[1].Страна;
                ИмяСборнойПФ4_label.Text = Program.Полуфинал[2].Страна;
            }
            РезультатСб1ПФ_numericUpDown.Enabled = true;
            РезультатСб2ПФ_numericUpDown.Enabled = true;
            Вкладки.SelectedIndex++;
        }

        private void ПримРезЧФ2_button_Click(object sender, EventArgs e)
        {
            РезультатСб12ЧФ_numericUpDown.Enabled = false;
            РезультатСб23ЧФ_numericUpDown.Enabled = false;
            ПримРезЧФ2_button.Visible = false;
            Program.Четвертьфинал[1].Результат = (int)РезультатСб12ЧФ_numericUpDown.Value;
            РезультатСб13ЧФ_numericUpDown.Enabled = true;
            РезультатСб22ЧФ_numericUpDown.Enabled = true;
        }

        private void ПримРезЧФ3_button_Click(object sender, EventArgs e)
        {
            РезультатСб13ЧФ_numericUpDown.Enabled = false;
            РезультатСб22ЧФ_numericUpDown.Enabled = false;
            ПримРезЧФ3_button.Visible = false;
            Program.Четвертьфинал[2].Результат = (int)РезультатСб13ЧФ_numericUpDown.Value;
            Program.Четвертьфинал[5].Результат = (int)РезультатСб23ЧФ_numericUpDown.Value;
            РезультатСб14ЧФ_numericUpDown.Enabled = true;
            РезультатСб21ЧФ_numericUpDown.Enabled = true;
        }

        private void ПримРезЧФ4_button_Click(object sender, EventArgs e)
        {
            РезультатСб14ЧФ_numericUpDown.Enabled = false;
            РезультатСб21ЧФ_numericUpDown.Enabled = false;
            ПримРезЧФ4_button.Visible = false;
            Program.Четвертьфинал[3].Результат = (int)РезультатСб14ЧФ_numericUpDown.Value;
            Program.Четвертьфинал[4].Результат = (int)РезультатСб24ЧФ_numericUpDown.Value;
            РасчетЧФ_button.Visible = true;
        }

        private void ПримРезЧФ1_button_Click(object sender, EventArgs e)
        {
            РезультатСб11ЧФ_numericUpDown.Enabled = false;
            РезультатСб24ЧФ_numericUpDown.Enabled = false;
            ПримРезЧФ1_button.Visible = false;
            Program.Четвертьфинал[0].Результат = (int)РезультатСб11ЧФ_numericUpDown.Value;
            Program.Четвертьфинал[7].Результат = (int)РезультатСб21ЧФ_numericUpDown.Value;
            РезультатСб12ЧФ_numericUpDown.Enabled = true;
            РезультатСб23ЧФ_numericUpDown.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб1ПФ_numericUpDown.Value == РезультатСб2ПФ_numericUpDown.Value)
                ПримРезПФ1_button.Enabled = false;
            else
                ПримРезПФ1_button.Enabled = true;
        }

        private void РезультатСб2ПФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб1ПФ_numericUpDown.Value == РезультатСб2ПФ_numericUpDown.Value)
                ПримРезПФ1_button.Enabled = false;
            else
                ПримРезПФ1_button.Enabled = true;
        }

        private void РезультатСб3ПФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб3ПФ_numericUpDown.Value == РезультатСб4ПФ_numericUpDown.Value)
                ПримРезПФ2_button.Enabled = false;
            else
                ПримРезПФ2_button.Enabled = true;
        }

        private void РезультатСб4ПФ_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб3ПФ_numericUpDown.Value == РезультатСб4ПФ_numericUpDown.Value)
                ПримРезПФ2_button.Enabled = false;
            else
                ПримРезПФ2_button.Enabled = true;
        }

        private void ПримРезПФ1_button_Click(object sender, EventArgs e)
        {
            ПримРезПФ1_button.Visible = false;
            РезультатСб1ПФ_numericUpDown.Enabled = false;
            РезультатСб2ПФ_numericUpDown.Enabled = false;
            РезультатСб3ПФ_numericUpDown.Enabled = true;
            РезультатСб4ПФ_numericUpDown.Enabled = true;
            ПримРезПФ2_button.Visible = true;
        }

        private void ПримРезПФ2_button_Click(object sender, EventArgs e)
        {
            ПримРезПФ2_button.Visible = false;
            РезультатСб3ПФ_numericUpDown.Enabled = false;
            РезультатСб4ПФ_numericUpDown.Enabled = false;
            РасчетПФ_button.Enabled = true;
            РасчетПФ_button.Visible = true;
        }

        private void РасчетПФ_button_Click(object sender, EventArgs e)
        {
            if (ИмяСборнойПФ1_label.Text == Program.Полуфинал[0].Страна)
            {
                Program.Полуфинал[0].Результат = (int)РезультатСб1ПФ_numericUpDown.Value;
                Program.Полуфинал[1].Результат = (int)РезультатСб2ПФ_numericUpDown.Value;
                Program.Полуфинал[2].Результат = (int)РезультатСб3ПФ_numericUpDown.Value;
                Program.Полуфинал[3].Результат = (int)РезультатСб4ПФ_numericUpDown.Value;
            }
            if (ИмяСборнойПФ1_label.Text == Program.Полуфинал[1].Страна)
            {
                Program.Полуфинал[1].Результат = (int)РезультатСб1ПФ_numericUpDown.Value;
                Program.Полуфинал[0].Результат = (int)РезультатСб2ПФ_numericUpDown.Value;
                Program.Полуфинал[2].Результат = (int)РезультатСб3ПФ_numericUpDown.Value;
                Program.Полуфинал[3].Результат = (int)РезультатСб4ПФ_numericUpDown.Value;
            }
            if (ИмяСборнойПФ1_label.Text == Program.Полуфинал[2].Страна)
            {
                Program.Полуфинал[2].Результат = (int)РезультатСб1ПФ_numericUpDown.Value;
                Program.Полуфинал[0].Результат = (int)РезультатСб2ПФ_numericUpDown.Value;
                Program.Полуфинал[1].Результат = (int)РезультатСб3ПФ_numericUpDown.Value;
                Program.Полуфинал[3].Результат = (int)РезультатСб4ПФ_numericUpDown.Value;
            }
            if (ИмяСборнойПФ1_label.Text == Program.Полуфинал[3].Страна)
            {
                Program.Полуфинал[3].Результат = (int)РезультатСб1ПФ_numericUpDown.Value;
                Program.Полуфинал[0].Результат = (int)РезультатСб2ПФ_numericUpDown.Value;
                Program.Полуфинал[1].Результат = (int)РезультатСб3ПФ_numericUpDown.Value;
                Program.Полуфинал[2].Результат = (int)РезультатСб4ПФ_numericUpDown.Value;
            }

            if (Program.Полуфинал[0].Результат == 1)
            {
                Program.Финал[0].Страна = Program.Полуфинал[0].Страна;
                if (Program.Полуфинал[1].Результат == 1)
                {
                    Program.Финал[1].Страна = Program.Полуфинал[1].Страна;
                    Program.Финал[2].Страна = Program.Полуфинал[2].Страна;
                    Program.Финал[3].Страна = Program.Полуфинал[3].Страна;
                }
                else
                {
                    if (Program.Полуфинал[2].Результат == 1)
                    {
                        Program.Финал[1].Страна = Program.Полуфинал[2].Страна;
                        Program.Финал[2].Страна = Program.Полуфинал[1].Страна;
                        Program.Финал[3].Страна = Program.Полуфинал[3].Страна;
                    }
                    else
                    {
                       if (Program.Полуфинал[3].Результат == 1)
                        Program.Финал[1].Страна = Program.Полуфинал[3].Страна;
                        Program.Финал[2].Страна = Program.Полуфинал[1].Страна;
                        Program.Финал[3].Страна = Program.Полуфинал[2].Страна;

                    }
                }
            }
            else
            {
                Program.Финал[2].Страна = Program.Полуфинал[0].Страна;
                if (Program.Полуфинал[1].Результат == 1)
                {
                    Program.Финал[0].Страна = Program.Полуфинал[1].Страна;
                    if (Program.Полуфинал[2].Результат == 1)
                    {
                        Program.Финал[1].Страна = Program.Полуфинал[2].Страна;
                        Program.Финал[3].Страна = Program.Полуфинал[3].Страна;
                    }
                    else
                    {
                        Program.Финал[1].Страна = Program.Полуфинал[3].Страна;
                        Program.Финал[3].Страна = Program.Полуфинал[2].Страна;
                    }
                }
                else
                {
                    Program.Финал[0].Страна = Program.Полуфинал[2].Страна;
                    Program.Финал[1].Страна = Program.Полуфинал[3].Страна;
                    Program.Финал[3].Страна = Program.Полуфинал[1].Страна;
                }
            }
            Вкладки.SelectedIndex++;
            РезультатСб1Ф_numericUpDown.Enabled = true;
            РезультатСб2Ф_numericUpDown.Enabled = true;

            ИмяСборнойФ1_label.Text = Program.Финал[0].Страна;
            ИмяСборнойФ2_label.Text = Program.Финал[1].Страна;
            ИмяСборнойФ3_label.Text = Program.Финал[2].Страна;
            ИмяСборнойФ4_label.Text = Program.Финал[3].Страна;
        }

        private void РезультатСб1Ф_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб1Ф_numericUpDown.Value == РезультатСб2Ф_numericUpDown.Value)
                ПримРезФ1_button.Enabled = false;
            else
                ПримРезФ1_button.Enabled = true;
        }

        private void РезультатСб2Ф_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб1Ф_numericUpDown.Value == РезультатСб2Ф_numericUpDown.Value)
                ПримРезФ1_button.Enabled = false;
            else
                ПримРезФ1_button.Enabled = true;
        }

        private void РезультатСб3Ф_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб3Ф_numericUpDown.Value == РезультатСб4Ф_numericUpDown.Value)
                ПримРезФ2_button.Enabled = false;
            else
                ПримРезФ2_button.Enabled = true;
        }

        private void РезультатСб4Ф_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (РезультатСб3Ф_numericUpDown.Value == РезультатСб4Ф_numericUpDown.Value)
                ПримРезФ2_button.Enabled = false;
            else
                ПримРезФ2_button.Enabled = true;
        }

        private void ПримРезФ1_button_Click(object sender, EventArgs e)
        {
            РезультатСб1Ф_numericUpDown.Enabled = false;
            РезультатСб2Ф_numericUpDown.Enabled = false;
            ПримРезФ1_button.Visible = false;
            РезультатСб3Ф_numericUpDown.Enabled = true;
            РезультатСб4Ф_numericUpDown.Enabled = true;
            ПримРезФ2_button.Visible = true;

        }

        private void ПримРезФ2_button_Click(object sender, EventArgs e)
        {
            ПримРезФ2_button.Visible = false;
            РезультатСб3Ф_numericUpDown.Enabled = false;
            РезультатСб4Ф_numericUpDown.Enabled = false;
            РасчетФ_button.Visible = true;
        }

        private void РасчетФ_button_Click(object sender, EventArgs e)
        {
                Program.Финал[0].Результат = (int)РезультатСб1Ф_numericUpDown.Value;
                Program.Финал[1].Результат = (int)РезультатСб2Ф_numericUpDown.Value;
                Program.Финал[2].Результат = (int)РезультатСб3Ф_numericUpDown.Value;
                Program.Финал[3].Результат = (int)РезультатСб4Ф_numericUpDown.Value;
            //
            if (Program.Финал[0].Результат == 1)
            {
                Program.Итог[0].Страна = Program.Финал[0].Страна;
                Program.Итог[1].Страна = Program.Финал[1].Страна;
            }
            else
            {
                Program.Итог[0].Страна = Program.Финал[1].Страна;
                Program.Итог[1].Страна = Program.Финал[0].Страна;
            }
            if (Program.Финал[2].Результат == 1)
            {
                Program.Итог[2].Страна = Program.Финал[2].Страна;
                Program.Итог[3].Страна = Program.Финал[3].Страна;
            }
            else
            {
                Program.Итог[2].Страна = Program.Финал[3].Страна;
                Program.Итог[3].Страна = Program.Финал[2].Страна;
            }
            Program.Итог[0].МестоИтог = 1;
            Program.Итог[1].МестоИтог = 2;
            Program.Итог[2].МестоИтог = 3;
            Program.Итог[3].МестоИтог = 4;
            Рез_Чемп_button.Visible = true;
        }

        private void Рез_Чемп_button_Click(object sender, EventArgs e)
        {
            РезультатыЧемпионата форма3 = new РезультатыЧемпионата();
            форма3.ВыводФ(Program.Итог);
            форма3.Show();
        }

        private void РасчетПоГр_button_Click(object sender, EventArgs e)
        {
            {

                Program.Группа1[0].ПропущенныеМячи[1] = Program.Группа1[1].ЗаброшенныеМячи[0];
                Program.Группа1[0].ПропущенныеМячи[2] = Program.Группа1[2].ЗаброшенныеМячи[0];
                Program.Группа1[0].ПропущенныеМячи[3] = Program.Группа1[3].ЗаброшенныеМячи[0];
                Program.Группа1[0].ПропущенныеМячи[4] = Program.Группа1[4].ЗаброшенныеМячи[0];
                Program.Группа1[0].ПропущенныеМячи[5] = Program.Группа1[5].ЗаброшенныеМячи[0];
                Program.Группа1[1].ПропущенныеМячи[0] = Program.Группа1[0].ЗаброшенныеМячи[1];
                Program.Группа1[1].ПропущенныеМячи[2] = Program.Группа1[2].ЗаброшенныеМячи[1];
                Program.Группа1[1].ПропущенныеМячи[3] = Program.Группа1[3].ЗаброшенныеМячи[1];
                Program.Группа1[1].ПропущенныеМячи[4] = Program.Группа1[4].ЗаброшенныеМячи[1];
                Program.Группа1[1].ПропущенныеМячи[5] = Program.Группа1[5].ЗаброшенныеМячи[1];
                Program.Группа1[2].ПропущенныеМячи[0] = Program.Группа1[0].ЗаброшенныеМячи[2];
                Program.Группа1[2].ПропущенныеМячи[1] = Program.Группа1[1].ЗаброшенныеМячи[2];
                Program.Группа1[2].ПропущенныеМячи[3] = Program.Группа1[3].ЗаброшенныеМячи[2];
                Program.Группа1[2].ПропущенныеМячи[4] = Program.Группа1[4].ЗаброшенныеМячи[2];
                Program.Группа1[2].ПропущенныеМячи[5] = Program.Группа1[5].ЗаброшенныеМячи[2];
                Program.Группа1[3].ПропущенныеМячи[0] = Program.Группа1[0].ЗаброшенныеМячи[3];
                Program.Группа1[3].ПропущенныеМячи[1] = Program.Группа1[1].ЗаброшенныеМячи[3];
                Program.Группа1[3].ПропущенныеМячи[2] = Program.Группа1[2].ЗаброшенныеМячи[3];
                Program.Группа1[3].ПропущенныеМячи[4] = Program.Группа1[4].ЗаброшенныеМячи[3];
                Program.Группа1[3].ПропущенныеМячи[5] = Program.Группа1[5].ЗаброшенныеМячи[3];
                Program.Группа1[4].ПропущенныеМячи[0] = Program.Группа1[0].ЗаброшенныеМячи[4];
                Program.Группа1[4].ПропущенныеМячи[1] = Program.Группа1[1].ЗаброшенныеМячи[4];
                Program.Группа1[4].ПропущенныеМячи[2] = Program.Группа1[2].ЗаброшенныеМячи[4];
                Program.Группа1[4].ПропущенныеМячи[3] = Program.Группа1[3].ЗаброшенныеМячи[4];
                Program.Группа1[4].ПропущенныеМячи[5] = Program.Группа1[5].ЗаброшенныеМячи[4];
                Program.Группа1[5].ПропущенныеМячи[0] = Program.Группа1[0].ЗаброшенныеМячи[5];
                Program.Группа1[5].ПропущенныеМячи[1] = Program.Группа1[1].ЗаброшенныеМячи[5];
                Program.Группа1[5].ПропущенныеМячи[2] = Program.Группа1[2].ЗаброшенныеМячи[5];
                Program.Группа1[5].ПропущенныеМячи[3] = Program.Группа1[3].ЗаброшенныеМячи[5];
                Program.Группа1[5].ПропущенныеМячи[4] = Program.Группа1[4].ЗаброшенныеМячи[5];
                //
                Program.Группа2[0].ПропущенныеМячи[1] = Program.Группа2[1].ЗаброшенныеМячи[0];
                Program.Группа2[0].ПропущенныеМячи[2] = Program.Группа2[2].ЗаброшенныеМячи[0];
                Program.Группа2[0].ПропущенныеМячи[3] = Program.Группа2[3].ЗаброшенныеМячи[0];
                Program.Группа2[0].ПропущенныеМячи[4] = Program.Группа2[4].ЗаброшенныеМячи[0];
                Program.Группа2[0].ПропущенныеМячи[5] = Program.Группа2[5].ЗаброшенныеМячи[0];
                Program.Группа2[1].ПропущенныеМячи[0] = Program.Группа2[0].ЗаброшенныеМячи[1];
                Program.Группа2[1].ПропущенныеМячи[2] = Program.Группа2[2].ЗаброшенныеМячи[1];
                Program.Группа2[1].ПропущенныеМячи[3] = Program.Группа2[3].ЗаброшенныеМячи[1];
                Program.Группа2[1].ПропущенныеМячи[4] = Program.Группа2[4].ЗаброшенныеМячи[1];
                Program.Группа2[1].ПропущенныеМячи[5] = Program.Группа2[5].ЗаброшенныеМячи[1];
                Program.Группа2[2].ПропущенныеМячи[0] = Program.Группа2[0].ЗаброшенныеМячи[2];
                Program.Группа2[2].ПропущенныеМячи[1] = Program.Группа2[1].ЗаброшенныеМячи[2];
                Program.Группа2[2].ПропущенныеМячи[3] = Program.Группа2[3].ЗаброшенныеМячи[2];
                Program.Группа2[2].ПропущенныеМячи[4] = Program.Группа2[4].ЗаброшенныеМячи[2];
                Program.Группа2[2].ПропущенныеМячи[5] = Program.Группа2[5].ЗаброшенныеМячи[2];
                Program.Группа2[3].ПропущенныеМячи[0] = Program.Группа2[0].ЗаброшенныеМячи[3];
                Program.Группа2[3].ПропущенныеМячи[1] = Program.Группа2[1].ЗаброшенныеМячи[3];
                Program.Группа2[3].ПропущенныеМячи[2] = Program.Группа2[2].ЗаброшенныеМячи[3];
                Program.Группа2[3].ПропущенныеМячи[4] = Program.Группа2[4].ЗаброшенныеМячи[3];
                Program.Группа2[3].ПропущенныеМячи[5] = Program.Группа2[5].ЗаброшенныеМячи[3];
                Program.Группа2[4].ПропущенныеМячи[0] = Program.Группа2[0].ЗаброшенныеМячи[4];
                Program.Группа2[4].ПропущенныеМячи[1] = Program.Группа2[1].ЗаброшенныеМячи[4];
                Program.Группа2[4].ПропущенныеМячи[2] = Program.Группа2[2].ЗаброшенныеМячи[4];
                Program.Группа2[4].ПропущенныеМячи[3] = Program.Группа2[3].ЗаброшенныеМячи[4];
                Program.Группа2[4].ПропущенныеМячи[5] = Program.Группа2[5].ЗаброшенныеМячи[4];
                Program.Группа2[5].ПропущенныеМячи[0] = Program.Группа2[0].ЗаброшенныеМячи[5];
                Program.Группа2[5].ПропущенныеМячи[1] = Program.Группа2[1].ЗаброшенныеМячи[5];
                Program.Группа2[5].ПропущенныеМячи[2] = Program.Группа2[2].ЗаброшенныеМячи[5];
                Program.Группа2[5].ПропущенныеМячи[3] = Program.Группа2[3].ЗаброшенныеМячи[5];
                Program.Группа2[5].ПропущенныеМячи[4] = Program.Группа2[4].ЗаброшенныеМячи[5];

                //

                Program.Группа1[0].РазницаЗабИПроп[1] = Program.Группа1[0].ЗаброшенныеМячи[1] - Program.Группа1[0].ПропущенныеМячи[1];
                Program.Группа1[0].РазницаЗабИПроп[2] = Program.Группа1[0].ЗаброшенныеМячи[2] - Program.Группа1[0].ПропущенныеМячи[2];
                Program.Группа1[0].РазницаЗабИПроп[3] = Program.Группа1[0].ЗаброшенныеМячи[3] - Program.Группа1[0].ПропущенныеМячи[3];
                Program.Группа1[0].РазницаЗабИПроп[4] = Program.Группа1[0].ЗаброшенныеМячи[4] - Program.Группа1[0].ПропущенныеМячи[4];
                Program.Группа1[0].РазницаЗабИПроп[5] = Program.Группа1[0].ЗаброшенныеМячи[5] - Program.Группа1[0].ПропущенныеМячи[5];
                Program.Группа1[1].РазницаЗабИПроп[0] = Program.Группа1[1].ЗаброшенныеМячи[0] - Program.Группа1[1].ПропущенныеМячи[0];
                Program.Группа1[1].РазницаЗабИПроп[2] = Program.Группа1[1].ЗаброшенныеМячи[2] - Program.Группа1[1].ПропущенныеМячи[2];
                Program.Группа1[1].РазницаЗабИПроп[3] = Program.Группа1[1].ЗаброшенныеМячи[3] - Program.Группа1[1].ПропущенныеМячи[3];
                Program.Группа1[1].РазницаЗабИПроп[4] = Program.Группа1[1].ЗаброшенныеМячи[4] - Program.Группа1[1].ПропущенныеМячи[4];
                Program.Группа1[1].РазницаЗабИПроп[5] = Program.Группа1[1].ЗаброшенныеМячи[5] - Program.Группа1[1].ПропущенныеМячи[5];
                Program.Группа1[2].РазницаЗабИПроп[0] = Program.Группа1[2].ЗаброшенныеМячи[0] - Program.Группа1[2].ПропущенныеМячи[0];
                Program.Группа1[2].РазницаЗабИПроп[1] = Program.Группа1[2].ЗаброшенныеМячи[1] - Program.Группа1[2].ПропущенныеМячи[1];
                Program.Группа1[2].РазницаЗабИПроп[3] = Program.Группа1[2].ЗаброшенныеМячи[3] - Program.Группа1[2].ПропущенныеМячи[3];
                Program.Группа1[2].РазницаЗабИПроп[4] = Program.Группа1[2].ЗаброшенныеМячи[4] - Program.Группа1[2].ПропущенныеМячи[4];
                Program.Группа1[2].РазницаЗабИПроп[5] = Program.Группа1[2].ЗаброшенныеМячи[5] - Program.Группа1[2].ПропущенныеМячи[5];
                Program.Группа1[3].РазницаЗабИПроп[0] = Program.Группа1[3].ЗаброшенныеМячи[0] - Program.Группа1[3].ПропущенныеМячи[0];
                Program.Группа1[3].РазницаЗабИПроп[1] = Program.Группа1[3].ЗаброшенныеМячи[1] - Program.Группа1[3].ПропущенныеМячи[1];
                Program.Группа1[3].РазницаЗабИПроп[2] = Program.Группа1[3].ЗаброшенныеМячи[2] - Program.Группа1[3].ПропущенныеМячи[2];
                Program.Группа1[3].РазницаЗабИПроп[4] = Program.Группа1[3].ЗаброшенныеМячи[4] - Program.Группа1[3].ПропущенныеМячи[4];
                Program.Группа1[3].РазницаЗабИПроп[5] = Program.Группа1[3].ЗаброшенныеМячи[5] - Program.Группа1[3].ПропущенныеМячи[5];
                Program.Группа1[4].РазницаЗабИПроп[0] = Program.Группа1[4].ЗаброшенныеМячи[0] - Program.Группа1[4].ПропущенныеМячи[0];
                Program.Группа1[4].РазницаЗабИПроп[1] = Program.Группа1[4].ЗаброшенныеМячи[1] - Program.Группа1[4].ПропущенныеМячи[1];
                Program.Группа1[4].РазницаЗабИПроп[2] = Program.Группа1[4].ЗаброшенныеМячи[2] - Program.Группа1[4].ПропущенныеМячи[2];
                Program.Группа1[4].РазницаЗабИПроп[3] = Program.Группа1[4].ЗаброшенныеМячи[3] - Program.Группа1[4].ПропущенныеМячи[3];
                Program.Группа1[4].РазницаЗабИПроп[5] = Program.Группа1[4].ЗаброшенныеМячи[5] - Program.Группа1[4].ПропущенныеМячи[5];
                Program.Группа1[5].РазницаЗабИПроп[0] = Program.Группа1[5].ЗаброшенныеМячи[0] - Program.Группа1[5].ПропущенныеМячи[0];
                Program.Группа1[5].РазницаЗабИПроп[1] = Program.Группа1[5].ЗаброшенныеМячи[1] - Program.Группа1[5].ПропущенныеМячи[1];
                Program.Группа1[5].РазницаЗабИПроп[2] = Program.Группа1[5].ЗаброшенныеМячи[2] - Program.Группа1[5].ПропущенныеМячи[2];
                Program.Группа1[5].РазницаЗабИПроп[3] = Program.Группа1[5].ЗаброшенныеМячи[3] - Program.Группа1[5].ПропущенныеМячи[3];
                Program.Группа1[5].РазницаЗабИПроп[4] = Program.Группа1[5].ЗаброшенныеМячи[4] - Program.Группа1[5].ПропущенныеМячи[4];

                //

                Program.Группа2[0].РазницаЗабИПроп[1] = Program.Группа2[0].ЗаброшенныеМячи[1] - Program.Группа2[0].ПропущенныеМячи[1];
                Program.Группа2[0].РазницаЗабИПроп[2] = Program.Группа2[0].ЗаброшенныеМячи[2] - Program.Группа2[0].ПропущенныеМячи[2];
                Program.Группа2[0].РазницаЗабИПроп[3] = Program.Группа2[0].ЗаброшенныеМячи[3] - Program.Группа2[0].ПропущенныеМячи[3];
                Program.Группа2[0].РазницаЗабИПроп[4] = Program.Группа2[0].ЗаброшенныеМячи[4] - Program.Группа2[0].ПропущенныеМячи[4];
                Program.Группа2[0].РазницаЗабИПроп[5] = Program.Группа2[0].ЗаброшенныеМячи[5] - Program.Группа2[0].ПропущенныеМячи[5];
                Program.Группа2[1].РазницаЗабИПроп[0] = Program.Группа2[1].ЗаброшенныеМячи[0] - Program.Группа2[1].ПропущенныеМячи[0];
                Program.Группа2[1].РазницаЗабИПроп[2] = Program.Группа2[1].ЗаброшенныеМячи[2] - Program.Группа2[1].ПропущенныеМячи[2];
                Program.Группа2[1].РазницаЗабИПроп[3] = Program.Группа2[1].ЗаброшенныеМячи[3] - Program.Группа2[1].ПропущенныеМячи[3];
                Program.Группа2[1].РазницаЗабИПроп[4] = Program.Группа2[1].ЗаброшенныеМячи[4] - Program.Группа2[1].ПропущенныеМячи[4];
                Program.Группа2[1].РазницаЗабИПроп[5] = Program.Группа2[1].ЗаброшенныеМячи[5] - Program.Группа2[1].ПропущенныеМячи[5];
                Program.Группа2[2].РазницаЗабИПроп[0] = Program.Группа2[2].ЗаброшенныеМячи[0] - Program.Группа2[2].ПропущенныеМячи[0];
                Program.Группа2[2].РазницаЗабИПроп[1] = Program.Группа2[2].ЗаброшенныеМячи[1] - Program.Группа2[2].ПропущенныеМячи[1];
                Program.Группа2[2].РазницаЗабИПроп[3] = Program.Группа2[2].ЗаброшенныеМячи[3] - Program.Группа2[2].ПропущенныеМячи[3];
                Program.Группа2[2].РазницаЗабИПроп[4] = Program.Группа2[2].ЗаброшенныеМячи[4] - Program.Группа2[2].ПропущенныеМячи[4];
                Program.Группа2[2].РазницаЗабИПроп[5] = Program.Группа2[2].ЗаброшенныеМячи[5] - Program.Группа2[2].ПропущенныеМячи[5];
                Program.Группа2[3].РазницаЗабИПроп[0] = Program.Группа2[3].ЗаброшенныеМячи[0] - Program.Группа2[3].ПропущенныеМячи[0];
                Program.Группа2[3].РазницаЗабИПроп[1] = Program.Группа2[3].ЗаброшенныеМячи[1] - Program.Группа2[3].ПропущенныеМячи[1];
                Program.Группа2[3].РазницаЗабИПроп[2] = Program.Группа2[3].ЗаброшенныеМячи[2] - Program.Группа2[3].ПропущенныеМячи[2];
                Program.Группа2[3].РазницаЗабИПроп[4] = Program.Группа2[3].ЗаброшенныеМячи[4] - Program.Группа2[3].ПропущенныеМячи[4];
                Program.Группа2[3].РазницаЗабИПроп[5] = Program.Группа2[3].ЗаброшенныеМячи[5] - Program.Группа2[3].ПропущенныеМячи[5];
                Program.Группа2[4].РазницаЗабИПроп[0] = Program.Группа2[4].ЗаброшенныеМячи[0] - Program.Группа2[4].ПропущенныеМячи[0];
                Program.Группа2[4].РазницаЗабИПроп[1] = Program.Группа2[4].ЗаброшенныеМячи[1] - Program.Группа2[4].ПропущенныеМячи[1];
                Program.Группа2[4].РазницаЗабИПроп[2] = Program.Группа2[4].ЗаброшенныеМячи[2] - Program.Группа2[4].ПропущенныеМячи[2];
                Program.Группа2[4].РазницаЗабИПроп[3] = Program.Группа2[4].ЗаброшенныеМячи[3] - Program.Группа2[4].ПропущенныеМячи[3];
                Program.Группа2[4].РазницаЗабИПроп[5] = Program.Группа2[4].ЗаброшенныеМячи[5] - Program.Группа2[4].ПропущенныеМячи[5];
                Program.Группа2[5].РазницаЗабИПроп[0] = Program.Группа2[5].ЗаброшенныеМячи[0] - Program.Группа2[5].ПропущенныеМячи[0];
                Program.Группа2[5].РазницаЗабИПроп[1] = Program.Группа2[5].ЗаброшенныеМячи[1] - Program.Группа2[5].ПропущенныеМячи[1];
                Program.Группа2[5].РазницаЗабИПроп[2] = Program.Группа2[5].ЗаброшенныеМячи[2] - Program.Группа2[5].ПропущенныеМячи[2];
                Program.Группа2[5].РазницаЗабИПроп[3] = Program.Группа2[5].ЗаброшенныеМячи[3] - Program.Группа2[5].ПропущенныеМячи[3];
                Program.Группа2[5].РазницаЗабИПроп[4] = Program.Группа2[5].ЗаброшенныеМячи[4] - Program.Группа2[5].ПропущенныеМячи[4];

                for (int i = 0; i < КолСборГр; i++) // очки
                    for (int j = 0; j < КолСборГр; j++)
                    {
                        if (i != j)
                        {
                            
                            if (Program.Группа1[i].ЗаброшенныеМячи[j] > Program.Группа1[i].ПропущенныеМячи[j])

                            Program.Группа1[i].Результат +=1; 

                            if (Program.Группа2[i].ЗаброшенныеМячи[j] > Program.Группа2[i].ПропущенныеМячи[j])

                            Program.Группа2[i].Результат +=1; 
                        }
                        
                    }
                int max1 = int.MinValue;
                int max2 = int.MinValue;
                for (int i = 0; i < КолСборГр; i++)
                {
                    for (int j = 0; j < КолСборГр; j++)
                    {
                        if (i != j)
                        {
                            if (Program.Группа1[i].РазницаЗабИПроп[j] > max1)
                            {
                                max1 = Program.Группа1[i].РазницаЗабИПроп[j];
                                Program.Группа1[i].ЛучшаяРазница = max1;
                            }
                            if (Program.Группа2[i].РазницаЗабИПроп[j] > max2)
                            {
                                max2 = Program.Группа2[i].РазницаЗабИПроп[j];
                                Program.Группа2[i].ЛучшаяРазница = max2;
                            }
                        }
                    }
                    max1 = int.MinValue;
                    max2 = int.MinValue;
                }

                for (int i = 0; i < КолСборГр; i++)
                    for (int j = 0; j < КолСборГр; j++)
                    { 
                        Program.Группа1[i].СуммаПроп += Program.Группа1[i].ПропущенныеМячи[j];
                    }
                for (int i = 0; i < КолСборГр; i++)
                    for (int j = 0; j < КолСборГр; j++)
                    {
                        Program.Группа2[i].СуммаПроп += Program.Группа2[i].ПропущенныеМячи[j];
                    }


                Array.Sort(Program.Группа1, new Comparison<Сборные>(Сборные.СравнитьСБ));
                Array.Sort(Program.Группа2, new Comparison<Сборные>(Сборные.СравнитьСБ));
                Program.Группа1[0].МестоГруппа = 1;
                Program.Группа1[1].МестоГруппа = 2;
                Program.Группа1[2].МестоГруппа = 3;
                Program.Группа1[3].МестоГруппа = 4;
                Program.Группа1[4].МестоГруппа = 5;
                Program.Группа1[5].МестоГруппа = 6;
                //
                Program.Группа2[0].МестоГруппа = 1;
                Program.Группа2[1].МестоГруппа = 2;
                Program.Группа2[2].МестоГруппа = 3;
                Program.Группа2[3].МестоГруппа = 4;
                Program.Группа2[4].МестоГруппа = 5;
                Program.Группа2[5].МестоГруппа = 6;
                //
                Program.Четвертьфинал = new Сборные[8];
                for (int i = 0; i < Program.Четвертьфинал.Length; i++)
                {
                    Program.Четвертьфинал[i] = new Сборные();
                }
                Program.Полуфинал = new Сборные[4];
                for (int i = 0; i < Program.Полуфинал.Length; i++)
                {
                    Program.Полуфинал[i] = new Сборные();
                }
                Program.Финал = new Сборные[4];
                for (int i = 0; i < Program.Финал.Length; i++)
                {
                    Program.Финал[i] = new Сборные();
                }
                Program.Итог = new Сборные[4];
                for (int i = 0; i < Program.Итог.Length; i++)
                {
                    Program.Итог[i] = new Сборные();
                }
                Program.Четвертьфинал[0].Страна = Program.Группа1[0].Страна;
                Program.Четвертьфинал[1].Страна = Program.Группа1[1].Страна;
                Program.Четвертьфинал[2].Страна = Program.Группа1[2].Страна;
                Program.Четвертьфинал[3].Страна = Program.Группа1[3].Страна;
                Program.Четвертьфинал[4].Страна = Program.Группа2[0].Страна;
                Program.Четвертьфинал[5].Страна = Program.Группа2[1].Страна;
                Program.Четвертьфинал[6].Страна = Program.Группа2[2].Страна;
                Program.Четвертьфинал[7].Страна = Program.Группа2[3].Страна;


                //
                РасчетПоГр_button.Enabled = false;
                РезИгрГр1_button.Visible = true;
                РезИгрГр2_button.Visible = true;
                ДалееНа3Вк_button.Visible = true;
                РезультатСб11ЧФ_numericUpDown.Enabled = true;
                РезультатСб24ЧФ_numericUpDown.Enabled = true;
                ИмяСборной11ЧФ_label.Text = Program.Четвертьфинал[0].Страна;
                ИмяСборной24ЧФ_label.Text = Program.Четвертьфинал[7].Страна;
                ИмяСборной12ЧФ_label.Text = Program.Четвертьфинал[1].Страна;
                ИмяСборной23ЧФ_label.Text = Program.Четвертьфинал[6].Страна;
                ИмяСборной13ЧФ_label.Text = Program.Четвертьфинал[2].Страна;
                ИмяСборной22ЧФ_label.Text = Program.Четвертьфинал[5].Страна;
                ИмяСборной14ЧФ_label.Text = Program.Четвертьфинал[3].Страна;
                ИмяСборной21ЧФ_label.Text = Program.Четвертьфинал[4].Страна;

            }   
        }

        private void СледПараСборн_Click(object sender, EventArgs e)
        {
            

            if (НомерГр == 0)
            {
                Program.Группа1[а].ЗаброшенныеМячи[б] = (int)РезультатСб1_numericUpDown.Value;
                Program.Группа1[б].ЗаброшенныеМячи[а] = (int)РезультатСб2_numericUpDown.Value;
                РезультатСб1_numericUpDown.Value = РезультатСб2_numericUpDown.Value = 0;
                б++;
                if (б < 6)
                {
                    ИмяСборной2_label.Text = Program.Группа1[б].Страна;
                }
                else
                {
                    а++;
                    б = а + 1;
                    if (а == 5)
                    {
                        ГруппаИмя_label.Text = "Группа 2";
                        ИмяСборной1_label.Text = Program.Группа2[0].Страна;
                        ИмяСборной2_label.Text = Program.Группа2[1].Страна;
                        НомерГр =1;
                        а = 0;
                        б = 1;
                    }
                    else
                    {
                        ИмяСборной1_label.Text = Program.Группа1[а].Страна;
                        ИмяСборной2_label.Text = Program.Группа1[б].Страна;
                    }
                }
            }
            else
            {
                
                Program.Группа2[а].ЗаброшенныеМячи[б] = (int)РезультатСб1_numericUpDown.Value;
                Program.Группа2[б].ЗаброшенныеМячи[а] = (int)РезультатСб2_numericUpDown.Value;
                РезультатСб1_numericUpDown.Value = РезультатСб2_numericUpDown.Value = 0;
                б++;
                if (б < 6)
                {
                    ИмяСборной2_label.Text = Program.Группа2[б].Страна;
                }
                else
                {
                    а++;
                    б = а + 1;
                    if (а == 5)
                    {
                        СледПараСборн.Enabled = false;
                        РезультатСб1_numericUpDown.Enabled = false;
                        РезультатСб2_numericUpDown.Enabled = false;
                        РасчетПоГр_button.Visible = true;
                        ДалееНа3Вк_button.Visible = false; 
                    }
                    else
                    {
                        ИмяСборной1_label.Text = Program.Группа2[а].Страна;
                        ИмяСборной2_label.Text = Program.Группа2[б].Страна;
                    }

                }
            }
        }
        }
    }

