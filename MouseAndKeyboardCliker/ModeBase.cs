using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAndKeyboardCliker
{
    public abstract class ModeBase
    {
        public abstract ElementCoords ExcelCell { get; }
        public abstract ElementCoords ExcelTextField { get; }
        public abstract ElementCoords AddButton { get; }
        public abstract ElementCoords Nomenclature { get; }
        public abstract ElementCoords Amount { get; }
        public abstract ElementCoords Price { get; }
        public abstract ElementCoords TransferPrice { get; }
    }
}
