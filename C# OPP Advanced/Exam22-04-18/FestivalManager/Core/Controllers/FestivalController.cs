namespace FestivalManager.Core.Controllers
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;
        private ISetFactory setFactory;
        private IPerformerFactory performerFactory;
        private IInstrumentFactory instrumentFactory;
        private ISongFactory songFactory;

		public FestivalController(IStage stage)
		{
			this.stage = stage;
            this.performerFactory = new PerformerFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
		}

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song.Name} ({song.Duration:mm\\:ss}) to {set.Name}";
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result;
        }

        private string FormatTime(TimeSpan lenght)
        {
            int hours = lenght.Hours;
            int hoursInMinutes = 0;
            if (hours > 0)
            {
                for (int i = 0; i < hours; i++)
                {
                    hoursInMinutes += 60;
                }
            }
            var newMinutes = lenght.Minutes + hoursInMinutes;
            var newSeconds = lenght.Seconds;
            if (newMinutes > 99)
            {
                return $"{newMinutes:D3}:{newSeconds:D2}";
            }

            return $"{newMinutes:D2}:{newSeconds:D2}";
        }

        public string RegisterSet(string[] args)
        {
            var nameOfSet = args[0];
            var typeOfSet = args[1];

            var setToRegister = this.setFactory.CreateSet(nameOfSet, typeOfSet);
            this.stage.AddSet(setToRegister);

            return $"Registered {typeOfSet} set";
        }

        public string RegisterSong(string[] args)
        {
            var nameOfSong = args[0];
            var minAndSec = args[1].Split(':').ToArray();
            var durationOfSong = new TimeSpan(0, int.Parse(minAndSec[0]), int.Parse(minAndSec[1]));

            var songToRegister = this.songFactory.CreateSong(nameOfSong, durationOfSong);
            this.stage.AddSong(songToRegister);

            return $"Registered song {nameOfSong} ({durationOfSong:mm\\:ss})";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrument = args.Skip(2).ToArray();

            var instrumenti2 = instrument
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var i in instrumenti2)
            {
                performer.AddInstrument(i);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }
    }
}