using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gnios.CashBack.Api.GenericControllers
{
    [Serializable]
    public class OptionsFilter
    {
        public List<string> id_like { get; set; }
        public int _take { get; set; }
        public string _sort { get; set; }
        public int _skip { get; set; }
        public int _page { get; set; }
        public IList<string> _filter { get; set; }
        public string VersionObject { get { return HelperMD5.ComputeHash(HelperMD5.ObjectToByteArray(this)); }}

    }
}
