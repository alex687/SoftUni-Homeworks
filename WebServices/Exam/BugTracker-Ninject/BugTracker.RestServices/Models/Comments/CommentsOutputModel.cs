namespace BugTracker.RestServices.Models.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using BugTracker.Data.Models;
    using BugTracker.RestServices.Infrastructure.Mapping;

    public class CommentsOutputModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentsOutputModel>()
                .ForMember(c => c.Author, opt => opt.MapFrom(c => c.Author.UserName));
        }
    }
}