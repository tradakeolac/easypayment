using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayment.Configuration
{
    public interface IPaymentSection
    {
        EasyPaymentCollection Settings { get; }
    }
}
