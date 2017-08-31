using System.ComponentModel.DataAnnotations;

namespace DataLayer {
    [MetadataType(typeof(CategoriaMetadata))]
    [ValidateUniqueCategoria(ErrorMessage = "Categoria já cadastrada!")]
    public partial class Categoria {
        // Note this class has nothing in it.  It's just here to add the class-level attribute.

        public override string ToString() {
            return Nome;
        }
    }

    public class CategoriaMetadata {
        // Name the field the same as EF named the property - "FirstName" for example.
        // Also, the type needs to match.  Basically just redeclare it.
        // Note that this is a field.  I think it can be a property too, but fields definitely should work.


        public int ID { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        [StringLength(30, MinimumLength = 4, ErrorMessage="{0} precisa ter entre {2} e {1} letras.")]
        public string Nome { get; set; }
    }
}
