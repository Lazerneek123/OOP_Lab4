using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace Лаб_4
{
    public partial class MainWindow : Window
    {
        private string loadFileBin = Directory.GetCurrentDirectory() + "\\SaveFiles\\Save.txt";
        private string loadFileXML = Directory.GetCurrentDirectory() + "\\SaveFiles\\Save.xml";
        private string loadFileJson = Directory.GetCurrentDirectory() + "\\SaveFiles\\Save.json";

        public MainWindow()
        {
            InitializeComponent();    
        }  

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {  
            MeasuringChannel information = new MeasuringChannel(listBox1.Items.Count + 1);

            if (listBox1.Items.Count + 1 <= information.NumberOfChannels)
            {
                FillingInInformation form = new FillingInInformation(listBox1.Items.Count + 1);
                listBox1.Items.Add(information);

                listBox1.SelectedItem = information;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Більше добавляти каналів не можна!");
            }
             
        }
        
        private void ButtonRedact_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.Items != null && listBox1.SelectedItem is MeasuringChannel)
            {
                MeasuringChannel information = (MeasuringChannel)listBox1.SelectedItem;
                FillingInInformation form = new FillingInInformation();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ви не вибрали канал!");
            }  
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists(loadFileBin))
                {
                    File.Create(loadFileBin);
                }

                if (!File.Exists(loadFileXML))
                {
                    File.Create(loadFileXML);
                }

                if (!File.Exists(loadFileJson))
                {
                    File.Create(loadFileJson);
                }

                FileStream fileStream2 = new FileStream(loadFileBin, FileMode.Open);
                BinaryFormatter bf2 = new BinaryFormatter();

                List<MeasuringChannel> information = new List<MeasuringChannel>();
                try
                {
                    information = bf2.Deserialize(fileStream2) as List<MeasuringChannel>;
                    fileStream2.Close();
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }


                foreach (var locality in information)
                {
                    listBox1.Items.Add(locality);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Не вдалося загрузити файл! Нові файли будуть створено автоматично!");

            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Зберегти зміни?", "Serialisation", MessageBoxButton.YesNoCancel);

            if (result == MessageBoxResult.Yes)
            {     
                List<MeasuringChannel> list = new List<MeasuringChannel>();
                foreach (var loc in listBox1.Items)
                {
                    list.Add((MeasuringChannel)loc);
                }
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<MeasuringChannel>), new Type[] { typeof(GeneralInformation), typeof(Device), typeof(Sensor), typeof(MeasuringChannel), typeof(TypeOfSizes) });

                FileStream fsBinary = new FileStream(loadFileBin, FileMode.Create);
                FileStream fsXML = new FileStream(loadFileXML, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();

                try
                {

                    string json = JsonConvert.SerializeObject(list);
                    File.WriteAllText(loadFileJson, json);
                    formatter.Serialize(fsBinary, list);
                    xmlFormatter.Serialize(fsXML, list);
                    fsBinary.Close();
                    fsXML.Close();
                    Close();
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);            
                }             
            }
            if (result == MessageBoxResult.No)
            {
                Close();
            }
        }

        private bool switch_0 = false;
        
        private void ButtonReversal_Click(object sender, RoutedEventArgs e)
        {
            if (switch_0 == false)
            {
                WindowState = WindowState.Maximized;
                buttonRemove.Margin = new Thickness(Width - 172, Height - 100, 31, 20);
                buttonEdit.Margin = new Thickness(-Width + 1072, Height - 100, 31, 20);
                buttonAdd.Margin = new Thickness(-Width + 230, Height - 100, 31, 20);

                buttonClose.Margin = new Thickness(Width - 50, 11, 0, 0);
                buttonReversal.Margin = new Thickness(Width - 95, 11, 0, 0);
                buttonCollapse.Margin = new Thickness(Width - 140, 11, 0, 0);

                listBox1.Width = Width - 58; listBox1.Height = Height - 160;

                switch_0 = true;
            }
            else
            {
                WindowState = WindowState.Normal;
                buttonRemove.Margin = new Thickness(Width - 172, Height - 100, 31, 20);
                buttonEdit.Margin = new Thickness(-Width + 832, Height - 100, 31, 20);
                buttonAdd.Margin = new Thickness(-540, Height - 100, 31, 20);

                buttonClose.Margin = new Thickness(Width - 50, 11, 0, 0);
                buttonReversal.Margin = new Thickness(Width - 95, 11, 0, 0);
                buttonCollapse.Margin = new Thickness(Width - 140, 11, 0, 0);

                listBox1.Width = Width - 58; listBox1.Height = Height - 160;

                switch_0 = false;
            }
            
        }

        private void ButtonCollapse_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
