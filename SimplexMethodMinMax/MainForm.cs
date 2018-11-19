using System;
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
    public partial class MainForm : Form
    {
        public int NumberOfVariables { get; set; }
        public int NumberOfConstraints { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NumberOfVariables = numberOfVariablesUpDown.SelectedIndex + 2;
                NumberOfConstraints = numberOfConstraintsUpDown.SelectedIndex + 2;

                if (NumberOfVariables < 2 || NumberOfConstraints < 2
                                          || NumberOfConstraints > 5
                                          || NumberOfVariables > 5)
                {
                    throw new Exception("Невірні початкові дані");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Close();
            }
        }
    }
}