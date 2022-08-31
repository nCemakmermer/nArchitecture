using Application.Features.Brands.Comments.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createSomeFeatureEntityCommand)
        {
            CreatedBrandDto result = await Mediator.Send(createSomeFeatureEntityCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
          GetBrandListQuery getBrandListQuery = new() { PageRequest = pageRequest};
            BrandListModel result = await Mediator.Send(getBrandListQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetBrandByIdQuery getBrandByIdQuery)
        {
           BrandGetByIdDto brandGetByIdDto =  await Mediator.Send(getBrandByIdQuery);
            return Ok(brandGetByIdDto);
        }
    }
}
