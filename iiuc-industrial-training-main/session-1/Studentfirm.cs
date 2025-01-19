using System;
using System.Data;
using System.Windows.Forms;

public partial class StudentForm : Form
{
    private StudentDatabase db = new StudentDatabase();

    public StudentForm()
    {
        InitializeComponent();
        LoadStudents();
    }

    private void LoadStudents()
    {
        dataGridView1.DataSource = db.GetStudents();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        db.AddStudent(txtFirstName.Text, txtLastName.Text, int.Parse(txtAge.Text), cmbGender.Text, txtCourse.Text);
        MessageBox.Show("Student added successfully!");
        LoadStudents();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        int id = int.Parse(txtStudentID.Text);
        db.UpdateStudent(id, txtFirstName.Text, txtLastName.Text, int.Parse(txtAge.Text), cmbGender.Text, txtCourse.Text);
        MessageBox.Show("Student updated successfully!");
        LoadStudents();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse(txtStudentID.Text);
        db.DeleteStudent(id);
        MessageBox.Show("Student deleted successfully!");
        LoadStudents();
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
            txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
            txtLastName.Text = row.Cells["LastName"].Value.ToString();
            txtAge.Text = row.Cells["Age"].Value.ToString();
            cmbGender.Text = row.Cells["Gender"].Value.ToString();
            txtCourse.Text = row.Cells["Course"].Value.ToString();
        }
    }
}
