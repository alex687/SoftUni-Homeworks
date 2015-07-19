namespace DistanceCalculatorRest.Controllers
{
    using System;
    using System.Web.Http;

    using DistanceCalculatorRest.Models;

    public class DistanceCalculatorController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CalculateDistance(Points points)
        {
            var startPoint = points.Start;
            var endPoint = points.End;


            var distance = Math.Sqrt(Math.Pow(startPoint.X - endPoint.X, 2) + Math.Pow(startPoint.Y - endPoint.Y, 2));
            return this.Ok(distance);
        }
    }
}
