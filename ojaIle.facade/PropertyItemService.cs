using Microsoft.EntityFrameworkCore;
using ojaIle.abstraction;
using OjaIle.data.Models;

namespace ojaIle.facade
{
    public class PropertyItemService : IPropertyItemServices
    {
        private readonly OjaileContext _contex;
        public PropertyItemService(OjaileContext contex)
        {
            _contex = contex;
        }

        public void DeletePropertyItem(int Id)
        {
            var propertyItem = _contex.PropertyItems.FirstOrDefault(x => x.Id == Id);
            _contex.Entry(propertyItem).State = EntityState.Deleted;
            _contex.SaveChanges();
        }

        public List<PropertyItem> GetPropertyItem()
        {
            return _contex.PropertyItems.ToList();
        }

        public PropertyItem GetPropertyItemById(int Id)
        {
            if (Id != 0)
            {
                var result = _contex.PropertyItems.Where(x => x.Id == Id).FirstOrDefault();
                return result;
            }

            else
                return null;
            //throw new NotImplementedException();
        }

        public PropertyItem GetPropertyItemByName(string name)
        {
            if (name != null)
            {
                return _contex.PropertyItems.Where(n => n.PropertyName == name).FirstOrDefault();
            }
            return null;
        }

        public List<PropertyItem> GetPropertyItemByUserId(string userId)
        {
            if (userId != null)
            {
                return _contex.PropertyItems.Where(n => n.UserId == userId).ToList();
            }
            return null;
        }

            public PropertyItem GetValue(string name, PropertyItem defaultValue)
            {
                throw new NotImplementedException();
            }

            public void SavePropertyItem(PropertyItem value)
            {
                if (value != null)
                {
                    _contex.PropertyItems.Add(value);
                    _contex.SaveChanges();
                }
                //throw new NotImplementedException();
            }

            public void SavePropertyItem()
            {
                throw new NotImplementedException();
            }

            public List<PropertyItem> SearchPropertyItem(string queryString)
            {
                if (queryString != null)
                {
                    return _contex.PropertyItems.Where(n => n.PropertyName == queryString || n.Address == queryString).ToList();
                }
                return null;
            }

            public void UpdatePropertyItem(int Id, PropertyItem value)
            {
                if (Id != 0)
                {
                    var _property = _contex.PropertyItems.FirstOrDefault(n => n.Id == Id);
                _property.Address = value.Address;
                _property.Created = DateTime.Now;
                _property.StateId = value.StateId;
                _property.CountryId = value.CountryId;
                _property.Lga = value.Lga;
                _property.PropertyDescription = value.PropertyDescription;
                _property.PropertyName = value.PropertyName;
                _property.PropertyTypeId = value.PropertyTypeId;
                _property.UserId = value.UserId;
                _property.CreatedBy = value.UserId;
                _contex.Entry(_property).State= EntityState.Modified;
                    _contex.SaveChanges();


                }
            }
        
    }
}