using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag2_Extensions.BrainTree
{
    public interface IBrainTreeGate  //для входа в BrainTree скачиваем пакет BrainTree
    {
        // create шлюза для BrainTree
        IBraintreeGateway CreateGatewa();

        IBraintreeGateway GetGatewa();
    }
}
