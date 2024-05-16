using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WS01.Controller;

namespace WS01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastrar : ContentPage
    {
        public PageCadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            MySQLCon.Inserir(txtNome.Text, txtIdade.Text);
            DisplayAlert("Cadastro", txtNome.Text+ " Cadastrado com Sucesso","Ok");
            Navigation.PushAsync(new PageListar());
        }
    }
}