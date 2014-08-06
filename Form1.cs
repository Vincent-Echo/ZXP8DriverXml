using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ZXP8DriverXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ret = false;
            if (!File.Exists(xmlFileName))
            {
                FileStream fs = File.Create(xmlFileName);
                fs.Flush();
                fs.Dispose();

            }

            unsafe
            {
                char* szPath = (char*)Marshal.StringToHGlobalUni(xmlFileName).ToPointer();
                char* devname = (char*)Marshal.StringToHGlobalUni("Zebra ZXP Series 8 USB Card Printer").ToPointer();
                ret = ToolBoxXml.ZMWSaveDEVMODEToXML(devname, szPath);

            }



            if (ret)
            {
                using (StreamReader sr = new StreamReader(xmlFileName))
                {
                    driverSettingRTB.Text = sr.ReadToEnd();
                }
                MessageBox.Show("XML Exported");
            }
            else
            {
                MessageBox.Show("LoadLibrary Error");
            }

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            bool ret = false;
            if (!File.Exists(xmlFileName))
            {
                MessageBox.Show("Cannot find configuration file :" + xmlFileName);
            }

            unsafe
            {
                char* szPath = (char*)Marshal.StringToHGlobalUni(xmlFileName).ToPointer();
                char* devname = (char*)Marshal.StringToHGlobalUni("Zebra ZXP Series 8 USB Card Printer").ToPointer();
                ret = ToolBoxXml.ZMWRestoreDEVMODEFromXML(devname, szPath);

            }

            if (ret)
            {

                MessageBox.Show("XML Imported");
            }
            else
            {
                MessageBox.Show("LoadLibrary Error/Configuration Load Error");
            }

        }

        public string xmlFileName = "C:\\workspace\\ddd.xml";

    }
}

