﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;
using System.IO.Ports;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private bool autosave = true;
        public class Data
        {
            public string comment { get; set; }
            public string timeStart { get; set; }
            public List<byte> lights { get; set; }
        }
        public class JsonFile
        {
            public List<Data> data { get; set; }
        }

        List<Data> lightData;

        private OpenFileDialog ofd = new OpenFileDialog(), ofd1 = new OpenFileDialog(); 

        private readonly uint[] colorTable = new uint[] 
        {
            0xFF0000, 0xFFFF00, 0x00FF00, 0x00FFFF, 0x0000FF, 0xFF00FF, 0xFFFFFF, 0x000000
        };

        private PictureBox[] colorSelector;
        Color currentColor = Color.Black;

        const int numberOfPeople = 9;
        const int bodyPart = 8;
        private PictureBox[, ] bodyParts;

        SetupIniIP ini = new SetupIniIP();
        string ini_filename = "lightdance.ini"; 
        //private int[, ] bodyPartsColorCode;

        //IPEndPoint test = ;
        IPEndPoint[] devs = {
            //new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000),
            new IPEndPoint(IPAddress.Parse("192.168.137.100"), 6000),
            new IPEndPoint(IPAddress.Parse("192.168.137.101"), 6000),
            new IPEndPoint(IPAddress.Parse("192.168.137.102"), 6000),
            new IPEndPoint(IPAddress.Parse("192.168.137.103"), 6000),
            new IPEndPoint(IPAddress.Parse("192.168.137.104"), 6000),
            new IPEndPoint(IPAddress.Parse("192.168.137.105"), 6000),
            new IPEndPoint(IPAddress.Parse("192.168.137.106"), 6000),
            new IPEndPoint(IPAddress.Parse("192.168.137.107"), 6000),
            new IPEndPoint(IPAddress.Parse("192.168.137.108"), 6000)
        };

        Socket socket;

        public static Color getColor(uint color)
        {
            return Color.FromArgb((byte)((color >> 16) & 0xFF), (byte)((color >> 8) & 0xFF), (byte)(color & 0xFF));
        }

        private void saveToJSON(string FileName)
        {
            if (FileName == "") {  return; }
            JsonFile t = new JsonFile();
            t.data = lightData;
            string json = JsonConvert.SerializeObject(t);
            File.WriteAllText(FileName, json);
        }

        private void colorSelectorClicked(object sender, EventArgs e)
        {
            PictureBox colorSel = (PictureBox)sender;
            currentColor = colorSel.BackColor;
            pictureBox1.BackColor = currentColor;
        }

        private void bodyClicked(object sender, EventArgs e)
        {
            PictureBox bodyPart = (PictureBox)sender;
            bodyPart.BackColor = currentColor;
        }

        private void colorSelectorInit()
        {
            int startX = 20, startY = 40;
            colorSelector = new PictureBox[colorTable.Length];
            
            for (int i = 0; i < colorTable.Length; i++)
            {
                colorSelector[i] = new PictureBox();
                colorSelector[i].BackColor = getColor(colorTable[i]);
                colorSelector[i].Size = new Size(50, 50);
                colorSelector[i].Location = new Point(startX, startY);
                colorSelector[i].Click += colorSelectorClicked;
                startX += 60;
            }
            metroTile1.Controls.AddRange(colorSelector);
            metroTile1.Width = 40 + 60 * colorTable.Length;
            pictureBox1.Width = metroTile1.Width;

            metroTile1.SendToBack();
        }

        private void bodyPartInit()
        {
            int startX = 30, startY = 120;
            //bodyPartsColorCode = new int[numberOfPeople, bodyPart];
            bodyParts = new PictureBox[numberOfPeople, bodyPart];
            for (int i = 0; i < numberOfPeople; i += 1)
            {
                bodyParts[i, 0] = new PictureBox(); // bodyPart_rightLeg
                bodyParts[i, 1] = new PictureBox(); // bodyPart_leftLeg
                bodyParts[i, 2] = new PictureBox(); // belly
                bodyParts[i, 3] = new PictureBox(); // bodyPart_rightarm
                bodyParts[i, 4] = new PictureBox(); // bodyPart_rightpalm
                bodyParts[i, 5] = new PictureBox(); // bodyPart_Head
                bodyParts[i, 6] = new PictureBox(); // bodyPart_leftarm
                bodyParts[i, 7] = new PictureBox(); // bodyPart_leftpaln

                for (int j = 0; j < bodyPart; j += 1)
                {
                    bodyParts[i, j].BackColor = Color.Black;
                    bodyParts[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    bodyParts[i, j].Click += bodyClicked;
                    this.Controls.Add(bodyParts[i, j]);
                }

                bodyParts[i, 0].Size = new Size(25, 80);
                bodyParts[i, 1].Size = new Size(25, 80);
                bodyParts[i, 2].Size = new Size(80, 100);
                bodyParts[i, 3].Size = new Size(25, 60);
                bodyParts[i, 4].Size = new Size(25, 60);
                bodyParts[i, 5].Size = new Size(60, 60);
                bodyParts[i, 6].Size = new Size(25, 60);
                bodyParts[i, 7].Size = new Size(25, 60);

                int margin = 5;
                bodyParts[i, 0].Location = new Point(startX + 25 + margin, startY + 160 + margin * 2);
                bodyParts[i, 1].Location = new Point(startX + 80 + margin, startY + 160 + margin * 2);
                bodyParts[i, 2].Location = new Point(startX + 25 + margin, startY + 60 + margin);
                bodyParts[i, 3].Location = new Point(startX, startY + 60 + margin);
                bodyParts[i, 4].Location = new Point(startX, startY + 120 + margin * 2);
                bodyParts[i, 5].Location = new Point(startX + margin + 25 + 10, startY);
                bodyParts[i, 6].Location = new Point(startX + margin * 2 + 105, startY + 60 + margin);
                bodyParts[i, 7].Location = new Point(startX + margin * 2 + 105, startY + 120 + margin * 2);

                /*PictureBox belly = new PictureBox();
                belly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.Controls.Add(belly);
                belly.Size = new Size(80, 100);
                belly.Location = new Point(startX + 25 + margin, startY + 60 + margin);
                belly.BackColor = Color.Black;*/

                startX += 180;
                
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Lightdance";
            colorSelectorInit();
            bodyPartInit();

            if (File.Exists(Application.StartupPath + "\\" + ini_filename))
            {
                ofd1.FileName = ini.IniReadValue("lightdance", "scriptURL", ini_filename);
                ofd.FileName = ini.IniReadValue("lightdance", "musicURL", ini_filename);

                if (ofd.FileName != "" && File.Exists(ofd.FileName))
                {
                    playerTimer = new System.Windows.Forms.Timer();
                    playerTimer.Interval = 10;
                    playerTimer.Tick += PlayerTimer_Tick;
                    WMP.URL = ofd.FileName;
                    WMP.PlayStateChange += WMP_PlayStateChange;
                    lblMusicFile.Text = ofd.SafeFileName;
                    WMP.controls.stop();
                }
                else
                {
                    ini.IniWriteValue("lightdance", "musicURL", "", ini_filename);
                }


                if (ofd1.FileName != "" && File.Exists(ofd1.FileName))
                {
                    string s = File.ReadAllText(ofd1.FileName);
                    lblJsonFile.Text = ofd1.SafeFileName;
                    File.WriteAllText(ofd1.FileName + ".bak", s);
                    lightData = JsonConvert.DeserializeObject<JsonFile>(s).data;
                    lstLightData.Items.Clear();
                    foreach (Data x in lightData)
                    {
                        string itemValue = x.comment + ", " + x.timeStart;
                        lstLightData.Items.Add(itemValue);
                    }
                }
                else 
                { 
                    ini.IniWriteValue("lightdance", "scriptURL", "", ini_filename); 
                }

                
            }
            else
            {
                File.Create(Application.StartupPath + "\\" + ini_filename);
            }

            for (int i = 0;i < numberOfPeople; i += 1)
            {
                metroComboBox1.Items.Add(i.ToString());
            }
            grpPlayMode.Location = grpEditMode.Location;
            grpEditMode.Visible = true;
            grpPlayMode.Visible = false;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ofd1.Filter = "json file (*.json)|*.json";
            ofd1.ShowDialog();
            if (ofd1.SafeFileName == "") { return; }
            lblJsonFile.Text = ofd1.SafeFileName;
            string s = File.ReadAllText(ofd1.FileName);
            File.WriteAllText(ofd1.FileName + ".bak", s);
            lightData = JsonConvert.DeserializeObject<JsonFile>(s).data;
            lstLightData.Items.Clear();
            foreach (Data x in lightData)
            {
                string itemValue = x.comment + ", " + x.timeStart;
                lstLightData.Items.Add(itemValue);
            }

            ini.IniWriteValue("lightdance", "scriptURL", ofd1.FileName, ini_filename);
        }

        System.Windows.Forms.Timer playerTimer;
        TimeSpan t;
        WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            string fileName = ofd1.FileName;
            if (fileName == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "json";
                saveFileDialog.ShowDialog();

                fileName = saveFileDialog.FileName;
                ofd1.FileName = fileName;
                lblJsonFile.Text = ofd1.SafeFileName;

                if (fileName == "") 
                {
                    MessageBox.Show("Save file failed.", "Fail", MessageBoxButtons.OKCancel);
                }
            }

            JsonFile t = new JsonFile();
            t.data = lightData;
            string json = JsonConvert.SerializeObject(t);
            File.WriteAllText(fileName, json);
        }

        private void PlayerTimer_Tick(object sender, EventArgs e)
        {
            t = TimeSpan.FromSeconds(WMP.controls.currentPosition);
            txtTimeStamp.Text = t.ToString(@"mm\:ss\.ff");
        }

        private void btnAddStamp_Click(object sender, EventArgs e)
        {
            int indexToInsert = lstLightData.SelectedIndex;
            // Update
            if (indexToInsert != -1 && lightData[indexToInsert].timeStart == txtTimeStamp.Text)
            {
                //lightData[indexToInsert].comment = txtComment.Text;

                //for (int i = 0; i < numberOfPeople; i += 1)
                //{
                //    for (int j = 0; j < bodyPart; j += 1)
                //    {
                //        uint colorVal = (uint)(bodyParts[i, j].BackColor.R) << 16 | (uint)(bodyParts[i, j].BackColor.G) << 8 | (uint)(bodyParts[i, j].BackColor.B);
                //        int colorIndex = Array.IndexOf(colorTable, colorVal);

                //        lightData[indexToInsert].lights[i * numberOfPeople + j] = colorIndex;
                //    }
                //}

                //string itemValue = txtComment.Text + ", " + txtTimeStamp.Text;
                //lstLightData.Items[indexToInsert] = itemValue;
            }
            else
            {
                TimeSpan timeToInsert; 
                if (!TimeSpan.TryParse("00:" + txtTimeStamp.Text, out timeToInsert)) 
                {
                    MessageBox.Show("Failed. Check TimeStamp.", "Fail", MessageBoxButtons.OKCancel);
                    return; 
                }

                if (lightData == null) lightData = new List<Data>();
                if (lightData.Count == 0) 
                { 
                    indexToInsert = 0;
                    lstLightData.Items.Insert(0, "");
                    Data tmp = new Data();
                    tmp.timeStart = "";
                    tmp.comment = "";
                    tmp.lights = new List<byte>(new byte[numberOfPeople * bodyPart]);

                    lightData.Insert(0, tmp);
                }
                else
                {
                    int i = lightData.Count - 1;
                    while (i >= 0)
                    {
                        if (TimeSpan.Parse("00:" + lightData[i].timeStart) == timeToInsert) 
                        { 
                            break; 
                        }
                        else if (TimeSpan.Parse("00:" + lightData[i].timeStart) < timeToInsert)
                        {
                            i += 1;
                            lstLightData.Items.Insert(i, "");
                            Data tmp = new Data();
                            tmp.timeStart = "";
                            tmp.comment = "";
                            tmp.lights = new List<byte>(new byte[numberOfPeople * bodyPart]);

                            lightData.Insert(i, tmp);
                            break;
                        }
                        i -= 1;
                    }

                    indexToInsert = i;
                }

            }

            lightData[indexToInsert].comment = txtComment.Text;
            lightData[indexToInsert].timeStart = txtTimeStamp.Text;

            for (int i = 0; i < numberOfPeople; i += 1)
            {
                for (int j = 0; j < bodyPart; j += 1)
                {
                    uint colorVal = (uint)(bodyParts[i, j].BackColor.R) << 16 | (uint)(bodyParts[i, j].BackColor.G) << 8 | (uint)(bodyParts[i, j].BackColor.B);
                    byte colorIndex = (byte)Array.IndexOf(colorTable, colorVal);
                    lightData[indexToInsert].lights[i * bodyPart + j] = colorIndex;
                }
            }

            string lstItemValue = txtComment.Text + ", " + txtTimeStamp.Text;
            lstLightData.Items[indexToInsert] = lstItemValue;

            if (autosave)
            {
                saveToJSON(ofd1.FileName);
            }
        }

        private void txtTimeStamp_TextChanged(object sender, EventArgs e)
        {
            if (playerTimer == null || playerTimer.Enabled) { return; }
            if (!TimeSpan.TryParse("00:" + txtTimeStamp.Text, out t)) { return; }
            WMP.controls.currentPosition = t.TotalSeconds;
        }

        bool play = false;
        private void btnPlayMusic_Click(object sender, EventArgs e)
        {
            btnPlayMusic.Focus();
            if (ofd.SafeFileName == "")
            {
                ofd.Filter = "music files (*.mp3;*.wav)|*.mp3;*.wav";
                ofd.ShowDialog();
                if (ofd.SafeFileName == "") { return; }

                playerTimer = new System.Windows.Forms.Timer();
                playerTimer.Interval = 10;
                playerTimer.Tick += PlayerTimer_Tick;
                WMP.URL = ofd.FileName;
                WMP.PlayStateChange += WMP_PlayStateChange;
                lblMusicFile.Text = ofd.SafeFileName;
                WMP.controls.stop();
                
                ini.IniWriteValue("lightdance", "musicURL", ofd.FileName, ini_filename);
                return;
            }
            
            if (!play)
            {
                WMP.controls.play();

                //playerTimer.Enabled = true;
                //btnPlayMusic.Text = "Pause";
            }
            else
            {
                WMP.controls.pause();

                //playerTimer.Enabled = false;
                //btnPlayMusic.Text = "Play";
            }
            play = !play;            
        }

        private void WMP_PlayStateChange(int NewState)
        {
            if (NewState == 1) // Stopped
            {
                playerTimer.Enabled = false;
                btnPlayMusic.Text = "Play";
            }
            else if (NewState == 2) // Paused
            {
                playerTimer.Enabled = false;
                btnPlayMusic.Text = "Play";
            }
            else if (NewState == 3) // Playing
            {
                playerTimer.Enabled = true;
                btnPlayMusic.Text = "Pause";
            }
        }

        private void lstLightData_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lstLightData.SelectedIndex;
            if (selectedIndex < 0) { return; }
            for (int i = 0; i < numberOfPeople; i += 1)
            {
                for (int j = 0; j < bodyPart; j += 1)
                {
                    int colorIndex = lightData[selectedIndex].lights[i * bodyPart + j];
                    bodyParts[i, j].BackColor = getColor(colorTable[colorIndex]);

                    txtComment.Text = lightData[selectedIndex].comment;
                    txtTimeStamp.Text = lightData[selectedIndex].timeStart;
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int i = metroComboBox1.SelectedIndex;
            if ( i < 0 ) { return; }    
            for (int j = 0; j < bodyPart; j += 1)
            {
                bodyParts[i, j].BackColor = currentColor;
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numberOfPeople; i += 1)
            {
                for (int j = 0; j < bodyPart; j += 1)
                {
                    bodyParts[i, j].BackColor = currentColor;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstLightData.SelectedIndex;
            if (selectedIndex == -1) { return; }

            lstLightData.Items.RemoveAt(selectedIndex);
            lightData.RemoveAt(selectedIndex);

            if (selectedIndex >= lstLightData.Items.Count) { selectedIndex -= 1; }
            lstLightData.SelectedIndex = selectedIndex;

            if (autosave)
            {
                saveToJSON(ofd1.FileName);
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            autosave = metroToggle1.Checked; 
        }

        private void btnEditMode_Click(object sender, EventArgs e)
        {
            grpEditMode.Visible = true;
            grpPlayMode.Visible = false;
            //this.Text = "Lightdance - Edit Mode";
        }

        //static Socket server;
        System.Windows.Forms.Timer playMode_playerTimer;
        TimeSpan playMode_t;
        WMPLib.WindowsMediaPlayer playMode_WMP;
        Queue<Data> playMode_data;
        static byte[] data_array = new byte [numberOfPeople * bodyPart];
        Data temp;

        //private void btnPlayMode_Play_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        playMode_data = new Queue<Data>(lightData);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("No data!");
        //        return;
        //    }

        //    playMode_playerTimer = new System.Windows.Forms.Timer();
        //    playMode_playerTimer.Interval = 50;
        //    playMode_playerTimer.Tick += PlayMode_playerTimer_Tick;
        //    playMode_WMP = new WMPLib.WindowsMediaPlayer();
        //    playMode_WMP.controls.play();
        //    playMode_WMP.URL = ofd.FileName;
        //    playMode_playerTimer.Enabled = true;
        //    socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //    temp = playMode_data.Dequeue();
        //    temp_lbl = temp.comment;
        //    data_array = (temp.lights).ToArray();
        //    playMode_t = TimeSpan.Parse("00:" + temp.timeStart);
        //}

        //private void PlayMode_playerTimer_Tick(object sender, EventArgs e)
        //{
        //    //if (!TimeSpan.TryParse("00:" + temp.timeStart, out playMode_t))
        //    //{
        //    //    return;
        //    //}
        //    if (TimeSpan.FromSeconds(playMode_WMP.controls.currentPosition).CompareTo(playMode_t) >= 0)
        //    {
        //        for (int i = 0; i < numberOfPeople; i = i + 1)
        //        {
        //            socket.SendTo(data_array, i * bodyPart, 7, 0, devs[i]);
        //        }

        //        LblplayMode.Text = temp_lbl;
        //        for (int i = 0; i < numberOfPeople; i++)
        //        {
        //            for (int j = 0; j < bodyPart; j++)
        //            {
        //                int index = data_array[i * bodyPart + j];
        //                bodyParts[i, j].BackColor = getColor(colorTable[index]);
        //            }
        //        }

        //        if (playMode_data.Count == 0) 
        //        { 
        //            playMode_playerTimer.Enabled = false; 
        //            return; 
        //        }

        //        temp = playMode_data.Dequeue();
        //        temp_lbl = temp.comment;
        //        data_array = (temp.lights).ToArray();
        //        playMode_t = TimeSpan.Parse("00:" + temp.timeStart);
        //    }
        //}
        private void btnPlayMode_Play_Click(object sender, EventArgs e)
        {
            try
            {
                playMode_data = new Queue<Data>(lightData);
            }
            catch
            {
                MessageBox.Show("No data!");
                return;
            }

            if (playMode_playerTimer != null)
            {
                playMode_playerTimer.Dispose(); playMode_playerTimer = null ;
                playMode_WMP.controls.stop();
            }

            playMode_playerTimer = new System.Windows.Forms.Timer();
            playMode_playerTimer.Interval = 50;
            playMode_playerTimer.Tick += PlayMode_playerTimer_Tick;
            playMode_WMP = new WMPLib.WindowsMediaPlayer();
            playMode_WMP.controls.play();
            playMode_WMP.URL = ofd.FileName;
            playMode_playerTimer.Enabled = true;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //temp = playMode_data.Dequeue();
            //temp_lbl = temp.comment;
            //data_array = (temp.lights).ToArray();
            //playMode_t = TimeSpan.Parse("00:" + temp.timeStart);

            temp = playMode_data.Dequeue();
            //temp_lbl = "";
            data_array = new byte[numberOfPeople * bodyPart];
            playMode_t = TimeSpan.Parse("00:" + temp.timeStart);

            btnPlayMode_Play.Text = "Restart";
        }

        int tick = 0, last = 0;
        private void PlayMode_playerTimer_Tick(object sender, EventArgs e)
        {
            //if (!TimeSpan.TryParse("00:" + temp.timeStart, out playMode_t))
            //{
            //    return;
            //}
            
            if (TimeSpan.FromSeconds(playMode_WMP.controls.currentPosition).CompareTo(playMode_t) >= 0)
            {
                tick = 4;
                data_array = (temp.lights).ToArray();
                LblplayMode.Text = temp.comment;
                for (int i = 0; i < numberOfPeople; i++)
                {
                    for (int j = 0; j < bodyPart; j++)
                    {
                        int index = data_array[i * bodyPart + j];
                        bodyParts[i, j].BackColor = getColor(colorTable[index]);
                    }
                }

                if (playMode_data.Count != 0) 
                { 
                    temp = playMode_data.Dequeue();
                    playMode_t = TimeSpan.Parse("00:" + temp.timeStart);
                    //playMode_playerTimer.Enabled = false;
                    //return;
                }
                else
                {
                    temp = null;
                    playMode_t = TimeSpan.Parse("01:00:00.00");
                }
            }

            tick += 1;
            if (tick == 5)
            {
                for (int i = 0; i < numberOfPeople; i = i + 1)
                {
                    socket.SendTo(data_array, i * bodyPart, bodyPart, 0, devs[i]);
                }
                if (temp == null)
                {
                    last += 1;
                    if (last == 5) { last = 0; playMode_playerTimer.Enabled = false; }
                }
                tick = 0;
            }
        }

        private void btnPlayMode_Click(object sender, EventArgs e)
        {
            grpEditMode.Visible = false;
            grpPlayMode.Visible = true;
            //this.Text = "Lightdance - Play Mode";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                //socket.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), 7000));
                btnPlayMode_Play.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception) 
            {
                MessageBox.Show("Create connection failed.", "Fail", MessageBoxButtons.OKCancel);
            }
        }

        private void lblMusicFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "music files (*.mp3;*.wav)|*.mp3;*.wav";
            ofd.ShowDialog();
            if (ofd.SafeFileName == "") { return; }

            if (playerTimer != null) { playerTimer.Dispose(); playerTimer = null; }
            playerTimer = new System.Windows.Forms.Timer();
            playerTimer.Interval = 10;
            playerTimer.Tick += PlayerTimer_Tick;
            WMP.URL = ofd.FileName;
            WMP.PlayStateChange += WMP_PlayStateChange;
            lblMusicFile.Text = ofd.SafeFileName;
            WMP.controls.stop();

            ini.IniWriteValue("lightdance", "musicURL", ofd.FileName, ini_filename);
            return;
        }

        private void btnStopMusic_Click(object sender, EventArgs e)
        {
            WMP.controls.stop();
            txtTimeStamp.Text = "00:00.00";
            play = false;
        }

        public class SetupIniIP
        {
            public string path;
            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);
            public void IniWriteValue(string Section, string Key, string Value, string inipath)
            {
                WritePrivateProfileString(Section, Key, Value, Application.StartupPath + "\\" + inipath);
            }
            public string IniReadValue(string Section, string Key, string inipath)
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp, 255, Application.StartupPath + "\\" + inipath);
                return temp.ToString();
            }
        }
    }
}
