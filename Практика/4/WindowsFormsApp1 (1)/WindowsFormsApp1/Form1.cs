using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        public Timer timer;
      
        private bool isRunning = false; 
        private Color forwardColor = Color.Red; 
        private Color backwardColor = Color.Blue;
        int sec = 0;
        int w = 50, h = 50;
        int x = 0, y =0;
        int dx = 5;
        bool da = false;
        enum STATUS { Left, Right, Up, Down };  
        STATUS flag;	
      
       public SolidBrush brush = new SolidBrush(Color.Red); 
      
        Rectangle rc; 
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 10; 
            timer.Tick += timer1_Tick;
            flag = STATUS.Down;
            this.KeyPreview = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(brush, rc);
        }

        public void setcolor (Color color)
        {
            backwardColor = color;
            brush = new SolidBrush(color);
        }
        public void setcolor_for(Color color)
        {
            forwardColor = color;
            brush = new SolidBrush(color);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++; 
            rc = new Rectangle(x, y, w, h); 
            this.Invalidate(rc, true);               

            if (flag == STATUS.Left) 
            {
                x -= dx;
                if (x < 1 && y > 0) 
                {
                    if (da)
                    {
                        flag = STATUS.Up;
                        da = false;
                    }
                    else
                    {
                        y += dx; 
                       
                        flag = STATUS.Down;
                    }
                      
                }
                
                else if (x <= 1 && y <= 0) 
                {
                    flag = STATUS.Right;
                }
                else if (x <= 1 && y >= (this.ClientSize.Height))
                {
                    flag = STATUS.Up; 
                }
            }
            else if (flag == STATUS.Right)
            {
                x += dx;
                if (x >= (this.ClientSize.Width - w)) 
                {
                    da = true;
                    flag = STATUS.Up; 
                }
            }
            else if (flag == STATUS.Up) 
            {
                y -= dx;
              
                if (y <= 1 && x >= 0)
                {
                    flag = STATUS.Down; 
                    if (da) { 
                        brush = new SolidBrush(backwardColor); 
                    }
                    else
                    {
                        brush = new SolidBrush(forwardColor);
                    }
                   
                }
            }
            else if (flag == STATUS.Down) 
            {
                y += dx;
                if (y >= (this.ClientSize.Height - h)) 
                {
                    flag = STATUS.Right; 
                }
                if (y >= (this.ClientSize.Height - h) && x >= 0)
                {
                    flag = STATUS.Left;
                }
                if (y > (this.ClientSize.Height )) 
                {
                    flag = STATUS.Up; 
                }

            }
            rc = new Rectangle(x, y, w, h); 
            this.Invalidate(rc, true);  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                timer.Stop();
                button1.Text = "Старт";
            }
            else
            {
                timer.Start();
                button1.Text = "Стоп";
            }
            isRunning = !isRunning;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {  
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
