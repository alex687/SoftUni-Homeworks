namespace MusicSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using MusicSystem.Models;
    using MusicSystem.Web.Models.Songs;

    public class SongsController : BaseController
    {
        public IHttpActionResult Get(int id)
        {
            var song = this.Data.Songs.Where(s => s.Id == id).Project().To<SongModel>();

            return this.Ok(song);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Add([FromBody]SongModel songModel)
        {
            if (songModel == null)
            {
                this.ModelState.AddModelError("Song", "There is no song to upload");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var song = Mapper.Map<Song>(songModel);
            this.Data.Songs.Add(song);
            songModel.Id = song.Id;

            this.Data.SaveChanges();

            return this.Ok(songModel);
        }


        [Authorize]
        [HttpPut]
        public IHttpActionResult Edit(int id, [FromBody]SongModel songModel)
        {
            var song = this.Data.Songs.FirstOrDefault(a => a.Id == id);
            if (song == null)
            {
                return this.NotFound();
            }

            if (songModel == null)
            {
                this.ModelState.AddModelError("Album", "There is no album to update");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            song.Genre = songModel.Genre;
            song.Title = songModel.Title;
            song.ArtistId = songModel.ArtistId;

            this.Data.SaveChanges();

            songModel.Id = id;
            return this.Ok(songModel);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var song = this.Data.Songs.FirstOrDefault(s => s.Id == id);
            if (song == null)
            {
                return this.NotFound();
            }

            this.Data.Songs.Remove(song);

            return this.Ok();
        }
    }
}