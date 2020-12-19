using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Вектора
{
    public partial class Vector : Form
    {
        public Vector()
        {
            InitializeComponent();
        }
        Single _Ax, _Ay, _Bx, _By, _Cx, _Cy, _lengthA, _lengthB, _lengthC, _korAx, _korBx, _korAy, _korBy, _korCx, _korCy;
        public void Drow()
        {
            Graphics bmp = pictureBox1.CreateGraphics();
            bmp.DrawLine(new Pen(Brushes.Black, 2), new Point(0, 200), new Point(900, 200));
            bmp.DrawLine(new Pen(Brushes.Black, 2), new Point(190, 0), new Point(190, 700));//отрисовка оси координат
            Pen penA = new Pen(Color.Red);
            bmp.DrawLine(penA, 190, 200, _korAx, _korAy);//рисует вектор А красным
            Pen penB = new Pen(Color.Blue);
            bmp.DrawLine(penB, 190, 200, _korBx, _korBy);//рисует вектор В синим
            if (radioButton1.Checked)
            {
                Pen penC = new Pen(Color.Green);
                bmp.DrawLine(penC, 190, 200, _korCx, _korCy);//рисует вектор С зеленым
            }
            if (radioButton2.Checked)
            {
                Pen penC = new Pen(Color.Green);
                bmp.DrawLine(penC, _korAx, _korAy, _korBx, _korBy);
            }
        }

        public void Calc()
        {
            _korAx = 190 +  _Ax;
            _korAy = 200 -  _Ay;
            _korBx = 190 +  _Bx;
            _korBy = 200 -  _By;
            if (radioButton1.Checked)
            {
                _korCy = 200 -  _Cy;
                _korCx = 190 +  _Cx;
            }
            if (radioButton2.Checked)
            {
            }
            _Ax = Convert.ToSingle(numericUpDown1.Value);
            _Ay = Convert.ToSingle(numericUpDown2.Value);
            _Bx = Convert.ToSingle(numericUpDown3.Value);
            _By = Convert.ToSingle(numericUpDown4.Value);
            _lengthA = (Single)Math.Sqrt((_Ax * _Ax) + (_Ay * _Ay));
            _lengthB = (Single)Math.Sqrt((_Bx * _Bx) + (_By * _By));
            _lengthC = (Single)Math.Sqrt((_Cx * _Cx) + (_Cy * _Cy));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calc();
            if (radioButton1.Checked)
            {
                _Cx = _Ax + _Bx;
                _Cy = _Ay + _By;
            }
            if (radioButton2.Checked)
            {
                _Cx = _Ax - _Bx;
                _Cy = _Ay - _By;
            }
            textBox1.Text = Convert.ToString(_lengthA);
            textBox2.Text = Convert.ToString(_lengthB);
            textBox3.Text = Convert.ToString(_Cx);
            textBox4.Text = Convert.ToString(_Cy);
            textBox5.Text = Convert.ToString(_lengthC);
            Graphics bmp = pictureBox1.CreateGraphics();
            bmp.Clear(SystemColors.Control);
            Drow();

        }
    }
}
