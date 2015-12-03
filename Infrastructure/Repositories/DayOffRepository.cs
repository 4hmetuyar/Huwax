using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huwax.Dal;
using Infrastructure.Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{


    public interface IDayOffRepository : IGenericRepository<DayOff>
    {
        DayOff AddNewDayOffByDayOffModel(DayOffModel model);
    }

    public class DayOffRepository : GenericRepository<DayOff>, IDayOffRepository
    {
        public DayOffRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public DayOff AddNewDayOffByDayOffModel(DayOffModel model)
        {
            try
            {
                var add = new DayOff
                {
                    IsDeleted = false,
                    CreatedDate = model.CreatedDate,
                    Date = model.Date,
                    CratedById = model.CratedById,
                    EndDate = model.EndDate,
                    PersonnelId = model.PersonnelId,
                    StartDate = model.StartDate,
                    UserId = model.UserId

                };
                Add(add);
                Commit();
                return add;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
