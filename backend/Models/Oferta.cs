using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public partial class Oferta
    {
        [Key]
        [Column("Id_Oferta")]
        public int IdOferta { get; set; }
        [Column("Id_Produto")]
        public int? IdProduto { get; set; }
        [Column("Id_Usuario")]
        public int? IdUsuario { get; set; }
        public int? Quantidade { get; set; }
        [StringLength(255)]
        public string Preco { get; set; }
        [Column("Foto_Url", TypeName = "text")]
        public string FotoUrl { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(Produto.Oferta))]
        public virtual Produto IdProdutoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Oferta))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
