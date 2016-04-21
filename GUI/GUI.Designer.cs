using System.ComponentModel;
using System.Windows.Forms;

namespace PetBattleEasy.GUI
{
    internal partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.On = new System.Windows.Forms.CheckBox();
            this.Only1 = new System.Windows.Forms.CheckBox();
            this.Nonstop = new System.Windows.Forms.CheckBox();
            this.LeaveGame = new System.Windows.Forms.CheckBox();
            this.Slot1Swap = new System.Windows.Forms.CheckBox();
            this.OK = new System.Windows.Forms.Button();
            this.NameReg = new System.Windows.Forms.ComboBox();
            this.reg = new System.Windows.Forms.Button();
            this.Slot1SwapLevel = new System.Windows.Forms.NumericUpDown();
            this.update = new System.Windows.Forms.Button();
            this.SoloReg = new System.Windows.Forms.Button();
            this.Solo = new System.Windows.Forms.CheckBox();
            this.Slot2SwapLevel = new System.Windows.Forms.NumericUpDown();
            this.Slot3SwapLevel = new System.Windows.Forms.NumericUpDown();
            this.Slot2Swap = new System.Windows.Forms.CheckBox();
            this.Slot3Swap = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.EnemyLevel = new System.Windows.Forms.NumericUpDown();
            this.Calculate = new System.Windows.Forms.Button();
            this.slotToInsert = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HpFactor = new System.Windows.Forms.NumericUpDown();
            this.DisFactor = new System.Windows.Forms.NumericUpDown();
            this.AdFactor = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpage1 = new System.Windows.Forms.TabPage();
            this.ImpruvedLogic = new System.Windows.Forms.CheckBox();
            this.SetPets = new System.Windows.Forms.Button();
            this.CheckCell = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Slot1SwapLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Slot2SwapLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Slot3SwapLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slotToInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HpFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdFactor)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabpage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // On
            // 
            this.On.AutoSize = true;
            this.On.Location = new System.Drawing.Point(13, 17);
            this.On.Name = "On";
            this.On.Size = new System.Drawing.Size(40, 17);
            this.On.TabIndex = 0;
            this.On.Text = "On";
            this.On.UseVisualStyleBackColor = true;
            this.On.CheckedChanged += new System.EventHandler(this.On_CheckedChanged);
            // 
            // Only1
            // 
            this.Only1.AutoSize = true;
            this.Only1.Location = new System.Drawing.Point(13, 41);
            this.Only1.Name = "Only1";
            this.Only1.Size = new System.Drawing.Size(53, 17);
            this.Only1.TabIndex = 1;
            this.Only1.Text = "Only1";
            this.Only1.UseVisualStyleBackColor = true;
            this.Only1.CheckedChanged += new System.EventHandler(this.Only1_CheckedChanged);
            // 
            // Nonstop
            // 
            this.Nonstop.AutoSize = true;
            this.Nonstop.Location = new System.Drawing.Point(13, 65);
            this.Nonstop.Name = "Nonstop";
            this.Nonstop.Size = new System.Drawing.Size(66, 17);
            this.Nonstop.TabIndex = 2;
            this.Nonstop.Text = "Nonstop";
            this.Nonstop.UseVisualStyleBackColor = true;
            this.Nonstop.CheckedChanged += new System.EventHandler(this.Nonstop_CheckedChanged);
            // 
            // LeaveGame
            // 
            this.LeaveGame.AutoSize = true;
            this.LeaveGame.Location = new System.Drawing.Point(13, 89);
            this.LeaveGame.Name = "LeaveGame";
            this.LeaveGame.Size = new System.Drawing.Size(84, 17);
            this.LeaveGame.TabIndex = 3;
            this.LeaveGame.Text = "LeaveGame";
            this.LeaveGame.UseVisualStyleBackColor = true;
            this.LeaveGame.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // Slot1Swap
            // 
            this.Slot1Swap.AutoSize = true;
            this.Slot1Swap.Location = new System.Drawing.Point(77, 43);
            this.Slot1Swap.Name = "Slot1Swap";
            this.Slot1Swap.Size = new System.Drawing.Size(77, 17);
            this.Slot1Swap.TabIndex = 4;
            this.Slot1Swap.Text = "Slot1Swap";
            this.Slot1Swap.UseVisualStyleBackColor = true;
            this.Slot1Swap.CheckedChanged += new System.EventHandler(this.Slot1Swap_CheckedChanged);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(361, 398);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 5;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // NameReg
            // 
            this.NameReg.FormattingEnabled = true;
            this.NameReg.Location = new System.Drawing.Point(6, 164);
            this.NameReg.Name = "NameReg";
            this.NameReg.Size = new System.Drawing.Size(121, 21);
            this.NameReg.TabIndex = 6;
            this.NameReg.TextChanged += new System.EventHandler(this.NameReg_Change);
            // 
            // reg
            // 
            this.reg.Location = new System.Drawing.Point(6, 205);
            this.reg.Name = "reg";
            this.reg.Size = new System.Drawing.Size(75, 23);
            this.reg.TabIndex = 7;
            this.reg.Text = "В очередь";
            this.reg.UseVisualStyleBackColor = true;
            this.reg.Click += new System.EventHandler(this.reg_Click);
            // 
            // Slot1SwapLevel
            // 
            this.Slot1SwapLevel.Location = new System.Drawing.Point(31, 42);
            this.Slot1SwapLevel.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Slot1SwapLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Slot1SwapLevel.Name = "Slot1SwapLevel";
            this.Slot1SwapLevel.Size = new System.Drawing.Size(40, 20);
            this.Slot1SwapLevel.TabIndex = 8;
            this.Slot1SwapLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Slot1SwapLevel.ValueChanged += new System.EventHandler(this.Slot1SwapLevel_ValueChanged);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(31, 118);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(40, 23);
            this.update.TabIndex = 9;
            this.update.Text = "update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // SoloReg
            // 
            this.SoloReg.Location = new System.Drawing.Point(130, 17);
            this.SoloReg.Name = "SoloReg";
            this.SoloReg.Size = new System.Drawing.Size(75, 41);
            this.SoloReg.TabIndex = 10;
            this.SoloReg.Text = "Играть одному";
            this.SoloReg.UseVisualStyleBackColor = true;
            this.SoloReg.Click += new System.EventHandler(this.SoloReg_Click);
            // 
            // Solo
            // 
            this.Solo.AutoSize = true;
            this.Solo.Location = new System.Drawing.Point(84, 17);
            this.Solo.Name = "Solo";
            this.Solo.Size = new System.Drawing.Size(47, 17);
            this.Solo.TabIndex = 11;
            this.Solo.Text = "Solo";
            this.Solo.UseVisualStyleBackColor = true;
            this.Solo.CheckedChanged += new System.EventHandler(this.Solo_CheckedChanged);
            // 
            // Slot2SwapLevel
            // 
            this.Slot2SwapLevel.Location = new System.Drawing.Point(31, 68);
            this.Slot2SwapLevel.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Slot2SwapLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Slot2SwapLevel.Name = "Slot2SwapLevel";
            this.Slot2SwapLevel.Size = new System.Drawing.Size(40, 20);
            this.Slot2SwapLevel.TabIndex = 12;
            this.Slot2SwapLevel.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Slot2SwapLevel.ValueChanged += new System.EventHandler(this.Slot2SwapLevel_ValueChanged);
            // 
            // Slot3SwapLevel
            // 
            this.Slot3SwapLevel.Location = new System.Drawing.Point(30, 94);
            this.Slot3SwapLevel.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Slot3SwapLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Slot3SwapLevel.Name = "Slot3SwapLevel";
            this.Slot3SwapLevel.Size = new System.Drawing.Size(40, 20);
            this.Slot3SwapLevel.TabIndex = 13;
            this.Slot3SwapLevel.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.Slot3SwapLevel.ValueChanged += new System.EventHandler(this.Slot3SwapLevel_ValueChanged);
            // 
            // Slot2Swap
            // 
            this.Slot2Swap.AutoSize = true;
            this.Slot2Swap.Location = new System.Drawing.Point(77, 70);
            this.Slot2Swap.Name = "Slot2Swap";
            this.Slot2Swap.Size = new System.Drawing.Size(77, 17);
            this.Slot2Swap.TabIndex = 14;
            this.Slot2Swap.Text = "Slot2Swap";
            this.Slot2Swap.UseVisualStyleBackColor = true;
            this.Slot2Swap.CheckedChanged += new System.EventHandler(this.Slot2Swap_CheckedChanged);
            // 
            // Slot3Swap
            // 
            this.Slot3Swap.AutoSize = true;
            this.Slot3Swap.Location = new System.Drawing.Point(77, 96);
            this.Slot3Swap.Name = "Slot3Swap";
            this.Slot3Swap.Size = new System.Drawing.Size(77, 17);
            this.Slot3Swap.TabIndex = 15;
            this.Slot3Swap.Text = "Slot3Swap";
            this.Slot3Swap.UseVisualStyleBackColor = true;
            this.Slot3Swap.CheckedChanged += new System.EventHandler(this.Slot3Swap_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(309, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(85, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // EnemyLevel
            // 
            this.EnemyLevel.Location = new System.Drawing.Point(354, 109);
            this.EnemyLevel.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.EnemyLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EnemyLevel.Name = "EnemyLevel";
            this.EnemyLevel.Size = new System.Drawing.Size(40, 20);
            this.EnemyLevel.TabIndex = 17;
            this.EnemyLevel.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.EnemyLevel.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(319, 135);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(75, 23);
            this.Calculate.TabIndex = 18;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // slotToInsert
            // 
            this.slotToInsert.Location = new System.Drawing.Point(312, 109);
            this.slotToInsert.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.slotToInsert.Name = "slotToInsert";
            this.slotToInsert.Size = new System.Drawing.Size(39, 20);
            this.slotToInsert.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // HpFactor
            // 
            this.HpFactor.Location = new System.Drawing.Point(6, 27);
            this.HpFactor.Name = "HpFactor";
            this.HpFactor.Size = new System.Drawing.Size(35, 20);
            this.HpFactor.TabIndex = 22;
            this.HpFactor.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.HpFactor.ValueChanged += new System.EventHandler(this.HpFactor_ValueChanged);
            // 
            // DisFactor
            // 
            this.DisFactor.Location = new System.Drawing.Point(18, 29);
            this.DisFactor.Name = "DisFactor";
            this.DisFactor.Size = new System.Drawing.Size(35, 20);
            this.DisFactor.TabIndex = 23;
            this.DisFactor.Value = new decimal(new int[] {
            29,
            0,
            0,
            0});
            this.DisFactor.ValueChanged += new System.EventHandler(this.DisFactor_ValueChanged);
            // 
            // AdFactor
            // 
            this.AdFactor.Location = new System.Drawing.Point(9, 29);
            this.AdFactor.Name = "AdFactor";
            this.AdFactor.Size = new System.Drawing.Size(35, 20);
            this.AdFactor.TabIndex = 24;
            this.AdFactor.Value = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.AdFactor.ValueChanged += new System.EventHandler(this.AdFactor_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabpage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1061, 391);
            this.tabControl1.TabIndex = 25;
            // 
            // tabpage1
            // 
            this.tabpage1.Controls.Add(this.ImpruvedLogic);
            this.tabpage1.Controls.Add(this.SetPets);
            this.tabpage1.Controls.Add(this.CheckCell);
            this.tabpage1.Controls.Add(this.NameReg);
            this.tabpage1.Controls.Add(this.Solo);
            this.tabpage1.Controls.Add(this.On);
            this.tabpage1.Controls.Add(this.SoloReg);
            this.tabpage1.Controls.Add(this.Only1);
            this.tabpage1.Controls.Add(this.reg);
            this.tabpage1.Controls.Add(this.Nonstop);
            this.tabpage1.Controls.Add(this.LeaveGame);
            this.tabpage1.Location = new System.Drawing.Point(4, 22);
            this.tabpage1.Name = "tabpage1";
            this.tabpage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage1.Size = new System.Drawing.Size(1053, 365);
            this.tabpage1.TabIndex = 0;
            this.tabpage1.Text = "Основные";
            this.tabpage1.UseVisualStyleBackColor = true;
            // 
            // ImpruvedLogic
            // 
            this.ImpruvedLogic.AutoSize = true;
            this.ImpruvedLogic.Location = new System.Drawing.Point(13, 113);
            this.ImpruvedLogic.Name = "ImpruvedLogic";
            this.ImpruvedLogic.Size = new System.Drawing.Size(130, 17);
            this.ImpruvedLogic.TabIndex = 14;
            this.ImpruvedLogic.Text = "Продвинутая логика";
            this.ImpruvedLogic.UseVisualStyleBackColor = true;
            this.ImpruvedLogic.CheckedChanged += new System.EventHandler(this.ImpruvedLogic_CheckedChanged);
            // 
            // SetPets
            // 
            this.SetPets.Location = new System.Drawing.Point(139, 258);
            this.SetPets.Name = "SetPets";
            this.SetPets.Size = new System.Drawing.Size(102, 42);
            this.SetPets.TabIndex = 13;
            this.SetPets.Text = "Вставить петов";
            this.SetPets.UseVisualStyleBackColor = true;
            this.SetPets.Click += new System.EventHandler(this.SetPets_Click);
            // 
            // CheckCell
            // 
            this.CheckCell.Location = new System.Drawing.Point(6, 258);
            this.CheckCell.Name = "CheckCell";
            this.CheckCell.Size = new System.Drawing.Size(111, 42);
            this.CheckCell.TabIndex = 12;
            this.CheckCell.Text = "Проверка петов на турнир";
            this.CheckCell.UseVisualStyleBackColor = true;
            this.CheckCell.Click += new System.EventHandler(this.CheckCell_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Controls.Add(this.Slot2Swap);
            this.tabPage2.Controls.Add(this.Slot3Swap);
            this.tabPage2.Controls.Add(this.Slot1Swap);
            this.tabPage2.Controls.Add(this.Slot1SwapLevel);
            this.tabPage2.Controls.Add(this.Slot3SwapLevel);
            this.tabPage2.Controls.Add(this.update);
            this.tabPage2.Controls.Add(this.Slot2SwapLevel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1053, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Петы в слотах";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(426, 32);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(583, 221);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.richTextBox3);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.richTextBox2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.Calculate);
            this.tabPage3.Controls.Add(this.slotToInsert);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.EnemyLevel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1053, 365);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Формула рейтинга";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.pictureBox4);
            this.groupBox7.Location = new System.Drawing.Point(296, 38);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(130, 229);
            this.groupBox7.TabIndex = 46;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.pictureBox3);
            this.groupBox6.Location = new System.Drawing.Point(166, 38);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(130, 229);
            this.groupBox6.TabIndex = 45;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "label10";
            this.label10.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.pictureBox2);
            this.groupBox5.Location = new System.Drawing.Point(36, 38);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(130, 229);
            this.groupBox5.TabIndex = 44;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "label11";
            this.label11.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "label6";
            this.label6.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(9, 108);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(115, 111);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 40;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(0, 108);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(115, 111);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 108);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(115, 111);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(411, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(309, 163);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(237, 186);
            this.richTextBox3.TabIndex = 33;
            this.richTextBox3.Text = resources.GetString("richTextBox3.Text");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Location = new System.Drawing.Point(7, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(293, 113);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Имолейт импрувет";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.HpFactor);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(72, 70);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "HpFactor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AdFactor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(173, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(66, 72);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adv";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "AdvFactor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DisFactor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(84, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(80, 71);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "DisFactor";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(7, 130);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(262, 219);
            this.richTextBox2.TabIndex = 25;
            this.richTextBox2.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1053, 365);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Табличка (beta)";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.EntryID,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(-4, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(843, 359);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Имя";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // EntryID
            // 
            this.EntryID.HeaderText = "EntryID";
            this.EntryID.Name = "EntryID";
            this.EntryID.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Скорость";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Сила";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "HP";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Тип";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Рейтинг";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Враг";
            this.Column7.Name = "Column7";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(28, 398);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(191, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 26;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox7);
            this.groupBox8.Controls.Add(this.groupBox5);
            this.groupBox8.Controls.Add(this.groupBox6);
            this.groupBox8.Location = new System.Drawing.Point(552, 58);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(462, 304);
            this.groupBox8.TabIndex = 47;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox8";
            // 
            // GUI
            // 
            this.ClientSize = new System.Drawing.Size(1074, 433);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.OK);
            this.Name = "GUI";
            this.Text = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Slot1SwapLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Slot2SwapLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Slot3SwapLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slotToInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HpFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdFactor)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabpage1.ResumeLayout(false);
            this.tabpage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button OK;
        private Button reg;
        internal CheckBox On;
        internal CheckBox Only1;
        internal CheckBox Nonstop;
        internal ComboBox NameReg;
        internal CheckBox LeaveGame;
        internal NumericUpDown Slot1SwapLevel;
        internal CheckBox Slot1Swap;
        private Button update;
        private Button SoloReg;
        internal CheckBox Solo;
        internal NumericUpDown Slot2SwapLevel;
        internal NumericUpDown Slot3SwapLevel;
        internal CheckBox Slot2Swap;
        internal CheckBox Slot3Swap;
        internal NumericUpDown EnemyLevel;
        private Button Calculate;
        internal NumericUpDown slotToInsert;
        internal Label label1;
        internal Label label2;
        internal NumericUpDown HpFactor;
        internal NumericUpDown DisFactor;
        internal NumericUpDown AdFactor;
        private TabControl tabControl1;
        private TabPage tabpage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private Label label3;
        private GroupBox groupBox1;
        private Label label5;
        private GroupBox groupBox2;
        private Label label4;
        private TabPage tabPage4;
        internal DataGridView dataGridView1;
        internal PictureBox pictureBox1;
        internal ProgressBar progressBar1;
        internal PictureBox pictureBox4;
        internal PictureBox pictureBox3;
        internal PictureBox pictureBox2;
        internal Label label9;
        internal Label label10;
        internal Label label11;
        internal Label label8;
        internal Label label7;
        internal Label label6;
        internal ComboBox comboBox1;
        private GroupBox groupBox7;
        private GroupBox groupBox6;
        private GroupBox groupBox5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn EntryID;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        internal Button CheckCell;
        internal Button SetPets;
        internal CheckBox ImpruvedLogic;
        private GroupBox groupBox8;
    }
}