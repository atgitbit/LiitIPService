using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiitIPService.ViewModels
{
    public class AccountDetailViewModel
    {
        //public Account Account { get; set; }
        //public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public int TotalRowCount { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
