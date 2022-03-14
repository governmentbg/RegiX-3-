using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.Core
{
    /// <summary>
    /// Начин на обработка
    /// </summary>
    enum ProcessType
    {
        /// <summary>
        /// Използва се извикване на конкретна операция от адаптер
        /// </summary>
        Normal,

        /// <summary>
        /// Използва се извикване на общата операция на адаптера. Заявкта се препредава към адаптера.
        /// </summary>
        TransparentCore
    }
}
