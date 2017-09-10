// Multithreading workout. 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Threading
{
    public partial class frmMain : Form
    {
        Thread thread1, thread2, thread3, thread4;
        Form theForm = new Form();
        Random randomGen;

        public frmMain()
        {
            InitializeComponent();
            theForm.FormClosing += new FormClosingEventHandler(formClosed);
            //checks if event handler happened
            //button2.Click += new EventHandler(checkBtn_Click);
            
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            randomGen = new Random();
        }

        //When the closing event is sent all threads are aborted
        //Current bug is that when closing the form
        //the drawing doesn't stop even if the thread does causing "System.ObjectDisposedException" to be thrown
        //Currently this error is in a try catch block till a real fix has been made.
        public void formClosed(object sender, FormClosingEventArgs e)
        {
            theForm = (Form)sender;
            thread1.Abort();
            thread2.Abort();
            thread4.Abort();
            thread3.Abort();
        }

        public void threadSleep()
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                }
                MessageBox.Show("Completed Red");
            }

        public void checkBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Button).Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(RedSquares);
            thread3 = new Thread(GreenSquares);
            thread1.Start();
            thread3.Start();
            
            //Stop Btn click 2 threads
          //  thread2.Abort();
           // thread4.Abort();
        }
     
        // Creates color squares using threads
        private void button2_Click(object sender, EventArgs e)
        {
            thread2 = new Thread(BlueSquares);
            thread4 = new Thread(OrangeSquares);
            thread2.Start();
            thread4.Start();
            //Stop Btn click 1 threads
            //thread1.Abort();
            //thread3.Abort();
        }


        // Pen drawn shapes
        public void BlueSquares()
        {
            for (int i = 0; i < 54; i++)
            {
                try
                {
                   this.CreateGraphics().DrawRectangle(new Pen(Brushes.Blue, 4), new Rectangle(randomGen.Next(0, this.Width), randomGen.Next(0, this.Height), 20, 100));
                }
                catch (System.ObjectDisposedException)
                {

                }
                Thread.Sleep(2);
            }
          //  MessageBox.Show("Completed Blue");
        }
        public void RedSquares()
        {
            for (int i = 0; i < 8; i++)
            {
                try{
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.RosyBrown, 21), new Rectangle(randomGen.Next(0, this.Width), randomGen.Next(0, this.Height),20,120));
                }
                catch (System.ObjectDisposedException)
                {

                }
                    Thread.Sleep(40);
            }
         //   MessageBox.Show("Completed Red");
        }
        public void OrangeSquares()
        {
            for (int i = 0; i < 11; i++)
            {
                try{
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Orange, 4), new Rectangle(randomGen.Next(0, this.Width), randomGen.Next(0, this.Height), 20, 80));
                }
                catch (System.ObjectDisposedException)
                {

                }
                Thread.Sleep(200);
            }
            //  MessageBox.Show("Completed Blue");
        }
        public void GreenSquares()
        {
            for (int i = 0; i < 32; i++)
            {   
                try{
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Green, 4), new Rectangle(randomGen.Next(0, this.Width), randomGen.Next(0, this.Height), 20, 60));
                }
                catch (System.ObjectDisposedException)
                {

                }
                 Thread.Sleep(58);
            }
            //  MessageBox.Show("Completed Blue");
        }
    }
}
