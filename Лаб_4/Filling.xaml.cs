using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Лаб_4
{  
    public partial class Filling : Window
    {
        public FillingInInformation fillingInInformation;

        public Filling()
        {
            InitializeComponent();
        }

        public Filling(int numberDevice)
        {
            InitializeComponent();

            comboBox1.Items.Add(TypeOfSizes.ValueSizes.Довжина);
            comboBox1.Items.Add(TypeOfSizes.ValueSizes.Градуси);
            comboBox1.Items.Add(TypeOfSizes.ValueSizes.Температура);
            comboBox1.Items.Add(TypeOfSizes.ValueSizes.Час);
            comboBox1.Items.Add(TypeOfSizes.ValueSizes.Відсоток);

            this.numberDevice = numberDevice;

            try
            {
                MeasuringChannel measuringChannel = (MeasuringChannel)((ListBox)Application.Current.Windows[0].FindName("listBox1")).SelectedItem;

                information_Copy8.Content = measuringChannel.NumberOfChannels;
                information_Copy9.Content = numberDevice;

                ListBox list1 = (ListBox)Application.Current.Windows[0].FindName("listBox1");
                ListBox list2 = (ListBox)Application.Current.Windows[2].FindName("listBox1");

                if (list2 != null && list2.Items.Count != 0)
                {
                    GeneralInformation generalInformation = (GeneralInformation)list2.SelectedItem;
                    if (generalInformation != null)
                    {
                        list2.Items.Remove(generalInformation);
                        measuringChannel.RemoveInformation(generalInformation);
                        list1.Items.Remove(generalInformation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int numberDevice = 0;
        public TypeOfSizes typeOfSizes;
        public Sensor sensor;
        public Device device; 

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            MeasuringChannel measuringChannel = (MeasuringChannel)((ListBox)Application.Current.Windows[0].FindName("listBox1")).SelectedItem;
            try
            {          
                TypeOfSizes typeOfSizes = new TypeOfSizes((TypeOfSizes.ValueSizes)comboBox1.SelectedItem);
                Sensor sensor = new Sensor(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                
                Device device = new Device(sensor, (DateTime)date.SelectedDate, numberDevice);
                
                GeneralInformation information = new GeneralInformation(typeOfSizes, sensor, device);
                measuringChannel.AddInformation(information);
                this.typeOfSizes = typeOfSizes;
                this.sensor = sensor;
                this.device = device;
                Close();  
            }
            catch
            {
                MessageBox.Show("Не всі поля заповнені!");
            }

        }

        public bool switch_0 { get; set; } = false;

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            if (switch_0 == true)
            {
                MeasuringChannel measuringChannel = (MeasuringChannel)((ListBox)Application.Current.Windows[0].FindName("listBox1")).SelectedItem;
                try
                {
                    TypeOfSizes typeOfSizes = new TypeOfSizes((TypeOfSizes.ValueSizes)comboBox1.SelectedItem);
                    Sensor sensor = new Sensor(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

                    Device device = new Device(sensor, (DateTime)date.SelectedDate, Convert.ToInt32(information_Copy9.Content));

                    GeneralInformation information = new GeneralInformation(typeOfSizes, sensor, device);
                    measuringChannel.AddInformation(information);

                    Close();
                }
                catch
                {
                    MessageBox.Show("Не всі поля заповнені!");
                }
            }

            Close();
        }

        private void ButtonCollapse_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (switch_0 == true)
            {
                MeasuringChannel measuringChannel = (MeasuringChannel)((ListBox)Application.Current.Windows[0].FindName("listBox1")).SelectedItem;
                try
                {
                    TypeOfSizes typeOfSizes = new TypeOfSizes((TypeOfSizes.ValueSizes)comboBox1.SelectedItem);
                    Sensor sensor = new Sensor(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

                    Device device = new Device(sensor, (DateTime)date.SelectedDate, Convert.ToInt32(information_Copy9.Content));

                    GeneralInformation information = new GeneralInformation(typeOfSizes, sensor, device);
                    measuringChannel.AddInformation(information);

                    Close();
                }
                catch
                {
                    MessageBox.Show("Не всі поля заповнені!");
                }
            }

            Close();
        }


        private new void TextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }
    }
}
