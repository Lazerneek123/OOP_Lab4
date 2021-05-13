using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Лаб_4
{
    [XmlRoot("MeasuringChannel")]
    [XmlInclude(typeof(Sensor)), XmlInclude(typeof(TypeOfSizes)), XmlInclude(typeof(Device)), XmlInclude(typeof(GeneralInformation))]
    [Serializable]
    public class MeasuringChannel
    {
        private static int numberOfChannels { get; set; } = 20;
   
        private int serialNumberOfTheChannel { get; set; }
        [XmlElement("serialNumberOfTheChannelCopy")]
        public int serialNumberOfTheChannelCopy { get; set; }

        [XmlElement("NumberOfChannels")]
        public int NumberOfChannels = numberOfChannels;

        [XmlArray("information")]
        [XmlArrayItem("GeneralInformation")]
        public List<GeneralInformation> information = new List<GeneralInformation>();

        public MeasuringChannel()
        {
            numberOfChannels = 10; serialNumberOfTheChannel = 1;
        }

        public MeasuringChannel(int serialNumberOfTheChannel)
        {
            numberOfChannels = 20; this.serialNumberOfTheChannel = serialNumberOfTheChannel; serialNumberOfTheChannelCopy = serialNumberOfTheChannel;
        }

        public MeasuringChannel(int serialNumberOfTheChannel, int measuringRange, int physicalSize)
        {
            numberOfChannels = 20; this.serialNumberOfTheChannel = serialNumberOfTheChannel; sensor = new Sensor(measuringRange, physicalSize);
        }

        public void AddInformation(GeneralInformation generalInformation)
        {
            information.Add(generalInformation);
        }

        public void RemoveInformation(GeneralInformation generalInformation)
        {
            information.Remove(generalInformation);
        }

        public void RemoveAllInformation()
        {
            information.Clear();
        }    
        
        protected string Information()
        {
            string information = "Загальна кількість каналів: " + numberOfChannels + " ; канал №" + serialNumberOfTheChannel + ";";  
            return information;
        }

        public void CopyInformation(TypeOfSizes typeOfSizes, Sensor sensor, Device device)
        {
            this.typeOfSizes = typeOfSizes;
            this.sensor = sensor;
            this.device = device;

        }

        public override String ToString()
        {
            return Information();
        }

        [XmlElement("typeOfSizes")]
        public TypeOfSizes typeOfSizes { get; set; }
        [XmlElement("sensor")]
        public Sensor sensor { get; set; }
        [XmlElement("device")]
        public Device device { get; set; }
    }
}
