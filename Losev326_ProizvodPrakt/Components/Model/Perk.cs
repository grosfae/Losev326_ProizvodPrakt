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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int TypePerkId { get; set; }
        public int TypeArticleId { get; set; }
        public int CharacterId { get; set; }
    
        public virtual Character Character { get; set; }
        public virtual TypeArticle TypeArticle { get; set; }
        public virtual TypePerk TypePerk { get; set; }
    }
}
