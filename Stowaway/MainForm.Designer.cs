namespace Stowaway
{
    partial class MainForm
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
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblLogs = new System.Windows.Forms.Label();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.lblSuccessIterations = new System.Windows.Forms.Label();
            this.numerSuccessIterations = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.numerGoalPositionX = new System.Windows.Forms.NumericUpDown();
            this.lblGoalPosition = new System.Windows.Forms.Label();
            this.numerGoalPositionY = new System.Windows.Forms.NumericUpDown();
            this.numerStartPositionX = new System.Windows.Forms.NumericUpDown();
            this.lblStartPosition = new System.Windows.Forms.Label();
            this.numerStartPositionY = new System.Windows.Forms.NumericUpDown();
            this.btnSelectLineColor = new System.Windows.Forms.Button();
            this.btnSelectFillColor = new System.Windows.Forms.Button();
            this.lblLineColor = new System.Windows.Forms.Label();
            this.lblFillColor = new System.Windows.Forms.Label();
            this.lblVerticalGrids = new System.Windows.Forms.Label();
            this.numerVerticalGrids = new System.Windows.Forms.NumericUpDown();
            this.lblHorizontalGrids = new System.Windows.Forms.Label();
            this.numerHorizontalGrids = new System.Windows.Forms.NumericUpDown();
            this.pnlGameField = new System.Windows.Forms.Panel();
            this.clrDialogSelector = new System.Windows.Forms.ColorDialog();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numerSuccessIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerGoalPositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerGoalPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerStartPositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerStartPositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerVerticalGrids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerHorizontalGrids)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pnlSettings.Controls.Add(this.btnReset);
            this.pnlSettings.Controls.Add(this.btnReport);
            this.pnlSettings.Controls.Add(this.lblLogs);
            this.pnlSettings.Controls.Add(this.txtLogs);
            this.pnlSettings.Controls.Add(this.lblSuccessIterations);
            this.pnlSettings.Controls.Add(this.numerSuccessIterations);
            this.pnlSettings.Controls.Add(this.btnStart);
            this.pnlSettings.Controls.Add(this.numerGoalPositionX);
            this.pnlSettings.Controls.Add(this.lblGoalPosition);
            this.pnlSettings.Controls.Add(this.numerGoalPositionY);
            this.pnlSettings.Controls.Add(this.numerStartPositionX);
            this.pnlSettings.Controls.Add(this.lblStartPosition);
            this.pnlSettings.Controls.Add(this.numerStartPositionY);
            this.pnlSettings.Controls.Add(this.btnSelectLineColor);
            this.pnlSettings.Controls.Add(this.btnSelectFillColor);
            this.pnlSettings.Controls.Add(this.lblLineColor);
            this.pnlSettings.Controls.Add(this.lblFillColor);
            this.pnlSettings.Controls.Add(this.lblVerticalGrids);
            this.pnlSettings.Controls.Add(this.numerVerticalGrids);
            this.pnlSettings.Controls.Add(this.lblHorizontalGrids);
            this.pnlSettings.Controls.Add(this.numerHorizontalGrids);
            this.pnlSettings.Location = new System.Drawing.Point(1, 1);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(180, 605);
            this.pnlSettings.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReset.Location = new System.Drawing.Point(16, 356);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(71, 23);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReport.Location = new System.Drawing.Point(103, 576);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(71, 23);
            this.btnReport.TabIndex = 19;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblLogs
            // 
            this.lblLogs.AutoSize = true;
            this.lblLogs.Location = new System.Drawing.Point(3, 400);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(30, 13);
            this.lblLogs.TabIndex = 18;
            this.lblLogs.Text = "Logs";
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(4, 416);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(170, 154);
            this.txtLogs.TabIndex = 17;
            // 
            // lblSuccessIterations
            // 
            this.lblSuccessIterations.AutoSize = true;
            this.lblSuccessIterations.Location = new System.Drawing.Point(13, 309);
            this.lblSuccessIterations.Name = "lblSuccessIterations";
            this.lblSuccessIterations.Size = new System.Drawing.Size(94, 13);
            this.lblSuccessIterations.TabIndex = 16;
            this.lblSuccessIterations.Text = "Success Iterations";
            // 
            // numerSuccessIterations
            // 
            this.numerSuccessIterations.Location = new System.Drawing.Point(103, 330);
            this.numerSuccessIterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numerSuccessIterations.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numerSuccessIterations.Name = "numerSuccessIterations";
            this.numerSuccessIterations.Size = new System.Drawing.Size(71, 20);
            this.numerSuccessIterations.TabIndex = 15;
            this.numerSuccessIterations.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnStart.Location = new System.Drawing.Point(103, 356);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(71, 23);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start/Cont.";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // numerGoalPositionX
            // 
            this.numerGoalPositionX.Location = new System.Drawing.Point(36, 259);
            this.numerGoalPositionX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numerGoalPositionX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numerGoalPositionX.Name = "numerGoalPositionX";
            this.numerGoalPositionX.Size = new System.Drawing.Size(58, 20);
            this.numerGoalPositionX.TabIndex = 13;
            this.numerGoalPositionX.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numerGoalPositionX.ValueChanged += new System.EventHandler(this.numerGoalPositionX_ValueChanged);
            // 
            // lblGoalPosition
            // 
            this.lblGoalPosition.AutoSize = true;
            this.lblGoalPosition.Location = new System.Drawing.Point(13, 243);
            this.lblGoalPosition.Name = "lblGoalPosition";
            this.lblGoalPosition.Size = new System.Drawing.Size(98, 13);
            this.lblGoalPosition.TabIndex = 12;
            this.lblGoalPosition.Text = "Goal Position (X, Y)";
            // 
            // numerGoalPositionY
            // 
            this.numerGoalPositionY.Location = new System.Drawing.Point(103, 259);
            this.numerGoalPositionY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numerGoalPositionY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numerGoalPositionY.Name = "numerGoalPositionY";
            this.numerGoalPositionY.Size = new System.Drawing.Size(58, 20);
            this.numerGoalPositionY.TabIndex = 11;
            this.numerGoalPositionY.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numerGoalPositionY.ValueChanged += new System.EventHandler(this.numerGoalPositionY_ValueChanged);
            // 
            // numerStartPositionX
            // 
            this.numerStartPositionX.Location = new System.Drawing.Point(36, 208);
            this.numerStartPositionX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numerStartPositionX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numerStartPositionX.Name = "numerStartPositionX";
            this.numerStartPositionX.Size = new System.Drawing.Size(58, 20);
            this.numerStartPositionX.TabIndex = 10;
            this.numerStartPositionX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numerStartPositionX.ValueChanged += new System.EventHandler(this.numerStartPositionX_ValueChanged);
            // 
            // lblStartPosition
            // 
            this.lblStartPosition.AutoSize = true;
            this.lblStartPosition.Location = new System.Drawing.Point(13, 192);
            this.lblStartPosition.Name = "lblStartPosition";
            this.lblStartPosition.Size = new System.Drawing.Size(98, 13);
            this.lblStartPosition.TabIndex = 9;
            this.lblStartPosition.Text = "Start Position (X, Y)";
            // 
            // numerStartPositionY
            // 
            this.numerStartPositionY.Location = new System.Drawing.Point(103, 208);
            this.numerStartPositionY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numerStartPositionY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numerStartPositionY.Name = "numerStartPositionY";
            this.numerStartPositionY.Size = new System.Drawing.Size(58, 20);
            this.numerStartPositionY.TabIndex = 8;
            this.numerStartPositionY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numerStartPositionY.ValueChanged += new System.EventHandler(this.numerStartPositionY_ValueChanged);
            // 
            // btnSelectLineColor
            // 
            this.btnSelectLineColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSelectLineColor.Location = new System.Drawing.Point(103, 134);
            this.btnSelectLineColor.Name = "btnSelectLineColor";
            this.btnSelectLineColor.Size = new System.Drawing.Size(71, 23);
            this.btnSelectLineColor.TabIndex = 7;
            this.btnSelectLineColor.Text = "Select";
            this.btnSelectLineColor.UseVisualStyleBackColor = false;
            this.btnSelectLineColor.Click += new System.EventHandler(this.btnSelectLineColor_Click);
            // 
            // btnSelectFillColor
            // 
            this.btnSelectFillColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSelectFillColor.Location = new System.Drawing.Point(103, 106);
            this.btnSelectFillColor.Name = "btnSelectFillColor";
            this.btnSelectFillColor.Size = new System.Drawing.Size(71, 23);
            this.btnSelectFillColor.TabIndex = 6;
            this.btnSelectFillColor.Text = "Select";
            this.btnSelectFillColor.UseVisualStyleBackColor = false;
            this.btnSelectFillColor.Click += new System.EventHandler(this.btnSelectFillColor_Click);
            // 
            // lblLineColor
            // 
            this.lblLineColor.AutoSize = true;
            this.lblLineColor.Location = new System.Drawing.Point(13, 139);
            this.lblLineColor.Name = "lblLineColor";
            this.lblLineColor.Size = new System.Drawing.Size(54, 13);
            this.lblLineColor.TabIndex = 5;
            this.lblLineColor.Text = "Line Color";
            // 
            // lblFillColor
            // 
            this.lblFillColor.AutoSize = true;
            this.lblFillColor.Location = new System.Drawing.Point(13, 106);
            this.lblFillColor.Name = "lblFillColor";
            this.lblFillColor.Size = new System.Drawing.Size(46, 13);
            this.lblFillColor.TabIndex = 4;
            this.lblFillColor.Text = "Fill Color";
            // 
            // lblVerticalGrids
            // 
            this.lblVerticalGrids.AutoSize = true;
            this.lblVerticalGrids.Location = new System.Drawing.Point(13, 70);
            this.lblVerticalGrids.Name = "lblVerticalGrids";
            this.lblVerticalGrids.Size = new System.Drawing.Size(69, 13);
            this.lblVerticalGrids.TabIndex = 3;
            this.lblVerticalGrids.Text = "Vertical Grids";
            // 
            // numerVerticalGrids
            // 
            this.numerVerticalGrids.Location = new System.Drawing.Point(103, 68);
            this.numerVerticalGrids.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numerVerticalGrids.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numerVerticalGrids.Name = "numerVerticalGrids";
            this.numerVerticalGrids.Size = new System.Drawing.Size(71, 20);
            this.numerVerticalGrids.TabIndex = 2;
            this.numerVerticalGrids.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numerVerticalGrids.ValueChanged += new System.EventHandler(this.numerVerticalGrids_ValueChanged);
            // 
            // lblHorizontalGrids
            // 
            this.lblHorizontalGrids.AutoSize = true;
            this.lblHorizontalGrids.Location = new System.Drawing.Point(13, 37);
            this.lblHorizontalGrids.Name = "lblHorizontalGrids";
            this.lblHorizontalGrids.Size = new System.Drawing.Size(81, 13);
            this.lblHorizontalGrids.TabIndex = 1;
            this.lblHorizontalGrids.Text = "Horizantal Grids";
            // 
            // numerHorizontalGrids
            // 
            this.numerHorizontalGrids.Location = new System.Drawing.Point(103, 35);
            this.numerHorizontalGrids.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numerHorizontalGrids.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numerHorizontalGrids.Name = "numerHorizontalGrids";
            this.numerHorizontalGrids.Size = new System.Drawing.Size(71, 20);
            this.numerHorizontalGrids.TabIndex = 0;
            this.numerHorizontalGrids.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numerHorizontalGrids.ValueChanged += new System.EventHandler(this.numerHorizontalGrids_ValueChanged);
            // 
            // pnlGameField
            // 
            this.pnlGameField.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pnlGameField.Location = new System.Drawing.Point(182, 1);
            this.pnlGameField.Name = "pnlGameField";
            this.pnlGameField.Size = new System.Drawing.Size(605, 605);
            this.pnlGameField.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 616);
            this.Controls.Add(this.pnlGameField);
            this.Controls.Add(this.pnlSettings);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stowaway";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numerSuccessIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerGoalPositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerGoalPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerStartPositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerStartPositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerVerticalGrids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerHorizontalGrids)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Panel pnlGameField;
        private System.Windows.Forms.Button btnSelectLineColor;
        private System.Windows.Forms.Button btnSelectFillColor;
        private System.Windows.Forms.Label lblLineColor;
        private System.Windows.Forms.Label lblFillColor;
        private System.Windows.Forms.Label lblVerticalGrids;
        private System.Windows.Forms.NumericUpDown numerVerticalGrids;
        private System.Windows.Forms.Label lblHorizontalGrids;
        private System.Windows.Forms.NumericUpDown numerHorizontalGrids;
        private System.Windows.Forms.ColorDialog clrDialogSelector;
        private System.Windows.Forms.NumericUpDown numerStartPositionX;
        private System.Windows.Forms.Label lblStartPosition;
        private System.Windows.Forms.NumericUpDown numerStartPositionY;
        private System.Windows.Forms.NumericUpDown numerGoalPositionX;
        private System.Windows.Forms.Label lblGoalPosition;
        private System.Windows.Forms.NumericUpDown numerGoalPositionY;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblSuccessIterations;
        private System.Windows.Forms.NumericUpDown numerSuccessIterations;
        private System.Windows.Forms.Label lblLogs;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnReset;
    }
}

