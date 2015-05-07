using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Configuration;

namespace WindowsFormsApplication2
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            comboBox1.Text = WindowsFormsApplication2.Properties.Settings.Default.COM_cb1;
            comboBox2.Text = WindowsFormsApplication2.Properties.Settings.Default.COM_cb2;
            comboBox3.Text = WindowsFormsApplication2.Properties.Settings.Default.COM_cb3;
            comboBox4.Text = WindowsFormsApplication2.Properties.Settings.Default.COM_cb4;
            comboBox5.Text = WindowsFormsApplication2.Properties.Settings.Default.COM_cb5;
            comboBox6.Text = WindowsFormsApplication2.Properties.Settings.Default.COM_cb6;
            comboBox7.Text = WindowsFormsApplication2.Properties.Settings.Default.COM_cb7;

            string[] portnames = SerialPort.GetPortNames();

            comboBox1.Items.AddRange(portnames);
            comboBox2.Items.AddRange(portnames);
            comboBox3.Items.AddRange(portnames);
            comboBox4.Items.AddRange(portnames);
            comboBox5.Items.AddRange(portnames);
            comboBox6.Items.AddRange(portnames);
            comboBox7.Items.AddRange(portnames);

            Public_Data.Value = comboBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication2.Properties.Settings.Default.COM_cb1 = comboBox1.Text;
            WindowsFormsApplication2.Properties.Settings.Default.COM_cb2 = comboBox2.Text;
            WindowsFormsApplication2.Properties.Settings.Default.COM_cb3 = comboBox3.Text;
            WindowsFormsApplication2.Properties.Settings.Default.COM_cb4 = comboBox4.Text;
            WindowsFormsApplication2.Properties.Settings.Default.COM_cb5 = comboBox5.Text;
            WindowsFormsApplication2.Properties.Settings.Default.COM_cb6 = comboBox6.Text;
            WindowsFormsApplication2.Properties.Settings.Default.COM_cb7 = comboBox7.Text;

            WindowsFormsApplication2.Properties.Settings.Default.Save();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
