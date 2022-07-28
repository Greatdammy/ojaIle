using OjaIle.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ojaIle.abstraction
{
    public interface IPropertyImageService
    {
        void SavePropertyImage(PropertyImage value);
        void DeletePropertyImage(int Id);
        void UpdatePropertyImage(int id, PropertyImage value);
        PropertyImage GetPropertyImageById(int Id);
        List<PropertyImage> GetPropertyImage();
        List<PropertyImage> GetPropertyImageByPropertyUnitId(long unitId);
    }
}
