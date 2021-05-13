using System.Windows;
using System.Windows.Controls;

namespace Лаб_4
{  
    public partial class FillingInInformation : Window
    {
        public FillingInInformation()
        {
            InitializeComponent();

            MeasuringChannel measuringChannel = (MeasuringChannel)((ListBox)Application.Current.Windows[0].FindName("listBox1")).SelectedItem;

            if (measuringChannel.information != null)
            {
                listBox1.Items.Clear();
                foreach (var plot in measuringChannel.information)
                {
                    listBox1.Items.Add(plot);
                }
            }
        }

        private int number = 0;

        public FillingInInformation(int number)
        {
            InitializeComponent();
            this.number = number;           
        }

        private int numberDevice = 1;

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            MeasuringChannel measuringChannel = (MeasuringChannel)((ListBox)Application.Current.Windows[0].FindName("listBox1")).SelectedItem;           
            Filling filling = new Filling(numberDevice++);   
            filling.ShowDialog();

            TypeOfSizes typeOfSize = filling.typeOfSizes;
            Sensor sensor = filling.sensor;  
            Device device = filling.device;
            measuringChannel.CopyInformation(typeOfSize,sensor, device);

            if (measuringChannel.information != null)
            {
                listBox1.Items.Clear();
                foreach (var plot in measuringChannel.information)
                {
                    listBox1.Items.Add(plot);
                }
            }
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            MeasuringChannel measuringChannel = (MeasuringChannel)((ListBox)Application.Current.Windows[0].FindName("listBox1")).SelectedItem;
            
            measuringChannel.RemoveInformation((GeneralInformation)listBox1.SelectedItem);
            listBox1.Items.Remove((GeneralInformation)listBox1.SelectedItem);
            
            if (measuringChannel.information != null)
            {
                listBox1.Items.Clear();
                foreach (var information in measuringChannel.information)
                {
                    listBox1.Items.Add(information);
                }
            }
        }

        private void ButtonRedact_Click(object sender, RoutedEventArgs e)
        {
            MeasuringChannel measuringChannel = (MeasuringChannel)((ListBox)Application.Current.Windows[0].FindName("listBox1")).SelectedItem;

            if (listBox1.SelectedItem != null)
            {
                string text = listBox1.SelectedItem.ToString();
                string textCopy = text;

                string[] str = text.Trim().Split('\n');
                
                Redact redact = new Redact(listBox1.SelectedIndex++);

                string[] str2 = str[0].Trim().Split(' ');
                redact.comboBox1.Text = str2[2].Trim().Split(';')[0];

                str2 = str[1].Trim().Split(' ');
                redact.textBox1.Text = str2[2];

                str2 = str[2].Trim().Split(' ');
                redact.textBox2.Text = str2[4].Trim().Split(';')[0];

                str2 = str[3].Trim().Split(' ');
                redact.date.Text = str2[3].Trim().Split(';')[0];

                str2 = str[4].Trim().Split(' ');
                redact.information_Copy9.Content = str2[3].Trim().Split(';')[0];
                
                redact.switch_0 = true;
                redact.ShowDialog();               

                if (measuringChannel.information != null)
                {
                    listBox1.Items.Clear();
                    foreach (var information in measuringChannel.information)
                    {
                        listBox1.Items.Add(information);
                    }
                }                
            }
            else
            {
                MessageBox.Show("Виберіть пристрій!");
            }
        }

        private void ButtonRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            MeasuringChannel information = (MeasuringChannel)((ListBox)Application.Current.Windows[0].FindName("listBox1")).SelectedItem;                     
            information.RemoveAllInformation();
            listBox1.Items.Clear();           
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonCollapse_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
