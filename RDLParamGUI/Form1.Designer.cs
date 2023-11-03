namespace RDLParamGUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterPatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autocompressOnSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.fileList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.valueList = new System.Windows.Forms.ListBox();
            this.hexData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.intData = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.floatData = new System.Windows.Forms.TextBox();
            this.curDataBox = new System.Windows.Forms.GroupBox();
            this.refDataBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.floatDataOrig = new System.Windows.Forms.TextBox();
            this.hexDataOrig = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.intDataOrig = new System.Windows.Forms.TextBox();
            this.labelBox = new System.Windows.Forms.TextBox();
            this.setLabel = new System.Windows.Forms.Button();
            this.clrLabel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.curDataBox.SuspendLayout();
            this.refDataBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.parameterPatchingToolStripMenuItem,
            this.updateLabelsToolStripMenuItem,
            this.compressionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openReferenceToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openReferenceToolStripMenuItem
            // 
            this.openReferenceToolStripMenuItem.Name = "openReferenceToolStripMenuItem";
            this.openReferenceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openReferenceToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.openReferenceToolStripMenuItem.Text = "Open Reference";
            this.openReferenceToolStripMenuItem.Click += new System.EventHandler(this.openReferenceToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // parameterPatchingToolStripMenuItem
            // 
            this.parameterPatchingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPatchToolStripMenuItem,
            this.generatePatchToolStripMenuItem});
            this.parameterPatchingToolStripMenuItem.Enabled = false;
            this.parameterPatchingToolStripMenuItem.Name = "parameterPatchingToolStripMenuItem";
            this.parameterPatchingToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.parameterPatchingToolStripMenuItem.Text = "Patching";
            // 
            // importPatchToolStripMenuItem
            // 
            this.importPatchToolStripMenuItem.Name = "importPatchToolStripMenuItem";
            this.importPatchToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.importPatchToolStripMenuItem.Text = "Import Patch";
            this.importPatchToolStripMenuItem.Click += new System.EventHandler(this.importPatchToolStripMenuItem_Click);
            // 
            // generatePatchToolStripMenuItem
            // 
            this.generatePatchToolStripMenuItem.Name = "generatePatchToolStripMenuItem";
            this.generatePatchToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.generatePatchToolStripMenuItem.Text = "Generate Patch";
            this.generatePatchToolStripMenuItem.Click += new System.EventHandler(this.generatePatchToolStripMenuItem_Click);
            // 
            // updateLabelsToolStripMenuItem
            // 
            this.updateLabelsToolStripMenuItem.Enabled = false;
            this.updateLabelsToolStripMenuItem.Name = "updateLabelsToolStripMenuItem";
            this.updateLabelsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.updateLabelsToolStripMenuItem.Text = "Refresh";
            this.updateLabelsToolStripMenuItem.Click += new System.EventHandler(this.updateLabelsToolStripMenuItem_Click);
            // 
            // compressionToolStripMenuItem
            // 
            this.compressionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decompressToolStripMenuItem,
            this.recompressToolStripMenuItem,
            this.autocompressOnSaveToolStripMenuItem});
            this.compressionToolStripMenuItem.Name = "compressionToolStripMenuItem";
            this.compressionToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.compressionToolStripMenuItem.Text = "Compression";
            // 
            // decompressToolStripMenuItem
            // 
            this.decompressToolStripMenuItem.Name = "decompressToolStripMenuItem";
            this.decompressToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.decompressToolStripMenuItem.Size = new System.Drawing.Size(314, 26);
            this.decompressToolStripMenuItem.Text = "Decompress File";
            this.decompressToolStripMenuItem.Click += new System.EventHandler(this.decompressToolStripMenuItem_Click);
            // 
            // recompressToolStripMenuItem
            // 
            this.recompressToolStripMenuItem.Name = "recompressToolStripMenuItem";
            this.recompressToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.recompressToolStripMenuItem.Size = new System.Drawing.Size(314, 26);
            this.recompressToolStripMenuItem.Text = "Compress File";
            this.recompressToolStripMenuItem.Click += new System.EventHandler(this.recompressToolStripMenuItem_Click);
            // 
            // autocompressOnSaveToolStripMenuItem
            // 
            this.autocompressOnSaveToolStripMenuItem.Checked = true;
            this.autocompressOnSaveToolStripMenuItem.CheckOnClick = true;
            this.autocompressOnSaveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autocompressOnSaveToolStripMenuItem.Name = "autocompressOnSaveToolStripMenuItem";
            this.autocompressOnSaveToolStripMenuItem.Size = new System.Drawing.Size(314, 26);
            this.autocompressOnSaveToolStripMenuItem.Text = "Autocompress .cmp Files On Save";
            this.autocompressOnSaveToolStripMenuItem.CheckedChanged += new System.EventHandler(this.autocompressOnSaveToolStripMenuItem_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Param Files";
            // 
            // fileList
            // 
            this.fileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileList.ForeColor = System.Drawing.SystemColors.Window;
            this.fileList.FormattingEnabled = true;
            this.fileList.HorizontalScrollbar = true;
            this.fileList.ItemHeight = 16;
            this.fileList.Location = new System.Drawing.Point(21, 55);
            this.fileList.Margin = new System.Windows.Forms.Padding(4);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(326, 564);
            this.fileList.TabIndex = 2;
            this.fileList.SelectedIndexChanged += new System.EventHandler(this.fileList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(355, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Values";
            // 
            // valueList
            // 
            this.valueList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.valueList.ForeColor = System.Drawing.SystemColors.Window;
            this.valueList.FormattingEnabled = true;
            this.valueList.HorizontalScrollbar = true;
            this.valueList.ItemHeight = 16;
            this.valueList.Location = new System.Drawing.Point(355, 55);
            this.valueList.Margin = new System.Windows.Forms.Padding(4);
            this.valueList.Name = "valueList";
            this.valueList.Size = new System.Drawing.Size(305, 484);
            this.valueList.TabIndex = 5;
            this.valueList.SelectedIndexChanged += new System.EventHandler(this.valueList_SelectedIndexChanged);
            // 
            // hexData
            // 
            this.hexData.Location = new System.Drawing.Point(12, 41);
            this.hexData.Margin = new System.Windows.Forms.Padding(4);
            this.hexData.Name = "hexData";
            this.hexData.Size = new System.Drawing.Size(87, 22);
            this.hexData.TabIndex = 6;
            this.hexData.TextChanged += new System.EventHandler(this.hexData_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hex";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "UInt32";
            // 
            // intData
            // 
            this.intData.Location = new System.Drawing.Point(12, 89);
            this.intData.Margin = new System.Windows.Forms.Padding(4);
            this.intData.Name = "intData";
            this.intData.Size = new System.Drawing.Size(169, 22);
            this.intData.TabIndex = 9;
            this.intData.TextChanged += new System.EventHandler(this.intData_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Float";
            // 
            // floatData
            // 
            this.floatData.Location = new System.Drawing.Point(12, 138);
            this.floatData.Margin = new System.Windows.Forms.Padding(4);
            this.floatData.Name = "floatData";
            this.floatData.Size = new System.Drawing.Size(169, 22);
            this.floatData.TabIndex = 11;
            this.floatData.TextChanged += new System.EventHandler(this.floatData_TextChanged);
            // 
            // curDataBox
            // 
            this.curDataBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.curDataBox.Controls.Add(this.label3);
            this.curDataBox.Controls.Add(this.floatData);
            this.curDataBox.Controls.Add(this.hexData);
            this.curDataBox.Controls.Add(this.label5);
            this.curDataBox.Controls.Add(this.label4);
            this.curDataBox.Controls.Add(this.intData);
            this.curDataBox.ForeColor = System.Drawing.SystemColors.Control;
            this.curDataBox.Location = new System.Drawing.Point(669, 55);
            this.curDataBox.Margin = new System.Windows.Forms.Padding(4);
            this.curDataBox.Name = "curDataBox";
            this.curDataBox.Padding = new System.Windows.Forms.Padding(4);
            this.curDataBox.Size = new System.Drawing.Size(197, 178);
            this.curDataBox.TabIndex = 12;
            this.curDataBox.TabStop = false;
            this.curDataBox.Text = "Current Data";
            // 
            // refDataBox
            // 
            this.refDataBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refDataBox.Controls.Add(this.label6);
            this.refDataBox.Controls.Add(this.floatDataOrig);
            this.refDataBox.Controls.Add(this.hexDataOrig);
            this.refDataBox.Controls.Add(this.label7);
            this.refDataBox.Controls.Add(this.label8);
            this.refDataBox.Controls.Add(this.intDataOrig);
            this.refDataBox.ForeColor = System.Drawing.SystemColors.Control;
            this.refDataBox.Location = new System.Drawing.Point(669, 241);
            this.refDataBox.Margin = new System.Windows.Forms.Padding(4);
            this.refDataBox.Name = "refDataBox";
            this.refDataBox.Padding = new System.Windows.Forms.Padding(4);
            this.refDataBox.Size = new System.Drawing.Size(197, 178);
            this.refDataBox.TabIndex = 13;
            this.refDataBox.TabStop = false;
            this.refDataBox.Text = "Reference Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Hex";
            // 
            // floatDataOrig
            // 
            this.floatDataOrig.Location = new System.Drawing.Point(12, 138);
            this.floatDataOrig.Margin = new System.Windows.Forms.Padding(4);
            this.floatDataOrig.Name = "floatDataOrig";
            this.floatDataOrig.ReadOnly = true;
            this.floatDataOrig.Size = new System.Drawing.Size(169, 22);
            this.floatDataOrig.TabIndex = 11;
            // 
            // hexDataOrig
            // 
            this.hexDataOrig.Location = new System.Drawing.Point(12, 41);
            this.hexDataOrig.Margin = new System.Windows.Forms.Padding(4);
            this.hexDataOrig.Name = "hexDataOrig";
            this.hexDataOrig.ReadOnly = true;
            this.hexDataOrig.Size = new System.Drawing.Size(87, 22);
            this.hexDataOrig.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Float";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "UInt32";
            // 
            // intDataOrig
            // 
            this.intDataOrig.Location = new System.Drawing.Point(12, 89);
            this.intDataOrig.Margin = new System.Windows.Forms.Padding(4);
            this.intDataOrig.Name = "intDataOrig";
            this.intDataOrig.ReadOnly = true;
            this.intDataOrig.Size = new System.Drawing.Size(169, 22);
            this.intDataOrig.TabIndex = 9;
            // 
            // labelBox
            // 
            this.labelBox.Location = new System.Drawing.Point(8, 23);
            this.labelBox.Margin = new System.Windows.Forms.Padding(4);
            this.labelBox.Name = "labelBox";
            this.labelBox.Size = new System.Drawing.Size(181, 22);
            this.labelBox.TabIndex = 12;
            // 
            // setLabel
            // 
            this.setLabel.ForeColor = System.Drawing.Color.Black;
            this.setLabel.Location = new System.Drawing.Point(8, 52);
            this.setLabel.Name = "setLabel";
            this.setLabel.Size = new System.Drawing.Size(87, 44);
            this.setLabel.TabIndex = 14;
            this.setLabel.Text = "Set\r\nLabel";
            this.setLabel.UseVisualStyleBackColor = true;
            this.setLabel.Click += new System.EventHandler(this.setLabel_Click);
            // 
            // clrLabel
            // 
            this.clrLabel.ForeColor = System.Drawing.Color.Black;
            this.clrLabel.Location = new System.Drawing.Point(102, 52);
            this.clrLabel.Name = "clrLabel";
            this.clrLabel.Size = new System.Drawing.Size(87, 44);
            this.clrLabel.TabIndex = 15;
            this.clrLabel.Text = "Clear\r\nLabel";
            this.clrLabel.UseVisualStyleBackColor = true;
            this.clrLabel.Click += new System.EventHandler(this.clrLabel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.labelBox);
            this.groupBox3.Controls.Add(this.clrLabel);
            this.groupBox3.Controls.Add(this.setLabel);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(669, 427);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(197, 112);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entry Labels";
            // 
            // discriptionBox
            // 
            this.descriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionBox.Location = new System.Drawing.Point(355, 546);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "discriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(511, 73);
            this.descriptionBox.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(882, 631);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.refDataBox);
            this.Controls.Add(this.curDataBox);
            this.Controls.Add(this.valueList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RDLParamEdit - Dreamixed";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.curDataBox.ResumeLayout(false);
            this.curDataBox.PerformLayout();
            this.refDataBox.ResumeLayout(false);
            this.refDataBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox valueList;
        private System.Windows.Forms.TextBox hexData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox intData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox floatData;
        private System.Windows.Forms.GroupBox curDataBox;
        private System.Windows.Forms.GroupBox refDataBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox floatDataOrig;
        private System.Windows.Forms.TextBox hexDataOrig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox intDataOrig;
        private System.Windows.Forms.ToolStripMenuItem updateLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parameterPatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autocompressOnSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openReferenceToolStripMenuItem;
        private System.Windows.Forms.TextBox labelBox;
        private System.Windows.Forms.Button setLabel;
        private System.Windows.Forms.Button clrLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox descriptionBox;
    }
}

