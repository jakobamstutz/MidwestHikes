using MidwestHikes.Data;
using MidwestHikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwestHikes.Services
{
    public class ParkService
    {
        private readonly ApplicationDbContext _context;
        public ParkService()
        {
            _context = new ApplicationDbContext();
        }
        public bool CreatePark(ParkCreate model)
        {
            var entity =
                new park()
                {

                    StateId = model.StateId,
                    ParkName = model.ParkName,
                    ParkDesc = model.ParkDesc

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Park.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<park> GetParksList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Park.ToList();
            }
        }
        public IEnumerable<ParkListPark> GetParks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Park
                        .Select(
                            e =>
                                new ParkListPark
                                {
                                    ParkId = e.ParkId,
                                    ParkName = e.ParkName,
                                    ParkDesc = e.ParkDesc
                                });
                return query.ToArray();

            }
        }

        public ParkDetail GetParkById(int id)
        { 
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Park
                
                        .Single(e => e.ParkId == id);
                return
                            new ParkDetail
                            {
                                ParkId = entity.ParkId,
                                ParkName = entity.ParkName,
                                ParkDesc = entity.ParkDesc,
                            };
                        //        Trail = ctx.Trail
                        //        .Where(t => t.ParkId == entity.ParkId)
                        //.Select(t => new TrailListTrail()
                        //{
                        //    TrailId = t.TrailId,
                        //    TrailName = t.TrailName,
                        //    TrailDesc = t.TrailDesc
                        //}
                        //.ToList())
                        //
                        


            }
        }

        public bool UpdatePark(ParkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Park
                        .Single(e => e.ParkId == model.ParkId);

                entity.ParkName = model.ParkName;
                entity.ParkDesc = model.ParkDesc;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePark(int parkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Park
                        .Single(e => e.ParkId == parkId);

                ctx.Park.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}