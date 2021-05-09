using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class TerritoriesLogic : BaseLogic, IABMLogic<Territories>
    {
        public void Add(Territories territorie)
        {
            context.Territories.Add(territorie);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var territorie = context.Territories.Find(id);
            context.Territories.Remove(territorie);
            context.SaveChanges();
        }

        public List<Territories> GetAll()
        {
            return context.Territories.ToList();
        }

        public void Update(Territories territorie)
        {
            var territorieUpdate = context.Territories.Find(territorie.TerritoryID);
            territorieUpdate.TerritoryDescription = territorie.TerritoryDescription;
            territorieUpdate.RegionID = territorie.RegionID;
            context.SaveChanges();
        }
        public List<TerritoriesJoinInfo> JoinRegions()
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
    }
}
