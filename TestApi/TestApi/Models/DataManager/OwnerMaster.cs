using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models.Repository;

namespace TestApi.Models.DataManager
{
    public class OwnerMaster : IDataRepository<OwnerData>
    {
        readonly OwnerContext _ownerContext;

        public OwnerMaster(OwnerContext context)
        {
            _ownerContext = context;
        }
        public IEnumerable<OwnerData> GetAll()
        {
            return _ownerContext.Owners.ToList();
        }
        
        public OwnerData Get(string id)
        {
            return _ownerContext.Owners
                  .FirstOrDefault(o => o.OwnerEmail == id);
        }
        public void Add(OwnerData entity)
        {
            _ownerContext.Owners.Add(entity);
            _ownerContext.SaveChanges();
        }

        public void Update(OwnerData owner, OwnerData entity)
        {
            owner.OwnerId = entity.OwnerId;
            owner.OwnerName = entity.OwnerName;
            owner.OwnerContact = entity.OwnerContact;
            owner.OwnerEmail = entity.OwnerEmail;
            owner.Ownerpass = entity.Ownerpass;
            
            _ownerContext.SaveChanges();
        }
        public void Delete(OwnerData owner)
        {
            _ownerContext.Owners.Remove(owner);
            _ownerContext.SaveChanges();
        }

        //public OwnerData Get(long id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
