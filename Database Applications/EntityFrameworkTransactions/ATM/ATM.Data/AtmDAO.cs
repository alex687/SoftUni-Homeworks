namespace ATM.Data
{
    using System;
    using System.Linq;

    public static class AtmDao
    {
        public static decimal WidrawMoney(decimal amount, string cardPin, string cardNumber, IAtmData atmData)
        {
            using (var transaction = atmData.BeginTransaction())
            {
                var currentCard = atmData.CardAccounts.Search(c => c.CardNumber == cardNumber && c.CardPIN == cardPin)
                    .FirstOrDefault();

                if (currentCard == null)
                {
                    transaction.Rollback();
                    throw new ArgumentNullException("There are no Card Account in database with this Pin and card number.");
                }

                if (currentCard.CardCash < amount)
                {
                    transaction.Rollback();
                    throw new InvalidOperationException("You dont have enought money.");
                }

                currentCard.CardCash -= amount;

                LogWithdrawalTransaction(cardNumber, amount, atmData);
                atmData.SaveChanges();
                transaction.Commit();

                return amount;
            }
        }

        private static void LogWithdrawalTransaction(string cardNumber, decimal amount, IAtmData atmData)
        {
            atmData.TransactionHistory.Add(new TransactionHistory
           {
               Amount = amount,
               CardNumber = cardNumber,
               TransactionDate = DateTime.Now
           });

            atmData.SaveChanges();
        }
    }
}
