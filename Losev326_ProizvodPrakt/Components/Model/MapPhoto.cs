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
    
    public partial class MapPhoto
    {
        public int Id { get; set; }
        public int MapId { get; set; }
        public byte[] ImagePath { get; set; }
    
        public virtual Map Map { get; set; }
    }
}