namespace FarmOu.Forms
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
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

        private async void Form6_Load(
            object sender,
            EventArgs e)
        {
            var crops = await cropService.GetAllCrops();

            if (crops.Any())
            {
                this.textBox1.Text = string.Join(Environment.NewLine, crops.Select(c => $"{c.Name} - {c.XpPerHarvest} - {c.QuantityPerHarvest} - {c.OverallSold} - {c.OverallBought}"));
            }
            else
            {
                this.textBox1.Text = "No crops found.";
            }
        }
    }
}
