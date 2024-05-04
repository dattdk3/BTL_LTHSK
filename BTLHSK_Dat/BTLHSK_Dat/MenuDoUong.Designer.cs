namespace BTLHSK_Dat
{
    partial class MenuDoUong
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.qLKDDoUongDataSet = new BTLHSK_Dat.QLKDDoUongDataSet();
            this.tblDoUongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblDoUongTableAdapter = new BTLHSK_Dat.QLKDDoUongDataSetTableAdapters.tblDoUongTableAdapter();
            this.tblDoUongBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tblDoUongBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tblSizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblSizeTableAdapter = new BTLHSK_Dat.QLKDDoUongDataSetTableAdapters.tblSizeTableAdapter();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.sSizeDoUongDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fTiSoGiaSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblSizeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtNguyenLieu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.qLKDDoUongDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDoUongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDoUongBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDoUongBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSizeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSizeBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Đồ Uống:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Đồ Uống:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Giá Gốc:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(382, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(285, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quản Lý Đồ Uống";
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(29, 387);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 23);
            this.btn_them.TabIndex = 9;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(167, 387);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(75, 23);
            this.btn_Sua.TabIndex = 10;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(298, 387);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(446, 387);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "In";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn_In);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(135, 142);
            this.maskedTextBox1.Mask = "00000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox1.TabIndex = 13;
            this.maskedTextBox1.ValidatingType = typeof(int);
            // 
            // qLKDDoUongDataSet
            // 
            this.qLKDDoUongDataSet.DataSetName = "QLKDDoUongDataSet";
            this.qLKDDoUongDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblDoUongBindingSource
            // 
            this.tblDoUongBindingSource.DataMember = "tblDoUong";
            this.tblDoUongBindingSource.DataSource = this.qLKDDoUongDataSet;
            // 
            // tblDoUongTableAdapter
            // 
            this.tblDoUongTableAdapter.ClearBeforeFill = true;
            // 
            // tblDoUongBindingSource1
            // 
            this.tblDoUongBindingSource1.DataMember = "tblDoUong";
            this.tblDoUongBindingSource1.DataSource = this.qLKDDoUongDataSet;
            // 
            // tblDoUongBindingSource2
            // 
            this.tblDoUongBindingSource2.DataMember = "tblDoUong";
            this.tblDoUongBindingSource2.DataSource = this.qLKDDoUongDataSet;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(474, 150);
            this.dataGridView1.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(538, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Bảng Size:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Bảng Đồ Uống:";
            // 
            // tblSizeBindingSource
            // 
            this.tblSizeBindingSource.DataMember = "tblSize";
            this.tblSizeBindingSource.DataSource = this.qLKDDoUongDataSet;
            // 
            // tblSizeTableAdapter
            // 
            this.tblSizeTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sSizeDoUongDataGridViewTextBoxColumn,
            this.fTiSoGiaSizeDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.tblSizeBindingSource1;
            this.dataGridView3.Location = new System.Drawing.Point(527, 201);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(254, 150);
            this.dataGridView3.TabIndex = 18;
            // 
            // sSizeDoUongDataGridViewTextBoxColumn
            // 
            this.sSizeDoUongDataGridViewTextBoxColumn.DataPropertyName = "sSizeDoUong";
            this.sSizeDoUongDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sSizeDoUongDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sSizeDoUongDataGridViewTextBoxColumn.Name = "sSizeDoUongDataGridViewTextBoxColumn";
            this.sSizeDoUongDataGridViewTextBoxColumn.Width = 60;
            // 
            // fTiSoGiaSizeDataGridViewTextBoxColumn
            // 
            this.fTiSoGiaSizeDataGridViewTextBoxColumn.DataPropertyName = "fTiSoGiaSize";
            this.fTiSoGiaSizeDataGridViewTextBoxColumn.HeaderText = "Tỷ Số Giá Size";
            this.fTiSoGiaSizeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fTiSoGiaSizeDataGridViewTextBoxColumn.Name = "fTiSoGiaSizeDataGridViewTextBoxColumn";
            this.fTiSoGiaSizeDataGridViewTextBoxColumn.Width = 125;
            // 
            // tblSizeBindingSource1
            // 
            this.tblSizeBindingSource1.DataMember = "tblSize";
            this.tblSizeBindingSource1.DataSource = this.qLKDDoUongDataSet;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Nguyên Liệu Gồm:";
            // 
            // txtNguyenLieu
            // 
            this.txtNguyenLieu.Location = new System.Drawing.Point(412, 145);
            this.txtNguyenLieu.Name = "txtNguyenLieu";
            this.txtNguyenLieu.Size = new System.Drawing.Size(100, 22);
            this.txtNguyenLieu.TabIndex = 20;
            // 
            // MenuDoUong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNguyenLieu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "MenuDoUong";
            this.Text = "MenuDoUong";
            this.Load += new System.EventHandler(this.MenuDoUong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qLKDDoUongDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDoUongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDoUongBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDoUongBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSizeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSizeBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private QLKDDoUongDataSet qLKDDoUongDataSet;
        private System.Windows.Forms.BindingSource tblDoUongBindingSource;
        private QLKDDoUongDataSetTableAdapters.tblDoUongTableAdapter tblDoUongTableAdapter;
        private System.Windows.Forms.BindingSource tblDoUongBindingSource1;
        private System.Windows.Forms.BindingSource tblDoUongBindingSource2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource tblSizeBindingSource;
        private QLKDDoUongDataSetTableAdapters.tblSizeTableAdapter tblSizeTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.BindingSource tblSizeBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSizeDoUongDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fTiSoGiaSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNguyenLieu;
    }
}