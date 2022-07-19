using OjaIle.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ojaIle.abstraction
{
    public interface IPropertyItemServices
    {
        void SavePropertyItem(PropertyItem value);
        void DeletePropertyItem();
        void UpdatePropertyItem(string name, PropertyItem value);
        PropertyItem GetPropertyItemByName(string name);
        PropertyItem GetValue(string name, PropertyItem defaultValue);
        PropertyItem GetPropertyItemById(int Id);
        List<PropertyItem> GetPropertyItem();
    }
}
