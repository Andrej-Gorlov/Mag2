using Braintree;
using Mag2_DataAcces.RepositoryPattern.IRepository;
using Mag2_Extensions;
using Mag2_Extensions.BrainTree;
using Mag2_Models;
using Mag2_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderHeaderRepository orderHeaderRepos;
        private readonly IOrderDetailRepository orderDetailRepos;
        private readonly IBrainTreeGate brain;

        [BindProperty]
        public OrderVM orderVM { get; set; }
        public OrderController(IOrderHeaderRepository orderHeaderRepos, IOrderDetailRepository orderDetailRepos,
            IBrainTreeGate brain)
        {
            this.orderHeaderRepos = orderHeaderRepos;
            this.orderDetailRepos = orderDetailRepos;
            this.brain = brain;
        }
        public IActionResult Index(string searchName=null,string searchEmail=null, string searchPhone=null, string Status=null)
        {
            OrderListVM orderListVM = new OrderListVM()
            {
                OrderHeaderList = this.orderHeaderRepos.GetAll(),
                StatuaList=WebConst.listStatus.ToList().Select(x=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text=x,
                    Value=x
                })
            };
            if (!string.IsNullOrEmpty(searchName))
            {
                orderListVM.OrderHeaderList = orderListVM.OrderHeaderList.Where(x => x.FullName.ToLower().Contains(searchName.ToLower()));
            }
            if (!string.IsNullOrEmpty(searchEmail))
            {
                orderListVM.OrderHeaderList = orderListVM.OrderHeaderList.Where(x => x.Email.ToLower().Contains(searchEmail.ToLower()));
            }
            if (!string.IsNullOrEmpty(searchPhone))
            {
                orderListVM.OrderHeaderList = orderListVM.OrderHeaderList.Where(x => x.PhoneNumber.ToLower().Contains(searchPhone.ToLower()));
            }
            if (!string.IsNullOrEmpty(Status)&& Status!= "--Order Status--")
            {
                orderListVM.OrderHeaderList = orderListVM.OrderHeaderList.Where(x => x.OrderStatus.ToLower().Contains(Status.ToLower()));
            }
            return View(orderListVM);
        }
        

        public IActionResult Details(int id)
        {
            orderVM = new OrderVM()
            {
                OrderHeader=this.orderHeaderRepos.FirstOrDefault(x=>x.Id==id),
                OrderDetail=this.orderDetailRepos.GetAll(x=>x.OrderHeaderId==id,includeProperties:"Product")
            };
            return View(orderVM);
        }

        [HttpPost]
        public IActionResult StartProcessing()
        {
            OrderHeader orderHeader = this.orderHeaderRepos.FirstOrDefault(x => x.Id == orderVM.OrderHeader.Id);
            orderHeader.OrderStatus = WebConst.StatusInProcess;
            this.orderHeaderRepos.Save();
            TempData[WebConst.Success] = "Order is In Processing";
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult ShipOrder()
        {
            OrderHeader orderHeader = this.orderHeaderRepos.FirstOrDefault(x => x.Id == orderVM.OrderHeader.Id);
            orderHeader.OrderStatus = WebConst.StatusShipped;
            orderHeader.ShippingDate = DateTime.Now;
            this.orderHeaderRepos.Save();
            TempData[WebConst.Success] = "Order shipped Susscessfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult CancelOrder()
        {
            OrderHeader orderHeader = this.orderHeaderRepos.FirstOrDefault(x => x.Id == orderVM.OrderHeader.Id);

            var gateway = this.brain.GetGatewa();
            Transaction transaction = gateway.Transaction.Find(orderHeader.TransactionId);

            if (transaction.Status==TransactionStatus.AUTHORIZED || transaction.Status == TransactionStatus.SUBMITTED_FOR_SETTLEMENT)
            {
                //no refund 
                Result<Transaction> resultvoid = gateway.Transaction.Void(orderHeader.TransactionId);
            }
            else
            {
                //refund 
                Result<Transaction> resultRefund = gateway.Transaction.Refund(orderHeader.TransactionId);
            }

            orderHeader.OrderStatus = WebConst.StatusRefunded;
            this.orderHeaderRepos.Save();
            TempData[WebConst.Success] = "Order cancelled Susscessfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateOrderDetails()
        {
            OrderHeader orderHeaderFromDb = this.orderHeaderRepos.FirstOrDefault(x => x.Id == orderVM.OrderHeader.Id);

            orderHeaderFromDb.FullName = orderVM.OrderHeader.FullName;
            orderHeaderFromDb.PhoneNumber = orderVM.OrderHeader.PhoneNumber;
            orderHeaderFromDb.StreetAddress = orderVM.OrderHeader.StreetAddress;
            orderHeaderFromDb.City = orderVM.OrderHeader.City;
            orderHeaderFromDb.State = orderVM.OrderHeader.State;
            orderHeaderFromDb.PostalCode = orderVM.OrderHeader.PostalCode;
            orderHeaderFromDb.Email = orderVM.OrderHeader.Email;

            this.orderHeaderRepos.Save();
            TempData[WebConst.Success] = "Order details update Susscessfully";
            return RedirectToAction("Details", "Order",new { id= orderHeaderFromDb.Id});
        }
    }
}
