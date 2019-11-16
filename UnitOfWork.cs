using System.Threading.Tasks;
using MyMusic.Core;
using MyMusic.Data.Repositories;

namespace MyMusic.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyMusicDbContext _context;
        private MusicRepository _musicRepository;
        private ArtistRepository _artistRepository;

        public UnitOfWork(MyMusicDbContext context)
        {
            this._context = context;
        }

        public MusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);

        public ArtistRepository Artists => _artistRepository = _artistRepository ?? new ArtistRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}