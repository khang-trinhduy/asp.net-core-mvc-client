namespace RequestTemplate.Models.CompleteTaskModel
{
    public class CompleteTaskModel
    {
        public int RequestId { get; set; }
        public int TaskId { get; set; }
        public bool IsDone { get; set; }
        public bool AutoAdvance { get; set; }
        
    }
    
}