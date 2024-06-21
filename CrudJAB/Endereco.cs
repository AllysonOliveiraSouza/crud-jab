using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudJAB
{
    public class Endereco
    {
        public Int64 Id { get; set; }
        public String Logradouro { get; set; }
        public String Numero { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public String Cep { get; set; }
        public String Complemento { get; set; }

        public Endereco()
        {

        }

        public Endereco(long id, string logradouro, string numero, string bairro, string cidade, string estado, string cep, string complemento)
        {
            Id=id;
            Logradouro=logradouro;
            Numero=numero;
            Bairro=bairro;
            Cidade=cidade;
            Estado=estado;
            Cep=cep;
            Complemento=complemento;
        }
    }
}
