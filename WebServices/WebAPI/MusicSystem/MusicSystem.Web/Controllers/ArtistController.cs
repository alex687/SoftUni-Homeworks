namespace MusicSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using MusicSystem.Models;
    using MusicSystem.Web.Models.Artists;

    public class ArtistController : BaseController
    {
        public IHttpActionResult Get(int id)
        {
            var artist = this.Data.Artists.Where(s => s.Id == id).Project().To<ArtistModel>();

            return this.Ok(artist);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Add([FromBody]ArtistModel artistModel)
        {
            if (artistModel == null)
            {
                this.ModelState.AddModelError("Artist", "There is no artist to upload");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artist = Mapper.Map<Artist>(artistModel);
            this.Data.Artists.Add(artist);
            artistModel.Id = artist.Id;

            this.Data.SaveChanges();

            return this.Ok(artistModel);
        }


        [Authorize]
        [HttpPut]
        public IHttpActionResult Edit(int id, [FromBody]ArtistModel artistModel)
        {
            var artist = this.Data.Artists.FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return this.NotFound();
            }

            if (artistModel == null)
            {
                this.ModelState.AddModelError("Album", "There is no album to update");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            artist.Country = artistModel.Country;
            artist.DateOfBirth = artistModel.DateOfBirth;
            artist.Name = artistModel.Name;

            this.Data.SaveChanges();

            artistModel.Id = id;
            return this.Ok(artistModel);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var artist = this.Data.Artists.FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return this.NotFound();
            }

            this.Data.Artists.Remove(artist);

            return this.Ok();
        }
    }
}