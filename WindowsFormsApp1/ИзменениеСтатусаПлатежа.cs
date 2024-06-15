using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ИзменениеСтатусаПлатежа : Form
    {
        public ИзменениеСтатусаПлатежа()
        {
            InitializeComponent();
        }

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        private void button1_Click(object sender, EventArgs e)
        {
            string статусПлатежа = comboBox1.SelectedItem.ToString();
            string номерКомнаты = textBox5.Text;

            // Валидация номера комнаты: должны быть только цифры и от 1 до 3 символов
            if (!ValidateRoomNumber(номерКомнаты))
            {
                MessageBox.Show("Номер комнаты должен состоять только из цифр и содержать от 3 до 3 символов!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Прекращаем выполнение метода, чтобы не добавлять заказ
            }

            // SQL-запрос для вставки данных
            string query = "UPDATE Заказы SET СтатусПлатежа = @статусПлатежа WHERE НомерКомнаты = @номерКомнаты";

            // Строка подключения к базе данных
            string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=Отель;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавляем параметры для SQL-запроса
                        command.Parameters.AddWithValue("@статусПлатежа", статусПлатежа);
                        command.Parameters.AddWithValue("@номерКомнаты", номерКомнаты);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Статус успешно изменен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm(); // Очищаем форму после успешного добавления
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось изменить статус!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateRoomNumber(string roomNumber)
        {
            // Проверяем, что номер комнаты состоит только из цифр и содержит от 1 до 3 символов
            return Regex.IsMatch(roomNumber, @"^\d{3,3}$");
        }

        private void ClearForm()
        {
            comboBox1.SelectedIndex = 0;
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ИзменениеСтатусаПлатежа_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormPos = Location;
            }
        }

        private void ИзменениеСтатусаПлатежа_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPos = Cursor.Position;
                int deltaX = currentCursorPos.X - lastCursorPos.X;
                int deltaY = currentCursorPos.Y - lastCursorPos.Y;
                Location = new Point(lastFormPos.X + deltaX, lastFormPos.Y + deltaY);
            }
        }

        private void ИзменениеСтатусаПлатежа_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void ИзменениеСтатусаПлатежа_Load(object sender, EventArgs e)
        {
            this.MouseDown += ИзменениеСтатусаПлатежа_MouseDown;
            this.MouseMove += ИзменениеСтатусаПлатежа_MouseMove;
            this.MouseUp += ИзменениеСтатусаПлатежа_MouseUp;
        }
    }
}
