using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ПанельСотрудникаНомеров : Form
    {
        public ПанельСотрудникаНомеров()
        {
            InitializeComponent();
        }

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        private void ПанельСотрудникаНомеров_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "отельDataSet1.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this.отельDataSet1.Заказы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "отельDataSet1.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.отельDataSet1.Пользователи);

            this.MouseDown += ПанельСотрудникаНомеров_MouseDown;
            this.MouseMove += ПанельСотрудникаНомеров_MouseMove;
            this.MouseUp += ПанельСотрудникаНомеров_MouseUp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            СозданиеЗаказа frm4 = new СозданиеЗаказа();
            frm4.ShowDialog();
            this.заказыTableAdapter.Fill(this.отельDataSet1.Заказы);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ИзменениеСтатусаПлатежа frm5 = new ИзменениеСтатусаПлатежа();
            frm5.ShowDialog();
            this.заказыTableAdapter.Fill(this.отельDataSet1.Заказы);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Авторизация auth = new Авторизация(); // Создаем новый экземпляр формы Form1
            auth.Show(); // Открываем Form1
        }

        private void ПанельСотрудникаНомеров_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormPos = Location;
            }
        }

        private void ПанельСотрудникаНомеров_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPos = Cursor.Position;
                int deltaX = currentCursorPos.X - lastCursorPos.X;
                int deltaY = currentCursorPos.Y - lastCursorPos.Y;
                Location = new Point(lastFormPos.X + deltaX, lastFormPos.Y + deltaY);
            }
        }

        private void ПанельСотрудникаНомеров_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}
