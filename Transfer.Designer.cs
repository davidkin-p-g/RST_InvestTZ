namespace RST_InvestTZ
{
    partial class Transfer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvShipment = new System.Windows.Forms.DataGridView();
            this.ReceiveItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiveItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvReception = new System.Windows.Forms.DataGridView();
            this.DispatchItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DispatchItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addShipment = new System.Windows.Forms.TextBox();
            this.addReception = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenInventory = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReception)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.Controls.Add(this.dgvShipment, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dgvReception, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.addShipment, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.addReception, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnOpenInventory, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(934, 521);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvShipment
            // 
            this.dgvShipment.AllowUserToAddRows = false;
            this.dgvShipment.AllowUserToDeleteRows = false;
            this.dgvShipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiveItemName,
            this.ReceiveItemQuantity});
            this.dgvShipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShipment.Location = new System.Drawing.Point(21, 137);
            this.dgvShipment.Name = "dgvShipment";
            this.dgvShipment.ReadOnly = true;
            this.dgvShipment.Size = new System.Drawing.Size(442, 317);
            this.dgvShipment.TabIndex = 0;
            // 
            // ReceiveItemName
            // 
            this.ReceiveItemName.HeaderText = "Наименование";
            this.ReceiveItemName.Name = "ReceiveItemName";
            this.ReceiveItemName.ReadOnly = true;
            // 
            // ReceiveItemQuantity
            // 
            this.ReceiveItemQuantity.HeaderText = "Количество";
            this.ReceiveItemQuantity.Name = "ReceiveItemQuantity";
            this.ReceiveItemQuantity.ReadOnly = true;
            // 
            // dgvReception
            // 
            this.dgvReception.AllowUserToAddRows = false;
            this.dgvReception.AllowUserToDeleteRows = false;
            this.dgvReception.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReception.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReception.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DispatchItemName,
            this.DispatchItemQuantity});
            this.dgvReception.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReception.Location = new System.Drawing.Point(469, 137);
            this.dgvReception.Name = "dgvReception";
            this.dgvReception.ReadOnly = true;
            this.dgvReception.Size = new System.Drawing.Size(442, 317);
            this.dgvReception.TabIndex = 12;
            // 
            // DispatchItemName
            // 
            this.DispatchItemName.HeaderText = "Наименование";
            this.DispatchItemName.Name = "DispatchItemName";
            this.DispatchItemName.ReadOnly = true;
            // 
            // DispatchItemQuantity
            // 
            this.DispatchItemQuantity.HeaderText = "Количество";
            this.DispatchItemQuantity.Name = "DispatchItemQuantity";
            this.DispatchItemQuantity.ReadOnly = true;
            // 
            // addShipment
            // 
            this.addShipment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addShipment.Location = new System.Drawing.Point(56, 65);
            this.addShipment.Name = "addShipment";
            this.addShipment.Size = new System.Drawing.Size(371, 29);
            this.addShipment.TabIndex = 2;
            // 
            // addReception
            // 
            this.addReception.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addReception.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addReception.Location = new System.Drawing.Point(510, 65);
            this.addReception.Name = "addReception";
            this.addReception.Size = new System.Drawing.Size(359, 29);
            this.addReception.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.Location = new System.Drawing.Point(180, 460);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(123, 30);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(442, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Поле ввода данных приема";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(469, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 36);
            this.label1.TabIndex = 9;
            this.label1.Text = "Поле ввода данных отгрузки";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(469, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(442, 36);
            this.label3.TabIndex = 10;
            this.label3.Text = "ПРИЕМ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(442, 36);
            this.label4.TabIndex = 11;
            this.label4.Text = "ОТГРУЗКА";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOpenInventory
            // 
            this.btnOpenInventory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOpenInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenInventory.Location = new System.Drawing.Point(617, 460);
            this.btnOpenInventory.Name = "btnOpenInventory";
            this.btnOpenInventory.Size = new System.Drawing.Size(145, 30);
            this.btnOpenInventory.TabIndex = 13;
            this.btnOpenInventory.Text = "Инвентарь";
            this.btnOpenInventory.UseVisualStyleBackColor = true;
            this.btnOpenInventory.Click += new System.EventHandler(this.btnOpenInventory_Click);
            // 
            // Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 521);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Transfer";
            this.Text = "Inventory Management";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReception)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvShipment;
        private System.Windows.Forms.TextBox addShipment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addReception;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvReception;
        private System.Windows.Forms.DataGridViewTextBoxColumn DispatchItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DispatchItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiveItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiveItemQuantity;
        private System.Windows.Forms.Button btnOpenInventory;
    }
}

