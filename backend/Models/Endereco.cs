using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        [Column("Id_Endereco")]
        public int IdEndereco { get; set; }
        [StringLength(255)]
        public string Rua { get; set; }
        [StringLength(255)]
        public string Bairro { get; set; }
        public int? Numero { get; set; }
        [StringLength(2)]
        public string Estado { get; set; }
        [Column("CEP")]
        [StringLength(9)]
        public string Cep { get; set; }

        [InverseProperty("IdEnderecoNavigation")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
