using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public partial class Receita
    {
        public Receita()
        {
            ProdutoReceita = new HashSet<ProdutoReceita>();
        }

        [Key]
        [Column("Id_Receita")]
        public int IdReceita { get; set; }
        [StringLength(255)]
        public string Nome { get; set; }

        [InverseProperty("IdReceitaNavigation")]
        public virtual ICollection<ProdutoReceita> ProdutoReceita { get; set; }
    }
}
