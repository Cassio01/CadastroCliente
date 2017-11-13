using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using SQLite.Net;

namespace CadastroCliente.Model
{
    class ClienteRepository : IDisposable
    {

        private SQLite.Net.SQLiteConnection _conexao;

        public ClienteRepository()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "banco.db3"));
            _conexao.CreateTable<Cliente>();
        }

        public void Insert(Cliente cliente)
        {
            _conexao.Insert(cliente);
        }

        public void Update(Cliente cliente)
        {
            _conexao.Update(cliente);
        }

        public void Delete(Cliente cliente)
        {
            _conexao.Delete(cliente);
        }

        public List<Cliente> Listar()
        {
            return _conexao.Table<Cliente>().OrderBy(c => c.Nome).ToList();
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
