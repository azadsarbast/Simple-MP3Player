
using System;
using System.Windows.Forms;
using NAudio.Wave;

namespace Mp3Player
{
    public partial class Form1 : Form
    {
        IWavePlayer player;
        AudioFileReader reader;

        string[] list;
        int i = 0;
        float j = 0.5f;

        public Form1()
        {
            InitializeComponent();

            
            player = new WaveOutEvent();
            player.Volume = j;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
        private void button8_Click(object sender, EventArgs e)
        {
            reader?.Dispose();
            player?.Dispose();

            this.Close();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            var di = new OpenFileDialog();

            di.Filter = "MP3 Files|*.mp3";

            if (di.ShowDialog() == DialogResult.OK)
            {
                PlaySong(di.FileName);

                pictureBox1.Visible = true;
                btn_play.Visible = false;
                btn_stop.Visible = true;
            }
        }

      
        private void btn_play_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                player.Play();

                btn_play.Visible = false;
                btn_stop.Visible = true;
                pictureBox1.Visible = true;
            }
        }

       
        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                player.Pause();

                btn_stop.Visible = false;
                btn_play.Visible = true;
                pictureBox1.Visible = false;
            }
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            var di = new OpenFileDialog();

            di.Multiselect = true;
            di.Filter = "MP3 Files|*.mp3";

            if (di.ShowDialog() == DialogResult.OK)
            {
                list = di.FileNames;
                i = 0;

                PlaySong(list[i]);

                pictureBox1.Visible = true;
                btn_play.Visible = false;
                btn_stop.Visible = true;
            }
        }

      
        private void button5_Click(object sender, EventArgs e)
        {
            if (list == null || list.Length == 0)
                return;

            if (i < list.Length - 1)
            {
                i++;

                PlaySong(list[i]);

                pictureBox1.Visible = true;
                btn_play.Visible = false;
                btn_stop.Visible = true;
            }
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            if (list == null || list.Length == 0)
                return;

            if (i > 0)
            {
                i--;

                PlaySong(list[i]);

                pictureBox1.Visible = true;
                btn_play.Visible = false;
                btn_stop.Visible = true;
            }
        }

       
        private void button6_Click(object sender, EventArgs e)
        {
            j += 0.1f;

            if (j > 1.0f)
                j = 1.0f;

            player.Volume = j;
        }

      
        private void button7_Click(object sender, EventArgs e)
        {
            j -= 0.1f;

            if (j < 0.0f)
                j = 0.0f;

            player.Volume = j;
        }

      
        private void PlaySong(string fileName)
        {
           
            player.Stop();

           
            reader?.Dispose();

          
            reader = new AudioFileReader(fileName);

          
            player.Init(reader);

           
            player.Play();
        }
    }
}

