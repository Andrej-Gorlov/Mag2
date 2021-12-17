using Braintree;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag2_Extensions.BrainTree
{
    public class BrainTreeGet : IBrainTreeGate
    {
        public BrainTreeSettings options { get; set; }
        public IBraintreeGateway braintreeGateway { get; set; }
        public BrainTreeGet(IOptions<BrainTreeSettings> options)
        {
            this.options = options.Value;
        }
        public IBraintreeGateway CreateGatewa()// шлюз платежной системы!!!
        {
            return new BraintreeGateway(this.options.Environment, this.options.MerchantId, this.options.PublicKey, this.options.PrivateKey);
        }

        public IBraintreeGateway GetGatewa()
        {
            if (braintreeGateway == null)
            {
                braintreeGateway = CreateGatewa();
            }
            return braintreeGateway;
        }
    }
}
