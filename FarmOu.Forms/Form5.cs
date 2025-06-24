namespace FarmOu.Forms
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private async void Form5_Load(
            object sender,
            EventArgs e)
        {
            var tools = await toolService.GetAllTools();

            if (tools.Any())
            {
                this.textBox1.Text = string.Join(Environment.NewLine, tools.Select(t => $"{t.Name} - {t.Rarity.ToString()}"));
            }
            else
            {
                this.textBox1.Text = "No tools found.";
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
    }
}
