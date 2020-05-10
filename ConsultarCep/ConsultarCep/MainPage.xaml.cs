using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultarCep.Service;
using ConsultarCep.Service.Model;

namespace ConsultarCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            botao.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();

            if (IsValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        resultado.Text = string.Format("Endereço: {2} Bairro: {3},{0},{1}", end.Localidade,end.UF, end.Logradouro, end.Bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", cep + "não existe", "OK");
                    }
                   
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO", "Erro critico!", e.Message, "OK");
                }
            }
  
        }

        private bool IsValidCEP(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP imvalido! CEP não contém 8 digitos", "OK");
                valido = false;
            }

            int novoCEP = 0;
            if(!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "CEP imvalido! Informe valores númericos", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
