﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftCertWeb.Models
{
    public partial class GiftCert
    {
        public GiftCert()
        {
            GcOutlet = new HashSet<GcOutlet>();
            GcPurchase = new HashSet<GcPurchase>();
            GcRedemption = new HashSet<GcRedemption>();
            ServicesType = new HashSet<ServicesType>();
        }

        [DisplayName("Gc Type")]
        [Required]
        public int? GcTypeId { get; set; }
        [Required]
        public decimal? Value { get; set; }
        [DisplayName("Issuance Date")]
        [DisplayFormat(DataFormatString = @"{0:MM\/dd\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? IssuanceDate { get; set; }
        [DisplayName("DTI Permit No")]
        public string DtiPermitNo { get; set; }
        [DisplayName("Expiration Date")]
        [DisplayFormat(DataFormatString = @"{0:MM\/dd\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [DisplayName("QR Code")]
        public string QrCode { get; set; }
        public string Note { get; set; }
        public int? Status { get; set; }
        [Required]
        [DisplayName("Gift Cert No")]
        public int GiftCertNo { get; set; }

        public GcType GcType { get; set; }
        public ICollection<GcOutlet> GcOutlet { get; set; }
        public ICollection<GcPurchase> GcPurchase { get; set; }
        public ICollection<GcRedemption> GcRedemption { get; set; }
        public ICollection<ServicesType> ServicesType { get; set; }

        [NotMapped]
        public string ExpirationDateStr
        {
            get
            {
                return ExpirationDate != null ? Convert.ToDateTime(ExpirationDate).ToShortDateString() : string.Empty;
            }         
        }

        [NotMapped]
        public string GcCodeValue { get; set; }
        [NotMapped]
        public string ValueCurrency {
            get
            {
                return Value != null ? String.Format("P{0:C}", Convert.ToInt32(Value)).Replace("$", "").Replace(".00", "") : string.Empty;
            }
        }

        [NotMapped]
        public string ExpirationDatePrintFormat
        {
            get
            {
                return ExpirationDate != null ? Convert.ToDateTime(ExpirationDate).ToString("dd MMMM yyyy") : string.Empty;
            }
        }

    }
}
