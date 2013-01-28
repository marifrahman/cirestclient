using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace RestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Uri address = new Uri("http://unlocklive.com/sun2moon/cirestserver/index.php/api/restacraft/trans");
            HttpWebRequest request = HttpWebRequest.Create(address) as HttpWebRequest;
            //request.Credentials = new NetworkCredential("username", "password");
            request.Method = "GET";
            //request.ContentType = "application/xml";
            //request.Accept = "application/xml";

            

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                textBox1.Text += reader.ReadToEnd();
            } 


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uri address = new Uri("http://unlocklive.com/sun2moon/cirestserver/index.php/api/restacraft/trans/id/" + txtId.Text + "/amount/" + txtAmount.Text + "/datetime/" + txtDate.Text);
            HttpWebRequest request = HttpWebRequest.Create(address) as HttpWebRequest;
            //request.Credentials = new NetworkCredential("username", "password");
            request.Method = "POST";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                textBox1.Text += reader.ReadToEnd();
            }
        }
    }
}
