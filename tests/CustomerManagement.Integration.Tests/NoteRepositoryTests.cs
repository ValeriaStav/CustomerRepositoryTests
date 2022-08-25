using CustomerManagement.BusinessEntities;
using CustomerManagement.Repositories;

namespace CustomerManagement.Integration.Tests
{
    public class NoteRepositoryTests
    {
        NoteRepositoryFixture Fixture => new NoteRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateNoteRepository()
        {
            var repository = new NoteRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateNote()
        {
            Fixture.DeleteAll();
            var repository = new NoteRepository();
            var note = new Notes()
            {
                CustomerId = 1,
                Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa."
            };
            repository.Create(note);
        }

        [Fact]
        public void ShouldBeAbleToReadNote()
        {
            Fixture.DeleteAll();
            var noteCustomer = Fixture.CreateNoteRepository().Read("1");
            Assert.Equal(1, noteCustomer.NoteId);
        }

        [Fact]
        public void ShouldNotBeAbleToReadNotes()
        {
            Fixture.DeleteAll();
            var noteCustomer = Fixture.CreateNoteRepository().Read("0");
            Assert.Null(noteCustomer);
        }

        [Fact]
        public void ShouldBeAbleToUodateNote()
        {
            Fixture.DeleteAll();
            var note = new Notes()
            {
                NoteId = 2,
                CustomerId = 10,
                Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor."
            };
            Fixture.CreateNoteRepository().Update(note);
        }

        [Fact]
        public void ShouldBeAbleToDeleteNote()
        {
            var note = new Notes()
            {
                CustomerId = 10,
                Note = "Aenean commodo ligula eget dolor."
            };
            Fixture.CreateNoteRepository().Create(note);
            Fixture.CreateNoteRepository().Delete(note.Note);
        }
    }
    public class NoteRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new CustomerRepository();
            repository.DeleteAll();
        }

        public NoteRepository CreateNoteRepository()
        {
            return new NoteRepository();
        }
    }
}
