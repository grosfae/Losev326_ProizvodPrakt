//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Losev326_ProizvodPrakt.Components.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Perk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Perk()
        {
            this.Character = new HashSet<Character>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FirstLevel { get; set; }
        public int SecondLevel { get; set; }
        public int ThirdLevel { get; set; }
        public byte[] Image { get; set; }
        public int TypePerkId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Character> Character { get; set; }
        public virtual TypePerk TypePerk { get; set; }
    }
}