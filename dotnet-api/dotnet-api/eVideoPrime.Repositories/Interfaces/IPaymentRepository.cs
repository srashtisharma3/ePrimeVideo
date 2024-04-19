using eVideoPrime.Core.Entities;
using eVideoPrime.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVideoPrime.Core.Interfaces
{
    public interface IPaymentRepository : IRepository<PaymentDetail>
    {
        IEnumerable<PaymentDetail> GetAllUsersPayment(int UserId);
    }
}
