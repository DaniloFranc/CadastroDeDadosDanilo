


//Desenvolvido por:

//Danilo Franco de Oliveira



namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tb_Nome = new TextBox();
            cb_Masc = new CheckBox();
            cb_Fem = new CheckBox();
            tb_Cidade = new TextBox();
            bt_Inclui = new Button();
            bt_Altera = new Button();
            bt_Exclui = new Button();
            bt_Contar = new Button();
            rt_Box1 = new RichTextBox();
            tb_Data = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 29);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(249, 199);
            listBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(287, 32);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 3;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(287, 65);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 4;
            label2.Text = "Sexo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(287, 99);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 5;
            label3.Text = "Cidade";
            // 
            // tb_Nome
            // 
            tb_Nome.Location = new Point(337, 29);
            tb_Nome.Name = "tb_Nome";
            tb_Nome.Size = new Size(177, 23);
            tb_Nome.TabIndex = 6;
            // 
            // cb_Masc
            // 
            cb_Masc.AutoSize = true;
            cb_Masc.Location = new Point(341, 65);
            cb_Masc.Name = "cb_Masc";
            cb_Masc.Size = new Size(81, 19);
            cb_Masc.TabIndex = 7;
            cb_Masc.Text = "Masculino";
            cb_Masc.UseVisualStyleBackColor = true;
            cb_Masc.CheckedChanged += cb_Masc_CheckedChanged;
            // 
            // cb_Fem
            // 
            cb_Fem.AutoSize = true;
            cb_Fem.Location = new Point(428, 65);
            cb_Fem.Name = "cb_Fem";
            cb_Fem.Size = new Size(76, 19);
            cb_Fem.TabIndex = 8;
            cb_Fem.Text = "Feminino";
            cb_Fem.UseVisualStyleBackColor = true;
            cb_Fem.CheckedChanged += cb_Fem_CheckedChanged;
            // 
            // tb_Cidade
            // 
            tb_Cidade.Location = new Point(337, 96);
            tb_Cidade.Name = "tb_Cidade";
            tb_Cidade.Size = new Size(177, 23);
            tb_Cidade.TabIndex = 9;
            // 
            // bt_Inclui
            // 
            bt_Inclui.Location = new Point(287, 176);
            bt_Inclui.Name = "bt_Inclui";
            bt_Inclui.Size = new Size(75, 23);
            bt_Inclui.TabIndex = 10;
            bt_Inclui.Text = "Inclui";
            bt_Inclui.UseVisualStyleBackColor = true;
            bt_Inclui.Click += bt_Inclui_Click;
            // 
            // bt_Altera
            // 
            bt_Altera.Location = new Point(368, 176);
            bt_Altera.Name = "bt_Altera";
            bt_Altera.Size = new Size(75, 23);
            bt_Altera.TabIndex = 11;
            bt_Altera.Text = "Altera";
            bt_Altera.UseVisualStyleBackColor = true;
            bt_Altera.Click += bt_Altera_Click;
            // 
            // bt_Exclui
            // 
            bt_Exclui.Location = new Point(449, 176);
            bt_Exclui.Name = "bt_Exclui";
            bt_Exclui.Size = new Size(75, 23);
            bt_Exclui.TabIndex = 12;
            bt_Exclui.Text = "Exclui";
            bt_Exclui.UseVisualStyleBackColor = true;
            bt_Exclui.Click += bt_Exclui_Click;
            // 
            // bt_Contar
            // 
            bt_Contar.Location = new Point(12, 470);
            bt_Contar.Name = "bt_Contar";
            bt_Contar.Size = new Size(506, 38);
            bt_Contar.TabIndex = 16;
            bt_Contar.Text = "Contar No de contatos por cidade";
            bt_Contar.UseVisualStyleBackColor = true;
            bt_Contar.Click += bt_Contar_Click_1;
            // 
            // rt_Box1
            // 
            rt_Box1.Location = new Point(12, 258);
            rt_Box1.Name = "rt_Box1";
            rt_Box1.Size = new Size(506, 206);
            rt_Box1.TabIndex = 19;
            rt_Box1.Text = "";
            // 
            // tb_Data
            // 
            tb_Data.Location = new Point(337, 131);
            tb_Data.Name = "tb_Data";
            tb_Data.Size = new Size(177, 23);
            tb_Data.TabIndex = 20;
            tb_Data.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(291, 134);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 21;
            label4.Text = "Data";
            label4.Visible = false;
            label4.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 537);
            Controls.Add(label4);
            Controls.Add(tb_Data);
            Controls.Add(rt_Box1);
            Controls.Add(bt_Contar);
            Controls.Add(bt_Exclui);
            Controls.Add(bt_Altera);
            Controls.Add(bt_Inclui);
            Controls.Add(tb_Cidade);
            Controls.Add(cb_Fem);
            Controls.Add(cb_Masc);
            Controls.Add(tb_Nome);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Cadastro de Dados - Nome: Danilo Franco de Oliveira";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tb_Nome;
        private CheckBox cb_Masc;
        private CheckBox cb_Fem;
        private TextBox tb_Cidade;
        private Button bt_Inclui;
        private Button bt_Altera;
        private Button bt_Exclui;
        private RichTextBox rt_Box;
        private Button bt_Contar;
        private RichTextBox rt_Box1;
        private TextBox tb_Data;
        private Label label4;
    }
}
