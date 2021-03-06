﻿namespace ShiftOS
{
    partial class NetGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetGen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlnetdesign = new System.Windows.Forms.Panel();
            this.pnlpcinfo = new System.Windows.Forms.Panel();
            this.btndelete = new System.Windows.Forms.Button();
            this.lbpcinfo = new System.Windows.Forms.Label();
            this.lbmoduletitle = new System.Windows.Forms.Label();
            this.btncloseinfo = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnaddmodule = new System.Windows.Forms.Button();
            this.pnlbuy = new System.Windows.Forms.Panel();
            this.txthostname = new System.Windows.Forms.TextBox();
            this.lbhostname = new System.Windows.Forms.Label();
            this.txtgrade = new System.Windows.Forms.TextBox();
            this.lbgrade = new System.Windows.Forms.Label();
            this.lbmoduleinfo = new System.Windows.Forms.Label();
            this.cmbbuyable = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btndonebuying = new System.Windows.Forms.Button();
            this.pnlnetinf = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbdifficulty = new System.Windows.Forms.ComboBox();
            this.txtfspeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtfskill = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnetdesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnetname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flbuttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.pnlnetinfo = new System.Windows.Forms.Panel();
            this.lbdescription = new System.Windows.Forms.Label();
            this.lbtitle = new System.Windows.Forms.Label();
            this.btnloadfromtemplate = new System.Windows.Forms.Button();
            this.pnltemplates = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbnets = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnrecreate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlnetdesign.SuspendLayout();
            this.pnlpcinfo.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlbuy.SuspendLayout();
            this.pnlnetinf.SuspendLayout();
            this.flbuttons.SuspendLayout();
            this.pnlnetinfo.SuspendLayout();
            this.pnltemplates.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnltemplates);
            this.panel1.Controls.Add(this.pnlnetdesign);
            this.panel1.Controls.Add(this.pnlnetinf);
            this.panel1.Controls.Add(this.flbuttons);
            this.panel1.Controls.Add(this.pnlnetinfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 591);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnlnetdesign
            // 
            this.pnlnetdesign.Controls.Add(this.pnlpcinfo);
            this.pnlnetdesign.Controls.Add(this.flowLayoutPanel1);
            this.pnlnetdesign.Controls.Add(this.pnlbuy);
            this.pnlnetdesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlnetdesign.Location = new System.Drawing.Point(0, 76);
            this.pnlnetdesign.Name = "pnlnetdesign";
            this.pnlnetdesign.Size = new System.Drawing.Size(894, 484);
            this.pnlnetdesign.TabIndex = 6;
            this.pnlnetdesign.MouseDown += new System.Windows.Forms.MouseEventHandler(this.place_module);
            // 
            // pnlpcinfo
            // 
            this.pnlpcinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlpcinfo.Controls.Add(this.btndelete);
            this.pnlpcinfo.Controls.Add(this.lbpcinfo);
            this.pnlpcinfo.Controls.Add(this.lbmoduletitle);
            this.pnlpcinfo.Controls.Add(this.btncloseinfo);
            this.pnlpcinfo.Location = new System.Drawing.Point(43, 167);
            this.pnlpcinfo.Name = "pnlpcinfo";
            this.pnlpcinfo.Size = new System.Drawing.Size(382, 280);
            this.pnlpcinfo.TabIndex = 9;
            this.pnlpcinfo.Visible = false;
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.AutoSize = true;
            this.btndelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Location = new System.Drawing.Point(106, 254);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(59, 23);
            this.btndelete.TabIndex = 8;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // lbpcinfo
            // 
            this.lbpcinfo.Location = new System.Drawing.Point(12, 41);
            this.lbpcinfo.Name = "lbpcinfo";
            this.lbpcinfo.Size = new System.Drawing.Size(367, 86);
            this.lbpcinfo.TabIndex = 6;
            this.lbpcinfo.Text = resources.GetString("lbpcinfo.Text");
            // 
            // lbmoduletitle
            // 
            this.lbmoduletitle.AutoSize = true;
            this.lbmoduletitle.Location = new System.Drawing.Point(10, 12);
            this.lbmoduletitle.Name = "lbmoduletitle";
            this.lbmoduletitle.Size = new System.Drawing.Size(75, 11);
            this.lbmoduletitle.TabIndex = 2;
            this.lbmoduletitle.Text = "Add Module";
            // 
            // btncloseinfo
            // 
            this.btncloseinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btncloseinfo.AutoSize = true;
            this.btncloseinfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btncloseinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncloseinfo.Location = new System.Drawing.Point(327, 254);
            this.btncloseinfo.Name = "btncloseinfo";
            this.btncloseinfo.Size = new System.Drawing.Size(52, 23);
            this.btncloseinfo.TabIndex = 1;
            this.btncloseinfo.Text = "Done.";
            this.btncloseinfo.UseVisualStyleBackColor = true;
            this.btncloseinfo.Click += new System.EventHandler(this.btncloseinfo_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnaddmodule);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 453);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(894, 31);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnaddmodule
            // 
            this.btnaddmodule.AutoSize = true;
            this.btnaddmodule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnaddmodule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddmodule.Location = new System.Drawing.Point(3, 3);
            this.btnaddmodule.Name = "btnaddmodule";
            this.btnaddmodule.Size = new System.Drawing.Size(87, 23);
            this.btnaddmodule.TabIndex = 0;
            this.btnaddmodule.Text = "Add Module";
            this.btnaddmodule.UseVisualStyleBackColor = true;
            this.btnaddmodule.Click += new System.EventHandler(this.btnaddmodule_Click);
            // 
            // pnlbuy
            // 
            this.pnlbuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlbuy.Controls.Add(this.txthostname);
            this.pnlbuy.Controls.Add(this.lbhostname);
            this.pnlbuy.Controls.Add(this.txtgrade);
            this.pnlbuy.Controls.Add(this.lbgrade);
            this.pnlbuy.Controls.Add(this.lbmoduleinfo);
            this.pnlbuy.Controls.Add(this.cmbbuyable);
            this.pnlbuy.Controls.Add(this.label4);
            this.pnlbuy.Controls.Add(this.btndonebuying);
            this.pnlbuy.Location = new System.Drawing.Point(3, 148);
            this.pnlbuy.Name = "pnlbuy";
            this.pnlbuy.Size = new System.Drawing.Size(382, 299);
            this.pnlbuy.TabIndex = 7;
            this.pnlbuy.Visible = false;
            // 
            // txthostname
            // 
            this.txthostname.BackColor = System.Drawing.Color.Black;
            this.txthostname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txthostname.ForeColor = System.Drawing.Color.White;
            this.txthostname.Location = new System.Drawing.Point(186, 236);
            this.txthostname.Name = "txthostname";
            this.txthostname.Size = new System.Drawing.Size(186, 18);
            this.txthostname.TabIndex = 10;
            // 
            // lbhostname
            // 
            this.lbhostname.AutoSize = true;
            this.lbhostname.Location = new System.Drawing.Point(112, 240);
            this.lbhostname.Name = "lbhostname";
            this.lbhostname.Size = new System.Drawing.Size(68, 11);
            this.lbhostname.TabIndex = 9;
            this.lbhostname.Text = "Hostname:";
            // 
            // txtgrade
            // 
            this.txtgrade.BackColor = System.Drawing.Color.Black;
            this.txtgrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgrade.ForeColor = System.Drawing.Color.White;
            this.txtgrade.Location = new System.Drawing.Point(65, 236);
            this.txtgrade.Name = "txtgrade";
            this.txtgrade.Size = new System.Drawing.Size(40, 18);
            this.txtgrade.TabIndex = 8;
            this.txtgrade.TextChanged += new System.EventHandler(this.txtgrade_TextChanged);
            // 
            // lbgrade
            // 
            this.lbgrade.AutoSize = true;
            this.lbgrade.Location = new System.Drawing.Point(12, 240);
            this.lbgrade.Name = "lbgrade";
            this.lbgrade.Size = new System.Drawing.Size(47, 11);
            this.lbgrade.TabIndex = 7;
            this.lbgrade.Text = "Grade:";
            // 
            // lbmoduleinfo
            // 
            this.lbmoduleinfo.Location = new System.Drawing.Point(10, 63);
            this.lbmoduleinfo.Name = "lbmoduleinfo";
            this.lbmoduleinfo.Size = new System.Drawing.Size(367, 156);
            this.lbmoduleinfo.TabIndex = 6;
            this.lbmoduleinfo.Text = resources.GetString("lbmoduleinfo.Text");
            // 
            // cmbbuyable
            // 
            this.cmbbuyable.BackColor = System.Drawing.Color.Black;
            this.cmbbuyable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbuyable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbbuyable.ForeColor = System.Drawing.Color.White;
            this.cmbbuyable.FormattingEnabled = true;
            this.cmbbuyable.Location = new System.Drawing.Point(12, 38);
            this.cmbbuyable.Name = "cmbbuyable";
            this.cmbbuyable.Size = new System.Drawing.Size(360, 19);
            this.cmbbuyable.TabIndex = 3;
            this.cmbbuyable.SelectedIndexChanged += new System.EventHandler(this.cmbbuyable_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 11);
            this.label4.TabIndex = 2;
            this.label4.Text = "Add Module";
            // 
            // btndonebuying
            // 
            this.btndonebuying.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btndonebuying.AutoSize = true;
            this.btndonebuying.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btndonebuying.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndonebuying.Location = new System.Drawing.Point(341, 273);
            this.btndonebuying.Name = "btndonebuying";
            this.btndonebuying.Size = new System.Drawing.Size(38, 23);
            this.btndonebuying.TabIndex = 1;
            this.btndonebuying.Text = "Buy";
            this.btndonebuying.UseVisualStyleBackColor = true;
            this.btndonebuying.Click += new System.EventHandler(this.btndonebuying_Click);
            // 
            // pnlnetinf
            // 
            this.pnlnetinf.Controls.Add(this.label6);
            this.pnlnetinf.Controls.Add(this.cbdifficulty);
            this.pnlnetinf.Controls.Add(this.txtfspeed);
            this.pnlnetinf.Controls.Add(this.label5);
            this.pnlnetinf.Controls.Add(this.txtfskill);
            this.pnlnetinf.Controls.Add(this.label3);
            this.pnlnetinf.Controls.Add(this.txtnetdesc);
            this.pnlnetinf.Controls.Add(this.label2);
            this.pnlnetinf.Controls.Add(this.txtnetname);
            this.pnlnetinf.Controls.Add(this.label1);
            this.pnlnetinf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlnetinf.Location = new System.Drawing.Point(0, 76);
            this.pnlnetinf.Name = "pnlnetinf";
            this.pnlnetinf.Size = new System.Drawing.Size(894, 484);
            this.pnlnetinf.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 11);
            this.label6.TabIndex = 11;
            this.label6.Text = "Difficulty (Tier)";
            // 
            // cbdifficulty
            // 
            this.cbdifficulty.BackColor = System.Drawing.Color.Black;
            this.cbdifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdifficulty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbdifficulty.ForeColor = System.Drawing.Color.Green;
            this.cbdifficulty.FormattingEnabled = true;
            this.cbdifficulty.Items.AddRange(new object[] {
            "easy",
            "medium",
            "hard"});
            this.cbdifficulty.Location = new System.Drawing.Point(170, 222);
            this.cbdifficulty.Name = "cbdifficulty";
            this.cbdifficulty.Size = new System.Drawing.Size(121, 19);
            this.cbdifficulty.TabIndex = 10;
            // 
            // txtfspeed
            // 
            this.txtfspeed.BackColor = System.Drawing.Color.Black;
            this.txtfspeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfspeed.ForeColor = System.Drawing.Color.Green;
            this.txtfspeed.Location = new System.Drawing.Point(142, 172);
            this.txtfspeed.Name = "txtfspeed";
            this.txtfspeed.Size = new System.Drawing.Size(41, 18);
            this.txtfspeed.TabIndex = 9;
            this.txtfspeed.TextChanged += new System.EventHandler(this.txtfspeed_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 11);
            this.label5.TabIndex = 8;
            this.label5.Text = "F. Speed";
            // 
            // txtfskill
            // 
            this.txtfskill.BackColor = System.Drawing.Color.Black;
            this.txtfskill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfskill.ForeColor = System.Drawing.Color.Green;
            this.txtfskill.Location = new System.Drawing.Point(142, 146);
            this.txtfskill.Name = "txtfskill";
            this.txtfskill.Size = new System.Drawing.Size(41, 18);
            this.txtfskill.TabIndex = 7;
            this.txtfskill.TextChanged += new System.EventHandler(this.txtfskill_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 11);
            this.label3.TabIndex = 6;
            this.label3.Text = "F. Skill";
            // 
            // txtnetdesc
            // 
            this.txtnetdesc.BackColor = System.Drawing.Color.Black;
            this.txtnetdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnetdesc.ForeColor = System.Drawing.Color.Green;
            this.txtnetdesc.Location = new System.Drawing.Point(142, 80);
            this.txtnetdesc.Name = "txtnetdesc";
            this.txtnetdesc.Size = new System.Drawing.Size(492, 18);
            this.txtnetdesc.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 11);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // txtnetname
            // 
            this.txtnetname.BackColor = System.Drawing.Color.Black;
            this.txtnetname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnetname.ForeColor = System.Drawing.Color.Green;
            this.txtnetname.Location = new System.Drawing.Point(142, 56);
            this.txtnetname.Name = "txtnetname";
            this.txtnetname.Size = new System.Drawing.Size(231, 18);
            this.txtnetname.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 11);
            this.label1.TabIndex = 2;
            this.label1.Text = "Network Name:";
            // 
            // flbuttons
            // 
            this.flbuttons.Controls.Add(this.btnnext);
            this.flbuttons.Controls.Add(this.btnback);
            this.flbuttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flbuttons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flbuttons.Location = new System.Drawing.Point(0, 560);
            this.flbuttons.Name = "flbuttons";
            this.flbuttons.Size = new System.Drawing.Size(894, 31);
            this.flbuttons.TabIndex = 0;
            // 
            // btnnext
            // 
            this.btnnext.AutoSize = true;
            this.btnnext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnext.Location = new System.Drawing.Point(846, 3);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(45, 23);
            this.btnnext.TabIndex = 0;
            this.btnnext.Text = "Next";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // btnback
            // 
            this.btnback.AutoSize = true;
            this.btnback.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Location = new System.Drawing.Point(795, 3);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(45, 23);
            this.btnback.TabIndex = 1;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // pnlnetinfo
            // 
            this.pnlnetinfo.Controls.Add(this.btnloadfromtemplate);
            this.pnlnetinfo.Controls.Add(this.lbdescription);
            this.pnlnetinfo.Controls.Add(this.lbtitle);
            this.pnlnetinfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlnetinfo.Location = new System.Drawing.Point(0, 0);
            this.pnlnetinfo.Name = "pnlnetinfo";
            this.pnlnetinfo.Size = new System.Drawing.Size(894, 76);
            this.pnlnetinfo.TabIndex = 1;
            // 
            // lbdescription
            // 
            this.lbdescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbdescription.Location = new System.Drawing.Point(15, 31);
            this.lbdescription.Name = "lbdescription";
            this.lbdescription.Size = new System.Drawing.Size(867, 36);
            this.lbdescription.TabIndex = 1;
            this.lbdescription.Text = "Information about the network.";
            // 
            // lbtitle
            // 
            this.lbtitle.AutoSize = true;
            this.lbtitle.Font = new System.Drawing.Font("Lucida Console", 13F);
            this.lbtitle.Location = new System.Drawing.Point(12, 9);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(217, 18);
            this.lbtitle.TabIndex = 0;
            this.lbtitle.Text = "Network Information";
            // 
            // btnloadfromtemplate
            // 
            this.btnloadfromtemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnloadfromtemplate.AutoSize = true;
            this.btnloadfromtemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnloadfromtemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnloadfromtemplate.Location = new System.Drawing.Point(683, 47);
            this.btnloadfromtemplate.Name = "btnloadfromtemplate";
            this.btnloadfromtemplate.Size = new System.Drawing.Size(199, 23);
            this.btnloadfromtemplate.TabIndex = 2;
            this.btnloadfromtemplate.Text = "This button breaks things.";
            this.btnloadfromtemplate.UseVisualStyleBackColor = true;
            this.btnloadfromtemplate.Visible = false;
            this.btnloadfromtemplate.Click += new System.EventHandler(this.btnloadfromtemplate_Click);
            // 
            // pnltemplates
            // 
            this.pnltemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnltemplates.Controls.Add(this.label9);
            this.pnltemplates.Controls.Add(this.cbnets);
            this.pnltemplates.Controls.Add(this.label10);
            this.pnltemplates.Controls.Add(this.btnrecreate);
            this.pnltemplates.Location = new System.Drawing.Point(256, 146);
            this.pnltemplates.Name = "pnltemplates";
            this.pnltemplates.Size = new System.Drawing.Size(382, 299);
            this.pnltemplates.TabIndex = 8;
            this.pnltemplates.Visible = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(367, 156);
            this.label9.TabIndex = 6;
            this.label9.Text = "Please choose a network from the above list. Net Generator will attempt to grab d" +
    "ata about the network and recreate it for you.";
            // 
            // cbnets
            // 
            this.cbnets.BackColor = System.Drawing.Color.Black;
            this.cbnets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbnets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbnets.ForeColor = System.Drawing.Color.White;
            this.cbnets.FormattingEnabled = true;
            this.cbnets.Location = new System.Drawing.Point(12, 38);
            this.cbnets.Name = "cbnets";
            this.cbnets.Size = new System.Drawing.Size(360, 19);
            this.cbnets.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 11);
            this.label10.TabIndex = 2;
            this.label10.Text = "Load from Network";
            // 
            // btnrecreate
            // 
            this.btnrecreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrecreate.AutoSize = true;
            this.btnrecreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnrecreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrecreate.Location = new System.Drawing.Point(334, 273);
            this.btnrecreate.Name = "btnrecreate";
            this.btnrecreate.Size = new System.Drawing.Size(45, 23);
            this.btnrecreate.TabIndex = 1;
            this.btnrecreate.Text = "Done";
            this.btnrecreate.UseVisualStyleBackColor = true;
            this.btnrecreate.Click += new System.EventHandler(this.btnrecreate_Click);
            // 
            // NetGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(894, 591);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.ForeColor = System.Drawing.Color.LightGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NetGen";
            this.Text = "NetGen";
            this.Load += new System.EventHandler(this.NetGen_Load);
            this.panel1.ResumeLayout(false);
            this.pnlnetdesign.ResumeLayout(false);
            this.pnlpcinfo.ResumeLayout(false);
            this.pnlpcinfo.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnlbuy.ResumeLayout(false);
            this.pnlbuy.PerformLayout();
            this.pnlnetinf.ResumeLayout(false);
            this.pnlnetinf.PerformLayout();
            this.flbuttons.ResumeLayout(false);
            this.flbuttons.PerformLayout();
            this.pnlnetinfo.ResumeLayout(false);
            this.pnlnetinfo.PerformLayout();
            this.pnltemplates.ResumeLayout(false);
            this.pnltemplates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flbuttons;
        private System.Windows.Forms.TextBox txtnetname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlnetinfo;
        private System.Windows.Forms.Label lbdescription;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.TextBox txtnetdesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Panel pnlnetdesign;
        private System.Windows.Forms.Panel pnlnetinf;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnaddmodule;
        private System.Windows.Forms.Panel pnlbuy;
        private System.Windows.Forms.TextBox txthostname;
        private System.Windows.Forms.Label lbhostname;
        private System.Windows.Forms.TextBox txtgrade;
        private System.Windows.Forms.Label lbgrade;
        private System.Windows.Forms.Label lbmoduleinfo;
        private System.Windows.Forms.ComboBox cmbbuyable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btndonebuying;
        private System.Windows.Forms.Panel pnlpcinfo;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Label lbpcinfo;
        private System.Windows.Forms.Label lbmoduletitle;
        private System.Windows.Forms.Button btncloseinfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbdifficulty;
        private System.Windows.Forms.TextBox txtfspeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtfskill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnloadfromtemplate;
        private System.Windows.Forms.Panel pnltemplates;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbnets;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnrecreate;
    }
}