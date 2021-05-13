using System;
using System.Xml.Serialization;

namespace Лаб_4
{
    [XmlType("Sensor")]
    [XmlInclude(typeof(Sensor)), XmlInclude(typeof(TypeOfSizes)), XmlInclude(typeof(Device)), XmlInclude(typeof(GeneralInformation))]
    [Serializable]
 
    public class Sensor
    {        
        private TypeOfSizes TypeOfSizes { get; set; }
        [XmlElement("TypeOfSizesCopy")]
        public TypeOfSizes TypeOfSizesCopy { get; set; }

        private int measuringRange { get; set; }
        [XmlElement("measuringRangeCopy")]
        public int measuringRangeCopy { get; set; }

        
        private int physicalSize { get; set; }
        [XmlElement("physicalSizeCopy")]
        public int physicalSizeCopy { get; set; }

        public Sensor()
        {
            measuringRange = 10;
            physicalSize = 5;
            TypeOfSizesCopy = TypeOfSizes;
            measuringRangeCopy = measuringRange;
            physicalSizeCopy = physicalSize;
        }

        public Sensor(int measuringRange, int physicalSize)
        {
            this.measuringRange = measuringRange;
            this.physicalSize = physicalSize;
            TypeOfSizesCopy = TypeOfSizes;
            measuringRangeCopy = measuringRange;
            physicalSizeCopy = physicalSize;
        }

        public override String ToString()
        {
            return "Діапазон вимірювання: " + measuringRange + " одиниця(ь);\nПоточне значення фізичної величини: " + physicalSize + ";";
        }
    }
}
