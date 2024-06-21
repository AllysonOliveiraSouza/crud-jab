using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CrudJAB
{
    public partial class FrmDadosUsuario : Form
    {
        PersistenciaDados dados = new PersistenciaDados();
        int IdUsuario;
        Int64 IdEndereco;
        Usuario usuarioSelecionado;
        Endereco enderecoUsuario;
        public FrmDadosUsuario(int idUsuario)
        {
            InitializeComponent();
            IdUsuario= idUsuario;
            usuarioSelecionado = dados.buscarUsuarioPorID(IdUsuario);
            enderecoUsuario = dados.buscarEnderecoPorID(usuarioSelecionado.IdEndereco);
            IdEndereco = enderecoUsuario.Id;
            CarregarTodosDados();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            irParaInicio();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            dados.excluirDadosUsuario(IdUsuario,IdEndereco);
            irParaInicio();
        }

        private void radEditar_CheckedChanged(object sender, EventArgs e)
        {
            HabiltarCamposParaEdicao();
        }

        private void radNaoEditar_CheckedChanged(object sender, EventArgs e)
        {
            DesabiltarCamposParaEdicao();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (radNaoEditar.Checked)
            {
                MessageBox.Show("Favor selecionar a opção editar para prosseguir a alteração!");
                return;
            }

            if (ValidarCamposVazios()==false)
            {
                MessageBox.Show("Favor revisar os campos antes de prosseguir a alteração de dados !");
                return;
            }

            try
            {
                String DataFormatadaInsert = DateTime.Parse(mskDataNascimento.Text).ToString("yyyy-MM-dd");
                dados.AlterarDadosUsuario(IdUsuario, txtNome.Text, mskCpf.Text, mskTelefone.Text, txtEmail.Text,
                    cmbSexo.Text, DataFormatadaInsert);
                dados.AlterarEndereco(IdEndereco, txtLogradouro.Text, txtNumero.Text, txtBairro.Text, 
                    txtCidade.Text, cmbUF.Text, mskCep.Text, txtComplemento.Text);
                MessageBox.Show("Alteração feita !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na alteração!\nFavor verificar os campos!\n\nErro:"+ex);
            }

            irParaInicio();

        }

        private void FrmDadosUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void HabiltarCamposParaEdicao()
        {
            cmbSexo.Visible=true;
            cmbUF.Visible=true;
            txtSexo.Visible=false;
            txtUF.Visible=false;
            txtNome.ReadOnly=false;
            mskCpf.ReadOnly=false;
            mskTelefone.ReadOnly=false;
            txtEmail.ReadOnly=false;
            mskDataNascimento.ReadOnly=false;          
            txtLogradouro.ReadOnly=false;
            txtNumero.ReadOnly=false;
            txtBairro.ReadOnly=false;
            txtCidade.ReadOnly=false;
            mskCep.ReadOnly=false;
            txtComplemento.ReadOnly=false;
        }

        private void DesabiltarCamposParaEdicao()
        {
            cmbSexo.Visible=false;
            cmbUF.Visible=false;
            txtSexo.Visible=true;
            txtUF.Visible=true;
            txtNome.ReadOnly=true;
            mskCpf.ReadOnly=true;
            mskTelefone.ReadOnly=true;
            txtEmail.ReadOnly=true;
            mskDataNascimento.ReadOnly=true;
            txtLogradouro.ReadOnly=true;
            txtNumero.ReadOnly=true;
            txtBairro.ReadOnly=true;
            txtCidade.ReadOnly=true;
            mskCep.ReadOnly=true;
            txtComplemento.ReadOnly=true;
        }

        private Boolean ValidarCamposVazios()
        {
            if (txtBairro.Text=="" || mskCep.Text.Length<9 || txtCidade.Text=="" || mskCpf.Text.Length<14 ||
                mskDataNascimento.Text.Length<10 || txtEmail.Text=="" ||
                txtLogradouro.Text=="" || txtNome.Text==""|| txtNumero.Text=="" || mskTelefone.Text.Length<13
                || cmbSexo.Text=="Selecione" ||
                cmbUF.Text=="Selecione")
            {
                return false;
            }
            return true;
        }

        private void irParaInicio()
        {
            FrmInicio inicio = new FrmInicio();
            inicio.Show();
            this.Hide();
        }

        private void CarregarTodosDados()
        {
            if (usuarioSelecionado.Sexo=="Masculino")
                lblTituloForm.Text="Dados do "+usuarioSelecionado.Nome+".";
            else
                lblTituloForm.Text="Dados da "+usuarioSelecionado.Nome+".";

            txtNome.Text=usuarioSelecionado.Nome;
            mskCpf.Text=usuarioSelecionado.Cpf;
            mskTelefone.Text=usuarioSelecionado.Telefone;
            txtEmail.Text=usuarioSelecionado.Email;
            mskDataNascimento.Text=usuarioSelecionado.DataNascimento;
            txtSexo.Text=usuarioSelecionado.Sexo;
            cmbSexo.Text=usuarioSelecionado.Sexo;

            txtLogradouro.Text=enderecoUsuario.Logradouro;
            txtNumero.Text=enderecoUsuario.Numero;
            txtBairro.Text=enderecoUsuario.Bairro;
            txtCidade.Text=enderecoUsuario.Cidade;
            txtUF.Text=enderecoUsuario.Estado;
            cmbUF.Text=enderecoUsuario.Estado;
            mskCep.Text=enderecoUsuario.Cep;
            txtComplemento.Text=enderecoUsuario.Complemento;
        }

    }
}
