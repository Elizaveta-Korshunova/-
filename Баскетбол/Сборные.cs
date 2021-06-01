using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Баскетбол
{
    public class Сборные
    {
        public string Страна;
        public int ИндексРезультатов;
        public int[] ЗаброшенныеМячи;
        public int[] ПропущенныеМячи;
        public int[] РазницаЗабИПроп;
        public int Результат;
        public int ЛучшаяРазница;
        public int СуммаПроп;
        public int МестоГруппа;
        public int МестоИтог;


        public static int СравнитьСБ(Сборные a, Сборные b)
        {
            if (a.Результат > b.Результат) // по очкам
                return -1;
            else if (a.Результат < b.Результат)
                return 1;
            else if (a.ЛучшаяРазница > b.ЛучшаяРазница) // по лучшей разнице пропущенных и заброшенных мячей
                return -1;
            else if (a.ЛучшаяРазница < b.ЛучшаяРазница)
                return 1;
            else if (a.СуммаПроп < b.СуммаПроп) // по наименьшему количеству пропущенных мячей
                return -1;
            else if (a.СуммаПроп > b.СуммаПроп)
                return 1;
            else if (a.ЗаброшенныеМячи[b.ИндексРезультатов] > b.ЗаброшенныеМячи[a.ИндексРезультатов]) // по результатам игр между собой
                return -1;
            else if (a.ЗаброшенныеМячи[b.ИндексРезультатов] < b.ЗаброшенныеМячи[a.ИндексРезультатов])
                return 1;
            else
                return 0;
        }
    }
}
