using System.Data.OleDb;
using System.Globalization;
using System.Text;



//Desenvolvido por:

//Danilo Franco de Oliveira





namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        Banco banco = new Banco();
        private string connectionString;

        public Form1()
        {
            InitializeComponent();

            connectionString = banco.ConnectionString;

            CarregarDados();
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void CarregarDados()
        {
            try
            {
                using (OleDbConnection conn = banco.ObterConexao())
                {

                    conn.Open();


                    OleDbCommand cmd = new OleDbCommand("SELECT Nome FROM Contatos", conn);


                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {

                        listBox1.Items.Clear();


                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader["Nome"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string nomeSelecionado = listBox1.SelectedItem.ToString();
                CarregarDetalhesContato(nomeSelecionado);
            }
        }

        private void CarregarDetalhesContato(string nome)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {

                    conn.Open();


                    OleDbCommand cmd = new OleDbCommand("SELECT Sexo, Cidade, Data FROM Contatos WHERE Nome = @Nome", conn);
                    cmd.Parameters.AddWithValue("@Nome", nome);


                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            tb_Nome.Text = nome;


                            string sexo = reader["Sexo"].ToString().Trim();



                            if (sexo == "M")
                            {
                                cb_Masc.Checked = true;
                                cb_Fem.Checked = false;
                            }
                            else if (sexo == "F")
                            {
                                cb_Fem.Checked = true;
                                cb_Masc.Checked = false;
                            }


                            tb_Cidade.Text = reader["Cidade"].ToString();
                            tb_Data.Text = reader["Data"].ToString();

                        }
                        else
                        {
                            tb_Nome.Clear();
                            cb_Masc.Checked = false;
                            cb_Fem.Checked = false;
                            tb_Cidade.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os detalhes do contato: " + ex.Message);
            }
        }

        private void bt_Inclui_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    string sexo = cb_Masc.Checked ? "M" : (cb_Fem.Checked ? "F" : "");

                    if (string.IsNullOrWhiteSpace(tb_Nome.Text) || string.IsNullOrWhiteSpace(sexo))
                    {
                        MessageBox.Show("Preencha todos os campos obrigatórios (Nome e Sexo).");
                        return;
                    }


                    string nome = tb_Nome.Text.Trim();
                    string queryVerificaNome = "SELECT COUNT(*) FROM Contatos WHERE Nome = @Nome";

                    using (OleDbCommand cmdVerifica = new OleDbCommand(queryVerificaNome, conn))
                    {
                        cmdVerifica.Parameters.AddWithValue("@Nome", nome);
                        int count = (int)cmdVerifica.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Este nome já existe. Por favor, insira um nome diferente.");
                            return;
                        }
                    }

                    tb_Data.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                    string queryCodContato = "SELECT MAX(CodContato) FROM Contatos";
                    int novoCodContato = 1;

                    using (OleDbCommand cmdCodContato = new OleDbCommand(queryCodContato, conn))
                    {
                        object result = cmdCodContato.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            novoCodContato = Convert.ToInt32(result) + 1;
                        }
                    }

                    string query = "INSERT INTO Contatos (CodContato, Nome, Sexo, Cidade, Data) VALUES (@CodContato, @Nome, @Sexo, @Cidade, @Data)";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodContato", novoCodContato);
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Sexo", sexo);
                        cmd.Parameters.AddWithValue("@Cidade", tb_Cidade.Text);
                        cmd.Parameters.AddWithValue("@Data", tb_Data.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Contato incluído com sucesso!");

                        CarregarDados();

                        tb_Nome.Clear();
                        cb_Masc.Checked = false;
                        cb_Fem.Checked = false;
                        tb_Cidade.Clear();
                        tb_Data.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao incluir o contato: " + ex.Message);
            }
        }



        private void bt_Exclui_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(tb_Nome.Text))
                {
                    MessageBox.Show("Selecione um contato para excluir.");
                    return;
                }


                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este contato?", "Confirmação", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {

                        conn.Open();


                        string query = "DELETE FROM Contatos WHERE Nome = @Nome";

                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("@Nome", tb_Nome.Text);


                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Contato excluído com sucesso!");

                                CarregarDados();

                                tb_Nome.Clear();
                                cb_Masc.Checked = false;
                                cb_Fem.Checked = false;
                                tb_Cidade.Clear();
                                tb_Data.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Erro: Nenhum contato foi encontrado com esse nome.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o contato: " + ex.Message);
            }
        }

        private void bt_Altera_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(tb_Nome.Text))
                {
                    MessageBox.Show("Selecione um contato para alterar.");
                    return;
                }


                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();


                    string sexo = cb_Masc.Checked ? "M" : (cb_Fem.Checked ? "F" : "");


                    if (string.IsNullOrWhiteSpace(tb_Nome.Text) || string.IsNullOrWhiteSpace(sexo))
                    {
                        MessageBox.Show("Preencha todos os campos obrigatórios (Nome e Sexo).");
                        return;
                    }


                    tb_Data.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");


                    string query = "UPDATE Contatos SET Nome = @Nome, Sexo = @Sexo, Cidade = @Cidade, Data = @Data WHERE Nome = @NomeOriginal";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {

                        string nomeOriginal = listBox1.SelectedItem.ToString();

                        cmd.Parameters.AddWithValue("@Nome", tb_Nome.Text);
                        cmd.Parameters.AddWithValue("@Sexo", sexo);
                        cmd.Parameters.AddWithValue("@Cidade", tb_Cidade.Text);
                        cmd.Parameters.AddWithValue("@Data", tb_Data.Text);
                        cmd.Parameters.AddWithValue("@NomeOriginal", nomeOriginal);


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Contato alterado com sucesso!");


                            CarregarDados();


                            tb_Nome.Clear();
                            cb_Masc.Checked = false;
                            cb_Fem.Checked = false;
                            tb_Cidade.Clear();
                            tb_Data.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Erro: Nenhum contato foi encontrado com esse nome.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar o contato: " + ex.Message);
            }
        }



        private void bt_Contar_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand("SELECT Nome, Sexo, Cidade, Data FROM Contatos", conn);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {

                        int totalContatos = 0;
                        int totalHomens = 0;
                        int totalMulheres = 0;
                        Dictionary<string, Dictionary<string, (int total, int homens, int mulheres)>> relatorio = new Dictionary<string, Dictionary<string, (int, int, int)>>();

                        while (reader.Read())
                        {
                            totalContatos++;
                            string sexo = reader["Sexo"].ToString().Trim();
                            string cidade = reader["Cidade"].ToString().Trim();
                            DateTime data = Convert.ToDateTime(reader["Data"]);
                            string mesAno = data.ToString("MMMM");


                            if (sexo == "M")
                            {
                                totalHomens++;
                            }
                            else if (sexo == "F")
                            {
                                totalMulheres++;
                            }


                            if (!relatorio.ContainsKey(cidade))
                            {
                                relatorio[cidade] = new Dictionary<string, (int total, int homens, int mulheres)>();
                            }

                            if (!relatorio[cidade].ContainsKey(mesAno))
                            {
                                relatorio[cidade][mesAno] = (0, 0, 0);
                            }


                            relatorio[cidade][mesAno] = (relatorio[cidade][mesAno].total + 1,
                                                          relatorio[cidade][mesAno].homens + (sexo == "M" ? 1 : 0),
                                                          relatorio[cidade][mesAno].mulheres + (sexo == "F" ? 1 : 0));
                        }


                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Análise dos contatos:");

                        sb.AppendLine($"Número de contatos no banco de dados: {totalContatos}, {totalHomens} homens e {totalMulheres} mulheres");

                        foreach (var cidade in relatorio)
                        {
                            sb.AppendLine($"\nContatos em {cidade.Key}:");
                            int totalCidade = 0;
                            foreach (var mes in cidade.Value)
                            {
                                sb.AppendLine($"{mes.Key}: {mes.Value.total}, {mes.Value.homens} homens e {mes.Value.mulheres} mulheres");
                                totalCidade += mes.Value.total;
                            }
                            sb.AppendLine($"Total: {totalCidade}");
                        }


                        rt_Box1.Text = sb.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao contar os contatos: " + ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cb_Masc_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Masc.Checked)
            {
                cb_Fem.Checked = false;
            }
        }

        private void cb_Fem_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Fem.Checked)
            {
                cb_Masc.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
