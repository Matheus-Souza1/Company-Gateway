namespace Company.Clients.Entities
{
    public class Client
    {
        public Client(string firstName, string lastName, string document)
        {
            Guid id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Document = document;
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string  LastName{ get; private set; }
        public string  Document{ get; private set; }

        public void Update (string firstName, string lastName, string document)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
        }
    }
}
