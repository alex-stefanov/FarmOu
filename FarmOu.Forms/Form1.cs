namespace FarmOu.Forms
{
    public partial class Form1
        : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(
            object sender,
            EventArgs e)
        {
            var farmer = await userService.RegisterUserAsync(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text);

            if (farmer is not null)
            {
                var form3 = new Form3();

                form3.label6.Text = farmer.FirstName;
                form3.label7.Text = farmer.LastName;
                form3.label8.Text = farmer.Email;
                form3.label9.Text = farmer.UserName;
                form3.label10.Text = farmer.Id;

                form3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        private void button2_Click(
            object sender,
            EventArgs e)
        {
            var form2 = new Form2();

            form2.Show();
            this.Hide();
        }
    }
}
