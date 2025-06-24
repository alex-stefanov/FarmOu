namespace FarmOu.Forms
{
    public partial class Form2
        : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void button1_Click(
            object sender,
            EventArgs e)
        {
            var farmer = await userService.LoginUserAsync(
                textBox1.Text,
                textBox2.Text);

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
                MessageBox.Show("Invalid credentials. Please try again.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();

            form1.Show();
            this.Hide();
        }
    }
}
