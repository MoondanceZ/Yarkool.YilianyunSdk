using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qc.YilianyunSdk.Models
{
    public class PrintTextOutputModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 商户系统内部订单号
        /// </summary>
        public string Origin_Id { get; set; }
    }
}
