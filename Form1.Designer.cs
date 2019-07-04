namespace calculador_logico
{
    partial class TabVjanela
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.TBexpressao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTbicond = new System.Windows.Forms.Button();
            this.BTdisjx = new System.Windows.Forms.Button();
            this.BTdisj = new System.Windows.Forms.Button();
            this.BTcond = new System.Windows.Forms.Button();
            this.BTconj = new System.Windows.Forms.Button();
            this.Btgertab = new System.Windows.Forms.Button();
            this.DGVtabverdade = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVtabverdade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expressão:";
            // 
            // TBexpressao
            // 
            this.TBexpressao.Location = new System.Drawing.Point(78, 14);
            this.TBexpressao.Name = "TBexpressao";
            this.TBexpressao.Size = new System.Drawing.Size(335, 20);
            this.TBexpressao.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 117);
            this.label2.TabIndex = 2;
            this.label2.Text = "Termos permitidos: \r\nLetras de a-z\r\nSeparadores (), [], {}\r\nNegação: !\r\nConjunção" +
    ": ˄\r\nDisjunção: ˅\r\nDisjunção exclusiva: ṿ\r\nCondicional: →\r\nBicondicional: ↔";
            // 
            // BTbicond
            // 
            this.BTbicond.Location = new System.Drawing.Point(328, 50);
            this.BTbicond.Name = "BTbicond";
            this.BTbicond.Size = new System.Drawing.Size(34, 23);
            this.BTbicond.TabIndex = 17;
            this.BTbicond.Text = "↔";
            this.BTbicond.UseVisualStyleBackColor = true;
            this.BTbicond.Click += new System.EventHandler(this.BTbicond_Click);
            // 
            // BTdisjx
            // 
            this.BTdisjx.Location = new System.Drawing.Point(248, 50);
            this.BTdisjx.Name = "BTdisjx";
            this.BTdisjx.Size = new System.Drawing.Size(34, 23);
            this.BTdisjx.TabIndex = 16;
            this.BTdisjx.Text = "ṿ";
            this.BTdisjx.UseVisualStyleBackColor = true;
            this.BTdisjx.Click += new System.EventHandler(this.BTdisjx_Click);
            // 
            // BTdisj
            // 
            this.BTdisj.Location = new System.Drawing.Point(208, 50);
            this.BTdisj.Name = "BTdisj";
            this.BTdisj.Size = new System.Drawing.Size(34, 23);
            this.BTdisj.TabIndex = 15;
            this.BTdisj.Text = "˅";
            this.BTdisj.UseVisualStyleBackColor = true;
            this.BTdisj.Click += new System.EventHandler(this.BTdisj_Click);
            // 
            // BTcond
            // 
            this.BTcond.Location = new System.Drawing.Point(288, 50);
            this.BTcond.Name = "BTcond";
            this.BTcond.Size = new System.Drawing.Size(34, 23);
            this.BTcond.TabIndex = 14;
            this.BTcond.Text = "→";
            this.BTcond.UseVisualStyleBackColor = true;
            this.BTcond.Click += new System.EventHandler(this.BTcond_Click);
            // 
            // BTconj
            // 
            this.BTconj.Location = new System.Drawing.Point(168, 50);
            this.BTconj.Name = "BTconj";
            this.BTconj.Size = new System.Drawing.Size(34, 23);
            this.BTconj.TabIndex = 13;
            this.BTconj.Text = "˄";
            this.BTconj.UseVisualStyleBackColor = true;
            this.BTconj.Click += new System.EventHandler(this.BTconj_Click);
            // 
            // Btgertab
            // 
            this.Btgertab.Location = new System.Drawing.Point(215, 107);
            this.Btgertab.Name = "Btgertab";
            this.Btgertab.Size = new System.Drawing.Size(97, 33);
            this.Btgertab.TabIndex = 18;
            this.Btgertab.Text = "Gerar tabela";
            this.Btgertab.UseVisualStyleBackColor = true;
            this.Btgertab.Click += new System.EventHandler(this.Btgertab_Click);
            // 
            // DGVtabverdade
            // 
            this.DGVtabverdade.AllowUserToAddRows = false;
            this.DGVtabverdade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVtabverdade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVtabverdade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVtabverdade.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVtabverdade.Location = new System.Drawing.Point(15, 198);
            this.DGVtabverdade.Name = "DGVtabverdade";
            this.DGVtabverdade.ReadOnly = true;
            this.DGVtabverdade.RowHeadersVisible = false;
            this.DGVtabverdade.ShowEditingIcon = false;
            this.DGVtabverdade.Size = new System.Drawing.Size(398, 179);
            this.DGVtabverdade.TabIndex = 19;
            // 
            // TabVjanela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 388);
            this.Controls.Add(this.DGVtabverdade);
            this.Controls.Add(this.Btgertab);
            this.Controls.Add(this.BTbicond);
            this.Controls.Add(this.BTdisjx);
            this.Controls.Add(this.BTdisj);
            this.Controls.Add(this.BTcond);
            this.Controls.Add(this.BTconj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBexpressao);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(441, 427);
            this.MinimumSize = new System.Drawing.Size(441, 427);
            this.Name = "TabVjanela";
            this.Text = "Tabela Verdade";
            ((System.ComponentModel.ISupportInitialize)(this.DGVtabverdade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBexpressao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTbicond;
        private System.Windows.Forms.Button BTdisjx;
        private System.Windows.Forms.Button BTdisj;
        private System.Windows.Forms.Button BTcond;
        private System.Windows.Forms.Button BTconj;
        private System.Windows.Forms.Button Btgertab;
        private System.Windows.Forms.DataGridView DGVtabverdade;
    }
}

