using System;
using Xamarin.Forms;
using CadastroCliente.Model;
using SQLite.Net.Interop;

[ assembly : Dependency(typeof(CadastroCliente.Droid.Config))]

namespace CadastroCliente.Droid
{
    class Config : IConfig
    {
        private string _diretorioDB;
        private SQLite.Net.Interop.ISQLitePlatform _plataforma;

        public string DiretorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(_diretorioDB))
                {
                    _diretorioDB = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _diretorioDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return _plataforma;
            }
        }
    }
}