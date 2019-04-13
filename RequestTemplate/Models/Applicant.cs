namespace RequestTemplate.Models
{
    public class Applicant
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string AppliedPosition { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
