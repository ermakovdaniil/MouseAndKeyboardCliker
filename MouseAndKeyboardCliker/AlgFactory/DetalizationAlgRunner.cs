using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MouseAndKeyboardCliker.InputSender;

namespace MouseAndKeyboardCliker
{
    public class DetalizationAlgRunner : ClickerAlg
    {
        public DetalizationAlgRunner(ModeBase resMode) : base(resMode)
        {
        }

        protected override void ModesAdditionalTasks()
        {
            // 13. Установка курсора на поле "Цена передачи" 
            SetCursor(resMode.TransferPrice.Field.X, resMode.TransferPrice.Field.Y);
            LeftMouseDblClick();
            LeftMouseDblClick();
            Thread.Sleep(stepTime);

            // 14. Стирание текста
            ClickKey(0x0e);
        }
    }
}
