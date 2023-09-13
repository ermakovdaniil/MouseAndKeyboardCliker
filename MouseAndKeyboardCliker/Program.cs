using System;
using System.Runtime.InteropServices;
using System.Threading;
using static MouseAndKeyboardCliker.InputSender;

namespace MouseAndKeyboardCliker
{
    public class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        public enum ScreenResolutions { QuadHD = 1, FullHD } // DCI2K (2560x1440), FullHD (1980x1080)

        public enum Modes { realization = 1, detalization }



        //private static ElementCoords excelCell = new ElementCoords(1340, 325); // TODO
        //private static ElementCoords excelTextField = new ElementCoords(1540, 190, 1575, 230);

        public static void Main()
        {
            Console.WriteLine("Разрешение экрана: ");
            Console.WriteLine("1. 2560x1440 | 2. 1980x1080 ");
            var resolution = (ScreenResolutions)Enum.Parse(typeof(ScreenResolutions), Console.ReadLine());

            Console.WriteLine("Режим работы: ");
            Console.WriteLine("1. Реализация | 2. Детализация за неделю ");
            var mode = (Modes)Enum.Parse(typeof(Modes), Console.ReadLine());

            Console.WriteLine("\nУкажите количество записей: ");
            int amountOfRecords = int.Parse(Console.ReadLine());
            
            int counter = 0;

            var resMode = ResolutionModeFactory.Create(resolution, mode);

            var ClickerAlg = AlgFactory.Create(resMode, mode);

            ClickerAlg.RunAlg(resMode, amountOfRecords);

            //var addButton = new ElementCoords();
            //var nomenclature = new ElementCoords();
            //var amount = new ElementCoords();
            //var price = new ElementCoords();
            //var transferPrice = new ElementCoords();

            //switch (mode)
            //{
            //    case Modes.realization:
            //        addButton.Field_X = 160;
            //        addButton.Field_Y = 700;

            //        nomenclature.Field_X = 240;
            //        nomenclature.Field_Y = 940;

            //        nomenclature.ContextMenuInsert_X = nomenclature.Field_X + 40;
            //        nomenclature.ContextMenuInsert_Y = nomenclature.Field_Y + 30;

            //        nomenclature.List_X = 280;
            //        nomenclature.List_Y = 970;

            //        amount.Field_X = 750;
            //        amount.Field_Y = nomenclature.Field_Y;

            //        amount.ContextMenuInsert_X = 800;
            //        amount.ContextMenuInsert_Y = nomenclature.ContextMenuInsert_Y;

            //        price.Field_X = 1015;
            //        price.Field_Y = nomenclature.Field_Y;

            //        price.ContextMenuInsert_X = 1055;
            //        price.ContextMenuInsert_Y = nomenclature.ContextMenuInsert_Y;

            //        break;

            //    case Modes.detalization:
            //        addButton.Field_X = 200;
            //        addButton.Field_Y = 705;

            //        nomenclature.Field_X = 250;
            //        nomenclature.Field_Y = 990;

            //        nomenclature.ContextMenuInsert_X = nomenclature.Field_X + 50;
            //        nomenclature.ContextMenuInsert_Y = nomenclature.Field_Y - 20;

            //        nomenclature.List_X = 300;
            //        nomenclature.List_Y = 920;

            //        amount.Field_X = 750;
            //        amount.Field_Y = nomenclature.Field_Y;

            //        amount.ContextMenuInsert_X = 800;
            //        amount.ContextMenuInsert_Y = nomenclature.ContextMenuInsert_Y;

            //        price.Field_X = 900;
            //        price.Field_Y = nomenclature.Field_Y;

            //        price.ContextMenuInsert_X = 950;
            //        price.ContextMenuInsert_Y = nomenclature.ContextMenuInsert_Y;

            //        transferPrice.Field_X = 1100;
            //        transferPrice.Field_Y = nomenclature.Field_Y;

            //        break;

            //    default:
            //        break;
            //}

            //switch (resolution)
            //{
            //    case ScreenResolutions.DCI2K:
            //        break;

            //    case ScreenResolutions.FullHD:

            //        excelCell.Field_X = excelCell.Field_X * 1980 / 2480;
            //        excelCell.Field_Y = excelCell.Field_Y * 1080 / 1440;

            //        excelTextField.Field_X = excelTextField.Field_X * 1980 / 2480;
            //        excelTextField.Field_Y = excelTextField.Field_Y * 1080 / 1440;

            //        excelTextField.ContextMenuInsert_X = excelTextField.ContextMenuInsert_X * 1980 / 2480;
            //        excelTextField.ContextMenuInsert_Y = excelTextField.ContextMenuInsert_Y * 1080 / 1440;

            //        addButton.Field_X = addButton.Field_X * 1980 / 2480;
            //        addButton.Field_Y = addButton.Field_Y * 1080 / 1440;

            //        nomenclature.Field_X = nomenclature.Field_X * 1980 / 2480;
            //        nomenclature.Field_Y = nomenclature.Field_Y * 1080 / 1440;

            //        nomenclature.ContextMenuInsert_X = nomenclature.ContextMenuInsert_X * 1980 / 2480;
            //        nomenclature.ContextMenuInsert_Y = nomenclature.ContextMenuInsert_Y * 1080 / 1440;

            //        nomenclature.List_X = nomenclature.List_X * 1980 / 2480;
            //        nomenclature.List_Y = nomenclature.List_Y * 1080 / 1440;

            //        amount.Field_X = amount.Field_X * 1980 / 2480;
            //        amount.Field_Y = amount.Field_Y * 1080 / 1440;

            //        amount.ContextMenuInsert_X = amount.ContextMenuInsert_X * 1980 / 2480;
            //        amount.ContextMenuInsert_Y = amount.ContextMenuInsert_Y * 1080 / 1440;

            //        price.Field_X = price.Field_X * 1980 / 2480;
            //        price.Field_Y = price.Field_Y * 1080 / 1440;

            //        price.ContextMenuInsert_X = price.ContextMenuInsert_X * 1980 / 2480;
            //        price.ContextMenuInsert_Y = price.ContextMenuInsert_Y * 1080 / 1440;

            //        transferPrice.Field_X = transferPrice.Field_X * 1980 / 2480;
            //        transferPrice.Field_Y = transferPrice.Field_Y * 1080 / 1440;

            //        break;

            //    default:
            //        break;
            //}

            // 1. Клик по ячейке Excel с названием номенклатуры
            //SetCursor(excelCell.Field_X, excelCell.Field_Y);
            //LeftMouseClick();
            //Thread.Sleep(stepTime);

            //for (int i = 0; i < amountOfRecords; i++)
            //{
            //    // 2. Получение данных из ячейки и копирование в буфер
            //    GetCellData();

            //    // Переход к 1C
            //    // 3. Установка курсора на кнопку "Добавить"
            //    SetCursor(addButton.Field_X, addButton.Field_Y);

            //    if (i == 0)
            //    {
            //        while (counter < 22) // Чтобы не обрабатывать сдвиги при добавлении записи
            //        {
            //            LeftMouseClick();
            //            Thread.Sleep(stepTime);
            //            counter++;
            //        }
            //    }
            //    LeftMouseClick();

            //    // 4. Установка курсора на поле "Номенклатура"
            //    SetCursor(nomenclature.Field_X, nomenclature.Field_Y);
            //    LeftMouseDblClick();
            //    Thread.Sleep(stepTime);

            //    // 5. Вставка текста
            //    UseContextMenu(nomenclature.ContextMenuInsert_X, nomenclature.ContextMenuInsert_Y);

            //    // 6. Выбор номенклатуры из списка
            //    SetCursor(nomenclature.List_X, nomenclature.List_Y);
            //    LeftMouseClick();
            //    Thread.Sleep(stepTime);

            //    // 7. Получение данных из следующей ячейки и копирование в буфер
            //    GetCellData();

            //    // 8. Установка курсора на поле "Количество" 
            //    SetCursor(amount.Field_X, amount.Field_Y);
            //    LeftMouseDblClick();
            //    LeftMouseDblClick();
            //    Thread.Sleep(stepTime);

            //    // 9. Вставка текста
            //    UseContextMenu(amount.ContextMenuInsert_X, amount.ContextMenuInsert_Y);

            //    // 10. Получение данных из следующей ячейки и копирование в буфер
            //    GetCellData();

            //    // 11. Установка курсора на поле "Цена"
            //    SetCursor(price.Field_X, price.Field_Y);
            //    LeftMouseDblClick();
            //    LeftMouseDblClick();
            //    Thread.Sleep(stepTime);

            //    // 12. Вставка текста
            //    UseContextMenu(price.ContextMenuInsert_X, price.ContextMenuInsert_Y);

            //    switch (mode)
            //    {
            //        case (int)Modes.realization:
            //            break;

            //        case (int)Modes.detalization:
            //            // 13. Установка курсора на поле "Цена передачи" 
            //            SetCursor(transferPrice.Field_X, transferPrice.Field_Y);
            //            LeftMouseDblClick();
            //            LeftMouseDblClick();
            //            Thread.Sleep(stepTime);

            //            // 14. Стирание текста
            //            ClickKey(0x0e);
            //            break;

            //        default:
            //            break;
            //    }

            //    // 15. Переход к следующей записи
            //    GoToNextRecord();
            //}

            //// 16. Удаление пустых записей
            //while (counter > 0)
            //{
            //    DeleteRecord();
            //    counter -= 2;
            //}

        }


    }
}
