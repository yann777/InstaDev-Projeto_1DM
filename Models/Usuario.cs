namespace InstaDev_Projeto_1DM.Models
{
    public class Usuario
    {
        public int idUsuario {get; set;}
        public string nome {get; set;}
        public string foto {get; set;}
        public int dataNascimento {get; set;}
        public int[] seguidos {get; set;}
        public string email {get; set;}
        public string username {get; set;}
        private string senha {get; set;}
    }
}