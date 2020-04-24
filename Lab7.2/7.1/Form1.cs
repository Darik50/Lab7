using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7._1
{
    public partial class Form1 : Form
    {
        int Mx;
        int My;
        int Fx = 500;
        int Fy = 500;
        int Bx;
        int By;
        int Spd = 1;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10;
            timer1.Enabled = true;
            Mx = Control.MousePosition.X;
            My = Control.MousePosition.Y;
            Bx = Convert.ToInt32(this.Size.Width / 2) - 45;
            By = Convert.ToInt32(this.Size.Height / 2) - 42;
            button1.Location = new Point(Convert.ToInt32(this.Size.Width / 2) - 45, Convert.ToInt32(this.Size.Height / 2) - 42);
        }
        public partial class Form2 : Form
        {
            public Form2()
            {
                this.label1 = new System.Windows.Forms.Label();
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(20, 20);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(46, 17);
                this.label1.TabIndex = 1;
                this.label1.Text = "Поздравляем! Вы смогли нажать на кнопку!";
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(100, 50);
                this.Controls.Add(this.label1);
                this.MinimumSize = new System.Drawing.Size(300, 50);
                this.Name = "Form2";
                this.Text = "Form2";
                this.ResumeLayout(false);
            }
            private System.Windows.Forms.Label label1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Поздравляем! Вы смогли нажать на кнопку!";
            timer1.Enabled = false;
            Form2 FF = new Form2();
            FF.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = Mx - Control.MousePosition.X;
            int y = My - Control.MousePosition.Y;
            int rasx = Math.Abs(Mx - button1.Location.X) - Math.Abs(Control.MousePosition.X - button1.Location.X);
            int rasy = Math.Abs(My - button1.Location.Y) - Math.Abs(Control.MousePosition.Y - button1.Location.Y);
            Mx = Control.MousePosition.X;
            My = Control.MousePosition.Y;
            if (button1.Location.X - Spd * x > 20 && button1.Location.X - Spd * x + button1.Size.Width < this.ClientSize.Width - 20
                && button1.Location.Y - Spd * y > 20 && button1.Location.Y - Spd * y + button1.Size.Height < this.ClientSize.Height - 20
                && rasx + rasy > 0)
            {
                button1.Location = new Point(button1.Location.X - Spd * x, button1.Location.Y - Spd * y);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            double x = Convert.ToDouble(this.Size.Width) / Convert.ToDouble(Fx);
            double y = Convert.ToDouble(this.Size.Height) / Convert.ToDouble(Fy);
            Bx = Convert.ToInt32(Convert.ToDouble(button1.Location.X) * x);
            By = Convert.ToInt32(Convert.ToDouble(button1.Location.Y) * y);
            button1.Location = new Point(Bx, By);
            Fx = this.Size.Width;
            Fy = this.Size.Height;
            timer1.Enabled = true;
        }
    }
}
