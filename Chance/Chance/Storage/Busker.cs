namespace Chance.Storage
{
    public class Busker : IStorable
    {
        private string Name;

        public Busker(string name)
        {
            Name = name;
        }

        public int Id{ get; set; }
    }
}