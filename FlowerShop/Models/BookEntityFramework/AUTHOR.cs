//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlowerShop.Models.BookEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class AUTHOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUTHOR()
        {
            this.WROTEs = new HashSet<WROTE>();
            this.WROTEs1 = new HashSet<WROTE>();
            this.WROTEs2 = new HashSet<WROTE>();
        }
    
        public int AUTHOR_NUM { get; set; }
        public string AUTHOR_LAST { get; set; }
        public string AUTHOR_FIRST { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WROTE> WROTEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WROTE> WROTEs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WROTE> WROTEs2 { get; set; }
    }
}
