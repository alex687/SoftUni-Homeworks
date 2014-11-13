using System;

public class CSharpExam : Exam
{
    public CSharpExam(int score)
    {
        if (score < 0 || score > 100)
        {
            throw new ArgumentOutOfRangeException("score", "Score must be greater than zero and less than 100");
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
