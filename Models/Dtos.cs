namespace DSALab.Models
{
    // Array requests

    public class InsertEndRequest
    {
        public int Value { get; set; }
    }

    public class InsertBeginningRequest
    {
        public int Value { get; set; }
    }

    public class InsertPositionRequest
    {
        public int Position { get; set; }
        public int Value { get; set; }
    }

    public class DeletePositionRequest
    {
        public int Position { get; set; }
    }

    public class UpdateRequest
    {
        public int Position { get; set; }
        public int NewValue { get; set; }
    }

    public class SearchRequest
    {
        public int Key { get; set; }
    }

    // Student requests

    public class AddStudentRequest
    {
        public int RollNumber { get; set; }
    }

    public class UpdateStudentRequest
    {
        public int OldRollNumber { get; set; }
        public int NewRollNumber { get; set; }
    }

    public class DeleteStudentRequest
    {
        public int RollNumber { get; set; }
    }
}