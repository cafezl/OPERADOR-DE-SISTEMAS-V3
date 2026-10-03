// [Deus da Guerra: projeto vazio concluído como gerenciador de tarefas]
using System;
using System.Drawing;
using System.Windows.Forms;

namespace novo_projeto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cboPrioridade.SelectedIndex = 1;
            dtpPrazo.Value = DateTime.Today;
            AtualizarResumo();
            AtualizarAcoes();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string descricao = txtTarefa.Text.Trim();
            if (descricao.Length == 0)
            {
                MessageBox.Show(this, "Digite uma tarefa antes de adicionar.", "Tarefa vazia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarefa.Focus();
                return;
            }

            ListViewItem tarefa = new ListViewItem(descricao);
            tarefa.SubItems.Add(cboPrioridade.Text);
            tarefa.SubItems.Add(dtpPrazo.Value.ToString("dd/MM/yyyy"));
            tarefa.SubItems.Add("Pendente");
            lstTarefas.Items.Add(tarefa);

            txtTarefa.Clear();
            txtTarefa.Focus();
            AtualizarResumo();
            AtualizarAcoes();
        }

        private void lstTarefas_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            e.Item.SubItems[3].Text = e.Item.Checked ? "Concluída" : "Pendente";
            e.Item.ForeColor = e.Item.Checked ? Color.Gray : lstTarefas.ForeColor;
            AtualizarResumo();
            AtualizarAcoes();
        }

        private void lstTarefas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarAcoes();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstTarefas.SelectedItems.Count == 0)
            {
                return;
            }

            lstTarefas.Items.Remove(lstTarefas.SelectedItems[0]);
            AtualizarResumo();
            AtualizarAcoes();
        }

        private void btnLimparConcluidas_Click(object sender, EventArgs e)
        {
            for (int i = lstTarefas.Items.Count - 1; i >= 0; i--)
            {
                if (lstTarefas.Items[i].Checked)
                {
                    lstTarefas.Items.RemoveAt(i);
                }
            }

            AtualizarResumo();
            AtualizarAcoes();
        }

        private void AtualizarResumo()
        {
            int concluidas = 0;
            foreach (ListViewItem tarefa in lstTarefas.Items)
            {
                if (tarefa.Checked)
                {
                    concluidas++;
                }
            }

            int pendentes = lstTarefas.Items.Count - concluidas;
            lblResumo.Text = "Tarefas: " + lstTarefas.Items.Count
                + "    Concluídas: " + concluidas
                + "    Pendentes: " + pendentes;
        }

        private void AtualizarAcoes()
        {
            btnRemover.Enabled = lstTarefas.SelectedItems.Count > 0;
            bool temConcluida = false;
            foreach (ListViewItem tarefa in lstTarefas.Items)
            {
                if (tarefa.Checked)
                {
                    temConcluida = true;
                    break;
                }
            }

            btnLimparConcluidas.Enabled = temConcluida;
        }
    }
}