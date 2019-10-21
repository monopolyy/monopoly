using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monopoly2019.Model;
using Monopoly2019.API;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Xna.Framework;
using Monopoly2019.Controller;
using System.Threading;
using System.Net.Http;

namespace Monopoly2019
{
    public partial class Form1 : Form
    {
        //IHubProxy _hub;
        //private Socket _serverSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        
        public Form1()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            
    }

        private void button2_Click(object sender, EventArgs e)
        {



            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
           // Timer mytier = new Timer();

            await Processor.LoadData("api/players", onSuccess: (data) =>
            {
                var players = JsonConvert.DeserializeObject<List<PlayerM.PlayerMono>>(data);
                int indexP = 0;
                foreach (var player in players)
                {
                    indexP++;

                    if (!string.IsNullOrEmpty(player.name) && textBox1.Text.Length > 0)
                    {
                        if (textBox1.Text.ToLower().Equals(player.name.ToLower()))
                        {
                            textBox2.AppendText(textBox1.Text + "already exist");
                            return;
                        }
                    }
                    else
                    {
                        textBox2.AppendText(textBox1.Text + "no name");
                        return;
                    }
                }

                //Disable labels
                //var content = new Dictionary<string, string> { { "name", textBox1.Text } };
                
                var payload = "{\"name\":\""+ textBox1.Text + "\",\"currentPosition\": 0,\"indexP\": " + indexP + ",\"isInJail\": 0,\"moneyP\": 1500}";
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                Processor.PostData("api/players/new", content, onSuccess: () =>
                {
                    label1.Text = "Succesfully connected";
                //timer1.Enabled = true;
               SetInterval(getnewest, 5000);
                  //  tmr.Stop();
                });
            }, onFailure: (error) => { });

            if (label1.Text == "Succesfully connected")
            {
                //timer1.Enabled;
            }
          /*  if (textBox1.Text.Length>0)
            {
                textBox2.AppendText(textBox1.Text + "yra");
            }
            else
            {
                textBox2.AppendText(textBox1.Text + "nera");
            }-*/
        }

        public static System.Timers.Timer SetInterval(Action Act, int Interval)
        {
            
            System.Timers.Timer tmr = new System.Timers.Timer();
            tmr.Elapsed += (sender, args) => Act();
            tmr.AutoReset = true;
            tmr.Interval = Interval;
            tmr.Start();

            return tmr;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private async void getnewest()
        {
            await Processor.LoadData("api/players", onSuccess: (data) =>
            {
                var players = JsonConvert.DeserializeObject<List<PlayerM.PlayerMono>>(data);
                int indexP = 0;
                foreach (var player in players)
                {
                    indexP++;
                }
                if (indexP == 3)
                {
                   // System.Timers.Timer tmr= ;
                //   tmr.Stop();
                    EntryPoint.StartGame();
                    
                }
                //Disable labels
                //var content = new Dictionary<string, string> { { "name", textBox1.Text } };


            }, onFailure: (error) => { });
        }

        private async void timer1_Tick_1(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
