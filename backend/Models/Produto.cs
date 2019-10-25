using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Oferta = new HashSet<Oferta>();
            Pedido = new HashSet<Pedido>();
            ProdutoReceita = new HashSet<ProdutoReceita>();
        }

        [Key]
        [Column("Id_Produto")]
        public int IdProduto { get; set; }
        [Column("Id_Cat_Produto")]
        public int? IdCatProduto { get; set; }
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string Validade { get; set; }

        [ForeignKey(nameof(IdCatProduto))]
        [InverseProperty(nameof(CatProduto.Produto))]
        public virtual CatProduto IdCatProdutoNavigation { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<Oferta> Oferta { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<Pedido> Pedido { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<ProdutoReceita> ProdutoReceita { get; set; }
    }
}
