using System;
using AT_CadastroDeAniversario;

namespace AT_CadastroDeAniversario.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
