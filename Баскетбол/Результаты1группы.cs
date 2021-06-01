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
    public partial class Результаты1группы : Form
    {
        public void Вывод(Сборные[] array)
        {
            {
                РезультатыГруппы_dataGridView.Columns.Add("НаименованиеСтраны", "Страна");
                РезультатыГруппы_dataGridView.Columns.Add("Место", "Место");


                РезультатыГруппы_dataGridView.Rows.Add(array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    РезультатыГруппы_dataGridView["НаименованиеСтраны", i].Value = array[i].Страна;
                    РезультатыГруппы_dataGridView["Место", i].Value = array[i].МестоГруппа;

                }
            }
            Show();
        }
        
        public Результаты1группы()
        {
            InitializeComponent();
        }
    }
}
