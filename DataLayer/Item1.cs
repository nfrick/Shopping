using System.ComponentModel.DataAnnotations;

namespace DataLayer {
    [MetadataType(typeof(ItemMetadata))]
    public partial class Item {
        // Note this class has nothing in it.  It's just here to add the class-level attribute.

        public decimal? Subtotal => QtdReal * Preco;

        public override string ToString() => Produto.Nome;

        public EditControl EControl => new EditControl(ID, !(QtdReal > 0));
    }

    public class ItemMetadata {
        // Name the field the same as EF named the property - "FirstName" for example.
        // Also, the type needs to match.  Basically just redeclare it.
        // Note that this is a field.  I think it can be a property too, but fields definitely should work.


        public int ID { get; set; }

        [Display(Name = "Lista")]
        [Required(ErrorMessage = "Lista é obrigatório")]
        public int ListaID { get; set; }

        [Display(Name = "Produto")]
        [Required(ErrorMessage = "Produto é obrigatório")]
        public int ProdutoID { get; set; }

        [Display(Name = "Qtd Prevista")]
        [Range(0.01, 50, ErrorMessage = "{0} deve ser um número entre {1} e {2}.")]
        public decimal? QtdPrevista { get; set; }

        [Display(Name = "Qtd Real")]
        [Range(0, 50, ErrorMessage = "{0} deve ser um número entre {1} e {2}.")]
        public decimal? QtdReal { get; set; }

        [StringLength(20, ErrorMessage = "{0} deve ter no máximo {1} letras.")]
        public string Marca { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        [Range(0.01, 300, ErrorMessage = "{0} deve ser um número entre {1} e {2}.")]
        public decimal? Preco { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Subtotal { get; }

        [Display(Name = "Lista")]
        public virtual Lista Lista { get; set; }


        [Display(Name = "Produto")]
        public virtual Produto Produto { get; set; }
    }
}