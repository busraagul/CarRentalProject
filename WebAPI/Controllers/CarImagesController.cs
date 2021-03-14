using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        private IWebHostEnvironment _environment;
        FileHelper _fileHelper;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment environment, FileHelper fileHelper)
        {
            _carImageService = carImageService;
            _environment = environment;
            _fileHelper = fileHelper;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, IFormFile file)
        {
            if (file == null)
            {
                carImage.ImagePath = "/Image/Logo.JPG";
                var result = _carImageService.Add(carImage);
                if (result.Success)
                {                   
                    return Ok(result);
                }
                return BadRequest(result);
            }
            else
            {
                var carImageCount = _carImageService.GetImagesByCarId(carImage.CarId);
                if (carImageCount.Success)
                {
                    var image = _fileHelper.Upload(file, _environment.WebRootPath, "Image");
                    if (image.Success)
                    {
                        carImage.ImagePath = image.Data;
                        var result = _carImageService.Add(carImage);
                        if (!result.Success)
                        {
                            return BadRequest(result);
                        }
                        return Ok(result);
                    }
                    return BadRequest(image);
                }
                return BadRequest(carImageCount);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int carImageId)//delete islemlerinde sadece kullanıcıdan Id istenir
        {
            var result = _carImageService.Delete(carImageId, _environment.WebRootPath);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //[HttpPut("update")]
        //public IActionResult Update([FromForm] CarImage carImage, IFormFile file)
        //{
        //    var result = _carImageService.Update(carImage, file);
        //    if (!result.Success)
        //    {
        //        return BadRequest(result);
        //    }
        //    return Ok(result);
        //}

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {

            var result = _carImageService.GetImagesByCarId(carId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
