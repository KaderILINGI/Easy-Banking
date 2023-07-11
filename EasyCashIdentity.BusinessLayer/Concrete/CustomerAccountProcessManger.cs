using EasyCashIdentity.BusinessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Abstract;
using EasyCashIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.BusinessLayer.Concrete
{
	public class CustomerAccountProcessManger : ICustomerAccountProcessService
	{
		private readonly ICustomerAccountProcessDAL _customerAccountProcessDAL;

		public CustomerAccountProcessManger(ICustomerAccountProcessDAL customerAccountProcessDAL)
		{
			_customerAccountProcessDAL = customerAccountProcessDAL;
		}

		public void TDelete(CustomerAccountProcess t)
		{
			_customerAccountProcessDAL.Delete(t);
		}

		public CustomerAccountProcess TGetByID(int id)
		{
			return _customerAccountProcessDAL.GetByID(id);
		}

		public List<CustomerAccountProcess> TGetList()
		{
			return _customerAccountProcessDAL.GetList();
		}

		public void TInsert(CustomerAccountProcess t)
		{
			_customerAccountProcessDAL.Insert(t);
		}

		public void TUpdate(CustomerAccountProcess t)
		{
			_customerAccountProcessDAL.Update(t);
		}
	}
}
