using Lab.EF.Entities;
using Lab.EF.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class TerritoriesLogic : BaseLogic
    {
        public void Add(Territories territorie)
        {
            try
            {
                context.Territories.Add(territorie);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new FieldException();
            }
        }

        public void Delete(string id)
        {
            var territorie = GetTerritorieIfFound(id);
            try
            {
                context.Territories.Remove(territorie);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("No se pudo eliminar!");
            }
        }

        public List<Territories> GetAll()
        {
            try
            {
                return context.Territories.ToList();
            }
            catch (Exception)
            {
                throw new Exception("No se pudo retornar registros!");
            }
        }

        public void Update(Territories territorie)
        {
            var territorieUpdate = GetTerritorieIfFound(territorie.TerritoryID);
            try
            {
                territorieUpdate.TerritoryDescription = territorie.TerritoryDescription;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw new FieldException();
            }
        }
        private Territories GetTerritorieIfFound(string id)
        {
            var territorie = context.Territories.Find(id);
            if (territorie == null)
            {
                throw new NotFoundException();
            }
            return territorie;
        }
        public List<TerritoriesJoinInfo> JoinRegions()
        {
            try
            {
                var territoriesList = from territories in context.Territories
                                      join regions in context.Region on
                                        territories.RegionID equals regions.RegionID
                                      select new TerritoriesJoinInfo()
                                      {
                                          id = territories.TerritoryID,
                                          descripcion = territories.TerritoryDescription,
                                          region = regions.RegionDescription,
                                          regionID = regions.RegionID
                                      };
                return territoriesList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
