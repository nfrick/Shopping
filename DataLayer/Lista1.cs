using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataLayer {
    [MetadataType(typeof(ListaMetadata))]
    public partial class Lista {
        // Note this class has nothing in it.  It's just here to add the class-level attribute.

        public override string ToString() => $"{Data:dd/MM/yyyy} - {Loja.Nome} - {Descricao}";

        public EditControl EControl => new EditControl(ID, !Itens.Any());
    }

    public class ListaMetadata {
        // Name the field the same as EF named the property - "FirstName" for example.
        // Also, the type needs to match.  Basically just redeclare it.
        // Note that this is a field.  I think it can be a property too, but fields definitely should work.


        public int ID { get; set; }


        // https://stackoverflow.com/questions/43820926/specify-date-format-in-mvc5-dd-mm-yyyy
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data é obrigatória (mesmo que seja apenas estimada)")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Data { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Descricao { get; set; }

        [Display(Name = "Loja")]
        [Required(ErrorMessage = "Loja é obrigatória")]
        public int LojaID { get; set; }

        [UIHint("BoolSimNao")]
        public bool Aberta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Itens { get; set; }

        public virtual Loja Loja { get; set; }
    }
}