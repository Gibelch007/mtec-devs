using System.ComponentModel.DataAnnotations;

namespace MtecDevs.ViewModels;

    public class RegisterVM
    {
        [ Display(Name = "Nome de Usuário", Prompt = "Informe seu Nome de Usuário")]
        [Required(ErrorMessage = " Por favor, informe seu Nome de Usuário")]
    
        public string Nome {get; set;}

        [ Display(Name = "Email", Prompt = "Informe seu Email")]
        [Required(ErrorMessage = " Por favor, informe seu Email")]
    
        public string Email {get; set;}

        [ Display(Name = "Data de nascimento", Prompt = "Informe sua Data de nascimento")]
        [Required(ErrorMessage = " Por favor, informe sua Data de nascimento")]
    
        public DateTime DataNascimento {get; set;}

        [ Display(Name = "Senha de Acesso", Prompt = "Informe sua Senha")]
        [Required(ErrorMessage = " Por favor, informe sua Senha")]
        [DataType(DataType.Password)]
        [ Display(Name = "Tipo de desenvolvedor", Prompt = "Informe seu Tipo de desenvolvedor")]
        [Required(ErrorMessage = " Por favor, informe seu Tipo")]
    
        public byte TipoDevId {get; set;}

        [ Display(Name = "Foto", Prompt = "Insira sua Foto")]
        [Required(ErrorMessage = " Por favor, Insira sua Foto")]
    
        public string Foto {get; set;}

        public string Senha {get; set;}
        [Display(Name = "Manter Conectado?")]

         public bool Lembrar {get; set;} = false;

         public string UrlRetorno{get; set;}

    }
