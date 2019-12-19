using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THE_BEST_TIC_TAC
{
    public partial class Form1 : Form
    {
        bool turn;
        int countTurn;
        String winner = "";
        public Form1()
        {
            Init();
            InitializeComponent();
            
        }
        private void Init()
        {
            turn = true;
            countTurn = 0;
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game is created by Polina");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            
            countTurn++;
            Button button = (Button)sender;
            if (turn)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }
            turn = !turn;
            button.Enabled = false;
            CheckWinner();
            if (!turn)
            {
                MakeByComputer();
            }
        }
        private void CheckWinner()
        {

            bool check = false;
            // CHECK HORIZOTAL WIN
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (A1.Text != ""))
                check = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B1.Text != ""))
                check = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (C1.Text != ""))
                check = true;
            //CHECK VERTICAL WIN
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (A1.Text != ""))
                check = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (A2.Text != ""))
                check = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (A3.Text != ""))
                check = true;
            // CHECK DIAGONAL WIN
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (A1.Text != ""))
                check = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (C1.Text != ""))
                check = true;
            if (check)
            {
                
                if (turn)
                {
                    winner = "Computer";
                    ComputerWin.Text = (Int32.Parse(ComputerWin.Text) + 1).ToString();
                }
                else
                {
                    winner = "Player";
                    PlayerWin.Text = (Int32.Parse(PlayerWin.Text) + 1).ToString();
                }

                MessageBox.Show("Winner is " + winner, "Yay!");
                DisableButtons();
            }
            else
            {
                if (countTurn == 9)
                {
                    DrawWin.Text = (Int32.Parse(DrawWin.Text) + 1).ToString();
                    MessageBox.Show("Draw!", "Boom!");
                }
            }

        }
        private void DisableButtons()
        {
            
                foreach (Control element in Controls)
                {
                try
                {
                    Button button = (Button)element;
                    button.Enabled = false;
                }
                catch
                { }
            
            }
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Init();
           
                foreach (Control element in Controls)
                {
                try
                {
                    Button button = (Button)element;
                    button.Enabled = true;
                    button.Text = "";
                }
                catch
                { }
            }
            
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled)
            {
                if (turn)
                {
                    button.Text = "X";
                }
                else
                {
                    button.Text = "O";
                }
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled)
            {
                button.Text = "";
            }
        }

        private void resetWinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawWin.Text = "0";
            PlayerWin.Text = "0";
            ComputerWin.Text = "0";
        }
        private void MakeByComputer()
        {
            // Computer logic goes here
            // step 1: get tic tac toe
            // step 2: block x tic tac toe
            // step 3: go corner space
            // step 4: pick open space
            Button move = null;
            move = LookWinOrBlock("O"); // step for win
            if (move == null)
            {
                move = LookWinOrBlock("X"); // if no win - step for block
                if (move == null)
                {
                    move = LookForCorner();
                    if(move == null)
                    {
                        move = LookForFreeSpace();
                    }
                }
            }
            if(move!= null)
            move.PerformClick();
        }
        private Button LookWinOrBlock(string item)
        {
            // Horizontal strategy
            if ((A1.Text == "") && (A2.Text == item) && (A3.Text == item))
                return A1;
            if ((A1.Text == item) && (A2.Text == "") && (A3.Text == item))
                return A2;
            if ((A1.Text == item) && (A2.Text == item) && (A3.Text == ""))
                return A3;

            if ((B1.Text == "") && (B2.Text == item) && (B3.Text == item))
                return B1;
            if ((B1.Text == item) && (B2.Text == "") && (B3.Text == item))
                return B2;
            if ((B1.Text == item) && (B2.Text == item) && (B3.Text == ""))
                return B3;

            if ((C1.Text == "") && (C2.Text == item) && (C3.Text == item))
                return C1;
            if ((C1.Text == item) && (C2.Text == "") && (C3.Text == item))
                return C2;
            if ((C1.Text == item) && (C2.Text == item) && (C3.Text == ""))
                return C3;

            // Vertical strategy
            if ((A1.Text == "") && (B1.Text == item) && (C1.Text == item))
                return A1;
            if ((A1.Text == item) && (B1.Text == "") && (C1.Text == item))
                return B1;
            if ((A1.Text == item) && (B1.Text == item) && (C1.Text == ""))
                return C1;

            if ((A2.Text == "") && (B2.Text == item) && (C2.Text == item))
                return A2;
            if ((A2.Text == item) && (B2.Text == "") && (C2.Text == item))
                return B2;
            if ((A2.Text == item) && (B2.Text == item) && (C2.Text == ""))
                return C2;

            if ((A3.Text == "") && (B3.Text == item) && (C3.Text == item))
                return A3;
            if ((A3.Text == item) && (B3.Text == "") && (C3.Text == item))
                return B3;
            if ((A3.Text == item) && (B3.Text == item) && (C3.Text == ""))
                return C3;
            // DIAGONAL STRATEGY
            if ((A1.Text == "") && (B2.Text == item) && (C3.Text == item))
                return A1;
            if ((A1.Text == item) && (B2.Text == "") && (C3.Text == item))
                return B2;
            if ((A1.Text == item) && (B2.Text == item) && (C3.Text == ""))
                return C3;
            if ((A3.Text == "") && (B2.Text == item) && (C1.Text == item))
                return A3;
            if ((A3.Text == item) && (B2.Text == "") && (C1.Text == item))
                return B2;
            if ((A3.Text == item) && (B2.Text == item) && (C1.Text == ""))
                return C1;
            return null;
        }
        private Button LookForCorner()
        {
            if (A1.Text =="O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }
            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }
            if (C1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (A1.Text == "")
                    return A1;
            }
            if (C3.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (A1.Text == "")
                    return A1;
                if (C1.Text == "")
                    return C1;
            }
            return null;
        }
        private Button LookForFreeSpace()
        {
            Button button = null;
            foreach( Control element in Controls)
            {
                button = element as Button;
                if (button != null && button.Text == "")
                    return button;
            }
            return null;
        }

    }
}
