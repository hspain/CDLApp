using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using CieDigitalAssessment.DAL;
using EntityFrameworkCoreMock;
using CieDigitalAssessment.API.Models;


namespace CieDigitalAssessment.Test
{
    public class MovieTests
    {

        public DbContextOptions<CDLAppContext> DummyOptions { get; } = new DbContextOptionsBuilder<CDLAppContext>().Options;
        DbContextMock<CDLAppContext> _context { get; set; }
        MockRepository<Movie> _movieRepository { get; set; }


        public MovieTests()
        {
            var initialEntities = new[]
                {
                    new Movie { Id = 0, Title = "Braveheart" },
                    new Movie { Id = 1, Title = "Titanic" },
                };

            _context = new DbContextMock<CDLAppContext>(DummyOptions);
            var usersDbSetMock = _context.CreateDbSetMock(x => x.Movie, initialEntities);

            _movieRepository = new MockRepository<Movie>(_context);
        }

        [Fact]
        public void MovieGet()
        {
            Assert.NotNull(_movieRepository.Get(1));
            Assert.Null(_movieRepository.Get(2));
        }

        [Fact]
        public async void MovieDelete()
        {

            _movieRepository.Delete(1);
            _movieRepository.Save();

            Assert.True(await _movieRepository.Get().CountAsync() == 1);

            _movieRepository.Delete(0);
            _movieRepository.Save();

            Assert.True(await _movieRepository.Get().CountAsync() == 0);
        }
    }
}
