namespace ATM.Console.Widraw
{
    using System;

    using ATM.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Card Pin:");
            string cardPin = Console.ReadLine();

            Console.WriteLine("Card Number:");
            string cardNumber = Console.ReadLine();

            Console.WriteLine("Ammount:");
            decimal ammount = decimal.Parse(Console.ReadLine());

            var atmData = new AtmSystemData();

            AtmDao.WidrawMoney(ammount, cardPin, cardNumber, atmData);

            //AtmDao.WidrawMoney(50, "1111", "7894787426", atmData);
        }
    }
}
