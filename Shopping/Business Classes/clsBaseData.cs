using System;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Shopping {
    [Serializable()]
    public class BaseData {
        [Category(@"1. Identificação"), ReadOnly(true)]
        public int ID { get; set; }

        [Browsable(false)]
        public bool IsNew => (ID == 0);

        [Browsable(false)]
        public bool Updated { get; set; }

        public BaseData() {
            ID = 0;
            Updated = false;
        }
        public BaseData(SqlDataReader r) {
            ID = (int)r["ID"];
            Updated = false;
        }
    }
}
