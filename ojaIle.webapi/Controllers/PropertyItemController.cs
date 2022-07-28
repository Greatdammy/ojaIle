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
        private readonly ILogger<PropertyItemController> _logger;


        public PropertyItemController(IPropertyItemServices propertyItem, ILogger<PropertyItemController> logger)
        {
            _propertyItem = propertyItem;
            _logger = logger;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateProperty")]
        public async Task<IActionResult> CreateProperty([FromBody] PropertyItemModel model)
        {
            _logger.LogInformation("Property creating started .....");


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // var userId = Id.FirstOrDefault().ToString();
            PropertyItem propertyItem = new PropertyItem();
            propertyItem.Address = model.Address;
            propertyItem.Created = DateTime.Now;
            propertyItem.StateId = model.StateId;
            propertyItem.CountryId = model.CountryId;
            propertyItem.Lga = model.Lga;
            propertyItem.PropertyDescription = model.PropertyDescription;
            propertyItem.PropertyName = model.PropertyName;
            propertyItem.PropertyTypeId = model.PropertyTypeId;
            propertyItem.UserId = userId;
            propertyItem.CreatedBy = userId;


            _propertyItem.SavePropertyItem(propertyItem);

            return Ok(model);

        }
        [Authorize]
        [HttpGet]
        [Route("GetProperty")]
        public IActionResult GetPropertyItem()
        {
            _logger.LogInformation("trying to retrive property list....");
            var result = _propertyItem.GetPropertyItem();
            _logger.LogInformation("this is what i am trying to log");
            return Ok(result);
        }


        [Authorize]
        [HttpPut]
        [Route("UpdateProperty/{Id}")]
        public async Task<IActionResult> UpdateProperty([FromBody] PropertyItemModel model, int Id)
        {
            _logger.LogInformation("Property creating started .....");


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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
            propertyItem.UserId = userId;
            propertyItem.CreatedBy = userId;


            _propertyItem.UpdatePropertyItem(Id, propertyItem);


            //_propertyItem.UpdatePropertyItem(model.Id, new PropertyItem
            //{
            //    Address = model.Address,
            //    StateId = model.StateId,
            //    CountryId = model.CountryId,
            //    Lga = model.Lga,
            //    PropertyDescription = model.PropertyDescription,
            //    PropertyName = model.PropertyName,
            //    PropertyTypeId = model.PropertyTypeId,
            //});

            return Ok(model);
        }



        [Authorize]
        [HttpDelete]
        [Route("DeleteProperty/{Id}")]
        public async Task<IActionResult> DeleteProperty(int Id)
        {
            _logger.LogInformation("Property creating started .....");
            try
            {
                _propertyItem.DeletePropertyItem(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}