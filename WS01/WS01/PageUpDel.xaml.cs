using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS01.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WS01.Controller;


namespace WS01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageUpDel : ContentPage
    {
        public Pessoa pessoa;
        public PageUpDel()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = this.pessoa;
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            MySQLCon.Atualizar(pessoa);
            Navigation.PopAsync();
        }

        private void btnApagar_Clicked(object sender, EventArgs e)
        {
            if (pessoa.id != 0)
            {
                MySQLCon.Excluir(pessoa.id);
                Navigation.PopAsync();
            }
        }
    }
}