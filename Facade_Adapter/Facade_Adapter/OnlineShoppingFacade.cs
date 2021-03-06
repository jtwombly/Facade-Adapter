﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Adapter
{
    class OnlineShoppingFacade
    {
        IInventory inventory = new InventoryManager();
        ICosting costManger = new CostManager();
        IPaymentGateway paymentGateWay = new PaymentGatewayManager();
        ILogistics logistics = new LogisticsManager();

        public void FinalizeOrder(OrderDetails orderDetails)
        {
            inventory.Update(orderDetails.ProductNo);
            orderDetails.Price = costManger.ApplyDiscounts(orderDetails.Price, orderDetails.DiscountPercent);
            paymentGateWay.VerifyCardDetails(orderDetails.CardNo);
            paymentGateWay.ProcessPayment(orderDetails.CardNo, orderDetails.Price);
            logistics.ShipProduct(orderDetails.ProductName, orderDetails.Name, string.Format("{0}, {1}", orderDetails.AddressLine1, orderDetails.AddressLine2));
        }
    }
}
