﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultarCep.Service.Model
{
    public class Endereco
    {
        #region Propriedades
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Unidade { get; set; }
        public string IBGE { get; set; }
        public string GIA { get; set; }
        #endregion
    }

}
