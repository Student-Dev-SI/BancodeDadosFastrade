using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public partial class Pedido
    {
        [Key]
        [Column("Id_Pedido")]
        public int IdPedido { get; set; }
        [Column("Id_Produto")]
        public int? IdProduto { get; set; }
        [Column("Id_Usuario")]
        public int? IdUsuario { get; set; }
        public int? Quantidade { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produto.Pedido))]
        public virtual Produto IdProdutoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Pedido))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
