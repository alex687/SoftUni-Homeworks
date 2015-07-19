namespace MusicSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using MusicSystem.Models;
    using MusicSystem.Web.Models.Albums;

    public class AlbumsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult GetAllAlbums()
        {
            var albums = this.Data.Albums.Project().To<AlbumSmallModel>();

            return this.Ok(albums);
        }

        public IHttpActionResult Get(int id)
        {
            var album = this.Data.Albums.Where(a => a.Id == id).Project().To<AlbumModel>();

            return this.Ok(album);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Add([FromBody]AlbumSmallModel albumModel)
        {
            if (albumModel == null)
            {
                this.ModelState.AddModelError("Album", "There is no album to upload");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var album = Mapper.Map<Album>(albumModel);
            this.Data.Albums.Add(album);

            this.Data.SaveChanges();

            albumModel.Id = album.Id;

            return this.Ok(albumModel);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Edit(int id, [FromBody]AlbumSmallModel albumModel)
        {
            var album = this.Data.Albums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return this.NotFound();
            }

            if (albumModel == null)
            {
                this.ModelState.AddModelError("Album", "There is no album to update");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            album.Producer = albumModel.Producer;
            album.Title = albumModel.Title;
            album.Year = albumModel.Year;

            this.Data.SaveChanges();

            albumModel.Id = id;
            return this.Ok(albumModel);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult AddArtists(int id, [FromBody]List<int> artistsIds)
        {
            var album = this.Data.Albums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return this.NotFound();
            }

            if (artistsIds == null)
            {
                this.ModelState.AddModelError("Artists", "There is no artists to add");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artists = this.Data.Artists.Where(a => artistsIds.Contains(a.Id)).ToList();
            foreach (var artist in artists)
            {
                album.Artists.Add(artist);
            }

            this.Data.SaveChanges();

            return this.Ok();
        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var album = this.Data.Albums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return this.NotFound();
            }

            this.Data.Albums.Remove(album);

            return this.Ok();
        }
    }
}
