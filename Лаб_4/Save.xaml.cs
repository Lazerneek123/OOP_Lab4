using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Xml.Serialization;
using System.Windows.Controls;

namespace Лаб_4
{ 
    public partial class Save : Window
    {
        private enum Serialization { All, Binary, XML, Json }

        private string saveFileBinary = Directory.GetCurrentDirectory() + "\\SaveFiles\\Save.txt";
        private string saveFileXML = Directory.GetCurrentDirectory() + "\\SaveFiles\\Save.xml";
        private string saveFileJson = Directory.GetCurrentDirectory() + "\\SaveFiles\\Save.json";

        public Save()
        {
            InitializeComponent();                
        }

        private ListBox listBox; 

        public Save(ListBox listBox)
        {
            InitializeComponent();
            comboBox1.Items.Add(Serialization.All);
            comboBox1.Items.Add(Serialization.Binary);
            comboBox1.Items.Add(Serialization.XML);
            comboBox1.Items.Add(Serialization.Json);         
            this.listBox = listBox;
        }
        
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {           
            List<MeasuringChannel> list = new List<MeasuringChannel>();
            foreach (var loc in listBox.Items)
            {
                list.Add((MeasuringChannel)loc);
            }

            try
            {
                listBox.Items.Clear();
                switch ((Serialization)comboBox1.SelectedItem)
                {

                    case Serialization.Binary:
                        if (!File.Exists(saveFileBinary))
                        {
                            File.Create(saveFileBinary);
                        }

                        try
                        {
                            FileStream fsBinary = new FileStream(saveFileBinary, FileMode.Create);
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(fsBinary, list);

                        }
                        catch (SerializationException)
                        {
                            MessageBox.Show("Файл не знайден! Після перезапуску програма сама створе цей файл.");
                        }
                        break;

                    case Serialization.XML:
                        if (!File.Exists(saveFileXML))
                        {
                            File.Create(saveFileXML);
                        }
                        /*FileStream fileStream = new FileStream(saveFileXML, FileMode.Open);
                        XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<MeasuringChannel>), new Type[] { typeof(GeneralInformation), typeof(Device), typeof(Sensor), typeof(MeasuringChannel), typeof(TypeOfSizes) });
                        FileStream fsXML = new FileStream(saveFileXML, FileMode.Create);
                        xmlFormatter.Serialize(fsXML, list);
                        List<MeasuringChannel> loc = new List<MeasuringChannel>();
                        try
                        {
                            loc = xmlFormatter.Deserialize(fileStream) as List<MeasuringChannel>;
                            fileStream.Close();
                        }
                        catch (SerializationException)
                        {
                            MessageBox.Show("Файл не знайден! Після перезапуску програма сама створе цей файл.");
                        }*/

                        List<MeasuringChannel> information = new List<MeasuringChannel>();

                        XmlSerializer serial = new XmlSerializer(typeof(List<MeasuringChannel>), new Type[] { typeof(GeneralInformation), typeof(Device), typeof(Sensor), typeof(MeasuringChannel), typeof(TypeOfSizes) });
                        using (FileStream fs = new FileStream("\\SaveFiles\\Save.xml",
                            FileMode.Create, FileAccess.Write))
                        {
                            serial.Serialize(fs, information);

                            fs.Close();
                        }

                        break;

                    case Serialization.Json:
                        if (!File.Exists(saveFileJson))
                        {
                            File.Create(saveFileJson);
                        }

                        List<MeasuringChannel> localityList = new List<MeasuringChannel>();
                        try
                        {
                            string json = JsonConvert.SerializeObject(list);
                            File.WriteAllText(saveFileJson, json);

                        }
                        catch (SerializationException)
                        {
                            MessageBox.Show("Файл не знайден! Після перезапуску програма сама створе цей файл.");
                        }

                        foreach (var p in localityList)
                        {
                            listBox.Items.Add(p);
                        }
                        break;

                    case Serialization.All:
                        if (!File.Exists(saveFileJson))
                        {
                            File.Create(saveFileJson);
                        }

                        List<MeasuringChannel> localityList1 = new List<MeasuringChannel>();

                        try
                        {
                            XmlSerializer xmlFormatter1 = new XmlSerializer(typeof(List<MeasuringChannel>), new Type[] { typeof(GeneralInformation), typeof(Device), typeof(Sensor), typeof(MeasuringChannel), typeof(TypeOfSizes) });

                            FileStream fsBinary1 = new FileStream(saveFileBinary, FileMode.Create);
                            FileStream fsXML1 = new FileStream(saveFileXML, FileMode.Create);
                            BinaryFormatter formatter = new BinaryFormatter();

                            string json = JsonConvert.SerializeObject(list);
                            File.WriteAllText(saveFileJson, json);
                            formatter.Serialize(fsBinary1, list);
                            xmlFormatter1.Serialize(fsXML1, list);

                        }
                        catch (SerializationException)
                        {
                            MessageBox.Show("Файл не знайден! Після перезапуску програма сама створе цей файл.");
                        }

                        foreach (var p in localityList1)
                        {
                            listBox.Items.Add(p);
                        }
                        break;

                    default:
                        MessageBox.Show("Виберіть формат!");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + " " + saveFileBinary + saveFileXML);

            }

            Close();
        }

        /*private void Deserialize(object sender, RoutedEventArgs e)
        {
            
        }*/

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
