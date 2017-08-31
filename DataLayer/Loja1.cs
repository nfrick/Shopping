using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataLayer {
    [MetadataType(typeof(LojaMetadata))]
    [ValidateUniqueLoja(ErrorMessage = "Loja já cadastrada!")]
    public partial class Loja {
        // Note this class has nothing in it.  It's just here to add the class-level attribute.

        public override string ToString() => Nome;

        public EditControl EControl => new EditControl(ID, !Listas.Any());

    }

    public class LojaMetadata {
        // Name the field the same as EF named the property - "FirstName" for example.
        // Also, the type needs to match.  Basically just redeclare it.
        // Note that this is a field.  I think it can be a property too, but fields definitely should work.

        public int ID { get; set; }

        [Display(Name = "Loja")]
        [Required(ErrorMessage = "Nome da loja é obrigatório")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "{0} precisa ter entre {2} e {1} letras.")]
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:n9}", ApplyFormatInEditMode = true)]
        [Range(-179.999999999, 179.999999999, ErrorMessage = "{0} deve ser um número entre {1} e {2}.")]
        public double Latitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:n9}", ApplyFormatInEditMode = true)]
        [Range(-179.999999999, 179.999999999, ErrorMessage = "{0} deve ser um número entre {1} e {2}.")]
        public double Longitude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mapa> Mapas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lista> Listas { get; set; }
    }
}