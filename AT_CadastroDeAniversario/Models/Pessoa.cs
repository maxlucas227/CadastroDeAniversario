using System;



namespace AT_CadastroDeAniversario.Models
{
    public class Pessoa
    {
        public string nome { get; set; }
        public DateTime DataDeAniversario { get; set; }

        public Guid Id { get; set; }


    }
}
