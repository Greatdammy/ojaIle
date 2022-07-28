using Microsoft.EntityFrameworkCore;
using ojaIle.abstraction;
using OjaIle.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ojaIle.facade
{
    public class PropertyImageService : IPropertyImageService
    {
        private readonly OjaileContext _db;
        public PropertyImageService(OjaileContext db)
        {
            _db = db;
        }
        public void DeletePropertyImage(int Id)
        {
            var propertyImage = _db.PropertyImages.FirstOrDefault(x => x.Id == Id);
            _db.Entry(propertyImage).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public List<PropertyImage> GetPropertyImage()
        {
            return _db.PropertyImages.ToList();
        }

        public PropertyImage GetPropertyImageById(int Id)
        {
            if (Id != 0)
            {
                var result = _db.PropertyImages.Where(x => x.Id == Id).FirstOrDefault();
                return result;

            }

            else
                return null;
        }

        public List<PropertyImage> GetPropertyImageByPropertyUnitId(long unitId)
        {
            if (unitId != null)
            {
                return _db.PropertyImages.Where(m => m.PropertyUnitId == unitId).ToList();
            }
            return null;
        }

        public void SavePropertyImage(PropertyImage value)
        {
            if (value != null)
            {
                _db.PropertyImages.Add(value);
                _db.SaveChanges();
            }
        }

        public void UpdatePropertyImage(int id, PropertyImage value)
        {
            throw new NotImplementedException();
        }
    }
}
