using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Shopping {
    // https://stackoverflow.com/questions/25422071/how-to-return-a-property-as-value-from-typeconverter-in-a-propertygrid
    class CategoriaConverter : TypeConverter {
        private static readonly List<clsCategoria> _categorias = Database.CategoriasGet().OriginalList;
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            return new StandardValuesCollection(_categorias);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture, object value) {
            if (!(value is string)) {
                return base.ConvertFrom(context, culture, value);
            }
            return _categorias.First(c => c.ToString() == value.ToString()).ID;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture, object value, Type destinationType) {
            if (destinationType == typeof(string)) {
                if (value is int) {
                    return _categorias.First(u => u.ID == (int)value).ToString();
                }
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
