
namespace course
{
    partial class Form2ForChart
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
            this.ChartForTheModel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ChartForTheModel)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartForTheModel
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartForTheModel.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartForTheModel.Legends.Add(legend1);
            this.ChartForTheModel.Location = new System.Drawing.Point(30, 25);
            this.ChartForTheModel.Name = "ChartForTheModel";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "BasicLine";
            this.ChartForTheModel.Series.Add(series1);
            this.ChartForTheModel.Size = new System.Drawing.Size(740, 404);
            this.ChartForTheModel.TabIndex = 0;
            this.ChartForTheModel.Text = "chart1";
            // 
            // Form2ForChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChartForTheModel);
            this.Name = "Form2ForChart";
            this.Text = "Form2ForChart";
            this.Load += new System.EventHandler(this.Form2ForChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChartForTheModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ChartForTheModel;
    }
}