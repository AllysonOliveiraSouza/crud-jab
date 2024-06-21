using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudJAB
{
    public partial class FrmListarUsuarios : Form
    {
        private int idUsuarioSelecionado;

        public FrmListarUsuarios()
        {
            InitializeComponent();
            CarregarListaUsuarios();            
            
        }

        private void FrmListarUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FrmInicio inicio = new FrmInicio();
            inicio.Show();
            this.Hide();
        }

        private void btnVerDados_Click(object sender, EventArgs e)
        {
            if (idUsuarioSelecionado==0)
            {
                MessageBox.Show("Selecione um usuário para ver os dados !");
                return;
            }

            FrmDadosUsuario frmDadosUsuario = new FrmDadosUsuario(idUsuarioSelecionado);
            frmDadosUsuario.Show();
            this.Hide();
        }

        private void lsvUsuarios_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView.SelectedListViewItemCollection lista = lsvUsuarios.SelectedItems;
            int idUsuario = 0;
            foreach (ListViewItem item in lista)
            {
                idUsuario = int.Parse(lista[0].Text);
            }
            if (idUsuario!=0)
            {
                idUsuarioSelecionado=idUsuario;
            }

        }

        private void CarregarListaUsuarios()
        {
            PersistenciaDados dados = new PersistenciaDados();
            List<Usuario> listaUsuarios = dados.carregarTodosUsuarios();

            foreach (Usuario u in listaUsuarios)
            {
                string[] colunas = new string[2];
                colunas[0]=u.Id.ToString();
                colunas[1]=u.Nome;
                ListViewItem listViewItem = new ListViewItem(colunas);
                lsvUsuarios.Items.Add(listViewItem);
            }
        }
    }
}
