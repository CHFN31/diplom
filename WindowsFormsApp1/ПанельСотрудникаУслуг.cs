using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ПанельСотрудникаУслуг : Form
    {
        public ПанельСотрудникаУслуг()
        {
            InitializeComponent();
        }

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        private void ПанельСотрудникаУслуг_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "отельDataSet1.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this.отельDataSet1.Заказы);

            this.MouseDown += ПанельСотрудникаУслуг_MouseDown;
            this.MouseMove += ПанельСотрудникаУслуг_MouseMove;
            this.MouseUp += ПанельСотрудникаУслуг_MouseUp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ИзменениеСтатусаЗаказа frm3 = new ИзменениеСтатусаЗаказа();
            frm3.ShowDialog();
            this.заказыTableAdapter.Fill(this.отельDataSet1.Заказы);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Авторизация auth = new Авторизация(); // Создаем новый экземпляр формы Form1
            auth.Show(); // Открываем Form1
        }

        private void ПанельСотрудникаУслуг_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormPos = Location;
            }
        }

        private void ПанельСотрудникаУслуг_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPos = Cursor.Position;
                int deltaX = currentCursorPos.X - lastCursorPos.X;
                int deltaY = currentCursorPos.Y - lastCursorPos.Y;
                Location = new Point(lastFormPos.X + deltaX, lastFormPos.Y + deltaY);
            }
        }

        private void ПанельСотрудникаУслуг_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}
