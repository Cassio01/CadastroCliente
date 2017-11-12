
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace CadastroCliente.Model
{
    class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public override string ToString()
        {
            return string.Format("Nome={0}", "CPF={1}", "Email={2}", "Telefone={3}", Nome, Cpf, Email, Telefone);
        }
    }
}
