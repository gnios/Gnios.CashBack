using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gnios.CashBack.Api.GenericControllers
{
    public class OptionsFilter
    {
        public List<string> id_like { get; set; }
        public string _take { get; set; }
        public string _sort { get; set; }
        public string _skip { get; set; }
        public string _page { get; set; }
        public IList<string> _filter { get; set; }

    }
}
