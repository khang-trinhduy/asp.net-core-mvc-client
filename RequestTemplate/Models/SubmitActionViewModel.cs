using System.Collections.Generic;

namespace RequestTemplate.Models.SubmitActionViewModel
{
    public class SubmitActionViewModel
    {
        public string source { get; set; }
        public string role { get; set; }
        public string action { get; set; }
        public string activity { get; set; }
        public string approver { get; set; }
        public List<DataCreateModel> data { get; set; }
        public bool doactivity { get; set; }
    }
}