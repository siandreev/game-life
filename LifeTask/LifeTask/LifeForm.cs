using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeTask
{
    public partial class LifeForm : Form , Iview
    {
        public event Action ResetEvent;
        public event Action TurnFinished;
        public event Action CreateEvent;

        int size;
        LifeAlgoritm alg;

        public LifeForm()
        {
            InitializeComponent();
            addDataToCombobox();
            ResetEvent += Prepare;
        }

        /// <summary>
        /// Field preparation before the next launch.
        /// </summary>
        private void Prepare()
        {
            if (alg != null)
            {
                alg.Unsubscribe(this);
            }           
            alg = new LifeAlgoritm(size, this);
            paint(size);
            alg.ColorizeEvent += Colorize;
            CreateEvent();
        }

        /// <summary>
        /// Combobox data filling.
        /// </summary>
        private void addDataToCombobox()
        {
            for (int i = 10; i <= 30; i++)
            {
                comboBox1.Items.Add(i);
            }
        }

        /// <summary>
        /// Cell field drawing.
        /// </summary>
        /// <param name="size">Size of the field.</param>
        private void paint(int size)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            Pen blackPen = new Pen(Color.Black, 1 / 2);
            for (int i = 0; i <= size; i++)
            {
                g.DrawLine(blackPen, 20 * i, 0, 20 * i, 20 * size);
            }
            for (int i = 0; i <= size; i++)
            {
                g.DrawLine(blackPen, 0, 20 * i, 20 * size , 20 * i);
            }
        }

        /// <summary>
        /// Drawing living cells on the field.
        /// </summary>
        /// <param name="matrix">Living cell information storage matrix</param>
        public void Colorize(int[,] matrix)
        {
            Graphics g = panel1.CreateGraphics();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 1)
                        g.FillRectangle(Brushes.Cyan, new Rectangle(j * 20 + 1, i * 20 + 1, 19, 19));
                    else
                        g.FillRectangle(Brushes.White, new Rectangle(j * 20 + 1, i * 20 + 1, 19, 19));
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          
            if (!checkBox1.Checked)
            {
                timer1.Stop();
                size = (int)comboBox1.SelectedItem;
                Prepare();
            }
            
        }

        private void panel1_Paint(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TurnFinished();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            timer1.Stop();
            ResetEvent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                comboBox1.SelectedIndex = 10;
                size = 20;
                Prepare();
            }
            if (checkBox1.Checked)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}
