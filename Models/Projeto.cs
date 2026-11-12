namespace Portifolio.Models
{
    public class Projeto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public string Link { get; set; } = string.Empty;

        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}