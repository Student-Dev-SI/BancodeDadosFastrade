using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Cat_Produto")]
    public partial class CatProduto
    {
        public CatProduto()
        {
            Produto = new HashSet<Produto>();
        }

        [Key]
        [Column("Id_Cat_Produto")]
        public int IdCatProduto { get; set; }
        [StringLength(255)]
        public string Tipo { get; set; }

        [InverseProperty("IdCatProdutoNavigation")]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
