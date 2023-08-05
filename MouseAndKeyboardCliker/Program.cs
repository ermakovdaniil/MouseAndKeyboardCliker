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

        public static void Main()
        {
            SetCursor(198, 707); // Установка курсора на "Добавить"
            LeftMouseClick();

            SetCursor(1340, 310); // Установка курсора на ячейку Excel с названием номенклатуры
            LeftMouseClick();

            goToExcel(); // Переход в Excel
            SelectAll(); // Выбор всего текста в поле
            CopyToBuffer(); // Копирование текста


            SetCursor(290, 779); // Установка курсора на поле с названием
            InsertInOneC(); // Вставка текста

            goToExcel();
            pressTAB();
            goToExcel(); // Переход в Excel
            SelectAll(); // Выбор всего текста в поле
            CopyToBuffer(); // Копирование текста

            SetCursor(290, 779); // Установка курсора на поле с названием
            pressTAB();
            InsertInOneC(); // Вставка текста
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

        private static void goToExcel()
        {
            SetCursor(1572, 210); // Установка курсора на поле с текстом
            LeftMouseClick();
        }

        private static void SelectAll()
        {
            LeftMouseClick();
            LeftMouseClick();
            LeftMouseClick();
        }

        private static void CopyToBuffer()
        {
            RightMouseClick();
            SetCursor(1560, 221);
            LeftMouseClick();
        }

        private static void InsertInOneC()
        {
            LeftMouseDblClick();
            RightMouseClick();
            SetCursor(290, 779);
            LeftMouseClick();

            Thread.Sleep(1000);

            SetCursor(326, 806);
            LeftMouseClick();
        }



        #endregion


        #region Клавиатура

        private static void pressTAB() // https://gist.github.com/dretax/fe37b8baf55bc30e9d63
        {
            SendKeyboardInput(new KeyboardInput[]
            {
                new KeyboardInput
                {
                    wScan = 0x0F,
                    dwFlags = (uint)(KeyEventF.ExtendedKey | KeyEventF.Scancode)
                }
            });
        }

        private static void pressArrow(ushort code)
        {
            SendKeyboardInput(new KeyboardInput[]
{
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
