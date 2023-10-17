using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace expensess.Viewmodel
{
    public class CardModel
    {
        public List<CardViewModel> Get()
        {
            List<CardViewModel> list = new List<CardViewModel>();
            list.Add(new CardViewModel { Balance = "$20,000", BgColor = Color.FromHex("#F88C4B"), Name = "VISA", Number = "1234 5678 8955 5455" });
            list.Add(new CardViewModel { Balance = "$20,000", BgColor = Color.FromHex("#313247"), Name = "VISA", Number = "1234 5678 8955 5455" });
            list.Add(new CardViewModel { Balance = "$20,000", BgColor = Color.FromHex("#8937F2"), Name = "VISA", Number = "1234 5678 8955 5455" });
            list.Add(new CardViewModel { Balance = "$20,000", BgColor = Color.FromHex("#1C1C25"), Name = "VISA", Number = "1234 5678 8955 5455" });
            list.Add(new CardViewModel { Balance = "$20,000", BgColor = Color.FromHex("#5567FB"), Name = "VISA", Number = "1234 5678 8955 5455" });
            return list;
        }
    }
}
