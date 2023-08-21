using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace IACounties
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FillComboBox1();
            FillComboBox2();
        }

        private void FillComboBox1()
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IACounties;Integrated Security=True";
            using (SqlConnection sql = new SqlConnection(constr))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("getCountyNames", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow dr = dt.NewRow();
                dr[0] = ("Please Select");
                dt.Rows.InsertAt(dr, 0);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "countyName";

            }
        }

        private void FillComboBox2()
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IACounties;Integrated Security=True";
            using (SqlConnection sql = new SqlConnection(constr))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("getCountyNames", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow dr = dt.NewRow();
                dr[0] = ("Please Select");
                dt.Rows.InsertAt(dr, 0);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "countyName";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Please Select")
            {
                MessageBox.Show("Please select a county in the first box.", "County Box Empty",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox2.Text == "Please Select")
            {
                MessageBox.Show("Please select a county in the second box.", "County Box Empty",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (AdjacencyCheck() == true)
            {
                label1.Visible = true;
                label2.Visible = false;
            }
            else
            {
                label1.Visible = false;
                label2.Visible = true;
            }

        }

        private bool AdjacencyCheck()
        {


            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IACounties;Integrated Security=True";
            using (SqlConnection sql = new SqlConnection(constr))
            {

                sql.Open();
                SqlCommand cmd = new SqlCommand("getCountyMapIds", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@comboBox1Text", comboBox1.Text);
                cmd.Parameters.AddWithValue("@comboBox2Text", comboBox2.Text);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView1.DataSource = dt;

                var cb1MapId = dataGridView1[0, 0].Value.ToString();
                var cb2MapId = dataGridView1[0, 1].Value.ToString();

                Debug.WriteLine($"ComboBox1 MapId is {cb1MapId} and Combobox2 MapId is {cb2MapId}");

                SqlCommand cmd2 = new SqlCommand("checkAdjacency", sql);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@comboBox1MapId", cb1MapId);
                cmd2.Parameters.AddWithValue("@comboBox2MapId", cb2MapId);
                cmd2.ExecuteNonQuery();
                if ((string)cmd2.ExecuteScalar() != null)
                {
                    return true;
                }

            }

            return false;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}