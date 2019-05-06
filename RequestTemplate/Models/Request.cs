using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestTemplate.Models
{
    public class Request
    {
        public int Id { get; set; }
        public Process Process { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public State CurrentState { get; set; }
        public Node CurrentNode { get; set; }
        public DateTime DateRequested { get; set; }
        public List<ActivityLog> Histories { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Data> Data { get; set; }
    }
    public class Process
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Action> Actions { get; set; }
        public ICollection<State> States { get; set; }
        public ICollection<TransitionRule> Rules { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<Node> Nodes { get; set; }
        public Node Root { get; set; }
    }

    public class ActivityLog
    {
        public int Id { get; set; }
        public string User { get; set; }
        public Activity Activity { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class Task
    {
        public Activity Activity { get; set; }
        public bool IsDone { get; set; }
        public DateTime Start { get; set; }
        public DateTime DeadLine { get; set; }
        public string UserRole { get; set; }
        public int Id { get; set; }

    }

    public class Data
    {
        public int Id { get; set; }
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
        public DataType DataType { get; set; }
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
        public bool IsRunning { get; set; }
        public List<ContactViewModel> Subscribers { get; set; }
        public int Age { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class Trigger
    {
        public int Id { get; set; }
        public Data Data { get; set; }
        public ICollection<Event> Events { get; set; }
        public Consequence Consequence { get; set; }
    }

    public class Consequence
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
    }

    public class Event
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Condition> Conditions { get; set; }
    }

    public class Condition
    {
        public int Id { get; set; }
        public string Param { get; set; }
        public string Operator { get; set; }
        public string Threshold { get; set; }
        public string Type { get; set; }
    }

    public class ContactViewModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public enum DataType{
        Documents = 0,
        Photo = 1,
        Video = 2,
        Others = 3,
        Email = 4,
        Comment = 5,
        TalentLeave = 6,
        Campaign = 7,
        Contact = 8
    }

    public enum ActivityType
    {
        Email = 0,
        Call = 1,
        Upload = 2,
        Generic = 3,
        Absent = 4,
        Contact = 5,
        Campaign = 6
    }

    public class Activity
    {
        public int Id { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool IsRequired { get; set; }
        public List<Role> Roles { get; set; }
        public List<Data> Data { get; set; }
        public string AbsentName { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DayOff { get; set; }
        public bool IsReallyNotApproved { get; set; }
        public string ApproverName { get; set; }
        public string Reason { get; set; }
        public string CampaignName { get; set; }
        public bool IsRunning { get; set; }
        public List<ContactViewModel> Subscribers { get; set; }
        public string Discriminator { get; set; }

    }
    public class NodeCreateModel
    {
        public int Id { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool IsRequired { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime DayOff { get; set; }
        public string Reason { get; set; }
    }
    public class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public enum StateType
    {
        start = 0,
        end = 1,
        normal = 2
    }
    public class State
    {
        public int Id { get; set; }
        public StateType StateType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Role> Roles { get; set; }
        public DateTime ETA { get; set; }

    }
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Role> Roles { get; set; }
        public Node Parent { get; set; }
        public List<Node> Childs { get; set; }
        public int Level { get; set; }
        public bool IsCompleted { get; set; }
        public List<Action> Actions { get; set; }
    }
    public class TransitionRule
    {
        public int Id { get; set; }
        public State CurrentState { get; set; }
        public State NextState { get; set; }
        public Action Action { get; set; }
        public Node CurrentNode { get; set; }
        public Node NextNode { get; set; }
        public Trigger Trigger { get; set; }
        public TransitionRule() { }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
