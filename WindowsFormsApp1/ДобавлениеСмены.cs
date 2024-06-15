using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ДобавлениеСмены : Form
    {
        string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=Отель;Integrated Security=True";

        public ДобавлениеСмены()
        {
            InitializeComponent();
            FillEmployeesComboBox();
        }

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        private void FillEmployeesComboBox()
        {
            comboBox1.Items.Clear();

            string query = "SELECT Фамилия, Имя, Отчество FROM Пользователи";

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
                    comboBox1.Items.Add(fullName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string employeeFullName = comboBox1.SelectedItem.ToString();
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            if (startDate >= endDate)
            {
                MessageBox.Show("Дата начала смены должна быть раньше даты конца смены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO Смена (ФИОСотрудника, НачалоДаты, КонецДаты) VALUES (@fullName, @startDate, @endDate)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fullName", employeeFullName);
                        command.Parameters.AddWithValue("@startDate", startDate);
                        command.Parameters.AddWithValue("@endDate", endDate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Смена успешно назначена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось назначить смену!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ДобавлениеСмены_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormPos = Location;
            }
        }

        private void ДобавлениеСмены_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPos = Cursor.Position;
                int deltaX = currentCursorPos.X - lastCursorPos.X;
                int deltaY = currentCursorPos.Y - lastCursorPos.Y;
                Location = new Point(lastFormPos.X + deltaX, lastFormPos.Y + deltaY);
            }
        }

        private void ДобавлениеСмены_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void ДобавлениеСмены_Load(object sender, EventArgs e)
        {
            this.MouseDown += ДобавлениеСмены_MouseDown;
            this.MouseMove += ДобавлениеСмены_MouseMove;
            this.MouseUp += ДобавлениеСмены_MouseUp;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            if (comboBox1.SelectedItem != null)
            {
                // Установить доступность остальных ComboBox'ов в значение false
                comboBox2.Enabled = false;
            }
            else
            {
                // Восстановить доступность остальных ComboBox'ов
                comboBox2.Enabled = true;
            }

            if (comboBox1.SelectedItem != null)
            {
                string fullName = comboBox1.SelectedItem.ToString();

                string query = @"SELECT rp.НазваниеРоли 
                                FROM Пользователи p
                                JOIN РольПользователя rp ON p.РольПользователя = rp.ИдентификаторРолиПользователей
                                WHERE CONCAT(p.Фамилия, ' ', p.Имя, ' ', p.Отчество) = @FullName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        comboBox2.Items.Add(reader["НазваниеРоли"].ToString());
                        comboBox2.SelectedIndex = 0; // Автоматически выбираем добавленный элемент
                    }
                }
            }
        }
    }
}