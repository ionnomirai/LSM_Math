using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace course.General
{
    class MathModelGeneral
    {
        private List<Double> dataX;//для заповнення даних по Х
        private List<Double> dataY;//для заповнення даних по Y
        private double forOtherCase = 0.0;//змінна для поточних потріб та розрахунків
        private double[] freeColumn;//матриця для збереження стовбчика вільних членів

        public MathModelGeneral(List<Double> dataX, List<Double> dataY)
        {
            this.dataX = dataX;
            this.dataY = dataY;
        }
        public List<Double> getDataX()
        {
            return dataX;
        }
        public List<Double> getDataY()
        {
            return dataY;
        }

        //рішення СЛАУ за методом Гауса 
        public double[] methodGauss(double[,] matrix)
        {
            freeColumn = setFreeCol(matrix); //заповнення вільних членів 
            straightPatgGauss(matrix, freeColumn);//виконання прямого ходу у методі Гауса-Жордана 
            searchRootsMatrix(matrix, freeColumn);//шукаємо корені СЛАУ 
            return freeColumn;
        }

        //створюється нова одномірна матриця та заповнюється вільними членами вказаної матриці 
        private double[] setFreeCol(double[,] matrix)
        {
            double[] x = new double[matrix.GetLength(0)];//GetLength(0) тобто кількість рядків (тут 3)
            for (int i = 0; i < x.GetLength(0); i++)
            {
                x[i] = matrix[i, matrix.GetLength(1) - 1];
            }
            return x;
        }

        //виконання прямого ходу у методі Гауса-Жордана (збереже чи void значення) 
        private void straightPatgGauss(double[,] matrix, double[] freeColumn)
        {
            double valueM; //створення змінної коефіцієнта для прямого ходу 
            for (int k = 1; k < matrix.GetLength(0); k++)
            { //за цією умовою зовнішній цикл відпрацьовує двічі (перший рядок не змінюється) 
                for (int j = k; j < matrix.GetLength(0); j++)
                {
                    valueM = matrix[j, k - 1] / matrix[k - 1, k - 1];//пошук коефіцієнта m 
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        matrix[j, i] = matrix[j, i] - valueM * matrix[k - 1, i];//знаходження нових значень шуканого рядка 
                    }
                    freeColumn[j] = freeColumn[j] - valueM * freeColumn[k - 1]; //це дубляція значень вільних стовпців у масив вільних членів
                }
            }
        }

        //пошук коренів рішення 
        private void searchRootsMatrix(double[,] matrix, double[] freeColumn)
        {
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    freeColumn[i] -= matrix[i, j] * freeColumn[j];
                }
                freeColumn[i] = freeColumn[i] / matrix[i, i];
            }
        }

        //підрахунок суми елементів списку (колонки) 
        public double sumOneList(List<Double> someList)
        {
            double newSum;
            forOtherCase = 0.0;
            for (int i = 0; i < someList.Count; i++)
            {
                forOtherCase += someList[i];
            }
            newSum = (forOtherCase);
            return newSum;
        }
    }
}
