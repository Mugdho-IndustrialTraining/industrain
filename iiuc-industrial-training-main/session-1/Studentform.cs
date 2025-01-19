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
        LoadCourses();
    }

    private void LoadStudents(string searchQuery = "")
    {
        dataGridViewStudents.DataSource = db.GetStudents(searchQuery);
    }

    private void LoadCourses()
    {
        comboBoxCourse.DataSource = db.GetCourses();
        comboBoxCourse.DisplayMember = "CourseName";
        comboBoxCourse.ValueMember = "CourseID";
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            db.AddStudent(txtFirstName.Text, txtLastName.Text, int.Parse(txtAge.Text), comboBoxGender.Text, comboBoxCourse.Text);
            MessageBox.Show("Student added successfully!");
            LoadStudents();
            ClearForm();
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ValidateInput() && int.TryParse(txtStudentID.Text, out int id))
        {
            db.UpdateStudent(id, txtFirstName.Text, txtLastName.Text, int.Parse(txtAge.Text), comboBoxGender.Text, comboBoxCourse.Text);
            MessageBox.Show("Student updated successfully!");
            LoadStudents();
            ClearForm();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (int.TryParse(txtStudentID.Text, out int id))
        {
            db.DeleteStudent(id);
            MessageBox.Show("Student deleted successfully!");
            LoadStudents();
            ClearForm();
        }
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        LoadStudents(txtSearch.Text);
    }

    private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dataGridViewStudents.Rows[e.RowIndex];
            txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
            txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
            txtLastName.Text = row.Cells["LastName"].Value.ToString();
            txtAge.Text = row.Cells["Age"].Value.ToString();
            comboBoxGender.Text = row.Cells["Gender"].Value.ToString();
            comboBoxCourse.Text = row.Cells["Course"].Value.ToString();
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || 
            string.IsNullOrEmpty(txtAge.Text) || string.IsNullOrEmpty(comboBoxGender.Text) || 
            string.IsNullOrEmpty(comboBoxCourse.Text))
        {
            MessageBox.Show("All fields are required!");
            return false;
        }

        if (!int.TryParse(txtAge.Text, out _))
        {
            MessageBox.Show("Age must be a number!");
            return false;
        }

        return true;
    }

    private void ClearForm()
    {
        txtStudentID.Clear();
        txtFirstName.Clear();
        txtLastName.Clear();
        txtAge.Clear();
        comboBoxGender.SelectedIndex = -1;
        comboBoxCourse.SelectedIndex = -1;
    }
}
