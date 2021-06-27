using MidwestHikes.Data;
using MidwestHikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwestHikes.Services
{
    public class StateService
    {
        private readonly ApplicationDbContext _context;
        public StateService()
        {
            _context = new ApplicationDbContext();
        }
        public bool CreateState(StateCreate model)
        {
            var entity =
                new state()
                {
                    
                    StateName = model.StateName,
                   
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.State.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StateListState> GetStates()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .State
                        .Select(
                            e =>
                                new StateListState
                                {
                                    StateId = e.StateId,
                                    StateName = e.StateName
                                });
                return query.ToArray();

            }
        }

        public StateDetail GetStateById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .State
                        .Single(e => e.StateId == id );
                return
                            new StateDetail
                            {
                                StateId = entity.StateId,
                                StateName = entity.StateName
                            };


            }
        }

        public bool UpdateState(StateEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .State
                        .Single(e => e.StateId == model.StateId );

                entity.StateName = model.StateName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteState(int stateId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .State
                        .Single(e => e.StateId == stateId );

                ctx.State.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}