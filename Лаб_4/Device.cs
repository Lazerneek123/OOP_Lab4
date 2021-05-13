using System;
using System.Xml.Serialization;

namespace Лаб_4
{
    [XmlType("Device")]
    [XmlInclude(typeof(Sensor)), XmlInclude(typeof(TypeOfSizes)), XmlInclude(typeof(Device)), XmlInclude(typeof(GeneralInformation))]
    [Serializable]
    public class Device
    {
        [XmlElement("sensor")]
        public Sensor sensor { get; set; }
        [XmlElement("dateTime")]
        public DateTime dateTime { get; set; }
        [XmlElement("numberDevice")]
        public int numberDevice { get; set; }

        public Device()
        {
            sensor = new Sensor(8, 5); dateTime = new DateTime(); numberDevice = 0;
        }

        public Device(Sensor sensor, DateTime dateTime, int numberDevice)
        {
            this.sensor = sensor;
            this.dateTime = dateTime;
            this.numberDevice = numberDevice;
        }

        public override String ToString()
        {
            char[] word = dateTime.ToString().ToCharArray();
            string date = null;

            for (int i = 0; i <= word.Length / 2; ++i)
            {   
                date += word[i];
            }

            return "Дата калібрування датчика: " + date + ";\n" + "Номер кріплення пристрою: " + numberDevice + ";";
        }
    }
}
