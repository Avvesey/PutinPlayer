using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace WindowsFormsPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Global_Data.Files.Add(openFileDialog1.FileName);
            playlist.Items.Add(Global_Data.GetFileName(openFileDialog1.FileName));

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = TimeSpan.FromSeconds(SubBass.GetPositionOfStream(SubBass.Streem)).ToString();
            SliderTime.Value = SubBass.GetPositionOfStream(SubBass.Streem);
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    
        private void open_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }


        private void stop_Click(object sender, EventArgs e)
        {
            SubBass.check = false;
            SubBass.Stop();
            timer1.Enabled = false;
            SliderTime.Value = 0;
            label1.Text = "00:00";
            label2.Text = "00:00";
        }


        private void pause_Click_1(object sender, EventArgs e)
        {
            SubBass.check = true;
            SubBass.Pause();
            timer1.Enabled = false;
            SliderTime.Value = SubBass.GetPositionOfStream(SubBass.Streem);
            label1.Text = TimeSpan.FromSeconds(SubBass.GetPositionOfStream(SubBass.Streem)).ToString();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (SubBass.check == true)
            {
                SubBass.Chanel_play();
                timer1.Enabled = true;
                SliderTime.Value = SubBass.GetPositionOfStream(SubBass.Streem);
                label1.Text = TimeSpan.FromSeconds(SubBass.GetPositionOfStream(SubBass.Streem)).ToString();
            }
            else
            {
                string current = Global_Data.Files[playlist.SelectedIndex = 0];
                SubBass.PLay(current, SubBass.Volume);
                label1.Text = TimeSpan.FromSeconds(SubBass.GetPositionOfStream(SubBass.Streem)).ToString();
                label2.Text = TimeSpan.FromSeconds(SubBass.GetTimeOfTrackSteam(SubBass.Streem)).ToString();
                SliderTime.Maximum = SubBass.GetTimeOfTrackSteam(SubBass.Streem);
                SliderTime.Value = SubBass.GetPositionOfStream(SubBass.Streem);
                timer1.Enabled = true;
            }
        }


        private void playlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void playlist_DoubleClick_1(object sender, EventArgs e)
        {
            SubBass.check = true;
            SubBass.Stop();



            string current = Global_Data.Files[playlist.SelectedIndex];
            SubBass.PLay(current, SubBass.Volume);
            label1.Text = TimeSpan.FromSeconds(SubBass.GetPositionOfStream(SubBass.Streem)).ToString();
            label2.Text = TimeSpan.FromSeconds(SubBass.GetTimeOfTrackSteam(SubBass.Streem)).ToString();
            SliderTime.Maximum = SubBass.GetTimeOfTrackSteam(SubBass.Streem);
            SliderTime.Value = SubBass.GetPositionOfStream(SubBass.Streem);
            timer1.Enabled = true;
        }


        private void SliderVolume_Scroll(object sender, ScrollEventArgs e)
        {
            SubBass.SetVolumeToStream(SubBass.Streem, SliderVolume.Value);
        }


        private void SliderTime_Scroll_1(object sender, ScrollEventArgs e)
        {
            SubBass.SetPosOfScroll(SubBass.Streem, SliderTime.Value);
        }

        
    }
}
