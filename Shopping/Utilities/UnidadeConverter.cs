using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Shopping {
    class UnidadeConverter : StringConverter {
        private static string[] _unidades = { "kg", "litro", "un" };
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            return new StandardValuesCollection(_unidades);
        }
    }
}
