using System;
using System.Xml.Serialization;

namespace Лаб_4
{
    [XmlType("TypeOfSizes")]
    [Serializable]    
    public class TypeOfSizes
    {       
        public enum ValueSizes
        {
            [XmlEnum(Name = "Довжина")] Довжина = 1, [XmlEnum(Name = "Градуси")] Градуси, [XmlEnum(Name = "Температура")]  Температура, [XmlEnum(Name = "Час")]  Час, [XmlEnum(Name = "Відсоток")] Відсоток
        }

        [XmlElement("valueSizes")]
        public ValueSizes valueSizes;

        public TypeOfSizes()
        {
            valueSizes = new ValueSizes();
        }

        public TypeOfSizes(ValueSizes valueSizes)
        {
            this.valueSizes = valueSizes;
        }

        public override String ToString()
        {
            return "Тип величини: " + valueSizes + ";";
        }

    }
}
