namespace Messages.Tests.Mocks
{
    using BugTracker.Data;
    using BugTracker.Data.Models;
    using BugTracker.Data.Repositories;

    using Microsoft.AspNet.Identity;

    public class BugTrackerDataMock : IBugTrackerData
    {
        private GenericRepositoryMock<User> usersMock = new GenericRepositoryMock<User>();
        private GenericRepositoryMock<Bug> bugsMock = new GenericRepositoryMock<Bug>();
        private GenericRepositoryMock<Comment> commentsMock = new GenericRepositoryMock<Comment>();

        public bool ChangesSaved { get; set; }

        public IGenericRepository<Comment> Comments
        {
            get
            {
                return this.commentsMock;
            }
        }

        public IGenericRepository<User> Users
        {
            get { return this.usersMock; }
        }

        public IGenericRepository<Bug> Bugs
        {
            get { return this.bugsMock; }
        }


        public int SaveChanges()
        {
            this.ChangesSaved = true;
            return 1;
        }
    }
}
