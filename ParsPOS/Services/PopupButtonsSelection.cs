﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public class PopupButtonsSelectionWrapper
    {
        public PopupButtonsSelection Selection { get; set; }
    }

    public enum PopupButtonsSelection
    {
        ProductCode,
        ProductDescr,
        PCs,
        AccMast,

    }
}
