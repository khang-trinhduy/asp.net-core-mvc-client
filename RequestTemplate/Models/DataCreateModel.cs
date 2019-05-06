using System;
using System.Collections.Generic;
using RequestTemplate.Models;

namespace RequestTemplate.Models.SubmitActionViewModel
{
    public class DataCreateModel
    {
        public int Id { get; set; }
        public Models.Request Request { get; set; }
        public int UserId { get; set; }
        public DataType DataType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Contents { get; set; }
        public byte[] Attach { get; set; }
        public string Server { get; set; }
        public string ConfirmEmail { get; set; }
        public string ConfirmPass { get; set; }
        public bool IsSent { get; set; }
        public string Client { get; set; }
        public string Messages { get; set; }
        public byte[] Emoji { get; set; }
        public string Topic { get; set; }
        public string AbsentName { get; set; }
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DayOff { get; set; }
        public string Reason { get; set; }
        public bool IsReallyNotApproved { get; set; }
        public bool IsDone { get; set; }
        public string ApproverName { get; set; }
        public string CampaignName { get; set; }
        public List<ContactViewModel> Subscribers { get; set; }
        public bool IsRunning { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}