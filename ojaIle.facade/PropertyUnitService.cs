using ojaIle.abstraction;
using OjaIle.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ojaIle.facade
{
    public class PropertyUnitService : IPropertyUnitService
    {
        private readonly OjaileContext _db;
        public PropertyUnitService(OjaileContext db)
        {
            _db = db;
        }
        public void DeletePropertyUnit()
        {
            throw new NotImplementedException();
        }

        public List<PropertyUnit> GetPropertyUnit()
        {
            throw new NotImplementedException();
        }

        public PropertyUnit GetPropertyUnitById(int Id)
        {
            throw new NotImplementedException();
        }

        public PropertyUnit GetPropertyUnitByName(string name)
        {
            throw new NotImplementedException();
        }

        public PropertyUnit GetValue(string name, PropertyUnit defaultValue)
        {
            throw new NotImplementedException();
        }

        public void SavePropertyUnit(PropertyUnit value)
        {
            if (value != null)
            {
                _db.PropertyUnits.Add(value);
                _db.SaveChanges();
            }
        }

        public void UpdatePropertyUnit(string name, PropertyUnit value)
        {
            throw new NotImplementedException();
        }
    }
}
