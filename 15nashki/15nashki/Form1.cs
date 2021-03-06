﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15nashki
{
    public partial class Form1 : Form
    {
        GameProc game;
        public Form1()
        {
            InitializeComponent();
            game = new GameProc(4);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int position = Convert.ToInt16(((Button)sender).Tag);

            //MessageBox.Show(position.ToString());
            game.smeshen(position);
            refresh();
            if (game.maybeWin())
            {
                MessageBox.Show("Победил");
                startGame();
            }
        }

        private Button backButton(int position)
        {
            switch(position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default:return null;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            startGame();
        }
        private void startTryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startGame();
        }
        private void startGame()
        {
            game.zapoln();

            for (int j = 0; j < 100; j++)
                game.smeshmnoghod();

            refresh();
        }

        private void refresh()
        {
            for(int position = 0;position<16;position++)
            {
                int agFN = game.facingNum(position);
                backButton(position).Text = agFN.ToString();
                backButton(position).Visible = (agFN > 0);
            }
        }

        
    }
}
