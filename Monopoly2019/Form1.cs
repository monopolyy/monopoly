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
        private List<PlayerM.PlayerMono> Allplayers = new List<PlayerM.PlayerMono>();
        Random rnd = new Random();
        PictureBox dice1Pic = new PictureBox();
        PictureBox dice2Pic = new PictureBox();
        const int playerSnumber = 2;
        List<PictureBox> playerDisplay = new List<PictureBox>();
        

        public Form1()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            label2.Visible = false;
            roundButton1.Visible = false;
            roundButton2.Visible = false;
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
                var payload = "";
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
                if (indexP == 0)
                {
                    payload = "{\"name\":\"" + textBox1.Text + "\",\"currentPosition\": 0,\"indexP\": " + indexP + ",\"isInJail\": 0,\"turn\": 1,\"moneyP\": 1500}";
                    currentPlayer.name = textBox1.Text;
                    currentPlayer.indexP = indexP;
                    currentPlayer.isInJail = false;
                    currentPlayer.moneyP = 1500;
                    currentPlayer.currentPosition = 0;
                    currentPlayer.turn = 1;
                }
                else
                {
                    payload = "{\"name\":\"" + textBox1.Text + "\",\"currentPosition\": 0,\"indexP\": " + indexP + ",\"isInJail\": 0,\"turn\": 0,\"moneyP\": 1500}";
                    currentPlayer.name = textBox1.Text;
                    currentPlayer.indexP = indexP;
                    currentPlayer.isInJail = false;
                    currentPlayer.moneyP = 1500;
                    currentPlayer.currentPosition = 0;
                    currentPlayer.turn = 0;
                }

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                string jsonContent = content.ReadAsStringAsync().Result;
                // CONTACT contact = JsonConvert.DeserializeObject<CONTACT>(jsonContent);
                Processor.PostData("api/players/new", content, onSuccess: () =>
                {

                    label1.Text = "Succesfully connected";
                    timer1.Enabled = true;
                    label2.Text = textBox1.Text;
                });
            }, onFailure: (error) => { });

            if (label1.Text == "Succesfully connected")
            {
                //timer1.Enabled;
            }
          //  Controls.Add(playerDisplay);

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
                int PCount = 0;
                foreach (var player in players)
                {
                    indexP++;
                    PCount = Allplayers.Where(pl => pl.indexP == player.indexP).Count();
                    if (PCount==0)
                    {
                        Allplayers.Add(player);
                    }

                }
                if (indexP == 2)
                {
                    Image board = Image.FromFile("../Content/FinalBoard.png");
                    int count = 0;
                    foreach (var player in players)
                    {
                        playerDisplay.Add(ShowPlayers(player));
                        Controls.Add(playerDisplay[count]);
                        count++;
                    }
                        ToogleGame(false);
                    label2.Visible = true;
                    label2.BackColor = Color.Transparent;
                    this.BackgroundImage = board;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    timer1.Enabled = false;
                  // ShowPlayers(player);
                    timer2.Enabled = true;
                }



            }, onFailure: (error) => { });
        }

    

        private void label1_Click(object sender, EventArgs e)
        {
        }


        private PictureBox ShowPlayers(PlayerM.PlayerMono player)
        {
            PictureBox playerPic = new PictureBox();
            if (player.indexP == 0)
            {
                playerPic.ImageLocation = "../Content/pawn1.png";
                playerPic.Size = new Size(20, 20);
                playerPic.Location = new Point(PlayerWithPositionOnBoard(player.currentPosition), PlayerHeightPositionOnBoard(player.currentPosition, 65));
                playerPic.SizeMode = PictureBoxSizeMode.Zoom;
                playerPic.BackColor = Color.Transparent;

            }
            else
            {
                playerPic.ImageLocation = "../Content/pawn2.png";
                playerPic.Size = new Size(20, 20);
                playerPic.Location = new Point(PlayerWithPositionOnBoard(player.currentPosition), PlayerHeightPositionOnBoard(player.currentPosition, 90));
                playerPic.SizeMode = PictureBoxSizeMode.Zoom;
                playerPic.BackColor = Color.Transparent;
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

       

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private PictureBox ShowDice(int number, int first)
        {
            PictureBox DicePic = new PictureBox();
            if (first == 1)
            {
                DicePic.ImageLocation = "../Content/" + number + ".png";
                DicePic.Size = new Size(20, 20);
                DicePic.Location = new Point(this.Width - 400, this.Height - 200);
                DicePic.SizeMode = PictureBoxSizeMode.Zoom;
                DicePic.BackColor = Color.Transparent;
            }
            else {
                DicePic.ImageLocation = "../Content/" + number + ".png";
                DicePic.Size = new Size(20, 20);
                DicePic.Location = new Point(this.Width - 370, this.Height - 200);
                DicePic.SizeMode = PictureBoxSizeMode.Zoom;
                DicePic.BackColor = Color.Transparent;
            }
            return DicePic;
        }

      


        public int GivePlayerIndex(int index)
        {
            int playerIndex;
            index++;
            if (index > playerSnumber - 1)
            {
                playerIndex = 0;
            }
            else { playerIndex = index; }
           

                return playerIndex;
        }

        public int PlayerWithPositionOnBoard(int position)
        {
            int playerPosition = 0;
            int squareWit = (this.Width - 65)/10;
            //  int squareHei = (this.Height - 65) / 10;
            if (position <= 10)
            {
                playerPosition = this.Width - 65 - position * squareWit;
            }
            else if (position <= 20)
            {
                playerPosition = 20;
            }
            else if (position <= 30)
            {
                int positionin = position - 20;
                playerPosition = 20 + positionin * squareWit;
            }
            else {
                playerPosition = this.Width - 65;
            }

            return playerPosition;
        }
        public int PlayerHeightPositionOnBoard(int position, int height)
        {
            int playerPosition = 0;
            int squareWit = (this.Width - height) / 10;
            //  int squareHei = (this.Height - 65) / 10;
            if (position <= 10)
            {
                playerPosition = this.Height - height;
            }
            else if (position <= 20)
            {
                int positionint = position - 10;
                playerPosition = this.Height - height - positionint * squareWit;
            }
            else if (position <= 30)
            {
                if (height == 90)
                {
                    playerPosition = 20;
                }
                else { playerPosition = 45; }
            }
            else
            {
                int positionint = position - 30;
                if (height == 90)
                {
                    playerPosition = 20+positionint*squareWit;
                }
                else { playerPosition = 45 + positionint * squareWit; }
            }

            return playerPosition;
        }




        //-----------------------------Timers-------------------------------------------------
        private async void timer1_Tick_1(object sender, EventArgs e)
        {
            getnewest();
        }



        private async void timer2_Tick(object sender, EventArgs e)
        {
            await Processor.LoadData("api/players", onSuccess: (data) =>
            {
                var players = JsonConvert.DeserializeObject<List<PlayerM.PlayerMono>>(data);

                foreach (var player in players)
                {
                    //timer2.Interval = 50000;
                    var playee = Allplayers.Find(pl => pl.indexP == player.indexP);
                    if (playee.currentPosition != player.currentPosition)
                    {
                      
                            playerDisplay[player.indexP].Visible = false;
                            playee.currentPosition = player.currentPosition;
                            var index = Allplayers.FindIndex(c => c.indexP == player.indexP);
                            Allplayers[index] = playee;
                            playerDisplay[player.indexP] = ShowPlayers(player);
                            Controls.Add(playerDisplay[player.indexP]);
                       
                    
                    }
                   // play = ShowPlayers(player);
                //    Controls.Add(play);
                    if (player.indexP == currentPlayer.indexP && player.turn == 1)
                    {
                        roundButton1.Image = Image.FromFile("../Content/Active.png");
                        roundButton1.Visible = true;
                        roundButton1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }



            }, onFailure: (error) => { });
        }



        //-----------------------------RoundButtons-------------------------------------------------

        private void roundButton1_Click(object sender, EventArgs e)
        {
            int dice1 = rnd.Next(1, 6);
            int dice2 = rnd.Next(1, 6);
            dice1Pic = ShowDice(dice1, 1);
            dice2Pic = ShowDice(dice2, 2);

            roundButton2.Image = Image.FromFile("../Content/EndTurn.png");
            roundButton2.Visible = true;
            roundButton2.BackgroundImageLayout = ImageLayout.Stretch;

            Controls.Add(dice1Pic);
            Controls.Add(dice2Pic);
            int newPosition = currentPlayer.currentPosition + dice1 + dice2;
            if (newPosition>=40)
            {
                newPosition = newPosition - 40;
            }
            currentPlayer.currentPosition = newPosition;
            var payload = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + newPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            Processor.UpdateData("api/players/move", content);
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            dice1Pic.Visible = false;
            dice2Pic.Visible = false;
            roundButton1.Visible = false;
            roundButton2.Visible = false;

            var payload = "{\"name\":\"" + currentPlayer.name + "\",\"turn\":  0  ,\"indexP\": " + currentPlayer.indexP + "}";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            Processor.UpdateData("api/players/endTurn", content);
            int anotherPlayerIndex = GivePlayerIndex(currentPlayer.indexP);
            var payload2 = "{\"turn\":  1  ,\"indexP\": " + anotherPlayerIndex + "}";
            HttpContent content2 = new StringContent(payload2, Encoding.UTF8, "application/json");
            Processor.UpdateData("api/players/endTurn", content2);
          //  timer2.Interval = 1000;
        }
    }
}
