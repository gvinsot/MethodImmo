//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MethodImmo.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Commentaire
    {
        public long Id { get; set; }
        public string Contenu { get; set; }
        public string DateDeCreation { get; set; }
    
        public virtual Contrat CommentaireDeContrat { get; set; }
        public virtual Action CommentaireDAction { get; set; }
        public virtual Personne CommentaireDePersonne { get; set; }
        public virtual Lot CommentaireDeLot { get; set; }
        public virtual Immeuble CommentaireDeImmeuble { get; set; }
        public virtual Individu Auteur { get; set; }
    }
}
