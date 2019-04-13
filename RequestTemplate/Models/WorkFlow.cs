using System.ComponentModel.DataAnnotations.Schema;

namespace RequestTemplate.Models
{
    public class WorkFlow
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        [ForeignKey("RequestId")]
        public Request Request { get; set; }
        public StageStatus Start { get; set; }
        public StageStatus End { get; set; }
        public string CurrentStage { get; set; }

        public StageStatus Stage1 { get; set; }
        public string Name1 { get; set; }
        public string Task1 { get; set; }
        public string Assignee1 { get; set; }
        public string Owner1 { get; set; }
        public string File1 { get; set; }

        public StageStatus Stage2 { get; set; }
        public string Name2 { get; set; }
        public string Task2 { get; set; }
        public string Assignee2 { get; set; }
        public string Owner2 { get; set; }
        public string File2 { get; set; }

        public StageStatus Stage3 { get; set; }
        public string Name3 { get; set; }
        public string Task3 { get; set; }
        public string Assignee3 { get; set; }
        public string Owner3 { get; set; }
        public string File3 { get; set; }

        public StageStatus Stage4 { get; set; }
        public string Name4 { get; set; }
        public string Task4 { get; set; }
        public string Assignee4 { get; set; }
        public string Owner4 { get; set; }
        public string File4 { get; set; }

        public StageStatus Stage5 { get; set; }
        public string Name5 { get; set; }
        public string Task5 { get; set; }
        public string Assignee5 { get; set; }
        public string Owner5 { get; set; }
        public string File5 { get; set; }
    }

    public enum StageStatus
    {
        Pending = 1,
        Canceled = 2,
        Completed = 3,
        Accepted = 4,
        Approved = 5
    }
}
