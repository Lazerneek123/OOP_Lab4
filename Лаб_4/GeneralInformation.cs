using System;
using System.Xml.Serialization;

namespace Лаб_4
{
    [XmlType("GeneralInformation")]
    [XmlInclude(typeof(Sensor)), XmlInclude(typeof(TypeOfSizes)), XmlInclude(typeof(Device)), XmlInclude(typeof(GeneralInformation))]
    [Serializable]
    public class GeneralInformation
    {
        [XmlElement("typeOfSizes")]
        private TypeOfSizes typeOfSizes { get; set; }
        [XmlElement("sensor")]
        private Sensor sensor { get; set; }
        [XmlElement("device")]
        private Device device { get; set; }

        public GeneralInformation()
        {
            typeOfSizes = new TypeOfSizes();
            sensor = new Sensor();
            device = new Device();
        }

        public GeneralInformation(TypeOfSizes typeOfSizes, Sensor sensor, Device device)
        {
            this.typeOfSizes = typeOfSizes;
            this.sensor = sensor;
            this.device = device;
        }

        protected string Information()
        {
            string information = typeOfSizes + "\n" + sensor + "\n" + device;

            return information;
        }

        public override String ToString()
        {
            return Information();
        }
    }
}
