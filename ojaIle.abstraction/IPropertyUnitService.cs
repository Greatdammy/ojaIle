using OjaIle.data.Models;
using System.Collections.Generic;

namespace ojaIle.abstraction
{
    public interface IPropertyUnitService
    {
        void SavePropertyUnit(PropertyUnit value);
        void DeletePropertyUnit();
        void UpdatePropertyUnit(string name, PropertyUnit value);
        PropertyUnit GetPropertyUnitByName(string name);
        PropertyUnit GetValue(string name, PropertyUnit defaultValue);
        PropertyUnit GetPropertyUnitById(int Id);
        List<PropertyUnit> GetPropertyUnit();

    }
}