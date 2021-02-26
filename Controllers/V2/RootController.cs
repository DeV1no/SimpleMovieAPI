using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DTOs;
using MoviesAPI.Helpers;

namespace MoviesAPI.Controllers.V2
{
    [ApiController]
    [Route("api")]
    [HttpHeaderIsPresent("x-version", "2")]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = "getRoot")]
        public ActionResult<IEnumerable<Link>> Get()
        {
            List<Link> links = new List<Link>();
            links.Add(new Link(href: Url.Link("getRoot", new { }), rel: "Self", method: "GET"));

            return links;
        }
    }
}