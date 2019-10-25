using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Oferta = new HashSet<Oferta>();
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }
        [Column("Id_Endereco")]
        public int? IdEndereco { get; set; }
        [Column("Id_Tipo_Usuario")]
        public int? IdTipoUsuario { get; set; }
        [Column("Nome_Razao_Social")]
        [StringLength(255)]
        public string NomeRazaoSocial { get; set; }
        [Column("CPF_CNPJ")]
        [StringLength(14)]
        public string CpfCnpj { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Senha { get; set; }
        [StringLength(255)]
        public string Celular { get; set; }

        [ForeignKey(nameof(IdEndereco))]
        [InverseProperty(nameof(Endereco.Usuario))]
        public virtual Endereco IdEnderecoNavigation { get; set; }
        [ForeignKey(nameof(IdTipoUsuario))]
        [InverseProperty(nameof(TipoUsuario.Usuario))]
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Oferta> Oferta { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
