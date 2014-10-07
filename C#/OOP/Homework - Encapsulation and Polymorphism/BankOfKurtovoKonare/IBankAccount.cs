namespace BankOfKurtovoKonare
{
    public interface IBankAccount : IInterestCalculatable
    {
        decimal Ballance { get;}
        
        decimal InterestRate { get; }
    
        Customer Customer { get; }
    }
}
