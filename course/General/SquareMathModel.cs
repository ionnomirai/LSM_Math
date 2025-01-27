using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.General
{
    class SquareMathModel : MathModelGeneral
    {
        private List<Double> listXDegreeTwo = new List<Double>();//для x^2
        private List<Double> listXDegreeThree = new List<Double>();//для x^3
        private List<Double> listXDegreeFour = new List<Double>();//для x^4
        private List<Double> dataXY = new List<Double>();//для x*y
        private List<Double> dataXDegree2Y = new List<Double>();//для x^2*y
        private double[] freeDoneColumn;
        private double[,] matrix = new double[3, 4];
        private double forOtherCase = 0.0;
        private double[] diflectionParticularSValueSq;
        private double diflectionTotalSValueSq = 0;

        private double newX;
        private double newY;

        String mathName = "";

        public SquareMathModel(List<Double> dataX, List<Double> dataY) : base(dataX, dataY)
        {
            diflectionParticularSValueSq = new double[base.getDataX().Count];
        }

        /*Центральний блок, який запитує виконання методів, та
            вивод у вигляді рядка вид математичної моделі */
        public String buildMathModel()
        {
            //автозаповнення таблиц
            autoSetOtherValue();

            //заповнюємо матрицю (СЛАУ) 
            setSystemOfEquations();

            //вирішуємо СЛАУ
            freeDoneColumn = methodGauss(matrix);

            //знаходимо окреме відхилення
            diflectionParticularS();

            //знаходимо повне відхилення
            diflectionTotalSValueSq = diflectionTotal();

            return mathName = String.Format("y = {0:N5}x^2 {1:+0.#####; -0.#####; +####.#####; -####.#####; 0}x " +
                "{2:+0.#####; -0.#####; +####.#####; -####.#####; 0}\n",
                freeDoneColumn[0], freeDoneColumn[1], freeDoneColumn[2]);
        }

        //автозаповнння таблиці
        private void autoSetOtherValue()
        {
            degreeX2();
            degreeX3();
            degreeX4();
            newX = sumOneList(base.getDataX());
            newY = sumOneList(base.getDataY());
            multiXYexperiment();
            multiXDegree2Yexperiment();
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

        //розрахунок для x^3
        private void degreeX3()
        {
            forOtherCase = 0.0;
            for (int i = 0; i < base.getDataX().Count; i++)
            {
                listXDegreeThree.Add(Math.Pow(base.getDataX()[i], 3));
                forOtherCase += listXDegreeThree[i];
            }
            listXDegreeThree.Add(forOtherCase);
        }

        //розрахунок для x^4
        private void degreeX4()
        {
            forOtherCase = 0.0;
            for (int i = 0; i < base.getDataX().Count; i++)
            {
                listXDegreeFour.Add(Math.Pow(base.getDataX()[i], 4));
                forOtherCase += listXDegreeFour[i];
            }
            listXDegreeFour.Add(forOtherCase);
        }

        //розрахунок для x*y
        private void multiXYexperiment()
        {
            forOtherCase = 0.0;
            for (int i = 0; i < base.getDataX().Count; i++)
            {
                dataXY.Add(base.getDataX()[i] * base.getDataY()[i]);
                forOtherCase += dataXY[i];
            }
            dataXY.Add(forOtherCase);
        }

        //розрахунок для (x^2)*y
        private void multiXDegree2Yexperiment()
        {
            List<Double> listXYExperiment = new List<Double>();
            forOtherCase = 0.0;
            for (int i = 0; i < listXDegreeTwo.Count-1; i++)
            {
                dataXDegree2Y.Add(listXDegreeTwo[i] * base.getDataY()[i]);
                forOtherCase += dataXDegree2Y[i];
            }
            dataXDegree2Y.Add(forOtherCase);
        }

        //заповнення матриці
        private void setSystemOfEquations()
        {
            matrix[0, 0] = listXDegreeFour[listXDegreeFour.Count -1];
            matrix[0, 1] = listXDegreeThree[listXDegreeThree.Count - 1];
            matrix[0, 2] = listXDegreeTwo[listXDegreeTwo.Count - 1];
            matrix[0, 3] = dataXDegree2Y[dataXDegree2Y.Count - 1];
            matrix[1, 0] = listXDegreeThree[listXDegreeThree.Count - 1];
            matrix[1, 1] = listXDegreeTwo[listXDegreeTwo.Count - 1];
            matrix[1, 2] = newX;
            matrix[1, 3] = dataXY[dataXY.Count - 1];
            matrix[2, 0] = listXDegreeTwo[listXDegreeTwo.Count - 1];
            matrix[2, 1] = newX;
            matrix[2, 2] = base.getDataX().Count;
            matrix[2, 3] = newY;
        }

        //повернути стовбець вільних членів
        public double[] getFreeDoneColumn1()
        { return freeDoneColumn; }

        //знаходимо окреме відхилення
        private void diflectionParticularS()
        {
            for (int i = 0; i < diflectionParticularSValueSq.GetLength(0); i++)
                diflectionParticularSValueSq[i] = freeDoneColumn[0] * Math.Pow(getDataX()[i], 2) 
                    + freeDoneColumn[1] * getDataX()[i] + freeDoneColumn[2];
        }

        //знаходимо повне відхилення
        private double diflectionTotal()
        {
            forOtherCase = 0.0;
            for (int i = 0; i < diflectionParticularSValueSq.GetLength(0); i++)
                forOtherCase += (getDataY()[i] - diflectionParticularSValueSq[i]) *
                                (getDataY()[i] - diflectionParticularSValueSq[i]);
            return forOtherCase;
        }

        //повертаємо повне відхилення
        public double getDiflectionTotalSValueSq()
        {
            return this.diflectionTotalSValueSq;
        }

        //повертаємо розраховану модель
        public String getMathModelName()
        {
            return this.mathName;
        }

    }
}
