using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CrudJAB
{
    internal class PersistenciaDados
    {
        private const String strConexao = "server=localhost;port=3306;UID=root;database=crudjab;pwd=;";
        private MySqlConnection conexao;
        private MySqlCommand comando;
        private Int64 idEnderecoCadastrado;
        private MySqlDataReader reader;

        public PersistenciaDados()
        {
            this.conexao = new MySqlConnection(strConexao);
            this.comando = new MySqlCommand();
            comando.Connection = conexao;
            this.idEnderecoCadastrado=0;

        }

        public void InserirEndereco(String logradouro,String numero,String bairro, String cidade, String estado,
            String cep, String complemento)
        {

            try
            {
                conexao.Open();
                String InsertEndereco = "insert into tb_endereco values(null,@logradouro,@numero_endereco," +
                    "@bairro,@cidade,@estado,@cep,@complemento);";

                comando.CommandText = InsertEndereco;
                comando.Parameters.AddWithValue("@logradouro", logradouro);
                comando.Parameters.AddWithValue("@numero_endereco", numero);
                comando.Parameters.AddWithValue("@bairro", bairro);
                comando.Parameters.AddWithValue("@cidade", cidade);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@cep", cep);
                comando.Parameters.AddWithValue("@complemento", complemento);
                comando.Prepare();
                comando.ExecuteNonQuery();

                //Recuperando id do endereço cadastrado para atrelar ao novo usuário

                String selectIdEndereco = "select id from tb_endereco order by id desc limit 1;";
                comando.CommandText=selectIdEndereco;
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    idEnderecoCadastrado=reader.GetInt64(0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir \n: "+ex);
            }

            finally
            {
                conexao.Close();
            }

        }

        public void InserirUsuario(String nome, String cpf, String telefone, String email, String sexo, String
            dataNascimento)
        {
            try
            {
                conexao.Open();
                String insertUsuario = "insert into tb_usuario values(null,@nome,@cpf," +
                    "@telefone,@email,@sexo,@data_nascimento,@id_endereco);";
                comando.CommandText=insertUsuario;
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@cpf", cpf);
                comando.Parameters.AddWithValue("@telefone", telefone);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@sexo", sexo);
                comando.Parameters.AddWithValue("@data_nascimento", dataNascimento);
                comando.Parameters.AddWithValue("@id_endereco", idEnderecoCadastrado);
                comando.Prepare();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado!");
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao inserir ! \n"+ex);
            }
            finally
            {
                conexao.Close();
            }

        }


        public List<Usuario> carregarTodosUsuarios()
        {
            String selectUsuarios = "select * from tb_usuario;";
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                conexao.Open();
                comando.CommandText=selectUsuarios;
                reader=comando.ExecuteReader();

                while(reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id=reader.GetInt64(0);
                    usuario.Nome=reader.GetString(1);
                    usuario.Cpf=reader.GetString(2);
                    usuario.Telefone=reader.GetString(3);
                    usuario.Email=reader.GetString(4);
                    usuario.Sexo=reader.GetString(5);
                    usuario.DataNascimento=reader.GetDateTime(6).ToString();
                    usuario.IdEndereco=reader.GetInt64(7);
                    listaUsuarios.Add(usuario);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro \n"+ex);
            }
            finally
            {
                conexao.Close();
            }
            return listaUsuarios;
        }

        public Usuario buscarUsuarioPorID(Int64 id)
        {
            Usuario usuario = new Usuario();
            try
            {
                conexao.Open();
                String selectIdUsuario = "select * from tb_usuario where id="+id+";";
                comando.CommandText=selectIdUsuario;
                reader=comando.ExecuteReader();

                while (reader.Read())
                {
                    usuario.Id=reader.GetInt64(0);
                    usuario.Nome=reader.GetString(1);
                    usuario.Cpf=reader.GetString(2);
                    usuario.Telefone=reader.GetString(3);
                    usuario.Email=reader.GetString(4);
                    usuario.Sexo=reader.GetString(5);
                    usuario.DataNascimento=reader.GetDateTime(6).ToString("dd/MM/yyyy");
                    usuario.IdEndereco=reader.GetInt64(7);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erro \n "+ex);
            }
            finally
            {
                conexao.Close();
            }

            return usuario;
        }

        public Endereco buscarEnderecoPorID(Int64 id)
        {
            Endereco endereco = new Endereco();
            try
            {
                conexao.Open();
                String selectIdEndereco = "select * from tb_endereco where id="+id+";";
                comando.CommandText=selectIdEndereco;
                reader=comando.ExecuteReader();

                while (reader.Read())
                {
                    endereco.Id=reader.GetInt64(0);
                    endereco.Logradouro=reader.GetString(1);
                    endereco.Numero=reader.GetString(2);
                    endereco.Bairro=reader.GetString(3);
                    endereco.Cidade=reader.GetString(4);
                    endereco.Estado=reader.GetString(5);
                    endereco.Cep=reader.GetString(6);
                    endereco.Complemento=reader.GetString(7);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro \n "+ex);
            }
            finally
            {
                conexao.Close();
            }

            return endereco;
        }

        public void excluirDadosUsuario(Int64 idUsuario, Int64 idEndereco)
        {
            //Excluindo usuário na tabela

            try
            {
                conexao.Open();
                String deleteUsuario = "delete from tb_usuario where id=@id;";
                comando.CommandText=deleteUsuario;
                comando.Parameters.AddWithValue("@id", idUsuario);
                comando.Prepare();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro:"+ex);
            }
            finally {
                conexao.Close();
            }
            //Excluindo endereço atrelado ao usuário

            try
            {
                conexao.Open();
                String deleteEndereco = "delete from tb_endereco where id=@id_endereco;";
                comando.CommandText=deleteEndereco;
                comando.Parameters.AddWithValue("@id_endereco", idEndereco);
                comando.Prepare();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:"+ex);
            }
            finally
            {
                conexao.Close();

            }

            MessageBox.Show("Excluído com sucesso !");

        }


        public void AlterarDadosUsuario(Int64 idUsuario, String nome, String cpf, String telefone, String email, 
            String sexo, String dataNascimento)
        {
            try
            {
                conexao.Open();
                String updateUsuario = "update tb_usuario set nome=@nome,cpf=@cpf," +
                    "telefone=@telefone,email=@email,sexo=@sexo,data_nascimento=@data_nascimento where id=@id;";
                comando.CommandText = updateUsuario;
                comando.Parameters.AddWithValue("@id", idUsuario);
                comando.Parameters.AddWithValue("@nome",nome);
                comando.Parameters.AddWithValue("@cpf", cpf);
                comando.Parameters.AddWithValue("@telefone", telefone);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@sexo", sexo);
                comando.Parameters.AddWithValue("@data_nascimento", dataNascimento);
                comando.Prepare();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: "+ex);
            }
            finally
            {
                conexao.Close();
            }

        }


        public void AlterarEndereco(Int64 idEndereco,String logradouro, String numero, String bairro, 
            String cidade,String estado,String cep, String complemento)
        {

            try
            {
                conexao.Open();
                String updateEndereco = "update tb_endereco set logradouro=@logradouro," +
                    "numero_endereco=@numero_endereco,bairro=@bairro,cidade=@cidade,estado=@estado,cep=@cep" +
                    ",complemento=@complemento where id=@id_endereco;";

                comando.CommandText = updateEndereco;
                comando.Parameters.AddWithValue("@id_endereco", idEndereco);
                comando.Parameters.AddWithValue("@logradouro", logradouro);
                comando.Parameters.AddWithValue("@numero_endereco", numero);
                comando.Parameters.AddWithValue("@bairro", bairro);
                comando.Parameters.AddWithValue("@cidade", cidade);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@cep", cep);
                comando.Parameters.AddWithValue("@complemento", complemento);
                comando.Prepare();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro \n: "+ex);
            }

            finally
            {
                conexao.Close();
            }

        }


    }

}