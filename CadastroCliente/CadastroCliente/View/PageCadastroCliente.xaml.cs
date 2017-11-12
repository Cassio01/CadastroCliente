using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CadastroCliente.Model;

namespace CadastroCliente.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastroCliente : ContentPage
    {
        private Cliente _cliente = null;

        public PageCadastroCliente()
        {
            InitializeComponent();
            using( var dados = new ClienteRepository())
            {
                this.Lista.ItemsSource = dados.Listar();
            }
        }

        protected void Salvar_Clicked(object sender, EventArgs e)
        {
            using (var dados = new ClienteRepository())
            {
                if(this._cliente != null)
                {
                    _cliente.Nome = this.Nome.Text;
                    _cliente.Cpf = this.Cpf.Text;
                    _cliente.Email = this.Email.Text;
                    _cliente.Telefone = this.Telefone.Text;
                    dados.Update(this._cliente);

                } else
                {
                    if(this.Nome != null)
                    {
                        this._cliente = new Cliente
                        {
                            Nome = this.Nome.Text,
                            Cpf = this.Cpf.Text,
                            Email = this.Email.Text,
                            Telefone = this.Telefone.Text

                        };

                        dados.Insert(this._cliente);
                    }
                }

                LimaparCampos();
                this.Lista.ItemsSource = dados.Listar();
            }
        }

        private void LimaparCampos()
        {
            this.Nome.Text = "";
            this.Cpf.Text = "";
            this.Email.Text = "";
            this.Telefone.Text = "";
        }

        private void Editar_Clicked(object sender, EventArgs e)
        {
            this._cliente = this.Lista.ItemsSource as Cliente;
            if(this._cliente != null)
            {
                this.Nome.Text = this._cliente.Nome;
                this.Cpf.Text = this._cliente.Cpf;
                this.Email.Text = this._cliente.Email;
                this.Telefone.Text = this._cliente.Telefone;
            }
        }

        private void Excluir_Clicked(object sender, EventArgs e)
        {
            this._cliente = this.Lista.SelectedItem as Cliente;
            if(_cliente != null)
            {
                using (var dados = new ClienteRepository())
                {
                    dados.Delete(this._cliente);
                    this.Lista.ItemsSource = dados.Listar();
                    LimaparCampos();
                }
            }
        }
    }
}