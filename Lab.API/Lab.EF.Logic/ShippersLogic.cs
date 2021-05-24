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
            try
            {
                context.Shippers.Remove(shipper);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("No se pudo eliminar!");
            }
        }

        public List<Shippers> GetAll()
        {
            try
            {
                return context.Shippers.ToList();
            }
            catch (Exception)
            {
                throw new Exception("No se pudo retornar registros!");
            }
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
            try
            {
                var shipper = context.Shippers.Find(id);
                return shipper;
            }
            catch (Exception)
            {
                throw new NotFoundException();
            }
        }
        private Shippers GetShipperIfFound(int id)
        {
            var shipper = context.Shippers.Find(id);
            if (shipper == null)
            {
                throw new NotFoundException();
            }
            return shipper;
        }
        public List<Shippers> SelecTop(int value)
        {
            try
            {
                var shippers = (from shipper in context.Shippers
                                select shipper).Take(value);
                return shippers.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error al seleccionar los datos");
            }
        }
    }
}
