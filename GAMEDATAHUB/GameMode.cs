//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GAMEDATAHUB
{
    using System;
    using System.Collections.Generic;
    
    public partial class GameMode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GameMode()
        {
            this.GameModeItem = new HashSet<GameModeItem>();
        }
    
        public int GameModeID { get; set; }
        public string GamemodeName { get; set; }
        public string Images { get; set; }
        public string Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameModeItem> GameModeItem { get; set; }
    }
}