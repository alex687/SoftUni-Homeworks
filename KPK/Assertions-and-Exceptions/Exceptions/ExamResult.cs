using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "Grade must be greater than zero");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade", "Min grade must be greater than zero");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("maxGrade", "Max grade must be greater than minGrade");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException("comments", "Comments cannot be null or empty");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
