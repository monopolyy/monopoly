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
        bool button5WasClicked = false;
        private PlayerM.PlayerMono currentPlayer = new PlayerM.PlayerMono();
        private List<PlayerM.PlayerMono> Allplayers = new List<PlayerM.PlayerMono>();
        Random rnd = new Random();
        PictureBox dice1Pic = new PictureBox();
        PictureBox dice2Pic = new PictureBox();
        const int playerSnumber = 2;
        List<PictureBox> playerDisplay = new List<PictureBox>();

        private static Form1 instance = null;
        private static readonly object threadLock = new object(); // lock token

        public Form1()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            roundButton1.Visible = false;
            roundButton2.Visible = false;
            roundButton3.Visible = false;
            roundButton4.Visible = false;
            roundButton5.Visible = false;
        }
        public static Form1 getInstance()
        {
            lock (threadLock)
            {
                if (instance == null)
                {
                    instance = new Form1();
                }
            }
            return instance;
        }

        //-------------------------------isjungti viska-------------------------
        private void button2_Click(object sender, EventArgs e)
        {

            var payload = "{\"name\":\"" + currentPlayer.name + "\",\"turn\":  2  ,\"indexP\": " + currentPlayer.indexP + "}";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            Processor.UpdateData("api/streets/DeleteStreetsTags", content);

            Processor.DeleteData("api/players/deleteAll");


            Application.Exit();
        }


        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
           // Processor.DeleteData("api/players/deleteAll");
            Application.Exit();
        }






        //-------------------------------------------Prisijungimas prie serverio-------------------------------------------
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
                    payload = "{\"name\":\"" + textBox1.Text + "\",\"currentPosition\": 0,\"indexP\": " + indexP + ",\"state\": 0,\"turn\": 1,\"moneyP\": 1500}";
                    currentPlayer.name = textBox1.Text;
                    currentPlayer.indexP = indexP;
                    currentPlayer.state = 0;
                    currentPlayer.moneyP = 1500;
                    currentPlayer.currentPosition = 0;
                    currentPlayer.turn = 1;
                   
                }
                else
                {
                    payload = "{\"name\":\"" + textBox1.Text + "\",\"currentPosition\": 0,\"indexP\": " + indexP + ",\"state\": 0,\"turn\": 0,\"moneyP\": 1500}";
                    currentPlayer.name = textBox1.Text;
                    currentPlayer.indexP = indexP;
                    currentPlayer.state = 0;
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }




        //-------------------------------------------timer1 funkcija-------------
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


        private async void ToogleGame(bool Toggle)
        {
            textBox1.Visible = Toggle;
            button1.Visible = Toggle;
            label1.Visible = Toggle;
            textBox2.Visible = Toggle;
          //  button2.Visible = Toggle;
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
                    if (player.indexP == currentPlayer.indexP && player.turn == 3)
                    {
                        
                        label5.Text = "You LOST";
                        label5.Size= new Size(200, 30);
                        label5.Visible = true;
                    }
                    else if (player.indexP != currentPlayer.indexP && player.turn == 3)
                    {
                        label5.Text = "You WON";
                        label5.Size = new Size(200, 30);
                        label5.Visible = true;
                    }
                    else

                    if (player.indexP == currentPlayer.indexP && player.turn == 1)
                    {
                        if (player.indexP == 0)
                        {
                            label3.Text = "this is You";
                            label3.Visible = true;
                        }
                        else
                        {
                            label4.Text = "this is You";
                            label4.Visible = true;
                        }

                        roundButton1.Image = Image.FromFile("../Content/Active.png");
                        roundButton1.Visible = true;
                        roundButton1.BackgroundImageLayout = ImageLayout.Stretch;
                        currentPlayer.idPlayer = player.idPlayer;
                        var payload = "{\"name\":\"" + currentPlayer.name + "\",\"turn\":  2  ,\"indexP\": " + currentPlayer.indexP + "}";
                        HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                        Processor.UpdateData("api/players/action/2", content);
                    }
                }



            }, onFailure: (error) => { });
        }



        //-----------------------------RoundButtons-------------------------------------------------

        private async void roundButton1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            int isStreetIndex;
            int dice1 = rnd.Next(1, 6);
            int dice2 = rnd.Next(1, 6);
            dice1Pic = ShowDice(dice1, 1);
            dice2Pic = ShowDice(dice2, 2);
            roundButton1.Visible = false;
            roundButton2.Image = Image.FromFile("../Content/EndTurn.png");
            roundButton2.Visible = true;
            bool exist;
           
            roundButton2.BackgroundImageLayout = ImageLayout.Stretch;
           // roundButton3.BackgroundImageLayout = ImageLayout.Stretch;

            Controls.Add(dice1Pic);
            Controls.Add(dice2Pic);
            int newPosition = currentPlayer.currentPosition + dice1 + dice2;
            if (newPosition>=40)
            {
                var payloadGet = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + newPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
                HttpContent contentGet = new StringContent(payloadGet, Encoding.UTF8, "application/json");
                Processor.UpdateData("api/players/action/5", contentGet);
                newPosition = newPosition - 40;
            }
            if (currentPlayer.currentPosition == 10 && currentPlayer.state == 1)
            {
                roundButton5.Visible = true;
                if (dice1 != dice2)
                {
                    var payloadPay = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + newPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
                    HttpContent contentPay = new StringContent(payloadPay, Encoding.UTF8, "application/json");
                    Processor.UpdateData("api/players/action/10", contentPay);
                    currentPlayer.state = 0;
                }
                else {
                    var payloadPay = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + newPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
                    HttpContent contentPay = new StringContent(payloadPay, Encoding.UTF8, "application/json");
                    Processor.UpdateData("api/players/action/11", contentPay);
                    currentPlayer.state = 0;
                }
              


            }
            currentPlayer.currentPosition = newPosition;

            if (newPosition == 0 || newPosition == 10 || newPosition == 20 )
            {
            }
            else if (newPosition == 30)
            {
                var payloadPay = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + newPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
                HttpContent contentPay = new StringContent(payloadPay, Encoding.UTF8, "application/json");
                Processor.UpdateData("api/players/action/9", contentPay);
                currentPlayer.state = 1;
                currentPlayer.currentPosition = 10;
            }
            else if (newPosition == 4 || newPosition == 38)
            {
                var payloadPay = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + newPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
                HttpContent contentPay = new StringContent(payloadPay, Encoding.UTF8, "application/json");
                Processor.UpdateData("api/players/action/4", contentPay);
            }
            //Chance
            else if (newPosition == 7 || newPosition == 22 || newPosition == 36)
            {
                var payloadPay = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + newPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
                HttpContent contentPay = new StringContent(payloadPay, Encoding.UTF8, "application/json");
                Processor.UpdateData("api/players/action/7", contentPay);
            }
            //Community
            else if (newPosition == 2 || newPosition == 17 || newPosition == 33)
            {
                var payloadPay = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + newPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
                HttpContent contentPay = new StringContent(payloadPay, Encoding.UTF8, "application/json");
                Processor.UpdateData("api/players/action/8", contentPay);
            }
            else
            {
                isStreetIndex = 0;
                await Processor.LoadData("api/streets", onSuccess: (data) =>
                {

                    var streetsMon = JsonConvert.DeserializeObject<List<PlayerM.StreetMono>>(data);

                    foreach (var street in streetsMon)
                    {
                        if (street.number == newPosition)
                        {
                            if (street.fkPlayeridPlayer != null)
                            {

                                if (street.fkPlayeridPlayer == currentPlayer.idPlayer)
                                {
                                    roundButton4.Visible = true;
                                    roundButton2.Visible = true;
                                }
                                else { isStreetIndex = street.number; }
                            }
                        }

                    }
                }, onFailure: (error) => { });


                if (isStreetIndex == 0)
                {
                    roundButton3.Image = Image.FromFile("../Content/Buy.png");
                    roundButton3.Visible = true;
                }
                else
                {


                    var payloadPay = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + newPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
                    HttpContent contentPay = new StringContent(payloadPay, Encoding.UTF8, "application/json");
                    Processor.UpdateData("api/players/action/3", contentPay);

                }


            }
            
            var payload = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + newPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            Processor.UpdateData("api/players/action/1", content);
            timer2.Enabled = true;

        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            dice1Pic.Visible = false;
            dice2Pic.Visible = false;
            roundButton1.Visible = false;
            roundButton2.Visible = false;
            roundButton4.Visible = false;
            roundButton3.Visible = false;
            // Kai turn =0 tai ne žaidėjo ėjimas, kai turn = 1 žaidėjui reikia mesti kauliukus, kai turn =2 tada žaidėjas išmetęs kauliukus ir perka gatvę arba baigia ėjimą
            var payload = "{\"name\":\"" + currentPlayer.name + "\",\"turn\":  0  ,\"indexP\": " + currentPlayer.indexP + "}";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            Processor.UpdateData("api/players/action/2", content);
            int anotherPlayerIndex = GivePlayerIndex(currentPlayer.indexP);
            var payload2 = "{\"turn\":  1  ,\"indexP\": " + anotherPlayerIndex + "}";
            HttpContent content2 = new StringContent(payload2, Encoding.UTF8, "application/json");
            Processor.UpdateData("api/players/action/2", content2);
          //  timer2.Interval = 1000;
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

        private void roundButton3_Click(object sender, EventArgs e)
        {
            roundButton3.Visible = false;
            timer2.Enabled = false;
            //  var payload = "{\"number\":\"" + currentPlayer.currentPosition + "\",\"FkPlayeridPlayer\": " + currentPlayer.idPlayer + "}";
            // var payload = "{\"number\":\"" + currentPlayer.currentPosition + ",\"FkPlayeridPlayer\": " + currentPlayer.idPlayer + "}";
            var payload = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + currentPlayer.currentPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            Processor.UpdateData("api/players/action/0", content);
            //  timer2.Enabled = false;
            timer2.Enabled = true;
          

        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
            roundButton4.Visible = false;
            timer2.Enabled = false;
            var payload = "{\"name\":\"" + currentPlayer.name + "\",\"currentPosition\": " + currentPlayer.currentPosition + ",\"indexP\": " + currentPlayer.indexP + "}";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            Processor.UpdateData("api/players/action/6", content);
            timer2.Enabled = true;
        }
        private void roundButton5_Click(object sender, EventArgs e)
        {
            roundButton5.Visible = false;
            //button5WasClicked = true;
            var payload = "{\"name\":\"" + currentPlayer.name + "\",\"turn\":  0  ,\"indexP\": " + currentPlayer.indexP + "}";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            Processor.UpdateData("api/players/action/2", content);
        }

        //----------------------------------------------------Show Something-------------------------------------------


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
            else
            {
                DicePic.ImageLocation = "../Content/" + number + ".png";
                DicePic.Size = new Size(20, 20);
                DicePic.Location = new Point(this.Width - 370, this.Height - 200);
                DicePic.SizeMode = PictureBoxSizeMode.Zoom;
                DicePic.BackColor = Color.Transparent;
            }
            return DicePic;
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

        public int PlayerWithPositionOnBoard(int position)
        {
            int playerPosition = 0;
            int squareWit = (this.Width - 125) / 10;
            //  int squareHei = (this.Height - 65) / 10;
            if (position <= 10)
            {
                playerPosition = this.Width - 90 - position * squareWit;
            }
            else if (position <= 20)
            {
                playerPosition = 20;
            }
            else if (position <= 30)
            {
                int positionin = position - 20;
                playerPosition = 50 + positionin * squareWit;
            }
            else
            {
                playerPosition = this.Width - 80;
            }

            return playerPosition;
        }
        public int PlayerHeightPositionOnBoard(int position, int height)
        {
            int playerPosition = 0;
          //  int squareWit = (this.Height - height ) / 10;
              int squareHei = (this.Height -50)  / 13;
            if (position <= 10)
            {
                playerPosition = this.Height - height;
            }
            else if (position <= 20)
            {
                int positionint = position - 10;
                int posfromtop = 11 - positionint;
                // playerPosition = this.Height - height- 10  - positionint * squareWit;
                playerPosition = 20 + posfromtop * squareHei;
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
                    int posfromtop = positionint + 1;
                    // playerPosition = this.Height - height- 10  - positionint * squareWit;
                    playerPosition = 20 + posfromtop * squareHei;
                    // playerPosition = 50 + positionint * squareHei;
                }
                else
                {

                    int posfromtop = positionint + 1;
                    playerPosition = 40 + posfromtop * squareHei;
                }
                  //  playerPosition = 75 + positionint * squareHei; }
            }

            return playerPosition;
        }

        
    }
}
