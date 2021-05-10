using Lab.EF.Entities;
using Lab.EF.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ShippersLogic : BaseLogic, IABMLogic<Shippers>
    {
        public void Add(Shippers shipper)
        {
            try
            {
                context.Shippers.Add(shipper);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new FieldException();
            }
        }

        public void Delete(int id)
        {
            var shipper = GetShipperIfFound(id);
            context.Shippers.Remove(shipper);
            context.SaveChanges();
        }

        public List<Shippers> GetAll()
        {
            return context.Shippers.ToList();
        }

        public void Update(Shippers shipper)
        {
            var shipperUpdate = GetShipperIfFound(shipper.ShipperID);
            try
            {
                shipperUpdate.CompanyName = shipper.CompanyName;
                shipperUpdate.Phone = shipper.Phone;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new FieldException();
            }
        }
        public Shippers GetOne(int id)
        {
            var shipper = GetShipperIfFound(id);
            return shipper;
        }
        private Shippers GetShipperIfFound(int id)
        {
            var shipper = context.Shippers.Find(id);
            if(shipper == null)
            {
                throw new NotFoundException();
            }
            return shipper;
        }
        public List<Shippers> SelecTop(int value)
        {
            var shippers = (from shipper in context.Shippers
                            select shipper).Take(value);
            return shippers.ToList();
        }
    }
}
