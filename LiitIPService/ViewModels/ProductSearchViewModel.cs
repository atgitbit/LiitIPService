using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiitIPService.ViewModels
{
    public class ProductSearchViewModel
    {
            public string q { get; set; }
            public string SortOrder { get; set; }
            public string SortField { get; set; }
            public string OppositeSortOrder { get; set; }
            public int Page { get; set; }
            public int TotalPages { get; set; }
            public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

    }
}
