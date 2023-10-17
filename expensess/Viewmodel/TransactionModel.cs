using System;
using System.Collections.Generic;
using System.Text;

namespace expensess.Viewmodel
{
    public class TransactionModel
    {
        public List<TransactionViewModel> Get()
        {
            List<TransactionViewModel> list = new List<TransactionViewModel>();
            list.Add(new TransactionViewModel { Name = "Sent", Description = "Payment Sent", Amount = "$120", Img = "https://img.icons8.com/cotton/2x/transfer-money.png" });
            list.Add(new TransactionViewModel { Name = "Receive", Description = "Payment Receive", Amount = "$200", Img = "https://img.icons8.com/cotton/2x/transfer-money.png" });
            list.Add(new TransactionViewModel { Name = "Loan", Description = "Home Loan", Amount = "#582", Img = "https://img.icons8.com/cotton/2x/transfer-money.png" });
            list.Add(new TransactionViewModel { Name = "EMI", Description = "Emi of Product", Amount = "$785", Img = "https://img.icons8.com/cotton/2x/transfer-money.png" });
            list.Add(new TransactionViewModel { Name = "Credit Card", Description = "Credit Card Payment", Amount = "$587", Img = "https://img.icons8.com/cotton/2x/transfer-money.png" });
            list.Add(new TransactionViewModel { Name = "Shopping", Description = "Online Shopping", Amount = "$785", Img = "https://img.icons8.com/cotton/2x/transfer-money.png" });
            list.Add(new TransactionViewModel { Name = "Petrol", Description = "Petrol Payment", Amount = "$258", Img = "https://img.icons8.com/cotton/2x/transfer-money.png" });
            return list;
        }
    }
}
