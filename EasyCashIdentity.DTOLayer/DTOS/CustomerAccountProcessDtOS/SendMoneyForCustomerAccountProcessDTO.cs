using EasyCashIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.DTOLayer.DTOS.CustomerAccountProcessDtOS
{
    public class SendMoneyForCustomerAccountProcessDTO
    {
        public int CustomerAccountProcessID { get; set; }
        public string Process { get; set; }
       
        public DateTime ProcessDate { get; set; }

        public int SenderID { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public int ReceiverID { get; set; }

    }
}
