using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAndKeyboardCliker
{
    public class Realization_QuadHD : ModeBase
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

        public Realization_QuadHD()
        {
            _excelCell = new ElementCoords(1340, 325);

            _excelTextField = new ElementCoords(1540, 190, 1575, 230);

            _addButton = new ElementCoords(160, 720);

            _nomenclature = new ElementCoords(240, 960);
            _nomenclature.ContextMenuInsert = new Coords(_nomenclature.Field.X + 40, _nomenclature.Field.Y + 30);
            _nomenclature.List = new Coords(280, 985);

            _amount = new ElementCoords(750, _nomenclature.Field.Y);
            _amount.ContextMenuInsert = new Coords(800, _nomenclature.ContextMenuInsert.Y);

            _price = new ElementCoords(1015, _nomenclature.Field.Y);
            _price.ContextMenuInsert = new Coords(1055, _nomenclature.ContextMenuInsert.Y);
        }

    }
}
