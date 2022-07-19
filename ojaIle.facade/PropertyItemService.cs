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

        public void DeletePropertyItem()
        {
            throw new NotImplementedException();
        }

        public List<PropertyItem> GetPropertyItem()
        {
            return _contex.PropertyItems.ToList();
        }

        public PropertyItem GetPropertyItemById(int Id)
        {
            if(Id != 0)
            {
                var  result = _contex.PropertyItems.Where(x => x.Id == Id).FirstOrDefault();
                return result;
            }
           
            else
                return null;
            //throw new NotImplementedException();
        }

        public PropertyItem GetPropertyItemByName(string name)
        {
            throw new NotImplementedException();
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

        public void UpdatePropertyItem(string name, PropertyItem value)
        {
            throw new NotImplementedException();
        }
    }
}