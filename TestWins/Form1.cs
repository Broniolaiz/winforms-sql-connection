using System.Drawing.Text;
using TestWins.Controller;
using TestWins.Model;

namespace TestWins;

public partial class Form1 : Form
{
    //business

    private readonly StudentController controller = new StudentController();

    public Form1()
    {
        InitializeComponent();

    private void loadData()
    {
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = controller.getAll();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Student s = new Student
            {
                Name = txtName.Text,
                age = int.Parse(txtAge.Text),
                course = txtCourse.Text
            };

            controller.createStudent(s);
            loadData();
            clearFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Student s = new Student
            {
                studentId = txtStudentId.Text,
                Name = txtName.Text,
                age = int.Parse(txtAge.Text),
                course = txtCourse.Text
            };

            controller.update(s);
            loadData();
            clearFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Update Error: " + ex.Message);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            controller.delete(txtStudentId.Text);
            loadData();
            clearFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Delete Error: " + ex.Message);
        }
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            var row = dataGridView1.Rows[e.RowIndex];


            txtStudentId.Text = row.Cells["studentId"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtAge.Text = row.Cells["age"].Value.ToString();
            txtCourse.Text = row.Cells["course"].Value.ToString();
        }
    }

    private void dataGridView1_CellClick(object sender, EventArgs e)
    private void clearFields()
    {

        txtStudentId.Text = "";
        txtName.Text = "";
        txtAge.Text = "";
        txtCourse.Text = "";
    }
}
