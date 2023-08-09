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

        private enum modes { realization = 1, detalization }

        public static void Main() // TODO: сделать два набора чисел и менять просто в одном свитче
        {
            Console.WriteLine("Режим работы: ");
            Console.WriteLine("1. Реализация | 2. Детализация за неделю ");
            int mode = int.Parse(Console.ReadLine());
            Console.WriteLine("\nУкажите количество записей: ");
            int amountOfRecords = int.Parse(Console.ReadLine());
            int counter = 0;

            // 1. Клик по ячейке Excel с названием номенклатуры
            SetCursor(1340, 325);
            LeftMouseClick();
            Thread.Sleep(430);

            for (int i = 0; i < amountOfRecords; i++)
            {
                // 2. Получение данных из ячейки и копирование в буфер
                GetCellData();

                // Переход к 1C
                // 3. Установка курсора на кнопку "Добавить"
                switch (mode)
                {
                    case (int)modes.realization:
                        SetCursor(160, 700);
                        break;
                    case (int)modes.detalization:
                        SetCursor(200, 705);
                        break;
                    default:
                        break;
                }

                if (i == 0)
                {
                    while (counter < 22) // Чтобы не обрабатывать сдвиги при добавлении записи
                    {
                        LeftMouseClick();
                        Thread.Sleep(430);
                        counter++;
                    }
                }
                LeftMouseClick();

                // 4. Установка курсора на поле "Номенклатура"
                switch (mode)
                {
                    case (int)modes.realization:
                        SetCursor(240, 940);
                        break;
                    case (int)modes.detalization:
                        SetCursor(240, 960);
                        break;
                    default:
                        break;
                }    
                LeftMouseDblClick();
                Thread.Sleep(430);

                // 5. Вставка текста
                UseContextMenu(280, 970);

                // 6. Выбор номенклатуры из списка
                switch (mode)
                {
                    case (int)modes.realization:
                        SetCursor(280, 970);
                        break;
                    case (int)modes.detalization:
                        SetCursor(290, 980);
                        break;
                    default:
                        break;
                }

                LeftMouseClick();
                Thread.Sleep(430);

                // 7. Получение данных из следующей ячейки и копирование в буфер
                GetCellData();

                // 8. Установка курсора на поле "Количество" 
                switch (mode)
                {
                    case (int)modes.realization:
                        SetCursor(750, 940);
                        break;
                    case (int)modes.detalization:
                        SetCursor(750, 960);
                        break;
                    default:
                        break;
                }
                LeftMouseDblClick();
                LeftMouseDblClick();
                Thread.Sleep(430);

                // 9. Вставка текста
                UseContextMenu(800, 970);

                // 10. Получение данных из следующей ячейки и копирование в буфер
                GetCellData();

                // 11. Установка курсора на поле "Цена"
                switch (mode)
                {
                    case (int)modes.realization:
                        SetCursor(1015, 940);
                        break;
                    case (int)modes.detalization:
                        SetCursor(900, 960);
                        break;
                    default:
                        break;
                }              
                LeftMouseDblClick();
                LeftMouseDblClick();
                Thread.Sleep(430);

                // 12. Вставка текста
                switch (mode)
                {
                    case (int)modes.realization:
                        UseContextMenu(1055, 970);
                        break;
                    case (int)modes.detalization:
                        UseContextMenu(950, 970);
                        break;
                    default:
                        break;
                }
                


                switch (mode)
                {
                    case (int)modes.realization:
                        break;
                    case (int)modes.detalization:
                        // 13. Установка курсора на поле "Цена передачи" 
                        SetCursor(1100, 960);
                        LeftMouseDblClick();
                        LeftMouseDblClick();
                        Thread.Sleep(430);

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
            Thread.Sleep(430);
            RightMouseClick();
            SetCursor(x, y); // Установка курсора на контекстное меню
            Thread.Sleep(430);
            LeftMouseClick();
            Thread.Sleep(430);
        }

        private static void GetCellData()
        {
            // 1. Клик по полю с текстом ячейки
            SetCursor(1540, 190);
            LeftMouseDblClick();
            Thread.Sleep(430);

            // 2. Выбор всего текста в поле
            SelectAll();
            Thread.Sleep(430);

            // 3. Копирование текста
            UseContextMenu(1575, 230);

            // 4. Переход к след. ячейке
            ClickKey(0x0f);
            Thread.Sleep(430);
        }

        private static void GoToNextRecord()
        {
            // 1. Клик по полю с текстом ячейки
            SetCursor(1540, 190);
            LeftMouseClick();
            Thread.Sleep(430);

            // 2. Шаг на клетку вниз
            PressSpecButton(0x50);
            Thread.Sleep(430);

            // 3. Три шага на клетку влево
            PressSpecButton(0x4B);
            Thread.Sleep(430);
            PressSpecButton(0x4B);
            Thread.Sleep(430);
            PressSpecButton(0x4B);
            Thread.Sleep(430);
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
