using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAndKeyboardCliker
{
    public class Detalization_QuadHD : ModeBase
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

        public Detalization_QuadHD()
        {
            _excelCell = new ElementCoords(1340, 325);

            _excelTextField = new ElementCoords(1540, 190, 1575, 230);

            _addButton = new ElementCoords(200, 705);

            //_nomenclature = new ElementCoords(260, 1010);
            //_nomenclature.ContextMenuInsert = new Coords(_nomenclature.Field.X + 50, _nomenclature.Field.Y - 20);
            //_nomenclature.List = new Coords(300, 940);

            _nomenclature = new ElementCoords(260, 990);
            _nomenclature.ContextMenuInsert = new Coords(_nomenclature.Field.X + 50, _nomenclature.Field.Y);
            _nomenclature.List = new Coords(300, 1010);

            _amount = new ElementCoords(750, _nomenclature.Field.Y);
            _amount.ContextMenuInsert = new Coords(800, _nomenclature.ContextMenuInsert.Y);

            _price = new ElementCoords(900, _nomenclature.Field.Y);
            _price.ContextMenuInsert = new Coords(950, _nomenclature.ContextMenuInsert.Y);

            _transferPrice = new ElementCoords(1100, _nomenclature.Field.Y);
        }

    }
}
