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
    public partial class РезультатыЧемпионата : Form
    {
        public void ВыводФ(Сборные[]array)
        {
            РезультатыЧемпионата_dataGridView.Columns.Add("НаименованиеСтраны", "Страна");
            РезультатыЧемпионата_dataGridView.Columns.Add("Место", "Место");
            РезультатыЧемпионата_dataGridView.Rows.Add(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                РезультатыЧемпионата_dataGridView["НаименованиеСтраны", i].Value = array[i].Страна;
                РезультатыЧемпионата_dataGridView["Место", i].Value = array[i].МестоИтог;

            }
            Show();
        }
        public РезультатыЧемпионата()
        {
            InitializeComponent();
        }

    }
}
