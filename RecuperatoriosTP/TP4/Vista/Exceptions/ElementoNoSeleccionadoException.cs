﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.Exceptions
{
    internal class ElementoNoSeleccionadoException : Exception
    {
        public ElementoNoSeleccionadoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}