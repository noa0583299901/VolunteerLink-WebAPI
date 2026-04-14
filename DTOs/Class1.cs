namespace DTOs
{
    public class Class1
    {
        public record VolunteerDTO
        {
            public int Id { get; init; }
            public string FirstName { get; init; }
            public string LastName { get; init; }
            public string Email { get; init; }
            public List<string> SkillNames { get; set; }
        }
        public record VolunteerPostDTO(string FirstName, string LastName, string Email, int SkillId)
        {
            public string PhoneNumber { get; set; }
            public string Password { get; set; }
            public DateTime? BirthDate { get; set; }
        }
    }
}
