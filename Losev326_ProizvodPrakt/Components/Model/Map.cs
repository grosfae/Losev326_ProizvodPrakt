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
    
    public partial class Map
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Map()
        {
            this.MapPhoto = new HashSet<MapPhoto>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string History { get; set; }
        public string Specials { get; set; }
        public byte[] Image { get; set; }
        public int TypeArticleId { get; set; }
    
        public virtual TypeArticle TypeArticle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MapPhoto> MapPhoto { get; set; }
    }
}
