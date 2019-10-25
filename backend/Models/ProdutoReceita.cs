using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Produto_Receita")]
    public partial class ProdutoReceita
    {
        [Key]
        [Column("Id_Produto_Receita")]
        public int IdProdutoReceita { get; set; }
        [Column("Id_Produto")]
        public int? IdProduto { get; set; }
        [Column("Id_Receita")]
        public int? IdReceita { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produto.ProdutoReceita))]
        public virtual Produto IdProdutoNavigation { get; set; }
        [ForeignKey(nameof(IdReceita))]
        [InverseProperty(nameof(Receita.ProdutoReceita))]
        public virtual Receita IdReceitaNavigation { get; set; }
    }
}
