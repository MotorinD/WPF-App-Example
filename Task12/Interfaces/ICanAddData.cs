using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    /// <summary>
    /// Для определения имеет ли Пользователь возможность добавлять новые данные
    /// </summary>
    internal interface ICanAddData
    {
        public bool IsCanAddData();
    }
}
