namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
	{
		private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            var performer = this.Performers.FirstOrDefault(x => x.Name == name);
            return performer;
        }

        public ISet GetSet(string name)
        {
            var set = this.Sets.FirstOrDefault(x => x.Name == name);

            return set;
        }

        public ISong GetSong(string name)
        {
            var song = this.Songs.FirstOrDefault(x => x.Name == name);

            return song;
        }

        public bool HasPerformer(string name)
        {
            if (this.Performers.Any(x => x.Name == name))
            {
                return true;
            }

            return false;
        }

        public bool HasSet(string name)
        {
            if (this.Sets.Any(x => x.Name == name))
            {
                return true;
            }

            return false;
        }

        public bool HasSong(string name)
        {
            if (this.Songs.Any(x => x.Name == name))
            {
                return true;
            }

            return false;
        }
    }
}
