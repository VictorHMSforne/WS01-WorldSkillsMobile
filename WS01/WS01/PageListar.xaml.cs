using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WS01.Controller; //adicionei
using WS01.Models; //adicionei

namespace WS01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListar : ContentPage
    {
        public PageListar()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lsvPessoas.ItemsSource = MySQLCon.ListarPessoas();
        }

        private void lsvPessoas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarPessoa(e.SelectedItem as Pessoa);
            
        }
        void NavegarPessoa(Pessoa pessoa)
        {
            PageUpDel upDel = new PageUpDel();
            upDel.pessoa = pessoa;
            Navigation.PushAsync(upDel);
        }
    }
}