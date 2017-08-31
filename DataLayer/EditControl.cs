using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public class EditControl {
        public int ID { get; }

        public bool ShowDelete { get; }


        public EditControl(int id, bool canDelete) {
            ID = id;
            ShowDelete = canDelete;
        }

    }
}
