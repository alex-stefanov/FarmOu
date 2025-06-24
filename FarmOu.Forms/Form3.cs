namespace FarmOu.Forms
{
    public partial class Form3
        : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            var form4 = new Form4();

            form4.label2.Text = this.label10.Text;

            form4.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            var form6 = new Form6();

            form6.label2.Text = this.label10.Text;

            form6.Show();
            this.Hide();
        }
    }
}
