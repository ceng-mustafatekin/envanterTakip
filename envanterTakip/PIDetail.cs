//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace envanterTakip
{
    using System;
    using System.Collections.Generic;
    
    public partial class PIDetail
    {
        public long pid_id { get; set; }
        public long pid_purchaseID { get; set; }
        public int pid_proID { get; set; }
    
        public virtual purchaseInvoice purchaseInvoice { get; set; }
    }
}