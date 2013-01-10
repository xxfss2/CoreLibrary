using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//

namespace Jiuzh.CoreBase
{
    public enum SortRules
    {
        /// <summary>
        /// 增序
        /// </summary>
        ESC = 1,
        /// <summary>
        /// 降序
        /// </summary>
        DESC = 0
    }
    public class PageBreakParam
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int DataCount { get; set; }
    }

    public class SortParam
    {
        public string SortCode { get; set; }
        public SortRules SortRule { get; set; }
    }
}
