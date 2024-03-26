namespace ExamSystem_Project.Forms
{
    partial class TeacherForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            button_createExam = new Button();
            dataGridView_teacherExams = new DataGridView();
            examIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            examStrIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            examTitleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            examDateTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            teacherFullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalHoursDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalMinutesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            randomQuestionOrderDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            courseTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ShowExam = new DataGridViewButtonColumn();
            ExamStatistics = new DataGridViewButtonColumn();
            examBindingSource = new BindingSource(components);
            textBox_filter = new TextBox();
            label_searchExam = new Label();
            panel4 = new Panel();
            button_Logout = new Button();
            label11 = new Label();
            button_delete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_teacherExams).BeginInit();
            ((System.ComponentModel.ISupportInitialize)examBindingSource).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // button_createExam
            // 
            button_createExam.BackColor = Color.FromArgb(0, 135, 209);
            button_createExam.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button_createExam.ForeColor = Color.White;
            button_createExam.Location = new Point(72, 162);
            button_createExam.Margin = new Padding(4);
            button_createExam.Name = "button_createExam";
            button_createExam.Size = new Size(240, 85);
            button_createExam.TabIndex = 0;
            button_createExam.Text = "Create Exam";
            button_createExam.UseVisualStyleBackColor = false;
            button_createExam.Click += button_createExam_Click;
            // 
            // dataGridView_teacherExams
            // 
            dataGridView_teacherExams.AutoGenerateColumns = false;
            dataGridView_teacherExams.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 135, 209);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 135, 209);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView_teacherExams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_teacherExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_teacherExams.Columns.AddRange(new DataGridViewColumn[] { examIdDataGridViewTextBoxColumn, examStrIdDataGridViewTextBoxColumn, examTitleDataGridViewTextBoxColumn, examDateTimeDataGridViewTextBoxColumn, teacherFullNameDataGridViewTextBoxColumn, totalHoursDataGridViewTextBoxColumn, totalMinutesDataGridViewTextBoxColumn, randomQuestionOrderDataGridViewCheckBoxColumn, courseTypeDataGridViewTextBoxColumn, ShowExam, ExamStatistics });
            dataGridView_teacherExams.DataSource = examBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView_teacherExams.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView_teacherExams.EnableHeadersVisualStyles = false;
            dataGridView_teacherExams.Location = new Point(72, 419);
            dataGridView_teacherExams.Margin = new Padding(4, 2, 4, 2);
            dataGridView_teacherExams.Name = "dataGridView_teacherExams";
            dataGridView_teacherExams.RowHeadersWidth = 51;
            dataGridView_teacherExams.RowTemplate.Height = 29;
            dataGridView_teacherExams.ScrollBars = ScrollBars.Vertical;
            dataGridView_teacherExams.Size = new Size(1584, 559);
            dataGridView_teacherExams.TabIndex = 5;
            dataGridView_teacherExams.CellClick += dataGridView_teacherExams_CellClick;
            dataGridView_teacherExams.SelectionChanged += dataGridView_teacherExams_SelectionChanged;
            // 
            // examIdDataGridViewTextBoxColumn
            // 
            examIdDataGridViewTextBoxColumn.DataPropertyName = "ExamId";
            examIdDataGridViewTextBoxColumn.HeaderText = "ExamId";
            examIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            examIdDataGridViewTextBoxColumn.Name = "examIdDataGridViewTextBoxColumn";
            examIdDataGridViewTextBoxColumn.Visible = false;
            examIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // examStrIdDataGridViewTextBoxColumn
            // 
            examStrIdDataGridViewTextBoxColumn.DataPropertyName = "ExamStrId";
            examStrIdDataGridViewTextBoxColumn.HeaderText = "ExamStrId";
            examStrIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            examStrIdDataGridViewTextBoxColumn.Name = "examStrIdDataGridViewTextBoxColumn";
            examStrIdDataGridViewTextBoxColumn.Visible = false;
            examStrIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // examTitleDataGridViewTextBoxColumn
            // 
            examTitleDataGridViewTextBoxColumn.DataPropertyName = "ExamTitle";
            examTitleDataGridViewTextBoxColumn.HeaderText = "Exam Title";
            examTitleDataGridViewTextBoxColumn.MinimumWidth = 8;
            examTitleDataGridViewTextBoxColumn.Name = "examTitleDataGridViewTextBoxColumn";
            examTitleDataGridViewTextBoxColumn.Width = 200;
            // 
            // examDateTimeDataGridViewTextBoxColumn
            // 
            examDateTimeDataGridViewTextBoxColumn.DataPropertyName = "ExamDateTime";
            examDateTimeDataGridViewTextBoxColumn.HeaderText = "Exam Date";
            examDateTimeDataGridViewTextBoxColumn.MinimumWidth = 8;
            examDateTimeDataGridViewTextBoxColumn.Name = "examDateTimeDataGridViewTextBoxColumn";
            examDateTimeDataGridViewTextBoxColumn.Width = 180;
            // 
            // teacherFullNameDataGridViewTextBoxColumn
            // 
            teacherFullNameDataGridViewTextBoxColumn.DataPropertyName = "TeacherFullName";
            teacherFullNameDataGridViewTextBoxColumn.HeaderText = "Teacher Name";
            teacherFullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            teacherFullNameDataGridViewTextBoxColumn.Name = "teacherFullNameDataGridViewTextBoxColumn";
            teacherFullNameDataGridViewTextBoxColumn.Width = 170;
            // 
            // totalHoursDataGridViewTextBoxColumn
            // 
            totalHoursDataGridViewTextBoxColumn.DataPropertyName = "TotalHours";
            totalHoursDataGridViewTextBoxColumn.HeaderText = "Total Hours";
            totalHoursDataGridViewTextBoxColumn.MinimumWidth = 8;
            totalHoursDataGridViewTextBoxColumn.Name = "totalHoursDataGridViewTextBoxColumn";
            totalHoursDataGridViewTextBoxColumn.Width = 140;
            // 
            // totalMinutesDataGridViewTextBoxColumn
            // 
            totalMinutesDataGridViewTextBoxColumn.DataPropertyName = "TotalMinutes";
            totalMinutesDataGridViewTextBoxColumn.HeaderText = "Total Minutes";
            totalMinutesDataGridViewTextBoxColumn.MinimumWidth = 8;
            totalMinutesDataGridViewTextBoxColumn.Name = "totalMinutesDataGridViewTextBoxColumn";
            totalMinutesDataGridViewTextBoxColumn.Width = 150;
            // 
            // randomQuestionOrderDataGridViewCheckBoxColumn
            // 
            randomQuestionOrderDataGridViewCheckBoxColumn.DataPropertyName = "RandomQuestionOrder";
            randomQuestionOrderDataGridViewCheckBoxColumn.HeaderText = "Random Question Order";
            randomQuestionOrderDataGridViewCheckBoxColumn.MinimumWidth = 8;
            randomQuestionOrderDataGridViewCheckBoxColumn.Name = "randomQuestionOrderDataGridViewCheckBoxColumn";
            randomQuestionOrderDataGridViewCheckBoxColumn.Width = 250;
            // 
            // courseTypeDataGridViewTextBoxColumn
            // 
            courseTypeDataGridViewTextBoxColumn.DataPropertyName = "CourseType";
            courseTypeDataGridViewTextBoxColumn.HeaderText = "CourseType";
            courseTypeDataGridViewTextBoxColumn.MinimumWidth = 8;
            courseTypeDataGridViewTextBoxColumn.Name = "courseTypeDataGridViewTextBoxColumn";
            courseTypeDataGridViewTextBoxColumn.Width = 150;
            // 
            // ShowExam
            // 
            ShowExam.HeaderText = "Edit Exam";
            ShowExam.MinimumWidth = 8;
            ShowExam.Name = "ShowExam";
            ShowExam.Text = "Open";
            ShowExam.UseColumnTextForButtonValue = true;
            ShowExam.Width = 140;
            // 
            // ExamStatistics
            // 
            ExamStatistics.HeaderText = "Exam Statistics";
            ExamStatistics.MinimumWidth = 8;
            ExamStatistics.Name = "ExamStatistics";
            ExamStatistics.Text = "Open";
            ExamStatistics.UseColumnTextForButtonValue = true;
            ExamStatistics.Width = 150;
            // 
            // examBindingSource
            // 
            examBindingSource.DataSource = typeof(Models.Exam);
            // 
            // textBox_filter
            // 
            textBox_filter.BorderStyle = BorderStyle.FixedSingle;
            textBox_filter.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_filter.Location = new Point(245, 365);
            textBox_filter.Margin = new Padding(4);
            textBox_filter.Name = "textBox_filter";
            textBox_filter.Size = new Size(490, 35);
            textBox_filter.TabIndex = 7;
            textBox_filter.TextChanged += textBox_filter_TextChanged;
            // 
            // label_searchExam
            // 
            label_searchExam.AutoSize = true;
            label_searchExam.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label_searchExam.ForeColor = Color.FromArgb(0, 135, 209);
            label_searchExam.Location = new Point(75, 365);
            label_searchExam.Margin = new Padding(4, 0, 4, 0);
            label_searchExam.Name = "label_searchExam";
            label_searchExam.Size = new Size(162, 30);
            label_searchExam.TabIndex = 8;
            label_searchExam.Text = "Search Exam : ";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(0, 135, 209);
            panel4.Controls.Add(button_Logout);
            panel4.Controls.Add(label11);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(1712, 88);
            panel4.TabIndex = 9;
            // 
            // button_Logout
            // 
            button_Logout.BackColor = Color.AliceBlue;
            button_Logout.BackgroundImageLayout = ImageLayout.Zoom;
            button_Logout.FlatStyle = FlatStyle.Flat;
            button_Logout.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button_Logout.ForeColor = Color.FromArgb(0, 135, 209);
            button_Logout.Location = new Point(1532, 18);
            button_Logout.Margin = new Padding(2);
            button_Logout.Name = "button_Logout";
            button_Logout.Size = new Size(148, 52);
            button_Logout.TabIndex = 10;
            button_Logout.Text = "Logout";
            button_Logout.UseVisualStyleBackColor = false;
            button_Logout.Click += button_Logout_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.Window;
            label11.Location = new Point(711, 10);
            label11.Margin = new Padding(0);
            label11.Name = "label11";
            label11.Size = new Size(310, 60);
            label11.TabIndex = 7;
            label11.Text = "Teacher Panel";
            // 
            // button_delete
            // 
            button_delete.BackColor = Color.FromArgb(0, 135, 209);
            button_delete.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button_delete.ForeColor = Color.White;
            button_delete.Location = new Point(367, 162);
            button_delete.Margin = new Padding(4);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(240, 85);
            button_delete.TabIndex = 10;
            button_delete.Text = "Delete Exam";
            button_delete.UseVisualStyleBackColor = false;
            button_delete.Click += button_delete_Click;
            // 
            // TeacherForm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1712, 1099);
            Controls.Add(button_delete);
            Controls.Add(label_searchExam);
            Controls.Add(dataGridView_teacherExams);
            Controls.Add(textBox_filter);
            Controls.Add(panel4);
            Controls.Add(button_createExam);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "TeacherForm";
            Text = "TeacherForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView_teacherExams).EndInit();
            ((System.ComponentModel.ISupportInitialize)examBindingSource).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_createExam;
        private BindingSource examBindingSource;
        public DataGridView dataGridView_teacherExams;
        private TextBox textBox_filter;
        private Label label_searchExam;
        private Panel panel4;
        private Label label11;
        private DataGridViewTextBoxColumn examIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn examStrIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn examTitleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn examDateTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn teacherFullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalHoursDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalMinutesDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn randomQuestionOrderDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn courseTypeDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn ShowExam;
        private DataGridViewButtonColumn ExamStatistics;
        public Button button_Logout;
        private Button button_delete;
    }
}