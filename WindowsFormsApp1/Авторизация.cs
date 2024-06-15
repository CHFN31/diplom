using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks; // Для выполнения задач асинхронно
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        private async void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-N1NJK31;Initial Catalog=Отель;Integrated Security=True";
            string username = textBox1.Text.ToLower(); // Приведение логина к нижнему регистру
            string password = textBox2.Text;

            // Проверка на использование только английских букв
            if (!Regex.IsMatch(username, @"^[a-z0-9]+$"))
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

            string query = @"SELECT p.*, rp.НазваниеРоли
                     FROM Пользователи p
                     JOIN РольПользователя rp ON p.РольПользователя = rp.ИдентификаторРолиПользователей
                     WHERE p.Логин = @username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(new SqlParameter("@username", username));
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["Пароль"].ToString();

                        if (password == storedPassword)
                        {
                            string role = reader["НазваниеРоли"].ToString();
                            Form nextForm = null;

                            switch (role)
                            {
                                case "Менеджер":
                                    nextForm = new ПанельМенеджера();
                                    break;
                                case "Сотрудник услуг":
                                    nextForm = new ПанельСотрудникаУслуг();
                                    break;
                                case "Сотрудник номеров":
                                    nextForm = new ПанельСотрудникаНомеров();
                                    break;
                                default:
                                    MessageBox.Show("Неизвестная роль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                            }

                            MessageBox.Show($"Вы успешно вошли! Ваша роль: {role}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Показать форму загрузки
                            ЗагрузкаАвторизации loadingForm = new ЗагрузкаАвторизации();
                            loadingForm.Show();

                            // Выполнить задачу асинхронно
                            await Task.Run(() =>
                            {
                                // Имитируем длительную операцию
                                System.Threading.Thread.Sleep(3000);
                            });

                            // Закрыть форму загрузки
                            loadingForm.Close();

                            // Показать следующую форму
                            nextForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неправильное имя пользователя или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
            pictureBox3.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void Авторизация_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormPos = Location;
            }
        }

        private void Авторизация_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPos = Cursor.Position;
                int deltaX = currentCursorPos.X - lastCursorPos.X;
                int deltaY = currentCursorPos.Y - lastCursorPos.Y;
                Location = new Point(lastFormPos.X + deltaX, lastFormPos.Y + deltaY);
            }
        }

        private void Авторизация_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void Авторизация_Load(object sender, EventArgs e)
        {
            this.MouseDown += Авторизация_MouseDown;
            this.MouseMove += Авторизация_MouseMove;
            this.MouseUp += Авторизация_MouseUp;
        }
    }
}
