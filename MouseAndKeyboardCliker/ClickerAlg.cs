using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static MouseAndKeyboardCliker.InputSender;


namespace MouseAndKeyboardCliker
{
    public abstract class ClickerAlg
    {
        [DllImport("user32.dll")]
        protected static extern IntPtr GetMessageExtraInfo();

        protected static int stepTime = 420;

        protected abstract void ModesAdditionalTasks();

        protected ModeBase resMode;

        public ClickerAlg(ModeBase resMode)
        {
            this.resMode = resMode;
        }

        public void RunAlg(ModeBase resMode, int amountOfRecords)
        {
            int counter = 0;

            // 1. Клик по ячейке Excel с названием номенклатуры
            SetCursor(resMode.ExcelCell.Field.X, resMode.ExcelCell.Field.Y);
            LeftMouseClick();
            Thread.Sleep(stepTime);

            for (int i = 0; i < amountOfRecords; i++)
            {
                // 2. Получение данных из ячейки и копирование в буфер
                GetCellData(resMode.ExcelTextField);

                // Переход к 1C
                // 3. Установка курсора на кнопку "Добавить"
                SetCursor(resMode.AddButton.Field.X, resMode.AddButton.Field.Y);

                if (i == 0)
                {
                    while (counter < 24) // Чтобы не обрабатывать сдвиги при добавлении записи
                    {
                        LeftMouseClick();
                        Thread.Sleep(stepTime);
                        counter++;
                    }
                }
                LeftMouseClick();

                // 4. Установка курсора на поле "Номенклатура"
                SetCursor(resMode.Nomenclature.Field.X, resMode.Nomenclature.Field.Y);
                LeftMouseDblClick();
                Thread.Sleep(stepTime);

                // 5. Вставка текста
                UseContextMenu(resMode.Nomenclature.ContextMenuInsert.X, resMode.Nomenclature.ContextMenuInsert.Y);

                // 6. Выбор номенклатуры из списка
                SetCursor(resMode.Nomenclature.List.X, resMode.Nomenclature.List.Y);
                LeftMouseClick();
                Thread.Sleep(stepTime);

                // 7. Получение данных из следующей ячейки и копирование в буфер
                GetCellData(resMode.ExcelTextField);

                // 8. Установка курсора на поле "Количество" 
                SetCursor(resMode.Amount.Field.X, resMode.Amount.Field.Y);
                LeftMouseDblClick();
                LeftMouseDblClick();
                Thread.Sleep(stepTime);

                // 9. Вставка текста
                UseContextMenu(resMode.Amount.ContextMenuInsert.X, resMode.Amount.ContextMenuInsert.Y);

                // 10. Получение данных из следующей ячейки и копирование в буфер
                GetCellData(resMode.ExcelTextField);

                // 11. Установка курсора на поле "Цена"
                SetCursor(resMode.Price.Field.X, resMode.Price.Field.Y);
                LeftMouseDblClick();
                LeftMouseDblClick();
                Thread.Sleep(stepTime);

                // 12. Вставка текста
                UseContextMenu(resMode.Price.ContextMenuInsert.X, resMode.Price.ContextMenuInsert.Y);

                ModesAdditionalTasks();

                //switch (mode)
                //{
                //    case (int)Modes.realization:
                //        break;

                //    case (int)Modes.detalization:
                //        // 13. Установка курсора на поле "Цена передачи" 
                //        SetCursor(resMode.TransferPrice.Field.X, resMode.TransferPrice.Field.Y);
                //        LeftMouseDblClick();
                //        LeftMouseDblClick();
                //        Thread.Sleep(stepTime);

                //        // 14. Стирание текста
                //        ClickKey(0x0e);
                //        break;

                //    default:
                //        break;
                //}

                // 15. Переход к следующей записи
                GoToNextRecord(resMode.ExcelTextField);
            }

            //// 16. Удаление пустых записей
            //while (counter > 0)
            //{
            //    DeleteRecord();
            //    counter -= 2;
            //}
        }

        protected static void UseContextMenu(int x, int y)
        {
            Thread.Sleep(stepTime);
            RightMouseClick();
            SetCursor(x, y); // Установка курсора на контекстное меню
            Thread.Sleep(stepTime);
            LeftMouseClick();
            Thread.Sleep(stepTime);
        }

        protected static void GetCellData(ElementCoords excelTextField)
        {
            // 1. Клик по полю с текстом ячейки
            SetCursor(excelTextField.Field.X, excelTextField.Field.Y);
            LeftMouseDblClick();
            Thread.Sleep(stepTime);

            // 2. Выбор всего текста в поле
            SelectAll();
            Thread.Sleep(stepTime);

            // 3. Копирование текста
            UseContextMenu(excelTextField.ContextMenuInsert.X, excelTextField.ContextMenuInsert.Y);

            // 4. Переход к след. ячейке
            ClickKey(0x0f);
            Thread.Sleep(stepTime);
        }

        protected static void GoToNextRecord(ElementCoords excelTextField)
        {
            // 1. Клик по полю с текстом ячейки
            SetCursor(excelTextField.Field.X, excelTextField.Field.Y);
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

        protected static void DeleteRecord()
        {
            // 1. Установка курсора на запись
            SetCursor(240, 760);
            LeftMouseClick();

            // 2. Удаление
            UseContextMenu(280, 790);
        }


        #region Мышь

        protected static void SetCursor(int x, int y)
        {
            SetCursorPosition(x, y);
        }

        protected static void RightMouseClick()
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

        protected static void LeftMouseClick()
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

        protected static void LeftMouseDblClick()
        {
            LeftMouseClick();
            LeftMouseClick();
        }

        protected static void SelectAll()
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

        protected static void PressSpecButton(ushort code)
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
