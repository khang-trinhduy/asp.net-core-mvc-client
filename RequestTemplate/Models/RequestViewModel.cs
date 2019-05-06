using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RequestTemplate.Models.SubmitActionViewModel;

namespace RequestTemplate.Models
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public ProcessViewModel Process { get; set; }
        public string Title { get; set; }
        public string CurrentState { get; set; }
    }

    public class DataViewModel
    {
        // public ActivityViewModel Activity { get; set; }
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
         public string AbsentName { get; set; }
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DayOff { get; set; }
        public string Reason { get; set; }
        public bool IsReallyNotApproved { get; set; }
        public bool IsDone { get; set; }
        public string ApproverName { get; set; }
        public string Messages { get; set; }
        public byte[] Emoji { get; set; }
        public string Topic { get; set; }

        // public string Discriminator { get; set; }
    }

    public class ProcessViewModel
    {
        public int Id { get; set; }
        public ICollection<ActionViewModel> Actions { get; set; }
        public ICollection<StateViewModel> States { get; set; }
        public ICollection<NodeViewModel> Nodes { get; set; }
        public ICollection<TransitionRuleViewModel> Rules { get; set; }
        public ICollection<RoleViewModel> Roles { get; set; }
        public ICollection<ActivityViewModel> Activities { get; set; }
    }

    public class NodeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<NodeViewModel> Childs { get; set; }
        public NodeViewModel Parent { get; set; }
        public int Level { get; set; }
        public bool IsCompleted { get; set; }
        public List<ActivityViewModel> Activities { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public int ProcessId { get; set; }
        public List<Action> Actions { get; set; }
    }

    public class ActivityViewModel
    {   
        public int Id { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public List<Data> Data { get; set; }
        public string AbsentName { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DayOff { get; set; }
        public bool IsReallyNotApproved { get; set; }
        public string ApproverName { get; set; }
        public string Reason { get; set; }
        public string Discriminator { get; set; }
        public bool IsRunning { get; set; }
        public string CampaignName { get; set; }

    }
    public class ActionViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class StateViewModel
    {
        public List<RoleViewModel> Roles { get; set; }
        public StateType StateType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ActivityViewModel> Activities { get; set; }
        public int Id { get; set; }
        public DateTime ETA { get; set; }

    }
    public class TransitionRuleViewModel
    {
        public string CurrentState { get; set; }
        public string NextState { get; set; }
        public string CurrentNode { get; set; }
        public string NextNode { get; set; }
        public int Id { get; set; }
        public string Action { get; set; }
        public TriggerCreateModel Trigger { get; set; }
    }

    public class TriggerCreateModel
    {
        public int Id { get; set; }
        public DataCreateModel Data { get; set; }
        public ICollection<Event> Events { get; set; }
        public Consequence Consequence { get; set; }
    }

    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}