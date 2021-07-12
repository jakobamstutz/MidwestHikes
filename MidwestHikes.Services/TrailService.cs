using MidwestHikes.Data;
using MidwestHikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwestHikes.Services
{
    public class TrailService
    {
        private readonly ApplicationDbContext _context;
        public TrailService()
        {
            _context = new ApplicationDbContext();
        }

        public bool CreateTrail(TrailCreate model)
        {
            var entity =
                new trail()
                {
                    ParkId = model.ParkId,
                    TrailName = model.TrailName,
                    TrailDesc = model.TrailDesc,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trail.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TrailListTrail> GetTrails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Trail
                        .Select(
                            e =>
                                new TrailListTrail
                                {
                                    ParkName = e.Park.ParkName,
                                    TrailId = e.TrailId,
                                    TrailName = e.TrailName,
                                    TrailDesc = e.TrailDesc
                                });
                return query.ToArray();

            }
        }

        public TrailDetails GetTrailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trail
                        .Single(e => e.TrailId == id);
                return
                            new TrailDetails
                            {
                                TrailId = entity.TrailId,
                                TrailName = entity.TrailName,
                                TrailDesc = entity.TrailDesc
                            };


            }
        }

        public bool UpdateTrail(TrailEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trail
                        .Single(e => e.TrailId == model.TrailId);

                entity.TrailName = model.TrailName;
                entity.TrailDesc = model.TrailDesc;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTrail(int trailId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trail
                        .Single(e => e.TrailId == trailId);

                ctx.Trail.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}