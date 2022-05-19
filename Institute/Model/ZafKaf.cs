using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Institute;

namespace Institute.Model
{
    public partial class ЗавКафедрой
    {
        public string FIO => String.Format("{0} {1} {2}", Фамилия, Имя, Отчество);
    }
}
