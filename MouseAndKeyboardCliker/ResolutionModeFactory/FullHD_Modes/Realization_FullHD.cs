using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAndKeyboardCliker
{
    public class Realization_FullHD : ModeBase
    {
        public override ElementCoords ExcelCell => _excelCell;

        public override ElementCoords ExcelTextField => _excelTextField;

        public override ElementCoords AddButton => _addButton;

        public override ElementCoords Nomenclature => _nomenclature;

        public override ElementCoords Amount => _amount;

        public override ElementCoords Price => _price;

        public override ElementCoords TransferPrice => throw new NotImplementedException();

        private ElementCoords _excelCell;
        private ElementCoords _excelTextField;
        private ElementCoords _addButton;
        private ElementCoords _nomenclature;
        private ElementCoords _amount;
        private ElementCoords _price;

        public Realization_FullHD()
        {
            _excelCell = new ElementCoords(1020, 293);

            _excelTextField = new ElementCoords(1220, 180, 1250, 215);

            _addButton = new ElementCoords(130, 550);

            _nomenclature = new ElementCoords(160, 750);
            _nomenclature.ContextMenuInsert = new Coords(_nomenclature.Field.X + 40, _nomenclature.Field.Y);
            _nomenclature.List = new Coords(200, 765);

            _amount = new ElementCoords(500, _nomenclature.Field.Y);
            _amount.ContextMenuInsert = new Coords(540, _nomenclature.ContextMenuInsert.Y);

            _price = new ElementCoords(710, _nomenclature.Field.Y);
            _price.ContextMenuInsert = new Coords(740, _nomenclature.ContextMenuInsert.Y);
        }

    }
}
