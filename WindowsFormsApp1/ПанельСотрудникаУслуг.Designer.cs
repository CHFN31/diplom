namespace WindowsFormsApp1
{
    partial class ПанельСотрудникаУслуг
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ПанельСотрудникаУслуг));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.идентификаторЗаказаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаСозданияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.статусЗаказаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.статусПлатежаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.номерКомнатыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.гостиничныеУслугиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоКлиентовDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.заказыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.отельDataSet1 = new WindowsFormsApp1.ОтельDataSet1();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.отельDataSet = new WindowsFormsApp1.ОтельDataSet();
            this.orderTableAdapter = new WindowsFormsApp1.ОтельDataSetTableAdapters.orderTableAdapter();
            this.заказыTableAdapter = new WindowsFormsApp1.ОтельDataSet1TableAdapters.ЗаказыTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.заказыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.отельDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.отельDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(925, 496);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(917, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Заказы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(8, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 45);
            this.button1.TabIndex = 18;
            this.button1.Text = "Изменить статус";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.идентификаторЗаказаDataGridViewTextBoxColumn,
            this.датаСозданияDataGridViewTextBoxColumn,
            this.статусЗаказаDataGridViewTextBoxColumn,
            this.статусПлатежаDataGridViewTextBoxColumn,
            this.номерКомнатыDataGridViewTextBoxColumn,
            this.гостиничныеУслугиDataGridViewTextBoxColumn,
            this.количествоКлиентовDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.заказыBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(8, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(900, 356);
            this.dataGridView1.TabIndex = 0;
            // 
            // идентификаторЗаказаDataGridViewTextBoxColumn
            // 
            this.идентификаторЗаказаDataGridViewTextBoxColumn.DataPropertyName = "ИдентификаторЗаказа";
            this.идентификаторЗаказаDataGridViewTextBoxColumn.HeaderText = "ИдентификаторЗаказа";
            this.идентификаторЗаказаDataGridViewTextBoxColumn.Name = "идентификаторЗаказаDataGridViewTextBoxColumn";
            this.идентификаторЗаказаDataGridViewTextBoxColumn.ReadOnly = true;
            this.идентификаторЗаказаDataGridViewTextBoxColumn.Width = 197;
            // 
            // датаСозданияDataGridViewTextBoxColumn
            // 
            this.датаСозданияDataGridViewTextBoxColumn.DataPropertyName = "ДатаСоздания";
            this.датаСозданияDataGridViewTextBoxColumn.HeaderText = "ДатаСоздания";
            this.датаСозданияDataGridViewTextBoxColumn.Name = "датаСозданияDataGridViewTextBoxColumn";
            this.датаСозданияDataGridViewTextBoxColumn.Width = 137;
            // 
            // статусЗаказаDataGridViewTextBoxColumn
            // 
            this.статусЗаказаDataGridViewTextBoxColumn.DataPropertyName = "СтатусЗаказа";
            this.статусЗаказаDataGridViewTextBoxColumn.HeaderText = "СтатусЗаказа";
            this.статусЗаказаDataGridViewTextBoxColumn.Name = "статусЗаказаDataGridViewTextBoxColumn";
            this.статусЗаказаDataGridViewTextBoxColumn.Width = 131;
            // 
            // статусПлатежаDataGridViewTextBoxColumn
            // 
            this.статусПлатежаDataGridViewTextBoxColumn.DataPropertyName = "СтатусПлатежа";
            this.статусПлатежаDataGridViewTextBoxColumn.HeaderText = "СтатусПлатежа";
            this.статусПлатежаDataGridViewTextBoxColumn.Name = "статусПлатежаDataGridViewTextBoxColumn";
            this.статусПлатежаDataGridViewTextBoxColumn.Width = 149;
            // 
            // номерКомнатыDataGridViewTextBoxColumn
            // 
            this.номерКомнатыDataGridViewTextBoxColumn.DataPropertyName = "НомерКомнаты";
            this.номерКомнатыDataGridViewTextBoxColumn.HeaderText = "НомерКомнаты";
            this.номерКомнатыDataGridViewTextBoxColumn.Name = "номерКомнатыDataGridViewTextBoxColumn";
            this.номерКомнатыDataGridViewTextBoxColumn.Width = 149;
            // 
            // гостиничныеУслугиDataGridViewTextBoxColumn
            // 
            this.гостиничныеУслугиDataGridViewTextBoxColumn.DataPropertyName = "ГостиничныеУслуги";
            this.гостиничныеУслугиDataGridViewTextBoxColumn.HeaderText = "ГостиничныеУслуги";
            this.гостиничныеУслугиDataGridViewTextBoxColumn.Name = "гостиничныеУслугиDataGridViewTextBoxColumn";
            this.гостиничныеУслугиDataGridViewTextBoxColumn.Width = 182;
            // 
            // количествоКлиентовDataGridViewTextBoxColumn
            // 
            this.количествоКлиентовDataGridViewTextBoxColumn.DataPropertyName = "КоличествоКлиентов";
            this.количествоКлиентовDataGridViewTextBoxColumn.HeaderText = "КоличествоКлиентов";
            this.количествоКлиентовDataGridViewTextBoxColumn.Name = "количествоКлиентовDataGridViewTextBoxColumn";
            this.количествоКлиентовDataGridViewTextBoxColumn.Width = 192;
            // 
            // заказыBindingSource
            // 
            this.заказыBindingSource.DataMember = "Заказы";
            this.заказыBindingSource.DataSource = this.отельDataSet1;
            // 
            // отельDataSet1
            // 
            this.отельDataSet1.DataSetName = "ОтельDataSet1";
            this.отельDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataMember = "order";
            this.orderBindingSource.DataSource = this.отельDataSet;
            // 
            // отельDataSet
            // 
            this.отельDataSet.DataSetName = "ОтельDataSet";
            this.отельDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // orderTableAdapter
            // 
            this.orderTableAdapter.ClearBeforeFill = true;
            // 
            // заказыTableAdapter
            // 
            this.заказыTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.RosyBrown;
            this.label1.Font = new System.Drawing.Font("Trajan Pro 3", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(502, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Панель сотрудника предоставления услуг отеля";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(891, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 22;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(822, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Ordering_25406.png");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(10, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(45, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "Поиск:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(267, 26);
            this.textBox1.TabIndex = 24;
            // 
            // ПанельСотрудникаУслуг
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 538);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ПанельСотрудникаУслуг";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отель - Панель сотрудника предоставляющий услуги";
            this.Load += new System.EventHandler(this.ПанельСотрудникаУслуг_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ПанельСотрудникаУслуг_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ПанельСотрудникаУслуг_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ПанельСотрудникаУслуг_MouseUp);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.заказыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.отельDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.отельDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ОтельDataSet отельDataSet;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private ОтельDataSetTableAdapters.orderTableAdapter orderTableAdapter;
        private System.Windows.Forms.Button button1;
        private ОтельDataSet1 отельDataSet1;
        private System.Windows.Forms.BindingSource заказыBindingSource;
        private ОтельDataSet1TableAdapters.ЗаказыTableAdapter заказыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn идентификаторЗаказаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаСозданияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусЗаказаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусПлатежаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерКомнатыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn гостиничныеУслугиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоКлиентовDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}