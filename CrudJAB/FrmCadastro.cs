using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CrudJAB
{
    public partial class FrmCadastro : Form
    {
        PersistenciaDados dados = new PersistenciaDados();

        public FrmCadastro()
        {
            InitializeComponent();
        }

        private void irParaInicio()
        {
            FrmInicio inicio = new FrmInicio();
            inicio.Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            irParaInicio();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (ValidarCamposVazios())
            {
                try
                {
                  String DataFormatadaInsert= DateTime.Parse(mskDataNascimento.Text).ToString("yyyy-MM-dd");
                    dados.InserirEndereco(txtLogradouro.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text,
                        cmbUF.Text, mskCep.Text, txtComplemento.Text);

                    dados.InserirUsuario(txtNome.Text, mskCpf.Text, mskTelefone.Text, txtEmail.Text, cmbSexo.Text
                        , DataFormatadaInsert);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no cadastro!\nFavor verificar os campos!\n\nErro:"+ex);
                }

                irParaInicio();
            }
            
            else
            {
                MessageBox.Show("Favor revisar os campos para cadastrar-se !");
            }

        }

        private void FrmCadastro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private Boolean ValidarCamposVazios()
        {
            if(txtBairro.Text=="" || mskCep.Text.Length<9 || txtCidade.Text=="" || mskCpf.Text.Length<14 || 
                mskDataNascimento.Text.Length<10 || txtEmail.Text=="" || 
                txtLogradouro.Text=="" || txtNome.Text==""|| txtNumero.Text=="" || mskTelefone.Text.Length<13 
                || cmbSexo.Text=="Selecione" || 
                cmbUF.Text=="Selecione")
            {
                return false;
            }
            return true;
        }


    }
}
