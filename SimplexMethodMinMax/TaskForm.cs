using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplexMethodMinMax
{
    public partial class TaskForm : Form
    {
        private MainForm mainForm;

        private int number_of_constraints, number_of_variables;
        private double[,] matrix;
        private ArrayList string_c;
        private ArrayList string_r;
        private int x, y;
        private string taskType;
        public TaskForm()
        {
            int x = 10;
            int y = 10;

            mainForm = new MainForm();

            if (mainForm.ShowDialog() == DialogResult.OK)
            {
                taskType = "max";
                number_of_constraints = mainForm.NumberOfConstraints;
                number_of_variables = mainForm.NumberOfVariables;
                Label label1 = new Label();
                label1.Text = "Цех скловиробів виготовляє скло 2-х кольорів: червоного та зеленого. \n" +
                              "Менеджери з продажу вважають, що за день у магазині реалізують не більше 7 стекол.\n" +
                              "Для виготовлення скла червоного кольору необхідно використати 1 л фарби.\n" +
                              "Для виготовлення скла зеленого кольору необхідно використати 3 л фарби.\n" +
                              "Цех може отримати не більше 15 л фарби на день.\n" +
                              "Для виготовлення скла червоного кольору необхідно 2 години машинного часу.\n" +
                              "Для виготовлення скла зеленого кольору необхідна 1 година машинного часу.\n" +
                              "Машину можна використовувати не більше 12 годин на день.\n" +
                              "Якщо прибуток від продажу стекол червоного кольору складає 3 грошових одиниці,\n" +
                              "а від стекол зеленого кольору - 2 грошових одиниці, то скільки стекол\n" +
                              "кожного кольору потрібно випускати за день?\n";
                label1.AutoSize = true;
                label1.Location = new Point(x, y);
                Controls.Add(label1);

                Button butSolve = new Button();
                butSolve.Location = new System.Drawing.Point(x + 150, y + label1.Height);
                butSolve.Name = "butSolve";
                butSolve.Text = "Скласти рівняння";
                butSolve.AutoSize = true;
                Controls.Add(butSolve);
                butSolve.Click += butSolve_Click;
            }

            if (mainForm.ShowDialog() == DialogResult.Yes)
            {
                taskType = "min";
                number_of_constraints = mainForm.NumberOfConstraints;
                number_of_variables = mainForm.NumberOfVariables;
                Label label1 = new Label();
                label1.Text = "Маємо два види продукції - йогурт та кефір." +
                              "В йогурті міститься 1 г жирів, 3 г білків та 2 г вуглеводів." +
                              "В кефірі міститься 2 г жирів, 2 г білків та 1 г вуглеводів." +
                              "Відомо, що необхідний мінімум білків в продукті - 10 г, жирів - 8 г,"+
                              "вуглеводів - 9 г."+
                              "Вартість йогурту - 3 грошових одиниці, кефіру - 4 грошових одиниці."+
                              "Скласти дієту, яка з одного боку містила достатню кількість білків," +
                              "жирів та вуглеводів, не меншу за науково обґрунтований мінімум"+
                              "і разом з тим потребувала мінімальних витрат.";
                label1.AutoSize = true;
                label1.Location = new Point(x, y);
                Controls.Add(label1);

                Button butSolve = new Button();
                butSolve.Location = new System.Drawing.Point(x + 150, y + label1.Height);
                butSolve.Name = "butSolve";
                butSolve.Text = "Скласти рівняння";
                butSolve.AutoSize = true;
                Controls.Add(butSolve);
                butSolve.Click += butSolve_Click;
            }

            InitializeComponent();
        }

        private void butSolve_Click(object sender, EventArgs e)
        {
            if (taskType == "max")
            {
                Controls.Clear();

                x = 0;
                y = 0;

                Label label_coef = new Label();
                label_coef.Text = "Функція для максимізації:";
                label_coef.AutoSize = true;
                label_coef.Location = new System.Drawing.Point(x, y);
                Controls.Add(label_coef);

                y += 30;
                x = 0;

                for (int i = 0; i < number_of_variables; i++)
                {
                    TextBox txtbx = new TextBox();
                    txtbx.Location = new System.Drawing.Point(x + 20, y);
                    txtbx.Name = "txtbxFuncCoef" + i;
                    if (i == 0)
                    {
                        txtbx.Text = 3.ToString();
                    }

                    if (i == 1)
                    {
                        txtbx.Text = 2.ToString();
                    }

                    txtbx.MaxLength = 3;
                    txtbx.Size = new System.Drawing.Size(20, 20);
                    Controls.Add(txtbx);

                    x += 40;

                    Label lab = new Label();
                    lab.Location = new System.Drawing.Point(x, y + 3);
                    lab.Size = new System.Drawing.Size(20, 20);
                    lab.Text = "x" + (i + 1);
                    Controls.Add(lab);

                    x += 10;
                }

                Label lab1 = new Label();
                lab1.Location = new System.Drawing.Point(x + 10, y + 3);
                lab1.Size = new System.Drawing.Size(20, 20);
                lab1.Text = "=";
                Controls.Add(lab1);

                x += 10;

                TextBox txtbx2 = new TextBox();
                txtbx2.Location = new System.Drawing.Point(x + 20, y);
                txtbx2.Name = "txtbxFuncRhs";
                txtbx2.Text = "0";
                txtbx2.MaxLength = 3;
                txtbx2.Size = new System.Drawing.Size(20, 20);
                Controls.Add(txtbx2);

                y += 30;

                Label label_const = new Label();
                label_const.Text = "Constraints:";
                label_const.Location = new System.Drawing.Point(0, y);
                Controls.Add(label_const);

                y += 30;
                x = 0;

                for (int i = 0; i < number_of_constraints; i++)
                {
                    for (int j = 0; j < number_of_variables; j++)
                    {
                        TextBox txtbx = new TextBox();
                        txtbx.Location = new System.Drawing.Point(x + 20, y);
                        txtbx.Name = "txtbxConst" + (i * number_of_variables + j);
                        txtbx.MaxLength = 3;
                        if (i == 0 && j == 0)
                        {
                            txtbx.Text = 1.ToString();
                        }

                        if (i == 0 && j == 1)
                        {
                            txtbx.Text = 3.ToString();
                        }

                        if (i == 1 && j == 0)
                        {
                            txtbx.Text = 1.ToString();
                        }

                        if (i == 1 && j == 1)
                        {
                            txtbx.Text = 1.ToString();
                        }

                        if (i == 2 && j == 0)
                        {
                            txtbx.Text = 2.ToString();
                        }

                        if (i == 2 && j == 1)
                        {
                            txtbx.Text = 1.ToString();
                        }

                        txtbx.Size = new System.Drawing.Size(20, 20);
                        Controls.Add(txtbx);

                        x += 40;

                        Label lab = new Label();
                        lab.Location = new System.Drawing.Point(x, y + 3);
                        lab.Size = new System.Drawing.Size(20, 20);
                        lab.Text = "x" + (j + 1);
                        Controls.Add(lab);

                        x += 10;
                    }

                    Label lab2 = new Label();
                    lab2.Location = new System.Drawing.Point(x + 10, y + 3);
                    lab2.Size = new System.Drawing.Size(20, 20);
                    lab2.Text = "<=";
                    Controls.Add(lab2);

                    TextBox txtbx3 = new TextBox();
                    txtbx3.Location = new System.Drawing.Point(x + 30, y);
                    txtbx3.Name = "txtbxConstRhs" + i;
                    txtbx3.MaxLength = 3;
                    if (i == 0)
                    {
                        txtbx3.Text = 15.ToString();
                    }

                    if (i == 1)
                    {
                        txtbx3.Text = 7.ToString();
                    }

                    if (i == 2)
                    {
                        txtbx3.Text = 12.ToString();
                    }

                    txtbx3.Size = new System.Drawing.Size(20, 20);
                    Controls.Add(txtbx3);

                    y += 30;
                    x = 0;
                }

                y += 10;
                Button butSolve1 = new Button();
                butSolve1.Location = new System.Drawing.Point(x + 90, y);
                butSolve1.Name = "butSolve";
                butSolve1.Text = "Розрахувати";
                butSolve1.AutoSize = true;
                Controls.Add(butSolve1);
                butSolve1.Click += new System.EventHandler(this.butSolve1_Click);
            }

            if (taskType == "min")
            {
                Controls.Clear();

                x = 0;
                y = 0;
                /*----------------------------------------------------------------------------------*/
                Label label_coef = new Label();
                label_coef.Text = "Функція для мінімізації:";
                label_coef.AutoSize = true;
                label_coef.Location = new System.Drawing.Point(x, y);
                Controls.Add(label_coef);

                y += 30;
                x = 0;

                for (int i = 0; i < number_of_variables; i++)
                {
                    TextBox txtbx = new TextBox();
                    txtbx.Location = new System.Drawing.Point(x + 20, y);
                    txtbx.Name = "txtbxFuncCoef" + i;
                    if (i == 0)
                    {
                        txtbx.Text = 3.ToString();
                    }

                    if (i == 1)
                    {
                        txtbx.Text = 2.ToString();
                    }

                    txtbx.MaxLength = 3;
                    txtbx.Size = new System.Drawing.Size(20, 20);
                    Controls.Add(txtbx);

                    x += 40;

                    Label lab = new Label();
                    lab.Location = new System.Drawing.Point(x, y + 3);
                    lab.Size = new System.Drawing.Size(20, 20);
                    lab.Text = "x" + (i + 1);
                    Controls.Add(lab);

                    x += 10;
                }

                Label lab1 = new Label();
                lab1.Location = new System.Drawing.Point(x + 10, y + 3);
                lab1.Size = new System.Drawing.Size(20, 20);
                lab1.Text = "=";
                Controls.Add(lab1);

                x += 10;

                TextBox txtbx2 = new TextBox();
                txtbx2.Location = new System.Drawing.Point(x + 20, y);
                txtbx2.Name = "txtbxFuncRhs";
                txtbx2.Text = "0";
                txtbx2.MaxLength = 3;
                txtbx2.Size = new System.Drawing.Size(20, 20);
                Controls.Add(txtbx2);

                y += 30;

                Label label_const = new Label();
                label_const.Text = "Constraints:";
                label_const.Location = new System.Drawing.Point(0, y);
                Controls.Add(label_const);

                y += 30;
                x = 0;

                for (int i = 0; i < number_of_constraints; i++)
                {
                    for (int j = 0; j < number_of_variables; j++)
                    {
                        TextBox txtbx = new TextBox();
                        txtbx.Location = new System.Drawing.Point(x + 20, y);
                        txtbx.Name = "txtbxConst" + (i * number_of_variables + j);
                        txtbx.MaxLength = 3;
                        if (i == 0 && j == 0)
                        {
                            txtbx.Text = 1.ToString();
                        }

                        if (i == 0 && j == 1)
                        {
                            txtbx.Text = 3.ToString();
                        }

                        if (i == 1 && j == 0)
                        {
                            txtbx.Text = 1.ToString();
                        }

                        if (i == 1 && j == 1)
                        {
                            txtbx.Text = 1.ToString();
                        }

                        if (i == 2 && j == 0)
                        {
                            txtbx.Text = 2.ToString();
                        }

                        if (i == 2 && j == 1)
                        {
                            txtbx.Text = 1.ToString();
                        }

                        txtbx.Size = new System.Drawing.Size(20, 20);
                        Controls.Add(txtbx);

                        x += 40;

                        Label lab = new Label();
                        lab.Location = new System.Drawing.Point(x, y + 3);
                        lab.Size = new System.Drawing.Size(20, 20);
                        lab.Text = "x" + (j + 1);
                        Controls.Add(lab);

                        x += 10;
                    }

                    Label lab2 = new Label();
                    lab2.Location = new System.Drawing.Point(x + 10, y + 3);
                    lab2.Size = new System.Drawing.Size(20, 20);
                    lab2.Text = "<=";
                    Controls.Add(lab2);

                    TextBox txtbx3 = new TextBox();
                    txtbx3.Location = new System.Drawing.Point(x + 30, y);
                    txtbx3.Name = "txtbxConstRhs" + i;
                    txtbx3.MaxLength = 3;
                    if (i == 0)
                    {
                        txtbx3.Text = 15.ToString();
                    }

                    if (i == 1)
                    {
                        txtbx3.Text = 7.ToString();
                    }

                    if (i == 2)
                    {
                        txtbx3.Text = 12.ToString();
                    }

                    txtbx3.Size = new System.Drawing.Size(20, 20);
                    Controls.Add(txtbx3);

                    y += 30;
                    x = 0;
                }

                y += 10;
                Button butSolve1 = new Button();
                butSolve1.Location = new System.Drawing.Point(x + 90, y);
                butSolve1.Name = "butSolve";
                butSolve1.Text = "Розрахувати";
                butSolve1.AutoSize = true;
                Controls.Add(butSolve1);
                butSolve1.Click += new System.EventHandler(this.butSolve1_Click);
            }
        }

        private void butSolve1_Click(object sender, EventArgs e)
        {
            matrix = new double[number_of_constraints + 1, number_of_variables + number_of_constraints + 1];

            try
            {
                for (int i = 0; i < number_of_variables; i++)
                {
                    matrix[0, i] = -1 * double.Parse(Controls.Find("txtbxFuncCoef" + i, false)[0].Text);
                }
            }
            catch
            {
                MessageBox.Show("Incorrect value!");
                this.Close();
            }

            for (int i = number_of_variables; i < number_of_variables + number_of_constraints; i++)
            {
                matrix[0, i] = 0;
            }

            Control[] funcRhs = Controls.Find("txtbxFuncRhs", false);
            try
            {
                matrix[0, number_of_variables + number_of_constraints] = double.Parse(funcRhs[0].Text);
            }
            catch
            {
                MessageBox.Show("Incorrect value!");
                this.Close();
            }

            try
            {
                for (int i = 1; i < number_of_constraints + 1; i++)
                {
                    for (int j = 0; j < number_of_variables; j++)
                    {
                        matrix[i, j] = double.Parse(Controls.Find("txtbxConst" + ((i - 1) * number_of_variables + j), false)[0].Text);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Incorrect value!");
                this.Close();
            }

            for (int i = 1; i < number_of_constraints + 1; i++)
            {
                for (int j = number_of_variables; j < number_of_variables + number_of_constraints; j++)
                {
                    if (j - number_of_variables + 1 == i) matrix[i, j] = 1;
                    else matrix[i, j] = 0;
                }
            }

            try
            {
                for (int i = 1; i < number_of_constraints + 1; i++)
                {
                    double n = double.Parse(Controls.Find("txtbxConstRhs" + (i - 1), false)[0].Text);
                    if (n < 0) throw new Exception();
                    matrix[i, number_of_variables + number_of_constraints] = n;
                }
            }
            catch
            {
                MessageBox.Show("Incorrect value!");
                this.Close();
            }

            string_c = new ArrayList();
            for (int i = 0; i < number_of_constraints; i++)
            {
                string str = "s" + (i + 1);
                string_c.Add(str);
            }

            string_r = new ArrayList();
            for (int i = 0; i < number_of_variables + number_of_constraints; i++)
            {
                if (i >= number_of_variables)
                {
                    string str = "s" + (i - number_of_variables + 1);
                    string_r.Add(str);
                }
                else
                {
                    string str = "x" + (i + 1);
                    string_r.Add(str);
                }
            }

            Controls.Clear();
            x = 0;
            y = 0;

        label1: PrintTable();

            if (IsOptimal())
            {
                y += 30;
                for (int i = 1; i < number_of_constraints + 1; i++)
                {
                    Label lab2 = new Label();
                    lab2.Location = new System.Drawing.Point(x, y);
                    lab2.AutoSize = true;
                    lab2.Text = (string)string_c[i - 1] + " = " + matrix[i, number_of_variables + number_of_constraints];
                    Controls.Add(lab2);

                    y += 30;
                }

                Label lab = new Label();
                lab.Location = new System.Drawing.Point(x, y);
                lab.AutoSize = true;
                lab.Text = "z(max) = " + matrix[0, number_of_variables + number_of_constraints];
                Controls.Add(lab);

                y += 30;

                string color = "";
                for (int i = 1; i < number_of_constraints + 1; i++)
                {
                    Label lab2 = new Label();
                    lab2.Location = new System.Drawing.Point(x, y);
                    lab2.AutoSize = true;
                    if ((string)string_c[i - 1] == "x1")
                    {
                        color = "Якщо використати фарбу червоного кольору";
                    }
                    if ((string)string_c[i - 1] == "x2")
                    {
                        color = "зеленого кольору";
                    }
                    if ((string)string_c[i - 1] == "s1")
                    {
                        color = "залишиться невикористаних додаткових матеріалів";
                    }
                    lab2.Text = color + " = " + matrix[i, number_of_variables + number_of_constraints] + "л";
                    Controls.Add(lab2);

                    y += 30;
                }

                Label lab1 = new Label();
                lab1.Location = new System.Drawing.Point(x, y);
                lab1.AutoSize = true;
                lab1.Text = "Максимальний прибуток = " + matrix[0, number_of_variables + number_of_constraints];
                Controls.Add(lab1);
            }
            else
            {
                int guiding_column = FindGuidingColumn();
                int guiding_row = FindGuidingRow(guiding_column);

                Label lab = new Label();
                lab.Location = new System.Drawing.Point(x, y);
                lab.AutoSize = true;
                lab.Text = "Guiding element:" + matrix[guiding_row, guiding_column];
                Controls.Add(lab);

                y += 30;

                MakeNewGuidingRow(guiding_row, matrix[guiding_row, guiding_column]);
                RecalculationOfTable(guiding_row, guiding_column);
                goto label1;
            }
        }

        private void PrintTable()
        {
            x += 30;
            for (int j = 0; j < number_of_constraints + number_of_variables + 1; j++)
            {
                if (j == number_of_variables + number_of_constraints)
                {
                    Label lab2 = new Label();
                    lab2.Location = new System.Drawing.Point(x, y);
                    lab2.AutoSize = true;
                    lab2.Text = "RHS";
                    Controls.Add(lab2);

                    x = 0;
                }
                else
                {
                    Label lab2 = new Label();
                    lab2.Location = new System.Drawing.Point(x, y);
                    lab2.Size = new System.Drawing.Size(20, 20);
                    lab2.Text = (string)string_r[j];
                    Controls.Add(lab2);

                    x += 30;
                }
            }

            y += 30;

            for (int i = 0; i < number_of_constraints + 1; i++)
            {
                for (int j = 0; j < number_of_constraints + number_of_variables + 2; j++)
                {
                    if (j == 0)
                    {
                        if (i == 0)
                        {
                            Label lab2 = new Label();
                            lab2.Location = new System.Drawing.Point(x, y);
                            lab2.Size = new System.Drawing.Size(20, 20);
                            lab2.Text = "z";
                            Controls.Add(lab2);

                            x += 30;
                        }
                        else
                        {
                            Label lab2 = new Label();
                            lab2.Location = new System.Drawing.Point(x, y);
                            lab2.Size = new System.Drawing.Size(20, 20);
                            lab2.Text = (string)string_c[i - 1];
                            Controls.Add(lab2);

                            x += 30;
                        }
                    }
                    else
                    {
                        Label lab2 = new Label();
                        lab2.Location = new System.Drawing.Point(x, y);
                        lab2.AutoSize = true;
                        //lab2.Size = new System.Drawing.Size(20, 20);
                        lab2.Text = matrix[i, j - 1].ToString();
                        Controls.Add(lab2);

                        x += 30;
                    }
                }
                y += 30;
                x = 0;
            }
        }

        bool IsOptimal()
        {
            for (int j = 0; j < number_of_constraints + number_of_variables + 1; j++)
            {
                if (matrix[0, j] < 0) return false;
            }
            return true;
        }

        int FindGuidingColumn()
        {
            double min = -0.000000000001;
            int num = 0;

            for (int j = 0; j < number_of_constraints + number_of_variables; j++)
            {
                if (matrix[0, j] < min)
                {
                    min = matrix[0, j];
                    num = j;
                }
            }
            return num;
        }

        int FindGuidingRow(int guidingColumn)
        {
            double min = int.MaxValue;
            int num = 0;

            for (int i = 1; i < number_of_constraints + 1; i++)
            {
                if (matrix[i, guidingColumn] > 0)
                {
                    if (matrix[i, number_of_constraints + number_of_variables] / matrix[i, guidingColumn] < min)
                    {
                        min = matrix[i, number_of_constraints + number_of_variables] / matrix[i, guidingColumn];
                        num = i;
                    }
                }
            }
            return num;
        }

        void MakeNewGuidingRow(int guidingRow, double guidingElement)
        {
            for (int j = 0; j < number_of_constraints + number_of_variables + 1; j++)
            {
                matrix[guidingRow, j] /= guidingElement;
            }
        }

        void RecalculationOfTable(int guiding_row, int guiding_column)
        {
            string_c[guiding_row - 1] = string_r[guiding_column];

            for (int i = 0; i < number_of_constraints + 1; i++)
            {
                if (matrix[i, guiding_column] != 0)
                {
                    if (i == guiding_row)
                    {
                        continue;
                    }

                    double[] row = new double[number_of_variables + number_of_constraints + 1];
                    for (int j = 0; j < number_of_variables + number_of_constraints + 1; j++)
                    {
                        row[j] = matrix[guiding_row, j];
                    }

                    for (int j = 0; j < number_of_variables + number_of_constraints + 1; j++)
                    {
                        row[j] *= matrix[i, guiding_column];
                    }

                    for (int j = 0; j < number_of_variables + number_of_constraints + 1; j++)
                    {
                        matrix[i, j] -= row[j];
                    }
                }
            }
        }
    }
}
