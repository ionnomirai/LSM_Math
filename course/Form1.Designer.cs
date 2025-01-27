
namespace course
{
    partial class MHK
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.DataFieldGrid = new System.Windows.Forms.DataGridView();
            this.LNumOfMeasurements = new System.Windows.Forms.Label();
            this.tbNumOfMeasurements = new System.Windows.Forms.TextBox();
            this.bToConfirmSize = new System.Windows.Forms.Button();
            this.line1Up = new System.Windows.Forms.Label();
            this.line1Down = new System.Windows.Forms.Label();
            this.rbLineModelMode = new System.Windows.Forms.RadioButton();
            this.rbQuadraticModel = new System.Windows.Forms.RadioButton();
            this.rbExponentialModel = new System.Windows.Forms.RadioButton();
            this.bPerform = new System.Windows.Forms.Button();
            this.tbResultsField = new System.Windows.Forms.TextBox();
            this.bShowForm2 = new System.Windows.Forms.Button();
            this.rbAutoChoice = new System.Windows.Forms.RadioButton();
            this.gpFunctions = new System.Windows.Forms.GroupBox();
            this.chartForModel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDiflection = new System.Windows.Forms.TextBox();
            this.cBBasicLine = new System.Windows.Forms.CheckBox();
            this.cBLine = new System.Windows.Forms.CheckBox();
            this.cBSquare = new System.Windows.Forms.CheckBox();
            this.cBExp = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataFieldGrid)).BeginInit();
            this.gpFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartForModel)).BeginInit();
            this.SuspendLayout();
            // 
            // DataFieldGrid
            // 
            this.DataFieldGrid.AllowUserToAddRows = false;
            this.DataFieldGrid.AllowUserToResizeColumns = false;
            this.DataFieldGrid.AllowUserToResizeRows = false;
            this.DataFieldGrid.ColumnHeadersHeight = 16;
            this.DataFieldGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataFieldGrid.Location = new System.Drawing.Point(37, 90);
            this.DataFieldGrid.Name = "DataFieldGrid";
            this.DataFieldGrid.RowHeadersWidth = 62;
            this.DataFieldGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataFieldGrid.RowTemplate.Height = 50;
            this.DataFieldGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataFieldGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.DataFieldGrid.Size = new System.Drawing.Size(256, 122);
            this.DataFieldGrid.TabIndex = 0;
            this.DataFieldGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataFieldGrid_EditingControlShowing);
            // 
            // LNumOfMeasurements
            // 
            this.LNumOfMeasurements.AutoSize = true;
            this.LNumOfMeasurements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LNumOfMeasurements.Location = new System.Drawing.Point(1, 33);
            this.LNumOfMeasurements.Name = "LNumOfMeasurements";
            this.LNumOfMeasurements.Size = new System.Drawing.Size(329, 22);
            this.LNumOfMeasurements.TabIndex = 1;
            this.LNumOfMeasurements.Text = "Введіть кількість вимірів (від 2 до 10):";
            // 
            // tbNumOfMeasurements
            // 
            this.tbNumOfMeasurements.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNumOfMeasurements.Location = new System.Drawing.Point(345, 25);
            this.tbNumOfMeasurements.Name = "tbNumOfMeasurements";
            this.tbNumOfMeasurements.Size = new System.Drawing.Size(31, 30);
            this.tbNumOfMeasurements.TabIndex = 2;
            this.tbNumOfMeasurements.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bToConfirmSize
            // 
            this.bToConfirmSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.bToConfirmSize.Location = new System.Drawing.Point(397, 25);
            this.bToConfirmSize.Name = "bToConfirmSize";
            this.bToConfirmSize.Size = new System.Drawing.Size(189, 38);
            this.bToConfirmSize.TabIndex = 3;
            this.bToConfirmSize.Text = "Застосувати зміни ";
            this.bToConfirmSize.UseVisualStyleBackColor = true;
            this.bToConfirmSize.Click += new System.EventHandler(this.bToConfirmSize_Click);
            // 
            // line1Up
            // 
            this.line1Up.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.line1Up.Location = new System.Drawing.Point(5, 76);
            this.line1Up.Name = "line1Up";
            this.line1Up.Size = new System.Drawing.Size(900, 1);
            this.line1Up.TabIndex = 4;
            // 
            // line1Down
            // 
            this.line1Down.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.line1Down.Location = new System.Drawing.Point(5, 224);
            this.line1Down.Name = "line1Down";
            this.line1Down.Size = new System.Drawing.Size(900, 1);
            this.line1Down.TabIndex = 5;
            // 
            // rbLineModelMode
            // 
            this.rbLineModelMode.AutoSize = true;
            this.rbLineModelMode.Checked = true;
            this.rbLineModelMode.Location = new System.Drawing.Point(6, 23);
            this.rbLineModelMode.Name = "rbLineModelMode";
            this.rbLineModelMode.Size = new System.Drawing.Size(152, 24);
            this.rbLineModelMode.TabIndex = 6;
            this.rbLineModelMode.TabStop = true;
            this.rbLineModelMode.Text = "Лінійна функція";
            this.rbLineModelMode.UseVisualStyleBackColor = true;
            // 
            // rbQuadraticModel
            // 
            this.rbQuadraticModel.AutoSize = true;
            this.rbQuadraticModel.Location = new System.Drawing.Point(6, 53);
            this.rbQuadraticModel.Name = "rbQuadraticModel";
            this.rbQuadraticModel.Size = new System.Drawing.Size(200, 24);
            this.rbQuadraticModel.TabIndex = 7;
            this.rbQuadraticModel.Text = "Квадратична функція";
            this.rbQuadraticModel.UseVisualStyleBackColor = true;
            // 
            // rbExponentialModel
            // 
            this.rbExponentialModel.AutoSize = true;
            this.rbExponentialModel.Location = new System.Drawing.Point(6, 83);
            this.rbExponentialModel.Name = "rbExponentialModel";
            this.rbExponentialModel.Size = new System.Drawing.Size(197, 24);
            this.rbExponentialModel.TabIndex = 8;
            this.rbExponentialModel.Text = "Експонентна функція";
            this.rbExponentialModel.UseVisualStyleBackColor = true;
            // 
            // bPerform
            // 
            this.bPerform.Location = new System.Drawing.Point(37, 243);
            this.bPerform.Name = "bPerform";
            this.bPerform.Size = new System.Drawing.Size(153, 52);
            this.bPerform.TabIndex = 9;
            this.bPerform.Text = "Розрахувати ";
            this.bPerform.UseVisualStyleBackColor = true;
            this.bPerform.Click += new System.EventHandler(this.bPerform_Click);
            // 
            // tbResultsField
            // 
            this.tbResultsField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbResultsField.Location = new System.Drawing.Point(447, 280);
            this.tbResultsField.Name = "tbResultsField";
            this.tbResultsField.ReadOnly = true;
            this.tbResultsField.Size = new System.Drawing.Size(425, 30);
            this.tbResultsField.TabIndex = 10;
            // 
            // bShowForm2
            // 
            this.bShowForm2.Enabled = false;
            this.bShowForm2.Location = new System.Drawing.Point(37, 310);
            this.bShowForm2.Name = "bShowForm2";
            this.bShowForm2.Size = new System.Drawing.Size(153, 45);
            this.bShowForm2.TabIndex = 11;
            this.bShowForm2.Text = "Показати графік";
            this.bShowForm2.UseVisualStyleBackColor = true;
            this.bShowForm2.Click += new System.EventHandler(this.bShowForm2_Click);
            // 
            // rbAutoChoice
            // 
            this.rbAutoChoice.AutoSize = true;
            this.rbAutoChoice.Location = new System.Drawing.Point(6, 113);
            this.rbAutoChoice.Name = "rbAutoChoice";
            this.rbAutoChoice.Size = new System.Drawing.Size(193, 24);
            this.rbAutoChoice.TabIndex = 12;
            this.rbAutoChoice.Text = "Автоматичний вибір ";
            this.rbAutoChoice.UseVisualStyleBackColor = true;
            // 
            // gpFunctions
            // 
            this.gpFunctions.Controls.Add(this.rbLineModelMode);
            this.gpFunctions.Controls.Add(this.rbAutoChoice);
            this.gpFunctions.Controls.Add(this.rbQuadraticModel);
            this.gpFunctions.Controls.Add(this.rbExponentialModel);
            this.gpFunctions.Location = new System.Drawing.Point(210, 243);
            this.gpFunctions.Name = "gpFunctions";
            this.gpFunctions.Size = new System.Drawing.Size(228, 150);
            this.gpFunctions.TabIndex = 13;
            this.gpFunctions.TabStop = false;
            this.gpFunctions.Text = "Обрана функція";
            // 
            // chartForModel
            // 
            chartArea1.Name = "ChartArea1";
            this.chartForModel.ChartAreas.Add(chartArea1);
            this.chartForModel.Enabled = false;
            legend1.MaximumAutoSize = 100F;
            legend1.Name = "Legend1";
            this.chartForModel.Legends.Add(legend1);
            this.chartForModel.Location = new System.Drawing.Point(12, 422);
            this.chartForModel.Name = "chartForModel";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Базова лінія";
            this.chartForModel.Series.Add(series1);
            this.chartForModel.Size = new System.Drawing.Size(890, 347);
            this.chartForModel.TabIndex = 14;
            this.chartForModel.Text = "chart1";
            this.chartForModel.Visible = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(7, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(900, 1);
            this.label1.TabIndex = 15;
            // 
            // tbDiflection
            // 
            this.tbDiflection.Location = new System.Drawing.Point(447, 355);
            this.tbDiflection.Multiline = true;
            this.tbDiflection.Name = "tbDiflection";
            this.tbDiflection.ReadOnly = true;
            this.tbDiflection.Size = new System.Drawing.Size(425, 35);
            this.tbDiflection.TabIndex = 17;
            // 
            // cBBasicLine
            // 
            this.cBBasicLine.AutoSize = true;
            this.cBBasicLine.Checked = true;
            this.cBBasicLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBBasicLine.Location = new System.Drawing.Point(880, 437);
            this.cBBasicLine.Name = "cBBasicLine";
            this.cBBasicLine.Size = new System.Drawing.Size(22, 21);
            this.cBBasicLine.TabIndex = 18;
            this.cBBasicLine.UseVisualStyleBackColor = true;
            this.cBBasicLine.Visible = false;
            this.cBBasicLine.CheckedChanged += new System.EventHandler(this.cBBasicLine_CheckedChanged);
            // 
            // cBLine
            // 
            this.cBLine.AutoSize = true;
            this.cBLine.Checked = true;
            this.cBLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBLine.Location = new System.Drawing.Point(880, 460);
            this.cBLine.Name = "cBLine";
            this.cBLine.Size = new System.Drawing.Size(22, 21);
            this.cBLine.TabIndex = 19;
            this.cBLine.UseVisualStyleBackColor = true;
            this.cBLine.Visible = false;
            this.cBLine.CheckedChanged += new System.EventHandler(this.cBLine_CheckedChanged);
            // 
            // cBSquare
            // 
            this.cBSquare.AutoSize = true;
            this.cBSquare.Checked = true;
            this.cBSquare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBSquare.Location = new System.Drawing.Point(880, 483);
            this.cBSquare.Name = "cBSquare";
            this.cBSquare.Size = new System.Drawing.Size(22, 21);
            this.cBSquare.TabIndex = 20;
            this.cBSquare.UseVisualStyleBackColor = true;
            this.cBSquare.Visible = false;
            this.cBSquare.CheckedChanged += new System.EventHandler(this.cBSquare_CheckedChanged);
            // 
            // cBExp
            // 
            this.cBExp.AutoSize = true;
            this.cBExp.Checked = true;
            this.cBExp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBExp.Location = new System.Drawing.Point(880, 507);
            this.cBExp.Name = "cBExp";
            this.cBExp.Size = new System.Drawing.Size(22, 21);
            this.cBExp.TabIndex = 21;
            this.cBExp.UseVisualStyleBackColor = true;
            this.cBExp.Visible = false;
            this.cBExp.CheckedChanged += new System.EventHandler(this.cBExp_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Математична модель:\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Відхилення:";
            // 
            // MHK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 883);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBExp);
            this.Controls.Add(this.cBSquare);
            this.Controls.Add(this.cBLine);
            this.Controls.Add(this.cBBasicLine);
            this.Controls.Add(this.tbDiflection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartForModel);
            this.Controls.Add(this.gpFunctions);
            this.Controls.Add(this.bShowForm2);
            this.Controls.Add(this.tbResultsField);
            this.Controls.Add(this.bPerform);
            this.Controls.Add(this.line1Down);
            this.Controls.Add(this.line1Up);
            this.Controls.Add(this.bToConfirmSize);
            this.Controls.Add(this.tbNumOfMeasurements);
            this.Controls.Add(this.LNumOfMeasurements);
            this.Controls.Add(this.DataFieldGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MHK";
            this.Text = "MHK";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataFieldGrid)).EndInit();
            this.gpFunctions.ResumeLayout(false);
            this.gpFunctions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartForModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataFieldGrid;
        private System.Windows.Forms.Label LNumOfMeasurements;
        private System.Windows.Forms.TextBox tbNumOfMeasurements;
        private System.Windows.Forms.Button bToConfirmSize;
        private System.Windows.Forms.Label line1Up;
        private System.Windows.Forms.Label line1Down;
        private System.Windows.Forms.RadioButton rbLineModelMode;
        private System.Windows.Forms.RadioButton rbQuadraticModel;
        private System.Windows.Forms.RadioButton rbExponentialModel;
        private System.Windows.Forms.Button bPerform;
        private System.Windows.Forms.TextBox tbResultsField;
        private System.Windows.Forms.Button bShowForm2;
        private System.Windows.Forms.RadioButton rbAutoChoice;
        private System.Windows.Forms.GroupBox gpFunctions;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartForModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDiflection;
        private System.Windows.Forms.CheckBox cBBasicLine;
        private System.Windows.Forms.CheckBox cBLine;
        private System.Windows.Forms.CheckBox cBSquare;
        private System.Windows.Forms.CheckBox cBExp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

