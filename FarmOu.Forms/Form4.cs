namespace FarmOu.Forms
{
    public partial class Form4
        : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private async void Form4_Load(
            object sender,
            EventArgs e)
        {
            var tools = await toolService.GetAllFarmerTools(
                this.label2.Text);

            if (tools.Any())
            {
                this.textBox1.Text = string.Join(Environment.NewLine, tools.Select(t => $"{t.Name} - {t.Rarity.ToString()}"));
            }
            else
            {
                this.textBox1.Text = "No tools found for this farmer.";
            }
        }

        private void button1_Click(
            object sender,
            EventArgs e)
        {
            var form3 = new Form3();

            form3.label10.Text = this.label2.Text;

            form3.Show();
            this.Hide();
        }

        private void button2_Click(
            object sender,
            EventArgs e)
        {
            var form5 = new Form5();

            form5.label2.Text = this.label2.Text;

            form5.Show();
            this.Hide();
        }
    }
}
