namespace RepositoryPattern.Domain
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public int Email { get; set; }
        public int Idade { get; set; }

        public Usuario(Guid id, string nome, int email, int idade) : base(id)
        {
            Nome = nome;
            Email = email;
            Idade = idade;
        }
        
    }
    
}