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
using Monopoly2019.Controller;
using System.Threading;
using Monopoly2019;

namespace Monopoly2019
{
    public partial class Form1 : Form
    {
       private bool toggle = false;
        private PlayerM.PlayerMono currentPlayer = new PlayerM.PlayerMono();


        public Form1()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            label2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {



            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

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
                var payload = "{\"name\":\"" + textBox1.Text + "\",\"currentPosition\": 0,\"indexP\": " + indexP + ",\"isInJail\": 0,\"moneyP\": 1500}";
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                Processor.PostData("api/players/new", content, onSuccess: () =>
                {
                    currentPlayer.name = textBox1.Text;
                    currentPlayer.indexP = indexP;
                    currentPlayer.isInJail = false;
                    currentPlayer.moneyP = 1500;
                    currentPlayer.currentPosition = 0;
                    label1.Text = "Succesfully connected";
                    timer1.Enabled = true;
                    label2.Text = textBox1.Text;
                });
            }, onFailure: (error) => { });

            if (label1.Text == "Succesfully connected")
            {
                //timer1.Enabled;
            }

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
                if (indexP == 2)
                {
                    ToogleGame(false);
                    var font = GetFont();
                 //   Controls.Add(font);
                    label2.Visible = true;
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                }
                


            }, onFailure: (error) => { });
        }

        private async void timer1_Tick_1(object sender, EventArgs e)
        {
            getnewest();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private PictureBox GetFont()
        {
            var size = new Size(this.Width, this.Height);
            PictureBox pb1 = new PictureBox();
            pb1.ImageLocation = "../Content/FinalBoard.png";
            pb1.SizeMode = PictureBoxSizeMode.Zoom;
            pb1.Size = new Size(this.Width, this.Height);
            pb1.SizeMode = PictureBoxSizeMode.CenterImage;
            pb1.Location = new Point((this.Width / 2) - (pb1.Width / 2), (this.Height / 2) - (pb1.Height / 2));
          //  pb1.GetPreferredSize = size;
            return pb1;
        }

         private PictureBox ShowPlayers(PlayerM.PlayerMono player)
        {
            PictureBox playerPic = new PictureBox();
            if (player.indexP == 0)
            {
                playerPic.ImageLocation = "../Content/pawn1.png";
                playerPic.Size = new Size(20, 20);
                playerPic.Location = new Point(50, 50);
                playerPic.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else
            {
                playerPic.ImageLocation = "../Content/pawn2.png";
                playerPic.Size = new Size(20, 20);
                playerPic.Location = new Point(50, 30);
                playerPic.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            return playerPic;
        }

        private async void ToogleGame(bool Toggle)
        {
            textBox1.Visible = Toggle;
            button1.Visible = Toggle;
            label1.Visible = Toggle;
            textBox2.Visible = Toggle;
            button2.Visible = Toggle;


        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            await Processor.LoadData("api/players", onSuccess: (data) =>
            {
                var players = JsonConvert.DeserializeObject<List<PlayerM.PlayerMono>>(data);
                timer2.Enabled = false;
                foreach (var player in players)
                {
                   
                    var play = ShowPlayers(player);
                    Controls.Add(play);
                    
                }




            }, onFailure: (error) => { });
        }
    }
}
