using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ИзменениеСтатуса : Form
    {
        string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=Отель;Integrated Security=True";

        public ИзменениеСтатуса()
        {
            InitializeComponent();
            // Вызываем метод FillEmployeesComboBox() при инициализации формы
            FillEmployeesComboBox();
        }

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Метод заполнения combobox2 данными из базы данных
        private void FillEmployeesComboBox()
        {
            comboBox2.Items.Clear(); // Очистка элементов combobox2 перед заполнением

            // Ваш SQL-запрос для получения ФИО сотрудников из базы данных
            string query = "SELECT Фамилия, Имя, Отчество FROM Пользователи";

            // Выполнение SQL-запроса и добавление ФИО в combobox2
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string lastName = reader["Фамилия"].ToString();
                    string firstName = reader["Имя"].ToString();
                    string middleName = reader["Отчество"].ToString();
                    string fullName = $"{lastName} {firstName} {middleName}";
                    comboBox2.Items.Add(fullName);
                }
            }
        }

        // Метод для загрузки текущего статуса выбранного сотрудника
        private void LoadEmployeeStatus()
        {
            // Проверяем, выбран ли какой-либо сотрудник в combobox2
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите сотрудника из списка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем выбранное ФИО сотрудника
            string selectedEmployeeFullName = comboBox2.SelectedItem.ToString();

            // Разделяем ФИО на части: фамилия, имя и отчество
            string[] parts = selectedEmployeeFullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3)
            {
                MessageBox.Show("Неверный формат ФИО выбранного сотрудника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string lastName = parts[0];
            string firstName = parts[1];
            string middleName = parts[2];

            // Ваш SQL-запрос для получения статуса сотрудника по ФИО из базы данных
            string query = "SELECT Статус FROM Пользователи WHERE Фамилия = @lastName AND Имя = @firstName AND Отчество = @middleName";

            // Выполнение SQL-запроса и загрузка статуса сотрудника
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@middleName", middleName);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    // Загружаем текущий статус сотрудника в combobox1
                    comboBox1.SelectedItem = result.ToString();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Загружаем текущий статус выбранного сотрудника
            LoadEmployeeStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, выбраны ли фамилия сотрудника и новый статус
            if (comboBox2.SelectedIndex == -1 || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите сотрудника и новый статус для обновления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем выбранную фамилию сотрудника и новый статус
            string selectedEmployeeFullName = comboBox2.SelectedItem.ToString();
            string selectedStatus = comboBox1.SelectedItem.ToString();

            // Разделяем ФИО на части: фамилия, имя и отчество
            string[] parts = selectedEmployeeFullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3)
            {
                MessageBox.Show("Неверный формат ФИО выбранного сотрудника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string lastName = parts[0];
            string firstName = parts[1];
            string middleName = parts[2];

            // SQL-запрос для обновления статуса сотрудника
            string query = "UPDATE Пользователи SET Статус = @status WHERE Фамилия = @lastName AND Имя = @firstName AND Отчество = @middleName";

            // Выполнение SQL-запроса и обновление статуса сотрудника
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", selectedStatus);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@middleName", middleName);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Статус сотрудника успешно обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Можно добавить здесь дополнительные действия, если нужно
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не удалось обновить статус сотрудника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ИзменениеСтатуса_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormPos = Location;
            }
        }

        private void ИзменениеСтатуса_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPos = Cursor.Position;
                int deltaX = currentCursorPos.X - lastCursorPos.X;
                int deltaY = currentCursorPos.Y - lastCursorPos.Y;
                Location = new Point(lastFormPos.X + deltaX, lastFormPos.Y + deltaY);
            }
        }

        private void ИзменениеСтатуса_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void ИзменениеСтатуса_Load(object sender, EventArgs e)
        {
            this.MouseDown += ИзменениеСтатуса_MouseDown;
            this.MouseMove += ИзменениеСтатуса_MouseMove;
            this.MouseUp += ИзменениеСтатуса_MouseUp;
        }
    }
}