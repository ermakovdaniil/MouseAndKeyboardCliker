using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MouseAndKeyboardCliker.Program;

namespace MouseAndKeyboardCliker
{
    public static class AlgFactory
    {
        public static ClickerAlg Create(ModeBase resMode, Modes mode)
        {
            switch (mode)
            {
                case Modes.realization:
                    return new RealizationAlgRunner(resMode);

                case Modes.detalization:
                    return new DetalizationAlgRunner(resMode);
            }

            return null;
        }
    }
}
