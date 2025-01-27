using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace course
{
    public partial class Form2ForChart : Form
    {
        private MHK form1 = new MHK();
        public Form2ForChart()
        {
            InitializeComponent();
        }

        private void Form2ForChart_Load(object sender, EventArgs e)
        {
            setBasicColumnsLine();
/*            if (form1.getListX() == null)
                MessageBox.Show("null");
            if (form1.getListX() != null)
                MessageBox.Show(Convert.ToString(form1.getListX()[1]));*/
            //проблема в том, что список передается пустым
        }

        //установка параметров, для рисования базовой линии
        private void setBasicColumnsLine()
        {
            double x, y;

            this.ChartForTheModel.Series[0].Points.Clear();
            //MessageBox.Show(Convert.ToString(listX[1])) ;


/*            for (int i = 0; i < form1.getTBNumOfMeasurements(); i++)
            {
*//*                x = form1.getListX()[i];
                y = form1.getListY()[i];
                this.ChartForTheModel.Series[0].Points.AddXY(x, y);*//*
            }*/

            /*            double a = -10, b = 10, h = 0.1, x, y; ;
                        this.ChartForTheModel.Series[0].Points.Clear();
                        this.ChartForTheModel.Series.Add("aa1");
                        x = a;
                        while (x <= b)
                        {
                            y = Math.Sin(x);
                            this.ChartForTheModel.Series["aa1"].Points.AddXY(x, y);
                            x += h;
                        }*/
            /*            this.ChartForTheModel.Series[0].Points.Clear();
                        for (int i = 0; i < form1.getTBNumOfMeasurements(); i++)
                            this.ChartForTheModel.Series[0].Points.AddXY(form1.getListX()[i],
                                form1.getListY()[i]);*/
        }
    }
}
