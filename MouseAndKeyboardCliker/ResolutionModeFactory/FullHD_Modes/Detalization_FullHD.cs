using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAndKeyboardCliker
{
    public class Detalization_FullHD : ModeBase
    {
        public override ElementCoords ExcelCell => _excelCell;

        public override ElementCoords ExcelTextField => _excelTextField;

        public override ElementCoords AddButton => _addButton;

        public override ElementCoords Nomenclature => _nomenclature;

        public override ElementCoords Amount => _amount;

        public override ElementCoords Price => _price;

        public override ElementCoords TransferPrice => _transferPrice;

        private ElementCoords _excelCell;
        private ElementCoords _excelTextField;
        private ElementCoords _addButton;
        private ElementCoords _nomenclature;
        private ElementCoords _amount;
        private ElementCoords _price;
        private ElementCoords _transferPrice;

        public Detalization_FullHD()
        {
            _excelCell = new ElementCoords(1020, 293);

            _excelTextField = new ElementCoords(1220, 180, 1250, 215);

            _addButton = new ElementCoords(150, 555);

            _nomenclature = new ElementCoords(200, 770);
            _nomenclature.ContextMenuInsert = new Coords(_nomenclature.Field.X + 40, _nomenclature.Field.Y - 15);
            _nomenclature.List = new Coords(240, 720);

            _amount = new ElementCoords(570, _nomenclature.Field.Y);
            _amount.ContextMenuInsert = new Coords(610, _nomenclature.ContextMenuInsert.Y);

            _price = new ElementCoords(690, _nomenclature.Field.Y);
            _price.ContextMenuInsert = new Coords(730, _nomenclature.ContextMenuInsert.Y);

            _transferPrice = new ElementCoords(850, _nomenclature.Field.Y);
        }

    }
}
