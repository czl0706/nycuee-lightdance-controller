namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstLightData = new System.Windows.Forms.ListBox();
            this.btnPlayMusic = new MetroFramework.Controls.MetroTile();
            this.btnAddStamp = new MetroFramework.Controls.MetroTile();
            this.txtTimeStamp = new System.Windows.Forms.TextBox();
            this.btnEditMode = new MetroFramework.Controls.MetroTile();
            this.lblMusicFile = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPlayMode = new MetroFramework.Controls.MetroTile();
            this.btnAll = new MetroFramework.Controls.MetroTile();
            this.btnApply = new MetroFramework.Controls.MetroTile();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.btnDelete = new MetroFramework.Controls.MetroTile();
            this.grpEditMode = new System.Windows.Forms.GroupBox();
            this.grpPlayMode = new System.Windows.Forms.GroupBox();
            this.LblplayMode = new System.Windows.Forms.Label();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.btnConnect = new MetroFramework.Controls.MetroTile();
            this.btnPlayMode_Play = new MetroFramework.Controls.MetroTile();
            this.metroTile8 = new MetroFramework.Controls.MetroTile();
            this.label4 = new System.Windows.Forms.Label();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.btnOpenFile = new MetroFramework.Controls.MetroTile();
            this.btnSaveFile = new MetroFramework.Controls.MetroTile();
            this.lblJsonFile = new System.Windows.Forms.Label();
            this.btnStopMusic = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpEditMode.SuspendLayout();
            this.grpPlayMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.BackColor = System.Drawing.Color.Silver;
            this.metroTile1.ForeColor = System.Drawing.Color.White;
            this.metroTile1.Location = new System.Drawing.Point(11, 97);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(539, 102);
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "Color Table";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile1.UseCustomBackColor = true;
            this.metroTile1.UseCustomForeColor = true;
            this.metroTile1.UseSelectable = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 10);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lstLightData
            // 
            this.lstLightData.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLightData.FormattingEnabled = true;
            this.lstLightData.HorizontalScrollbar = true;
            this.lstLightData.ItemHeight = 30;
            this.lstLightData.Location = new System.Drawing.Point(1628, 33);
            this.lstLightData.Name = "lstLightData";
            this.lstLightData.Size = new System.Drawing.Size(241, 544);
            this.lstLightData.TabIndex = 4;
            this.lstLightData.SelectedIndexChanged += new System.EventHandler(this.lstLightData_SelectedIndexChanged);
            // 
            // btnPlayMusic
            // 
            this.btnPlayMusic.ActiveControl = null;
            this.btnPlayMusic.Location = new System.Drawing.Point(963, 505);
            this.btnPlayMusic.Name = "btnPlayMusic";
            this.btnPlayMusic.Size = new System.Drawing.Size(76, 48);
            this.btnPlayMusic.TabIndex = 6;
            this.btnPlayMusic.Text = "Play";
            this.btnPlayMusic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPlayMusic.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnPlayMusic.UseSelectable = true;
            this.btnPlayMusic.Click += new System.EventHandler(this.btnPlayMusic_Click);
            // 
            // btnAddStamp
            // 
            this.btnAddStamp.ActiveControl = null;
            this.btnAddStamp.Location = new System.Drawing.Point(1045, 505);
            this.btnAddStamp.Name = "btnAddStamp";
            this.btnAddStamp.Size = new System.Drawing.Size(130, 48);
            this.btnAddStamp.TabIndex = 6;
            this.btnAddStamp.Text = "Add/Update";
            this.btnAddStamp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddStamp.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnAddStamp.UseSelectable = true;
            this.btnAddStamp.Click += new System.EventHandler(this.btnAddStamp_Click);
            // 
            // txtTimeStamp
            // 
            this.txtTimeStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeStamp.Location = new System.Drawing.Point(963, 469);
            this.txtTimeStamp.Name = "txtTimeStamp";
            this.txtTimeStamp.Size = new System.Drawing.Size(167, 30);
            this.txtTimeStamp.TabIndex = 10;
            this.txtTimeStamp.TextChanged += new System.EventHandler(this.txtTimeStamp_TextChanged);
            // 
            // btnEditMode
            // 
            this.btnEditMode.ActiveControl = null;
            this.btnEditMode.Location = new System.Drawing.Point(11, 42);
            this.btnEditMode.Name = "btnEditMode";
            this.btnEditMode.Size = new System.Drawing.Size(128, 48);
            this.btnEditMode.TabIndex = 6;
            this.btnEditMode.Text = "Edit";
            this.btnEditMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditMode.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnEditMode.UseSelectable = true;
            this.btnEditMode.Click += new System.EventHandler(this.btnEditMode_Click);
            // 
            // lblMusicFile
            // 
            this.lblMusicFile.AutoSize = true;
            this.lblMusicFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicFile.Location = new System.Drawing.Point(958, 556);
            this.lblMusicFile.Name = "lblMusicFile";
            this.lblMusicFile.Size = new System.Drawing.Size(73, 25);
            this.lblMusicFile.TabIndex = 7;
            this.lblMusicFile.Text = "No File";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtComment.Location = new System.Drawing.Point(963, 433);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(167, 30);
            this.txtComment.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(844, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "TimeStamp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(860, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Comment";
            // 
            // btnPlayMode
            // 
            this.btnPlayMode.ActiveControl = null;
            this.btnPlayMode.Location = new System.Drawing.Point(145, 42);
            this.btnPlayMode.Name = "btnPlayMode";
            this.btnPlayMode.Size = new System.Drawing.Size(128, 48);
            this.btnPlayMode.TabIndex = 6;
            this.btnPlayMode.Text = "Play";
            this.btnPlayMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayMode.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnPlayMode.UseSelectable = true;
            this.btnPlayMode.Click += new System.EventHandler(this.btnPlayMode_Click);
            // 
            // btnAll
            // 
            this.btnAll.ActiveControl = null;
            this.btnAll.Location = new System.Drawing.Point(556, 151);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(96, 48);
            this.btnAll.TabIndex = 6;
            this.btnAll.Text = "All";
            this.btnAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAll.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnAll.UseSelectable = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnApply
            // 
            this.btnApply.ActiveControl = null;
            this.btnApply.Location = new System.Drawing.Point(556, 97);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(96, 48);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnApply.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnApply.UseSelectable = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 24;
            this.metroComboBox1.Location = new System.Drawing.Point(556, 61);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(96, 30);
            this.metroComboBox1.TabIndex = 14;
            this.metroComboBox1.UseSelectable = true;
            // 
            // btnDelete
            // 
            this.btnDelete.ActiveControl = null;
            this.btnDelete.Location = new System.Drawing.Point(1181, 505);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 48);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grpEditMode
            // 
            this.grpEditMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpEditMode.Controls.Add(this.pictureBox1);
            this.grpEditMode.Controls.Add(this.btnEditMode);
            this.grpEditMode.Controls.Add(this.metroComboBox1);
            this.grpEditMode.Controls.Add(this.btnAll);
            this.grpEditMode.Controls.Add(this.btnApply);
            this.grpEditMode.Controls.Add(this.btnPlayMode);
            this.grpEditMode.Controls.Add(this.metroTile1);
            this.grpEditMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpEditMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEditMode.Location = new System.Drawing.Point(15, 380);
            this.grpEditMode.Name = "grpEditMode";
            this.grpEditMode.Size = new System.Drawing.Size(664, 210);
            this.grpEditMode.TabIndex = 18;
            this.grpEditMode.TabStop = false;
            this.grpEditMode.Text = "Edit";
            // 
            // grpPlayMode
            // 
            this.grpPlayMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpPlayMode.Controls.Add(this.LblplayMode);
            this.grpPlayMode.Controls.Add(this.metroTile2);
            this.grpPlayMode.Controls.Add(this.btnConnect);
            this.grpPlayMode.Controls.Add(this.btnPlayMode_Play);
            this.grpPlayMode.Controls.Add(this.metroTile8);
            this.grpPlayMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpPlayMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPlayMode.Location = new System.Drawing.Point(466, 145);
            this.grpPlayMode.Name = "grpPlayMode";
            this.grpPlayMode.Size = new System.Drawing.Size(664, 210);
            this.grpPlayMode.TabIndex = 19;
            this.grpPlayMode.TabStop = false;
            this.grpPlayMode.Text = "Play";
            // 
            // LblplayMode
            // 
            this.LblplayMode.AutoSize = true;
            this.LblplayMode.Location = new System.Drawing.Point(27, 135);
            this.LblplayMode.Name = "LblplayMode";
            this.LblplayMode.Size = new System.Drawing.Size(92, 32);
            this.LblplayMode.TabIndex = 15;
            this.LblplayMode.Text = "label3";
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(11, 42);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(128, 48);
            this.metroTile2.TabIndex = 6;
            this.metroTile2.Text = "Edit";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.Click += new System.EventHandler(this.btnEditMode_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.ActiveControl = null;
            this.btnConnect.Location = new System.Drawing.Point(556, 97);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(96, 48);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConnect.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnConnect.UseSelectable = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnPlayMode_Play
            // 
            this.btnPlayMode_Play.ActiveControl = null;
            this.btnPlayMode_Play.Enabled = false;
            this.btnPlayMode_Play.Location = new System.Drawing.Point(556, 151);
            this.btnPlayMode_Play.Name = "btnPlayMode_Play";
            this.btnPlayMode_Play.Size = new System.Drawing.Size(96, 48);
            this.btnPlayMode_Play.TabIndex = 6;
            this.btnPlayMode_Play.Text = "Play";
            this.btnPlayMode_Play.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlayMode_Play.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnPlayMode_Play.UseSelectable = true;
            this.btnPlayMode_Play.Click += new System.EventHandler(this.btnPlayMode_Play_Click);
            // 
            // metroTile8
            // 
            this.metroTile8.ActiveControl = null;
            this.metroTile8.Location = new System.Drawing.Point(145, 42);
            this.metroTile8.Name = "metroTile8";
            this.metroTile8.Size = new System.Drawing.Size(128, 48);
            this.metroTile8.TabIndex = 6;
            this.metroTile8.Text = "Play";
            this.metroTile8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile8.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile8.UseSelectable = true;
            this.metroTile8.Click += new System.EventHandler(this.btnPlayMode_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(725, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "AutoSave";
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Checked = true;
            this.metroToggle1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle1.Location = new System.Drawing.Point(744, 425);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 20);
            this.metroToggle1.TabIndex = 23;
            this.metroToggle1.Text = "On";
            this.metroToggle1.UseSelectable = true;
            this.metroToggle1.CheckedChanged += new System.EventHandler(this.metroToggle1_CheckedChanged);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.ActiveControl = null;
            this.btnOpenFile.Location = new System.Drawing.Point(721, 451);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(103, 48);
            this.btnOpenFile.TabIndex = 20;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpenFile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnOpenFile.UseSelectable = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.ActiveControl = null;
            this.btnSaveFile.Location = new System.Drawing.Point(721, 505);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(103, 48);
            this.btnSaveFile.TabIndex = 21;
            this.btnSaveFile.Text = "Save File";
            this.btnSaveFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveFile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnSaveFile.UseSelectable = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // lblJsonFile
            // 
            this.lblJsonFile.AutoSize = true;
            this.lblJsonFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJsonFile.Location = new System.Drawing.Point(716, 557);
            this.lblJsonFile.Name = "lblJsonFile";
            this.lblJsonFile.Size = new System.Drawing.Size(73, 25);
            this.lblJsonFile.TabIndex = 22;
            this.lblJsonFile.Text = "No File";
            // 
            // btnStopMusic
            // 
            this.btnStopMusic.ActiveControl = null;
            this.btnStopMusic.Location = new System.Drawing.Point(881, 505);
            this.btnStopMusic.Name = "btnStopMusic";
            this.btnStopMusic.Size = new System.Drawing.Size(76, 48);
            this.btnStopMusic.TabIndex = 6;
            this.btnStopMusic.Text = "Stop";
            this.btnStopMusic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStopMusic.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnStopMusic.UseSelectable = true;
            this.btnStopMusic.Click += new System.EventHandler(this.btnStopMusic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1892, 600);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.metroToggle1);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.lblJsonFile);
            this.Controls.Add(this.grpPlayMode);
            this.Controls.Add(this.grpEditMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtTimeStamp);
            this.Controls.Add(this.lblMusicFile);
            this.Controls.Add(this.btnStopMusic);
            this.Controls.Add(this.btnPlayMusic);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddStamp);
            this.Controls.Add(this.lstLightData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpEditMode.ResumeLayout(false);
            this.grpPlayMode.ResumeLayout(false);
            this.grpPlayMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstLightData;
        private MetroFramework.Controls.MetroTile btnPlayMusic;
        private MetroFramework.Controls.MetroTile btnAddStamp;
        private System.Windows.Forms.TextBox txtTimeStamp;
        private MetroFramework.Controls.MetroTile btnEditMode;
        private System.Windows.Forms.Label lblMusicFile;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTile btnPlayMode;
        private MetroFramework.Controls.MetroTile btnAll;
        private MetroFramework.Controls.MetroTile btnApply;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroTile btnDelete;
        private System.Windows.Forms.GroupBox grpEditMode;
        private System.Windows.Forms.GroupBox grpPlayMode;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile btnPlayMode_Play;
        private MetroFramework.Controls.MetroTile metroTile8;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Controls.MetroTile btnOpenFile;
        private MetroFramework.Controls.MetroTile btnSaveFile;
        private System.Windows.Forms.Label lblJsonFile;
        private MetroFramework.Controls.MetroTile btnConnect;
        private System.Windows.Forms.Label LblplayMode;
        private MetroFramework.Controls.MetroTile btnStopMusic;
    }
}

