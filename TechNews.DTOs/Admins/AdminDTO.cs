using System;

namespace TechNews.Dtos.Admins
{
    public class AdminDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
