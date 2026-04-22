using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GHTKFeeResponse_DTO
    {
            public bool success { get; set; }
            public Fee fee { get; set; }

            public class Fee
            {
                public int fee { get; set; }
                public int insurance_fee { get; set; }
                public string name { get; set; }
                public string delivery_type { get; set; }
            }
        

    }
}
