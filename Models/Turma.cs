namespace Portifolio.Models
{
    public class Turma
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Ano { get; set; } = string.Empty;

        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}