using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ПанельМенеджера : Form
    {
        public ПанельМенеджера()
        {
            InitializeComponent();
        }

        private void ПанельМенеджера_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "отельDataSet1.Смена". При необходимости она может быть перемещена или удалена.
            this.сменаTableAdapter.Fill(this.отельDataSet1.Смена);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "отельDataSet1.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this.отельDataSet1.Заказы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "отельDataSet1.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.отельDataSet1.Пользователи);

            this.MouseDown += ПанельМенеджера_MouseDown;
            this.MouseMove += ПанельМенеджера_MouseMove;
            this.MouseUp += ПанельМенеджера_MouseUp;
        }

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        private void button2_Click(object sender, EventArgs e)
        {
            ДобавлениеСотрудника frm2 = new ДобавлениеСотрудника();
            frm2.ShowDialog();
            this.пользователиTableAdapter.Fill(this.отельDataSet1.Пользователи);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            СозданиеЗаказа frm4 = new СозданиеЗаказа();
            frm4.ShowDialog();
            this.заказыTableAdapter.Fill(this.отельDataSet1.Заказы);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ИзменениеСтатусаЗаказа frm5 = new ИзменениеСтатусаЗаказа();
            frm5.ShowDialog();
            this.заказыTableAdapter.Fill(this.отельDataSet1.Заказы);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ДобавлениеСмены frm6 = new ДобавлениеСмены();
            frm6.ShowDialog();
            this.сменаTableAdapter.Fill(this.отельDataSet1.Смена);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Авторизация auth = new Авторизация(); // Создаем новый экземпляр формы Form1
            auth.Show(); // Открываем Form1
        }

        private void ПанельМенеджера_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormPos = Location;
            }
        }

        private void ПанельМенеджера_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPos = Cursor.Position;
                int deltaX = currentCursorPos.X - lastCursorPos.X;
                int deltaY = currentCursorPos.Y - lastCursorPos.Y;
                Location = new Point(lastFormPos.X + deltaX, lastFormPos.Y + deltaY);
            }
        }

        private void ПанельМенеджера_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ИзменениеСтатуса frm3 = new ИзменениеСтатуса();
            frm3.ShowDialog();
            this.пользователиTableAdapter.Fill(this.отельDataSet1.Пользователи);
        }
    }
}
