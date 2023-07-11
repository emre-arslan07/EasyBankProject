using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBankProject.DTO.DTOs.CustomerAccountProcessDTOs
{
    public class SendMoneyForCustomerAccountProcessDTO
    {
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string Description { get; set; }
    }
}
