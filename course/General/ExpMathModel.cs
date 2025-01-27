using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course.General
{
    class ExpMathModel : MathModelGeneral
    {
        private List<Double> listXDegreeTwo = new List<Double>();//для x^2
        private List<Double> dataXmultiExpY = new List<Double>();//для x*y^e
        private List<Double> listExpY = new List<Double>();//для y^e
        private double[] freeDoneColumn = new double[2];
        private double[,] matrix = new double[2, 3];
        private double forOtherCase = 0.0;

        private double[] diflectionParticularSValueExp;//для окремого відхилення
        private double diflectionTotalSValueExp = 0;//для повного квадрату відхилення

        private double newX;
        private double newY;

        String mathName = "";

        public ExpMathModel(List<Double> dataX, List<Double> dataY) : base(dataX, dataY)
        {
            diflectionParticularSValueExp = new double[base.getDataX().Count];
        }

        /*Центральний блок, який запитує виконання методів, та
            вивод у вигляді рядка вид математичної моделі */
        public String buildMathModel()
        {
            //автозаповнення таблиці
            autoSetOtherValue();

            //заповнюємо матрицю (СЛАУ) 
            setSystemOfEquations();

            //вирішуємо  СЛАУ
            freeDoneColumn = methodGauss(matrix);

            //b = e^b
            freeDoneColumn[1] = Math.Exp(freeDoneColumn[1]);

            //Знаходимо окреме відхилення 
            diflectionParticularE();

            //Знаходимо повне відхилення 
            diflectionTotalSValueExp = diflectionTotal();

            return mathName = String.Format("y = {0:N5} * e^{1: +0.#####; -0.#####; +####.#####; -####.#####; 0}*x\n",
                freeDoneColumn[1], freeDoneColumn[0]);
        }

        //автозаповнння таблиці
        private void autoSetOtherValue()
        {
            degreeX2();
            newX = sumOneList(base.getDataX());
            newY = sumOneList(base.getDataY());
            logExpY();
            XmultiXexpY();
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

        //розрахунок для для y^e
        private void logExpY()
        {
            forOtherCase = 0.0;
            for(int i = 0; i < base.getDataY().Count; i++)
            {
                listExpY.Add(Math.Log(base.getDataY()[i]));
                forOtherCase += listExpY[i];
            }
            listExpY.Add(forOtherCase);
        }

        //розрахунок для для x*y
        private void XmultiXexpY()
        {
            forOtherCase = 0.0;
            for (int i = 0; i < base.getDataX().Count; i++)
            {
                dataXmultiExpY.Add(base.getDataX()[i] * listExpY[i]);
                forOtherCase += dataXmultiExpY[i];
            }
            dataXmultiExpY.Add(forOtherCase);
        }

        //заповнення матриці
        private void setSystemOfEquations()
        {
            matrix[0, 0] = listXDegreeTwo[listXDegreeTwo.Count - 1];
            matrix[0, 1] = newX;
            matrix[0, 2] = dataXmultiExpY[dataXmultiExpY.Count -1];
            matrix[1, 0] = newX;
            matrix[1, 1] = base.getDataX().Count;
            matrix[1, 2] = listExpY[listExpY.Count -1];
        }

        //повернути стовбець вільних членів
        public double[] getFreeDoneColumn()
        { return freeDoneColumn; }

        //знаходимо окреме відхилення
        private void diflectionParticularE()
        {
            for (int i = 0; i < diflectionParticularSValueExp.GetLength(0); i++)
                diflectionParticularSValueExp[i] = freeDoneColumn[1] * Math.Exp(freeDoneColumn[0]* getDataX()[i]);
                
        }

        //знаходимо повне відхилення
        private double diflectionTotal()
        {
            forOtherCase = 0.0;
            for (int i = 0; i < diflectionParticularSValueExp.GetLength(0); i++)
                forOtherCase += (getDataY()[i] - diflectionParticularSValueExp[i]) *
                                (getDataY()[i] - diflectionParticularSValueExp[i]);
            return forOtherCase;
        }

        //повертаємо повне відхилення
        public double getDiflectionTotalSValueExp()
        {
            return this.diflectionTotalSValueExp;
        }

        //повертаємо розраховану модель
        public String getMathModelName()
        {
            return this.mathName;
        }

        //решение слау для данного случая, проблема с нулями (проблема решена, метод не нужен)
        /*        private void searchCoef(double[,] matrix) //чтобы точно не ошибиться введем параметр
                {
                    freeDoneColumn[0] = (base.getDataX().Count * dataXmultiExpY[dataXmultiExpY.Count - 1]
                        - newX* listExpY[listExpY.Count - 1])
                        / (base.getDataX().Count * listXDegreeTwo[listXDegreeTwo.Count - 1] - Math.Pow(newX,2));
                    freeDoneColumn[1] = (matrix[1, 2] - newX*freeDoneColumn[0])/ base.getDataX().Count;
                }*/
    }
}
