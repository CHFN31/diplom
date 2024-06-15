using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ДобавлениеСотрудника : Form
    {
        public ДобавлениеСотрудника()
        {
            InitializeComponent();
        }

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        private void button2_Click(object sender, EventArgs e)
        {
            string generatedPassword = GeneratePassword(10);
            textBox1.Text = generatedPassword;
        }

        private string GeneratePassword(int length)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(validChars[random.Next(validChars.Length)]);
            }

            return result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Строка подключения к базе данных
            string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=Отель;Integrated Security=True";

            // Получаем данные из текстовых полей
            string login = textBox5.Text.ToLower();
            string password = textBox1.Text;
            string lastName = textBox2.Text;
            string firstName = textBox6.Text;
            string middleName = textBox4.Text;
            string role = comboBox1.Text;

            // Проверка на использование только английских букв
            if (!Regex.IsMatch(login, @"^[a-z0-9]+$"))
            {
                MessageBox.Show("Логин должен содержать только английские буквы и цифры, и быть в нижнем регистре!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем длину пароля
            if (password.Length < 12)
            {
                MessageBox.Show("Пароль должен содержать не менее 12 символов!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка пароля на наличие цифры, заглавной буквы и специального символа
            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну цифру!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну букву в верхнем регистре!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]"))
            {
                MessageBox.Show("Пароль должен содержать хотя бы один специальный символ!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateRussianName(lastName))
            {
                MessageBox.Show("Фамилия должна содержать только русские буквы и не содержать цифр!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateRussianName(firstName))
            {
                MessageBox.Show("Имя должно содержать только русские буквы и не содержать цифр!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateRussianName(middleName))
            {
                MessageBox.Show("Отчество должно содержать только русские буквы и не содержать цифр!", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Преобразование текстовой роли в числовое представление
            int roleId;
            switch (role)
            {
                case "Менеджер":
                    roleId = 2;
                    break;
                case "Сотрудник предоставление услуг отеля":
                    roleId = 3;
                    break;
                case "Сотрудник обслуживания номеров":
                    roleId = 1;
                    break;
                default:
                    MessageBox.Show("Выбранная роль не распознана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // SQL-запрос для вставки данных
            string query = "INSERT INTO Пользователи (Логин, Пароль, Фамилия, Имя, Отчество, РольПользователя, Статус) " +
                           "VALUES (@логин, @пароль, @фамилия, @имя, @отчество, @рольпользователя, @статус)";

            // Открываем соединение и выполняем запрос
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Параметры SQL-запроса
                        command.Parameters.AddWithValue("@логин", login);
                        command.Parameters.AddWithValue("@пароль", password);
                        command.Parameters.AddWithValue("@статус", "Работает"); // Установка значения "Работает" для столбца "Статус"
                        command.Parameters.AddWithValue("@фамилия", lastName);
                        command.Parameters.AddWithValue("@имя", firstName);
                        command.Parameters.AddWithValue("@отчество", middleName);
                        command.Parameters.AddWithValue("@рольпользователя", roleId);

                        // Выполняем запрос
                        int rowsAffected = command.ExecuteNonQuery();

                        // Проверяем, были ли вставлены данные
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Сотрудник успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm(); // Использование метода для очистки формы
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить сотрудника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обрабатываем ошибки
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidateLogin(string login)
        {
            // Проверяем, что логин содержит от 6 до 12 символов и состоит только из английских букв и цифр
            return Regex.IsMatch(login, "^[a-zA-Z0-9]{6,12}$");
        }

        private bool ValidatePassword(string password)
        {
            // Проверяем, что пароль содержит от 6 до 10 символов и состоит только из латинских букв и цифр
            return password.Length >= 6 && Regex.IsMatch(password, "^[a-zA-Z0-9]{6,12}$");
        }

        private bool ValidateRussianName(string name)
        {
            // Проверяем, что имя содержит только русские буквы и не содержит цифр
            return Regex.IsMatch(name, "^[А-Яа-яЁё]+$");
        }

        private void ClearForm()
        {
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox6.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void ДобавлениеСотрудника_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormPos = Location;
            }
        }

        private void ДобавлениеСотрудника_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPos = Cursor.Position;
                int deltaX = currentCursorPos.X - lastCursorPos.X;
                int deltaY = currentCursorPos.Y - lastCursorPos.Y;
                Location = new Point(lastFormPos.X + deltaX, lastFormPos.Y + deltaY);
            }
        }

        private void ДобавлениеСотрудника_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void ДобавлениеСотрудника_Load(object sender, EventArgs e)
        {
            this.MouseDown += ДобавлениеСотрудника_MouseDown;
            this.MouseMove += ДобавлениеСотрудника_MouseMove;
            this.MouseUp += ДобавлениеСотрудника_MouseUp;
        }
    }
}