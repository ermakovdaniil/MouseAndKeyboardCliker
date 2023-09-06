using System;
using System.Runtime.InteropServices;
using System.Threading;
using static MouseAndKeyboardCliker.InputSender;

namespace MouseAndKeyboardCliker
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        private enum ScreenResolution { DCI2K = 1, FullHD } // DCI2K (2560x1440), FullHD (1980x1080)

        private enum Modes { realization = 1, detalization }

        private static int stepTime = 430;

        private static CoordStruct excelCell = new CoordStruct(1340, 325); // TODO
        private static CoordStruct excelTextField = new CoordStruct(1540, 190, 1575, 230);

        public static void Main()
        {
            Console.WriteLine("Разрешение экрана: ");
            Console.WriteLine("1. 2560x1440 | 2. 1980x1080 ");
            int resolution = int.Parse(Console.ReadLine());

            Console.WriteLine("Режим работы: ");
            Console.WriteLine("1. Реализация | 2. Детализация за неделю ");
            int mode = int.Parse(Console.ReadLine());

            Console.WriteLine("\nУкажите количество записей: ");
            int amountOfRecords = int.Parse(Console.ReadLine());
            
            int counter = 0;

            var addButton = new CoordStruct();
            var nomenclature = new CoordStruct();
            var amount = new CoordStruct();
            var price = new CoordStruct();
            var transferPrice = new CoordStruct();

            switch (mode)
            {
                case (int)Modes.realization:
                    addButton.field_X = 160;
                    addButton.field_Y = 700;

                    nomenclature.field_X = 240;
                    nomenclature.field_Y = 940;

                    nomenclature.contextMenuInsert_X = nomenclature.field_X + 40;
                    nomenclature.contextMenuInsert_Y = nomenclature.field_Y + 30;

                    nomenclature.list_X = 280;
                    nomenclature.list_Y = 970;

                    amount.field_X = 750;
                    amount.field_Y = nomenclature.field_Y;

                    amount.contextMenuInsert_X = 800;
                    amount.contextMenuInsert_Y = nomenclature.contextMenuInsert_Y;

                    price.field_X = 1015;
                    price.field_Y = nomenclature.field_Y;

                    price.contextMenuInsert_X = 1055;
                    price.contextMenuInsert_Y = nomenclature.contextMenuInsert_Y;

                    break;

                case (int)Modes.detalization:
                    addButton.field_X = 200;
                    addButton.field_Y = 705;

                    nomenclature.field_X = 250;
                    nomenclature.field_Y = 990;

                    nomenclature.contextMenuInsert_X = nomenclature.field_X + 50;
                    nomenclature.contextMenuInsert_Y = nomenclature.field_Y - 20;

                    nomenclature.list_X = 300;
                    nomenclature.list_Y = 920;

                    amount.field_X = 750;
                    amount.field_Y = nomenclature.field_Y;

                    amount.contextMenuInsert_X = 800;
                    amount.contextMenuInsert_Y = nomenclature.contextMenuInsert_Y;

                    price.field_X = 900;
                    price.field_Y = nomenclature.field_Y;

                    price.contextMenuInsert_X = 950;
                    price.contextMenuInsert_Y = nomenclature.contextMenuInsert_Y;

                    transferPrice.field_X = 1100;
                    transferPrice.field_Y = nomenclature.field_Y;

                    break;

                default:
                    break;
            }

            switch (resolution)
            {
                case (int)ScreenResolution.DCI2K:
                    break;

                case (int)ScreenResolution.FullHD:

                    excelCell.field_X = excelCell.field_X * 1980 / 2480; 
                    excelCell.field_Y = excelCell.field_Y * 1080 / 1440;

                    excelTextField.field_X = excelTextField.field_X * 1980 / 2480; // 1220 180 и 1540 190
                    excelTextField.field_Y = excelTextField.field_Y * 1080 / 1440;

                    excelTextField.contextMenuInsert_X = excelTextField.contextMenuInsert_X * 1980 / 2480;
                    excelTextField.contextMenuInsert_Y = excelTextField.contextMenuInsert_Y * 1080 / 1440;

                    addButton.field_X = addButton.field_X * 1980 / 2480;
                    addButton.field_Y = addButton.field_Y * 1080 / 1440;

                    nomenclature.field_X = nomenclature.field_X * 1980 / 2480;
                    nomenclature.field_Y = nomenclature.field_Y * 1080 / 1440;

                    nomenclature.contextMenuInsert_X = nomenclature.contextMenuInsert_X * 1980 / 2480;
                    nomenclature.contextMenuInsert_Y = nomenclature.contextMenuInsert_Y * 1080 / 1440;

                    nomenclature.list_X = nomenclature.list_X * 1980 / 2480;
                    nomenclature.list_Y = nomenclature.list_Y * 1080 / 1440;

                    amount.field_X = amount.field_X * 1980 / 2480;
                    amount.field_Y = amount.field_Y * 1080 / 1440;

                    amount.contextMenuInsert_X = amount.contextMenuInsert_X * 1980 / 2480;
                    amount.contextMenuInsert_Y = amount.contextMenuInsert_Y * 1080 / 1440;

                    price.field_X = price.field_X * 1980 / 2480;
                    price.field_Y = price.field_Y * 1080 / 1440;

                    price.contextMenuInsert_X = price.contextMenuInsert_X * 1980 / 2480;
                    price.contextMenuInsert_Y = price.contextMenuInsert_Y * 1080 / 1440;

                    transferPrice.field_X = transferPrice.field_X * 1980 / 2480;
                    transferPrice.field_Y = transferPrice.field_Y * 1080 / 1440;

                    break;

                default:
                    break;
            }

            // 1. Клик по ячейке Excel с названием номенклатуры
            SetCursor(excelCell.field_X, excelCell.field_Y);
            LeftMouseClick();
            Thread.Sleep(stepTime);

            for (int i = 0; i < amountOfRecords; i++)
            {
                // 2. Получение данных из ячейки и копирование в буфер
                GetCellData();

                // Переход к 1C
                // 3. Установка курсора на кнопку "Добавить"
                SetCursor(addButton.field_X, addButton.field_Y);

                if (i == 0)
                {
                    while (counter < 22) // Чтобы не обрабатывать сдвиги при добавлении записи
                    {
                        LeftMouseClick();
                        Thread.Sleep(stepTime);
                        counter++;
                    }
                }
                LeftMouseClick();

                // 4. Установка курсора на поле "Номенклатура"
                SetCursor(nomenclature.field_X, nomenclature.field_Y);
                LeftMouseDblClick();
                Thread.Sleep(stepTime);

                // 5. Вставка текста
                UseContextMenu(nomenclature.contextMenuInsert_X, nomenclature.contextMenuInsert_Y);

                // 6. Выбор номенклатуры из списка
                SetCursor(nomenclature.list_X, nomenclature.list_Y);
                LeftMouseClick();
                Thread.Sleep(stepTime);

                // 7. Получение данных из следующей ячейки и копирование в буфер
                GetCellData();

                // 8. Установка курсора на поле "Количество" 
                SetCursor(amount.field_X, amount.field_Y);
                LeftMouseDblClick();
                LeftMouseDblClick();
                Thread.Sleep(stepTime);

                // 9. Вставка текста
                UseContextMenu(amount.contextMenuInsert_X, amount.contextMenuInsert_Y);

                // 10. Получение данных из следующей ячейки и копирование в буфер
                GetCellData();

                // 11. Установка курсора на поле "Цена"
                SetCursor(price.field_X, price.field_Y);
                LeftMouseDblClick();
                LeftMouseDblClick();
                Thread.Sleep(stepTime);

                // 12. Вставка текста
                UseContextMenu(price.contextMenuInsert_X, price.contextMenuInsert_Y);

                switch (mode)
                {
                    case (int)Modes.realization:
                        break;

                    case (int)Modes.detalization:
                        // 13. Установка курсора на поле "Цена передачи" 
                        SetCursor(transferPrice.field_X, transferPrice.field_Y);
                        LeftMouseDblClick();
                        LeftMouseDblClick();
                        Thread.Sleep(stepTime);

                        // 14. Стирание текста
                        ClickKey(0x0e);
                        break;

                    default:
                        break;
                }

                // 15. Переход к следующей записи
                GoToNextRecord();
            }

            //// 16. Удаление пустых записей
            //while (counter > 0)
            //{
            //    DeleteRecord();
            //    counter -= 2;
            //}

        }

        private static void UseContextMenu(int x, int y)
        {
            Thread.Sleep(stepTime);
            RightMouseClick();
            SetCursor(x, y); // Установка курсора на контекстное меню
            Thread.Sleep(stepTime);
            LeftMouseClick();
            Thread.Sleep(stepTime);
        }

        private static void GetCellData()
        {
            // 1. Клик по полю с текстом ячейки
            SetCursor(excelTextField.field_X, excelTextField.field_Y);
            LeftMouseDblClick();
            Thread.Sleep(stepTime);

            // 2. Выбор всего текста в поле
            SelectAll();
            Thread.Sleep(stepTime);

            // 3. Копирование текста
            UseContextMenu(excelTextField.contextMenuInsert_X, excelTextField.contextMenuInsert_Y);

            // 4. Переход к след. ячейке
            ClickKey(0x0f);
            Thread.Sleep(stepTime);
        }

        private static void GoToNextRecord()
        {
            // 1. Клик по полю с текстом ячейки
            SetCursor(excelTextField.field_X, excelTextField.field_Y);
            LeftMouseClick();
            Thread.Sleep(stepTime);

            // 2. Шаг на клетку вниз
            PressSpecButton(0x50);
            Thread.Sleep(stepTime);

            // 3. Три шага на клетку влево
            PressSpecButton(0x4B);
            Thread.Sleep(stepTime);
            PressSpecButton(0x4B);
            Thread.Sleep(stepTime);
            PressSpecButton(0x4B);
            Thread.Sleep(stepTime);
        }

        private static void DeleteRecord()
        {
            // 1. Установка курсора на запись
            SetCursor(240, 760);
            LeftMouseClick();

            // 2. Удаление
            UseContextMenu(280, 790);
        }


        #region Мышь

        private static void SetCursor(int x, int y)
        {
            SetCursorPosition(x, y);
        }

        private static void RightMouseClick()
        {
            SendMouseInput(new MouseInput[]
            {
                new MouseInput
                {
                    dwFlags = (uint)MouseEventF.RightDown
                },
                new MouseInput
                {
                    dwFlags = (uint)MouseEventF.RightUp
                }
            });
        }

        private static void LeftMouseClick()
        {
            SendMouseInput(new MouseInput[]
            {
                new MouseInput
                {
                    dwFlags = (uint)MouseEventF.LeftDown
                },
                new MouseInput
                {
                    dwFlags = (uint)MouseEventF.LeftUp
                }
            });
        }

        private static void LeftMouseDblClick()
        {
            LeftMouseClick();
            LeftMouseClick();
        }

        private static void SelectAll()
        {
            LeftMouseClick();
            LeftMouseClick();
            LeftMouseClick();
        }

        #endregion


        #region Клавиатура
       
        // https://gist.github.com/dretax/fe37b8baf55bc30e9d63
        //private static void ClickKey(ushort code)
        //{
        //    SendKeyboardInput(new KeyboardInput[]
        //    {
        //        new KeyboardInput
        //        {
        //            wScan = code,
        //            dwFlags = (uint)(KeyEventF.ExtendedKey | KeyEventF.Scancode)
        //        }
        //    });
        //}

        private static void PressSpecButton(ushort code)
        {
            SendKeyboardInput(new KeyboardInput[]
            {
                new KeyboardInput
                {
                    wScan = 0xe0,
                    dwFlags = (uint)(KeyEventF.ExtendedKey | KeyEventF.Scancode),
                },
                new KeyboardInput
                {
                    wScan = code,
                    dwFlags = (uint)(KeyEventF.ExtendedKey | KeyEventF.Scancode)
                }
            });
        }

        #endregion
    }
}
