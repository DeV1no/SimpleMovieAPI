using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MoviesAPI.Validations;
using Newtonsoft.Json;

namespace MoviesAPI.DTOs
{
    public class PersonCreationDTO:PersonPatchDTO
    {
      
        [FileSizeValidator(10)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile  Picture { get; set; }
    }
}