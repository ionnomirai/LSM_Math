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
    public partial class MHK : Form
    {
        private int countCells = 2;

        private List<Double> listX = new List<Double>(); //для збереження даних за Х
        private List<Double> listYExperiment = new List<Double>(); //для збереження даних за Y
        private  General.LineMathModel lineMathModel;//поле для подальшої ініціалізацації лінійної моделі
        private General.SquareMathModel squareMathModel;//поле для подальшої ініціалізацації квадратичної моделі
        private General.ExpMathModel expMathModel;//поле для подальшої ініціалізацації експонентної моделі
        private double x, y; //змінні для побудови графіку
        private bool flagExp = false; //флаг для варіативності дій, в залєжності від введених даних
        private double maxX = 0;

        public MHK()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //встановлення загальних налаштування форми та компонентів
            basicSetDataFieldGrid();
            settingOtherComponents();

            this.chartForModel.Series.Add("Лінійна функція");//створюємо нову лінію, для подальшого застосування
            this.chartForModel.Series.Add("Квадратична функція");//створюємо нову лінію, для подальшого застосування
            this.chartForModel.Series.Add("Експонентна функція");//створюємо нову лінію, для подальшого застосування
        }

        //створення об'єктів класів
        private void madeStandModel()
        {
            lineMathModel = new General.LineMathModel(listX, listYExperiment);
            squareMathModel = new General.SquareMathModel(listX, listYExperiment);
            expMathModel = new General.ExpMathModel(listX, listYExperiment);
        }

        //встановлення необхідних базових налаштувань для DataFieldGrid
        private void basicSetDataFieldGrid()
        {
            DataFieldGrid.ColumnCount = 2; //встановлення початкової кількості стовбчиків
            //встановлення висоті рядків
            DataFieldGrid.RowTemplate.Height = (DataFieldGrid.Size.Height / DataFieldGrid.ColumnCount) -1;
            DataFieldGrid.RowCount = 2; //встановлення початкового кількості рядків 
            //встановлення ширини стовбців (для усіх)
            for (int i = 0; i < DataFieldGrid.ColumnCount; i++)
                DataFieldGrid.Columns[i].Width = 60;
            DataFieldGrid.RowHeadersWidth = 50;//встановлення ширини клітинки легенди
            //встановлення ширини DataFieldGrid
            DataFieldGrid.Width = DataFieldGrid.RowHeadersWidth + 2 + (60 * DataFieldGrid.ColumnCount);
            DataFieldGrid.Rows[0].HeaderCell.Value = "X"; // встановлення назв рядків
            DataFieldGrid.Rows[1].HeaderCell.Value = "Y";
            DataFieldGrid.ColumnHeadersVisible = false;//приховати заголовок стовпців 
            DataFieldGrid.AllowUserToAddRows = false;//заборона на додавання рядків 
            DataFieldGrid.AllowUserToDeleteRows = false;//заборона  видалення рядків для користувача
        }

        // встановлення необхідних налаштувань для компонентів форми
        private void settingOtherComponents()
        {
            this.Height = 295; // базова висота головної форми 
            //заборона авторозміру для TextBox відповідального за вибір кількість вимірів 
            tbNumOfMeasurements.AutoSize = false;
            //Встановлення висоти компонента tbNumOfMeasurements(прив'язка до кнопки підтвердити розмір)
            tbNumOfMeasurements.Height = bToConfirmSize.Height;
            tbNumOfMeasurements.Width = 30;//встановлення ширини компонента tbNumOfMeasurements 
            //заборона авторозміру для TextBox, який відповідає за виведення результату 
            tbResultsField.AutoSize = false;
            //установка висоти компонента tbNumOfMeasurements (прив'язка до кнопки bPerform) 
            tbResultsField.Height = bPerform.Height;
        }

        //встановлення кількості вимірів. Кількість може бути від 2 до 10. За замовчуванням це 2. Якщо більше 
        //їх розмірність також встановлюється. При введенні некоректного символу виводиться помилка 
        private void bToConfirmSize_Click(object sender, EventArgs e)
        {
            try
            {
                countCells = Convert.ToInt32(tbNumOfMeasurements.Text);
                if (countCells < 2 | countCells > 10)
                {
                    MessageBox.Show("Введене число має бути в межах від 2 до 10");
                }
                else
                {
                    DataFieldGrid.ColumnCount = countCells;//встановлення кількості осередків на запит користувача 
                    for (int i = 0; i < DataFieldGrid.ColumnCount; i++)
                    {
                        DataFieldGrid.Columns[i].Width = 50;
                        DataFieldGrid.Width = DataFieldGrid.RowHeadersWidth + 2 + (50 * DataFieldGrid.ColumnCount);
                    }
                }    
            }
            catch (Exception a)
            {
                MessageBox.Show("Ви ввели некоректний символ. Введіть ціле значення.");
            }
        }

        //виконати розрахунок + перевірка на коректність заповнення 
        private void bPerform_Click(object sender, EventArgs e)
        {
            //перевірка на правильність заповнення. Якщо осередок не заповнений, то підсвічується красинм. 
            bool firstCheckFillCell = true;

            for (int i = 0; i < DataFieldGrid.RowCount; i++)
            {
                for (int j = 0; j < DataFieldGrid.ColumnCount; j++)
                {
                    if (DataFieldGrid[j, i].Value == null)//перша перевірка на відсутність значень
                    {
                        DataFieldGrid.Rows[i].Cells[j].Style.BackColor = Color.LightSalmon;
                        firstCheckFillCell = false;
                    }
                    else if (DataFieldGrid[j, i].Value != null)////спочатку все добре, на кожній ітерації
                        DataFieldGrid.Rows[i].Cells[j].Style.BackColor = Color.White;

                    if(DataFieldGrid[j, i].Value != null)//друга перевірка на коректність введених даних
                    {
                        String negative = DataFieldGrid[j, i].Value.ToString();//зберігаєм значення клітинки у рядок
                        int flagRe = 0;//флаг про повторення небезпечних символів
                        for (int p = 0; p < negative.Length; p++)//проходимо кожий символ з рядку
                        {
                            if (negative[p] == '-' && p > 0)//якщо '-' знаходиться не на нульовому місці - помилка
                            {
                                firstCheckFillCell = false;
                                DataFieldGrid.Rows[i].Cells[j].Style.BackColor = Color.LightSalmon;
                            }
                            if (negative[p] == ',')//якщо кома повторюється декілька раз, або є першим символом
                            {
                                flagRe++;
                                if (negative[p] == ',' && p == 0)
                                {
                                    firstCheckFillCell = false;
                                    DataFieldGrid.Rows[i].Cells[j].Style.BackColor = Color.LightSalmon;
                                }
                            }
                        }
                        if(flagRe > 1)//якщо повторюється більш одного разу - помилка
                        {
                            firstCheckFillCell = false;
                            DataFieldGrid.Rows[i].Cells[j].Style.BackColor = Color.LightSalmon;
                        }
                    }  
                }
            }

            //перехід до виконання розрахунку 
            if (firstCheckFillCell)
            {
                //перенесення значень DataFieldGrid до списку, який буде основою для побудови моделі 
                setTheBasicColumnsForModel();
                //створення об'єктів класів
                madeStandModel();

                maxX = listX[0];
                for(int t = 0; t < listX.Count; t++)
                {
                    if (maxX < listX[t])
                        maxX = listX[t];
                }
                if (rbLineModelMode.Checked)//якщо включена радіокнопка лінійної функції, то 
                {
                    tbResultsField.Text = lineMathModel.buildMathModel();//виведення моделі у текстове поле 
                    tbDiflection.Text = String.Format("{0:N5} - лінійна функція", lineMathModel.getDiflectionTotalSValueL());
                }
                else if(rbQuadraticModel.Checked) //якщо включена радіокнопка квадратичної функції, то 
                {
                    tbResultsField.Text = squareMathModel.buildMathModel();//виведення моделі у текстове поле 
                    tbDiflection.Text = String.Format("{0:N5} - квадратична функція", squareMathModel.getDiflectionTotalSValueSq());
                }
                else if(rbExponentialModel.Checked)//якщо включена радіокнопка екснонентної функції, то 
                {
                    if (flagExp == false)
                    {
                        tbResultsField.Text = expMathModel.buildMathModel();//виведення моделі у текстове поле 
                        tbDiflection.Text = String.Format("{0:N5} - експоненціальна функція", expMathModel.getDiflectionTotalSValueExp());
                     }
                    else if (flagExp == true)//якщо неможливо розрахувати експонентну функцію
                    {
                        MessageBox.Show("Y для експонентної функції не може бути менше нуля або дорівнювати нулю.");
                    }
                }
                else if(rbAutoChoice.Checked)//якщо включена радіокнопка автоматичного підбору, то 
                {
                    lineMathModel.buildMathModel();
                    squareMathModel.buildMathModel();
                    if (flagExp == false)
                        expMathModel.buildMathModel();
                    else
                        MessageBox.Show("Y для експонентної функції не може бути менше нуля або дорівнювати нулю.");
                    compareDiflectionThreeFunc();//порівняння відхилень моделей за функціями
                }

                //не відкривати графік якщо неможливо показати exp 
                if (rbExponentialModel.Checked && flagExp)
                    flagExp = false;
                else 
                { 
                    bShowForm2.Enabled = true;//зробити активною кнопку "показати графік"
                    gpFunctions.Enabled = false;//заблокувати вибір функцій
                }
            }
            else
            {
                MessageBox.Show("Ви заповнили не всі дані або некоректно ввели дані. Заповніть будь ласка червоні ділянки. ");
            }    
        }

        //перенесення значень DataFieldGrid до списку, який буде основою для побудови моделі 
        private void setTheBasicColumnsForModel()
        {
            if (listX.Count != 0 | listYExperiment.Count != 0)
            {
                //видалення попередніх даних матриці (для повторного використання) 
                listX.Clear();
                listYExperiment.Clear();
            }

            //перенесення значень до таблиці, що бере участь у розрахунках 
            for (int i = 0; i < DataFieldGrid.RowCount; i++)
                for (int j = 0; j < DataFieldGrid.ColumnCount; j++)
                {
                    if (i == 0)
                        listX.Add(Convert.ToDouble(DataFieldGrid[j, i].Value));
                    else if (i == 1)
                    {
                            listYExperiment.Add(Convert.ToDouble(DataFieldGrid[j, i].Value));
                            if (Convert.ToDouble(DataFieldGrid[j, i].Value) <= 0)
                                flagExp = true;
                    }
                }
        }

        //DataFieldGrid_EditingControlShowing + tb_KeyPress здійснюють введення лише цифр, знака мінус та коми 
        private void DataFieldGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;//Control вказуе що ми працюємо з виділеною клітиною
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);//при натисканні клавіші, нова подія

            if (e.Control is TextBox && tb != null)//is перевіряє, чи сумісний результат виразу із зазначеним типом. 
            {
                tb.TextChanged += new EventHandler(ItemTxtBox_TextChanged);//при зміні тексту, нова подія
            }
        }

        //зміна крапки на кому, та корегування видалення символів
        private void ItemTxtBox_TextChanged(object sender, EventArgs e)
        {
                var txt = (TextBox)sender;//створюємо змінну txt, и кладемо в неї значення з об'єкту що отримали
            if (txt.Text != null && txt.Text.Trim() != "")
                {
                    int positionDel = txt.SelectionStart;//встановлення значення положення курсора
                    txt.Text = txt.Text.Replace(".", ",");//заміна одного символа на інший
                    txt.SelectionStart = positionDel;//встановлення позиції після видалення символів
                }
        }

        //зміна пройде, якщо натиснута певна клавіша
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '-')) && !((e.KeyChar == ',')) && !((e.KeyChar == '.')))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                     e.Handled = true;
                }
            }
        }

        //кнопка по натисканню збільшення батьківської форми та показ графіка 
        private void bShowForm2_Click(object sender, EventArgs e)
        {
            this.Height = 547;//новий розмір центральної форми
            chartForModel.Visible = true;//умикаєио видимість поля для графіка
            chartForModel.Enabled = true;//умикаєио можливість взаємодії поля для графіка
            visibleCheckBoxes(false);//вимикаємо видимість CheckBoxes включення певних ліній
            checkBoxTurnOn();//за замовчуванням, усі лінії включені
  
            //створємо базову лінію графіка
            this.chartForModel.Series["Базова лінія"].Points.Clear();
            for (int i = 0; i < listX.Count; i++)
            {
                x = listX[i];
                y = listYExperiment[i];
                this.chartForModel.Series[0].Points.AddXY(x, y);
            }
            
            //вимикаємо видимість легенди
            this.chartForModel.Series["Лінійна функція"].IsVisibleInLegend = false;
            this.chartForModel.Series["Квадратична функція"].IsVisibleInLegend = false;
            this.chartForModel.Series["Експонентна функція"].IsVisibleInLegend = false;

            //видаляємо попередені дані для функцій
            this.chartForModel.Series["Лінійна функція"].Points.Clear();
            this.chartForModel.Series["Квадратична функція"].Points.Clear();
            this.chartForModel.Series["Експонентна функція"].Points.Clear();

            if (rbLineModelMode.Checked == true)//якщо увімкнено, креслимо лінійну функції
            {
                chartLineModelON();
            }

            if (rbQuadraticModel.Checked == true)//якщо увімкнено, креслимо квадратичну функції
            {
                chartQuadraticModelON();
            }

            if (rbExponentialModel.Checked == true)//якщо увімкнено, креслимо експонентну функції
            {
                if(flagExp == false)//креслимо тільки тоді, якщо це можливо (умова виконана)
                    chartExponentialModelON();
            }

            if(rbAutoChoice.Checked == true)//якщо увімкнено, креслимо усі функції
            {
                chartLineModelON();

                chartQuadraticModelON();

                if (flagExp == false)
                    chartExponentialModelON();

                visibleCheckBoxes(true);
                
            }
            bShowForm2.Enabled = false;//поки не розрахуємо нові дані, заблокувати кнопку Показати графік
            gpFunctions.Enabled = true;//увімкнути можливість обрати функцію для розрахунку
        }
        
        //метод для креслення лінійної функції
        private void chartLineModelON()
        {
            this.chartForModel.Series["Лінійна функція"].IsVisibleInLegend = true;
            this.chartForModel.Series["Лінійна функція"].ChartType =
                        System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            this.chartForModel.Series["Лінійна функція"].BorderWidth = 3;
            for (double i = listX[0]; i < maxX +2;
                i += 1f)
            {
                x = i;
                y = lineMathModel.getFreeDoneColumn()[0] * x
                    + lineMathModel.getFreeDoneColumn()[1];
                this.chartForModel.Series["Лінійна функція"].Points.AddXY(x, y);
            }
        }

        //увімкнути усі checkBox для відображення ліній на графіку
        private void checkBoxTurnOn()
        {
            cBBasicLine.Checked = true;
            cBLine.Checked = true;
            cBSquare.Checked = true;
            cBExp.Checked = true;
        }

        //метод для креслення квадратичної функції
        private void chartQuadraticModelON()
        {
            this.chartForModel.Series["Квадратична функція"].IsVisibleInLegend = true;
            this.chartForModel.Series["Квадратична функція"].ChartType =
                        System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            this.chartForModel.Series["Квадратична функція"].BorderWidth = 3;
            for (double i = listX[0]; i < maxX +2; i++)
            {
                x = i;
                y = squareMathModel.getFreeDoneColumn1()[0] * Math.Pow(x, 2)
                    + squareMathModel.getFreeDoneColumn1()[1] * x
                    + squareMathModel.getFreeDoneColumn1()[2];
                this.chartForModel.Series["Квадратична функція"].Points.AddXY(x, y);
            }
        }

        //метод для креслення експонентної функції
        private void chartExponentialModelON()
        {
                this.chartForModel.Series["Експонентна функція"].IsVisibleInLegend = true;
                this.chartForModel.Series["Експонентна функція"].ChartType =
                            System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                this.chartForModel.Series["Експонентна функція"].BorderWidth = 3;
                for (double i = listX[0]; i < maxX +2; i++)
                {
                    x = i;
                    y = expMathModel.getFreeDoneColumn()[1] * Math.Exp((expMathModel.getFreeDoneColumn()[0] * x));
                    this.chartForModel.Series["Експонентна функція"].Points.AddXY(x, y);
                }
        }

        //Якщо увімкнено checkBox на Basic Line тоді показувати її, якщо немає приховати 
        private void cBBasicLine_CheckedChanged(object sender, EventArgs e)
        {
            if (cBBasicLine.Checked)
                this.chartForModel.Series["Базова лінія"].BorderWidth = 3;
            else
                this.chartForModel.Series["Базова лінія"].BorderWidth = 0;
        }

        //Якщо увімкнено checkBox на Лінійна функція тоді показувати її, якщо ні приховати 
        private void cBLine_CheckedChanged(object sender, EventArgs e)
        {
            if (cBLine.Checked)
                this.chartForModel.Series["Лінійна функція"].BorderWidth = 3;
            else
                this.chartForModel.Series["Лінійна функція"].BorderWidth = 0;
        }

        //Якщо увімкнено checkBox на Квадратична функція тоді показувати її, якщо немає приховати 
        private void cBSquare_CheckedChanged(object sender, EventArgs e)
        {
            if (cBSquare.Checked)
                this.chartForModel.Series["Квадратична функція"].BorderWidth = 3;
            else
                this.chartForModel.Series["Квадратична функція"].BorderWidth = 0;
        }

        //Якщо включений checkBox на Експонентна функція тоді показувати її, якщо ні приховати 
        private void cBExp_CheckedChanged(object sender, EventArgs e)
        {
            if (cBExp.Checked)
                this.chartForModel.Series["Експонентна функція"].BorderWidth = 3;
            else
                this.chartForModel.Series["Експонентна функція"].BorderWidth = 0;
        }

        //включення та відключення чекбоксів відповідальних за відображення ліній 
        private void visibleCheckBoxes(bool flagTurn)
        {
            if (flagTurn)
            {
                cBBasicLine.Visible = true;
                cBLine.Visible = true;
                cBSquare.Visible = true;
                if(flagExp == false)
                    cBExp.Visible = true;
            }
            else
            {
                cBBasicLine.Visible = false;
                cBLine.Visible = false;
                cBSquare.Visible = false;
                cBExp.Visible = false;
            }   
        }

        //порівняння відхилень для випадку з 3 функціями 
        private void compareDiflectionThreeFunc()
        {
            if(flagExp == false)
            {
                if (lineMathModel.getDiflectionTotalSValueL() <= squareMathModel.getDiflectionTotalSValueSq()
               && lineMathModel.getDiflectionTotalSValueL() <= expMathModel.getDiflectionTotalSValueExp())
                {
                    tbDiflection.Text = String.Format("{0:N7} - лінайна функція", lineMathModel.getDiflectionTotalSValueL());
                    tbResultsField.Text = lineMathModel.getMathModelName();
                }
                else if (squareMathModel.getDiflectionTotalSValueSq() < lineMathModel.getDiflectionTotalSValueL()
                    && squareMathModel.getDiflectionTotalSValueSq() < expMathModel.getDiflectionTotalSValueExp())
                {
                    tbDiflection.Text = String.Format("{0:N7} - квадратична функція", squareMathModel.getDiflectionTotalSValueSq());
                    tbResultsField.Text = squareMathModel.getMathModelName();
                }
                else
                {
                    tbDiflection.Text = String.Format("{0:N7} - експоненціальна функція", expMathModel.getDiflectionTotalSValueExp());
                    tbResultsField.Text = expMathModel.getMathModelName();
                }
            }
            else
            {
                if (lineMathModel.getDiflectionTotalSValueL() <= squareMathModel.getDiflectionTotalSValueSq())
                {
                    tbDiflection.Text = String.Format("{0:N7} - лінайна функція", lineMathModel.getDiflectionTotalSValueL());
                    tbResultsField.Text = lineMathModel.getMathModelName();
                }
                else
                {
                    tbDiflection.Text = String.Format("{0:N7} - квадратична функція", squareMathModel.getDiflectionTotalSValueSq());
                    tbResultsField.Text = squareMathModel.getMathModelName();
                }
            }
           
        }
    }
}
