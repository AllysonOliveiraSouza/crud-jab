using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudJAB
{
    public partial class FrmInicio : Form
    {
        String opcaoSelecionada;

        public FrmInicio()
        {
            InitializeComponent();           
        }

        private void btnSairSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            opcaoSelecionada = lbOpcoes.SelectedItem as String;

        }

        private void btnOpcaoSelecionada_Click(object sender, EventArgs e)
        {
            if (opcaoSelecionada==null)
                MessageBox.Show("Selecione uma opção para prosseguir !");
            else
            {
                irParaForm(opcaoSelecionada);
            }
            
        }

        private void FrmInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void irParaForm(String nomeDoForm)
        {
            if (nomeDoForm == "Cadastrar novo usuário")
            {
                FrmCadastro cadastro = new FrmCadastro();
                cadastro.Show();
            }
            else
            {
                FrmListarUsuarios frmListarUsuarios = new FrmListarUsuarios();
                frmListarUsuarios.Show();
            }
            this.Hide();
        }
    }
}
