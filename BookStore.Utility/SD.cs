using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utility
{
    public static class SD
    {
        public const string ManagerRole = "Manager";
        public const string FrontDeskRole = "FrontDesk";
        public const string StaffRole = "Staff";
        public const string CustomerRole = "Customer";

        public const string StatusPending = "Pending_Payment";
        public const string StatusSubimitted = "Submitted_PaymentApproved";
        public const string StatusRejected = "Rejected_Payment";
        public const string StatusInProcess = "Being Process";
        public const string StatusReady = "Ready for pick up";
        public const string StatusCompleted = "Completed ";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded= "Refunded";

    }
}
