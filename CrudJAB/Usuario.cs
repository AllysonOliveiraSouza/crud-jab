using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudJAB
{
    public class Usuario
    {
        public Int64 Id {  get; set; }
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
        public String Sexo { get; set; }
        public String DataNascimento { get; set; }
        public Int64 IdEndereco { get; set; }

        public Usuario()
        {

        }

        public Usuario(long id, string nome, string cpf, string telefone, string email, string sexo, 
            string dataNascimento, int idEndereco)
        {
            Id=id;
            Nome=nome;
            Cpf=cpf;
            Telefone=telefone;
            Email=email;
            Sexo=sexo;
            DataNascimento=dataNascimento;
            IdEndereco=idEndereco;
        }

    }
}
