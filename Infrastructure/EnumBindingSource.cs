using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GettingReal.Infrastructure
{
    public class EnumBindingSource : MarkupExtension
    {
        public Type EnumType { get; private set; }
        public EnumBindingSource() { }
        public EnumBindingSource (Type enumType)
        {
            if (enumType == null || !enumType.IsEnum)
                throw new Exception("EnumType must not be null and of type Enum");
            EnumType = enumType;
        }

            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return Enum.GetValues(EnumType);
            }
        }
}
