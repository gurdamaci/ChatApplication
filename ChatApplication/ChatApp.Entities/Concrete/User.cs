using ChatApp.Entities.Abstract;

namespace ChatApp.Entities.Concrete
{
    public class User : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
    }
}