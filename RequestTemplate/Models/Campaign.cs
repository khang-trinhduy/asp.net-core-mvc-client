using System.Collections.Generic;

namespace RequestTemplate.Models
{
    public class Campaign
    {
        public string Name { get; set; }   
        public bool IsRunning { get; set; }
        public List<Contact> Subscribers { get; set; }
    }

    public class Contact
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumer { get; set; }
    }
}