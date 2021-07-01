using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace YoketoruVS2021
{
    public partial class Form1 : Form
    {
        const bool isDebeg = true;


        const int PlayerMax = 1;
        const int EnemyMax = 3;
        const int ltemMax = 3;
        const int ChrMax = PlayerMax + EnemyMax + ltemMax;

        Label[] chrs = new Label[ChrMax];

        const int PlayerIndex = 0;
        const int EnemyIndex = PlayerMax;
        const int ItemIndex = EnemyIndex + EnemyMax;

        const string PlayerText = "(・ω・)";
        const string EnemyText = "◇";
        const string ItemText = "★";

        static Random rand = new Random();


        enum State
        {
            None = -1,  // 無効
            Title,      // タイトル
            Game,       // ゲーム
            Gameover,   // ゲームオーバー
            Clear       // クリア
        }
        State currentState = State.None;
        State nextState = State.Title;

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        public Form1()
        {
            InitializeComponent();

            for (int i =0; i<ChrMax;i++ )
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true;
                if (i == PlayerIndex)
                {
                    chrs[i].Text = PlayerText;
                }
                else if (i<ltemMax)
                {
                    chrs[i].Text = EnemyText;
                }
                else
                {
                    chrs[i].Text = ItemText;
                }

                chrs[i].Text = ItemText;
                Controls.Add(chrs[i]);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isDebeg)
            {
                if (GetAsyncKeyState((int)Keys.O) <0)
                {
                    nextState = State.Gameover;
                }
                else if (GetAsyncKeyState((int)Keys.C)<0)
                        {
                    nextState = State.Clear;
                }
            }

            if (nextState != State.None)
            {
                initProc();
            }

            if (currentState == State.Game)
            {
                UpdateGame();
            }
        }

        void initProc()
        {
            currentState = nextState;
            nextState = State.None;

            switch (currentState)
            {
                case State.Title:
                    titleLabel.Visible = true;
                    startButton.Visible = true;
                    copyrightLabel.Visible = true;
                    hiLabel.Visible = true;
                    GameOcerLabel.Visible = false;
                    titleButton.Visible = false;
                    clearLabel.Visible = false;
                    break;

                case State.Game:
                    titleLabel.Visible = false;
                    startButton.Visible = false;
                    copyrightLabel.Visible = false;
                    hiLabel.Visible = false;
                    break;

                    for (int i=EnemyIndex;i<ChrMax; i++)
                    {
                        chrs[i].Left = rand.Next(ClientSize.Width - chrs[i].Width);
                        chrs[i].Top = rand.Next(ClientSize.Height - chrs[i].Height);
                    }

                case State.Gameover:
                    //MessageBox.Show("GameOver");
                    GameOcerLabel.Visible = true;
                    titleButton.Visible = true;
                    break;

                case State.Clear:
                    // MessageBox.Show("Clear");
                    clearLabel.Visible = true;
                    titleButton.Visible = true;
                    break;
            }
        }

        void UpdateGame()
        {
            Point mp = PointToClient(MousePosition);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            nextState = State.Game;
        }

        private void titleButton_Click(object sender, EventArgs e)
        {
            nextState = State.Title;
        }
    }
}
