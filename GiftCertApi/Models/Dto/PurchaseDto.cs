using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftCertApi.Models.Dto
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string Remarks { get; set; }
        public string PaymentMode { get; set; }
        public string CcNumber { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string CardType { get; set; }

        public List<GiftCertDto> GiftCerts { get; set; }
    }
}
