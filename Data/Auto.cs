//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cars.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auto()
        {
            this.Rent = new HashSet<Rent>();
        }
    
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int ColorId { get; set; }
        public string ProductDateYear { get; set; }
        public string GovNumber { get; set; }
        public double Insurance { get; set; }
        public double DailyRentalCost { get; set; }
        public Nullable<bool> Available { get; set; }
        public double Cost { get; set; }
    
        public virtual Color Color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rent> Rent { get; set; }
    }
}
