using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ojaIle.abstraction;
using ojaIle.facade;
using ojaIle.webapi.Model;
using OjaIle.data.Models;
using System.Security.Claims;

namespace ojaIle.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyItemController : ControllerBase
    {
        private readonly IPropertyItemServices _propertyItem;


        public PropertyItemController(IPropertyItemServices propertyItem)
        {
            _propertyItem = propertyItem;

        }


        [HttpPost]
        [Route("CreateProperty")]
        public async Task<IActionResult> CreateProperty([FromBody] PropertyItemModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           // var Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userId = Id.FirstOrDefault().ToString();
            PropertyItem propertyItem = new PropertyItem();
            propertyItem.Address = model.Address;
            propertyItem.Created = DateTime.Now;
            propertyItem.StateId = model.StateId;
            propertyItem.CountryId = model.CountryId;
            propertyItem.Lga = model.Lga;
            propertyItem.PropertyDescription = model.PropertyDescription;
            propertyItem.PropertyName = model.PropertyName;
            propertyItem.PropertyTypeId = model.PropertyTypeId;
            propertyItem.UserId = model.UserId;
            propertyItem.CreatedBy = model.CreatedBy;


            _propertyItem.SavePropertyItem(propertyItem);

            return Ok(model);
        }

        [HttpGet]
        [Route("GetProperty")]
        public IActionResult GetPropertyItem()
        {
            var result = _propertyItem.GetPropertyItem();
            return Ok(result);
        }
    }
}