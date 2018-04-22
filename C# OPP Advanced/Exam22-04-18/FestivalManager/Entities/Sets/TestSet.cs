using FestivalManager.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FestivalManager.Entities.Sets
{
    public abstract class TestSet : ISet
    {
        private readonly List<IPerformer> performers;
        private readonly List<ISong> songs;

        public TestSet(string name, TimeSpan maxDuration)
        {
            this.Name = name;
            this.MaxDuration = maxDuration;
            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public string Name { get; }

        public TimeSpan MaxDuration { get; }

        public TimeSpan ActualDuration { get; private set; }

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (song.Duration > this.MaxDuration)
            {
                throw new InvalidOperationException("Song is over the set limit!");
            }
            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            if (this.Performers.Count > 0 && this.Songs.Count > 0 && this.Performers.Any(p => p.Instruments.Count > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
