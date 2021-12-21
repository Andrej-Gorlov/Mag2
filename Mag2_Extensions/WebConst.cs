using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2_Extensions
{
    public static class WebConst
    {
        public const string ImagePath = @"\images\product\";

        //key для доступа к сеансу(SessionExtension)
        public const string SessionCart = "ShoppingCartSession";
        public const string SessionInquiryId = "InquirySession";

        public const string AdminRole = "Admin";
        public const string CustomerRole = "Customer";


        public const string EmailAdmin = "zverekane@yandex.ru";

        public const string CategoryName = "Category";
        public const string ApplicationTypeName = "ApplicationType";

        public const string Success = "Success";
        public const string Error = "Error";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public static readonly IEnumerable<string> listStatus = new ReadOnlyCollection<string>(
           
            new List<string>
            {
                StatusApproved, StatusCancelled,StatusInProcess,StatusPending,StatusRefunded,StatusShipped
            });
        
    }
}
