using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Candal.ValorCardinalPortugal _valorCardinalPortugal;

        public Form1()
        {
            InitializeComponent();
            _valorCardinalPortugal = new Candal.ValorCardinalPortugal();
        }

        private void textBoxValue_Enter(object sender, EventArgs e)
        {
            textBoxValue.Text = textBoxValue.Text.Replace(",", "").Replace("€", "").Trim();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            InfoStateChange(false);

            textBoxValue_Enter(sender, e);

            //decimal: max value =  79228162514264337593543950335
            //decimal: min value = -79228162514264337593543950335
            //after this value round decimal : 99999999999999999999999999.99

            decimal valor = 0;
            try
            {
                valor = Convert.ToDecimal(textBoxValue.Text);
                textBoxValue.Text = String.Format("{0, 10:#,##0.00} {1}", valor, "€");
                Application.DoEvents();
                textBoxDescr.Text = _valorCardinalPortugal.Converte(valor, true, true);
            }
            catch (System.Exception ex)
            {
                this.textBoxDescr.Text = ex.Message;
            }
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxValue.Focus();
        }

        bool infoIsDisplay = false;

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            InfoStateChange(true);
        }

        private void InfoStateChange(bool revert)
        {
            if (!revert)
            {
                this.groupBox1.Visible = false;
                infoIsDisplay = false;
                return;
            }

            if (infoIsDisplay)
                this.groupBox1.Visible = false;
            else
                this.groupBox1.Visible = true;

            infoIsDisplay = !infoIsDisplay;
        }
    }
}