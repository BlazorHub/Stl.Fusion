using System;
using System.ComponentModel;
using System.Globalization;
using Stl.Text;

namespace Stl.Internal
{
    // Used by JSON.NET to serialize dictionary keys of this type
    public class SymbolTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (destinationType == typeof(string))
                return ((Symbol) value).Value;
            return base.ConvertTo(context, culture, value, destinationType)!;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string s)
                // ReSharper disable once HeapView.BoxingAllocation
                return new Symbol(s);
            return base.ConvertFrom(context, culture, value)!;
        }
    }
}
