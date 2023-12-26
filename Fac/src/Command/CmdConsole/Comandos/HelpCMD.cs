﻿using Command;
using Fac.src.Funciones.StyleConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.Command.CmdConsole.Comandos
{
    public class HelpCMD : CommandBaseC
    {
        
        public override void Execute(string [] parameter)
        {
            StyleConsole2 st = new();
            st.Margin = new(1, 1, 1, 1);
            st.Padding = new(1, 1, 1, 1);

            string msg = string.Empty;
            msg += "-  view [tabla]";

            Console.WriteLine(st.GenerarContenedor(msg, "--- Help ---"));
        }
    }
}
