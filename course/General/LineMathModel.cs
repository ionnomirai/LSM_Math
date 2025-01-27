using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.General
{
    class LineMathModel : MathModelGeneral
    {
        private List<Double> listXDegreeTwo = new List<Double>();//для х^2
        private List<Double> dataXY = new List<Double>();//для х*у
        private double forOtherCase = 0.0;//для поточних потреб
        private double[] freeDoneColumn;// = new double[2];
        private double[,] matrix = new double[2, 3];
        private double[] diflectionParticularSValueL;// = new double[base.getDataX().Count];
        private double diflectionTotalSValueL = 0;

        private double newX;
        private double newY;

        private String mathName = "";
        public LineMathModel(List<Double> dataX, List<Double> dataY) : base(dataX, dataY)
        {
            diflectionParticularSValueL = new double[base.getDataX().Count];
        }

        /*Центральний блок, який запитує виконання методів, та
            вивод у вигляді рядка вид математичної моделі */
        public String buildMathModel()
        {
            //автозаповнення таблиці
            autoSetOtherValue();

            //заповнюємо матрицю (СЛАУ) 
            setSystemOfEquations();

            //вирішуємо СЛАУ
            freeDoneColumn = methodGauss(matrix);

            //знаходимо окреме відхилення
            diflectionParticularS();

            //знаходимо повне відхилення
            diflectionTotalSValueL = diflectionTotal();

            return mathName = String.Format("y = {0:N5}x {1:+0.#####; -0.#####; +####.#####; -####.#####; 0}\n", 
                                                freeDoneColumn[0], freeDoneColumn[1]);
        }

        //автозаповнння таблиці
        private void autoSetOtherValue()
        {
            degreeX2();
            multiXYexperiment();
            newX = sumOneList(base.getDataX());
            newY = sumOneList(base.getDataY());
        }

        //розрахунок для x^2
        private void degreeX2()
        {
            forOtherCase = 0.0;
            for (int i = 0; i < base.getDataX().Count; i++)
            {
                listXDegreeTwo.Add((base.getDataX()[i] * base.getDataX()[i]));
                forOtherCase += listXDegreeTwo[i];
            }
            listXDegreeTwo.Add(forOtherCase);
        }

        //розрахунок для x*у
        private void multiXYexperiment()
        {
            List<Double> listXYExperiment = new List<Double>();
            forOtherCase = 0.0;
            for (int i = 0; i < base.getDataX().Count; i++)
            {
                dataXY.Add(base.getDataX()[i] * base.getDataY()[i]);
                forOtherCase += dataXY[i];
            }
            dataXY.Add(forOtherCase);
        }

        //заповнення матриці
        private void setSystemOfEquations()
        {
            matrix[0, 0] = listXDegreeTwo[(listXDegreeTwo.Count - 1)];
            matrix[0, 1] = newX;
            matrix[0, 2] = dataXY[dataXY.Count - 1];
            matrix[1, 0] = newX;
            matrix[1, 1] = base.getDataX().Count;
            matrix[1, 2] = newY;
        }

        //знаходимо окреме відхилення
        private void diflectionParticularS()
        {
            for (int i = 0; i < diflectionParticularSValueL.GetLength(0); i++)
                diflectionParticularSValueL[i] = freeDoneColumn[0] * base.getDataX()[i] + freeDoneColumn[1];
        }

        //знаходимо повне відхилення
        private double diflectionTotal()
        {
            forOtherCase = 0.0;
            for (int i = 0; i < diflectionParticularSValueL.GetLength(0); i++)
                forOtherCase += (base.getDataY()[i] - diflectionParticularSValueL[i]) *
                        (base.getDataY()[i] - diflectionParticularSValueL[i]);
            return forOtherCase;
        }

        //повертаємо повне відхилення
        public double getDiflectionTotalSValueL()
        {
            return this.diflectionTotalSValueL;
        }

        //повернути стовбець вільних членів
        public double[] getFreeDoneColumn()
        { return freeDoneColumn; }

        //повертаємо розраховану модель
        public String getMathModelName()
        {
            return this.mathName;
        }
    }
}
