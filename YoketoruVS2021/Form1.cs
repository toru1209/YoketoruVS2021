﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoketoruVS2021
{
    public partial class Form1 : Form
    {

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


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (nextState != State.None)
            {
                initProc();
            }
        }

        void initProc()
        {
            State currentState = State.None;
            State nextState = State.Title;

            switch (currentState)
            {
                case State.Title:
                    titleLabel.Visible = true;
                    startButton.Visible = true;
                    copyrightLabel.Visible = true;
                    hiLabel.Visible = true;
                    GameOcerLabel.Visible = false;
                    titleButton.Visible = false;
                    CLEARLabel.Visible = false;
                    break;

                case State.Game:
                    titleLabel.Visible = false;
                    startButton.Visible = false;
                    copyrightLabel.Visible = false;
                    hiLabel.Visible = false;
                    break;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            nextState = State.Game;
        }
    }
}
