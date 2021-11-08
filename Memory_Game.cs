/************************************************************************************
    PROGRAMME	:	Memory Game
    OUTLINE		:	This programme lets the user pick 2 boxes each containing a letter.
                    If the two boxes have the same letter then those letters stay up, 
                    and the user has to try to match every pair.
    PROGRAMMER	:	Mian Rafay
    DATE		:	March 1, 2020
 ************************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
namespace RafayM_BONUS_MemoryGame
{
    public partial class frmMemory : Form
    {
        public frmMemory()
        {
            InitializeComponent();
        }
        string[] collet = { "", "", "", "", "", "", "", "" };
        bool oneShow = false;
        Button btnShowing;
        private void btnStart_Click(object sender, EventArgs e)
        {
            string[] letters = { "A", "B", "C", "D" };
            Random rnd = new Random();
            Button[] col = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8 };
            btnShowing = null;
            foreach (Button btn in col)
            {
                btn.Text = "";
                btn.BackColor = Color.Maroon;
                btn.Enabled = true;
            }
            int[] checks = { 0, 0, 0, 0 };
                for (int i = 0; i < col.Length; i ++)
                {
                int rand = rnd.Next(0, 4);
                if (checks[rand] == 2)
                {
                    i -= 1;
                    continue;
                }
                checks[rand] += 1;
                collet[i] = letters[rand];
                }
        }
        private void btn1_Click(object sender, EventArgs e) 
        {
            Button[] col = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8 };
            Button clicked = (Button)sender;
            string name = clicked.Name.Substring(3);
            clicked.Text = collet[Int32.Parse(name) - 1];
            if (oneShow == false)
            {
                btnShowing = clicked;
                btnShowing.Enabled = false;
                oneShow = true;
            }
            else
            {
                try
                {
                    if (clicked.Text == btnShowing.Text)
                    {
                        btnShowing.BackColor = Color.LightGreen;
                        clicked.BackColor = Color.LightGreen;
                        clicked.Enabled = false;
                        bool Fin = true;
                        foreach (Button btn in col)
                        {
                            if (btn.Text == "")
                            {
                                Fin = false;
                            }
                        }
                        if (Fin == true)
                        {
                            MessageBox.Show("You won!!!", "Winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                else
                {
                    btnShowing.BackColor = Color.Red;
                    clicked.BackColor = Color.Red;
                    Refresh();
                    System.Threading.Thread.Sleep(1000);
                    btnShowing.Text = "";
                    clicked.Text = "";
                    btnShowing.BackColor = Color.Maroon;
                    clicked.BackColor = Color.Maroon;
                    btnShowing.Enabled = true;
                }
                }
                catch (Exception)
                {}
                oneShow = false;
            }
        }
    }
}
