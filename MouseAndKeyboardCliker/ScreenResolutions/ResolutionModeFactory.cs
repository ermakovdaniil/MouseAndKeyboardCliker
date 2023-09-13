using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MouseAndKeyboardCliker.Program;

namespace MouseAndKeyboardCliker
{
    public static class ResolutionModeFactory
    {
        public static ModeBase Create(ScreenResolutions sceenRes, Modes mode)
        {
            switch (sceenRes)
            {
                case ScreenResolutions.QuadHD:
                    switch (mode)
                    {
                        case Modes.realization: 
                            return new Realization_QuadHD();

                        case Modes.detalization:
                            return new Detalization_QuadHD();
                    }
                    break;
                
            }
            return null;
        }
    }
}
