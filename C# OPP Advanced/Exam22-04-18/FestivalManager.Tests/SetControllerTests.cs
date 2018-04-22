// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Sets;


    using NUnit.Framework;
    using System;
    using System.Reflection;
    using System.Linq;

    [TestFixture]
    public class SetControllerTests
    {
        private IStage stage;
        private IStage stage2;
        private ISetController setController;
        private ISetController setController2;
        private ISet set;
        private ISet set1;
        private IPerformer performer;
        private ISong song;
        private IInstrument instrument;

        [SetUp]
        public void SetUpSetController()
        {
            this.stage = new Stage();
            this.set = new Long("set1");
            this.performer = new Performer("Pesho", 20);
            this.song = new Song("BoraBora", new TimeSpan(0, 3, 12));
            this.instrument = new Guitar();
            this.performer.AddInstrument(this.instrument);
            this.set.AddPerformer(this.performer);
            this.set.AddSong(this.song);

            this.stage.AddSet(this.set);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(this.song);

            this.setController = new SetController(this.stage);

            this.stage2 = new Stage();
            this.set1 = new Short("set2");
            this.stage2.AddSet(this.set1);
            this.setController2 = new SetController(this.stage2);
        }

        [Test]
        public void TestDidNotPerform()
        {
            var result = this.setController2.PerformSets();

            Assert.That(result, Is.EqualTo("1. set2:\r\n-- Did not perform"));
        }

        [Test]
        public void TestPerformSuccessfull()
        {
            var result = this.setController.PerformSets();

            Assert.That(result, Is.EqualTo("1. set1:\r\n-- 1. BoraBora (03:12)\r\n-- Set Successful"));
        }

        [Test]
        public void TestBothPerforms()
        {
            this.stage.AddSet(this.set1);
            IPerformer performer = new Performer("Lili Ivanova", 150);
            IInstrument instrument = new Microphone();
            IInstrument instrument2 = new Guitar();
            performer.AddInstrument(instrument);
            performer.AddInstrument(instrument2);
            ISong song = new Song("Vetrove", new TimeSpan(0, 4, 30));

            IPerformer performer1 = new Performer("Avicci", 30);
            IInstrument instrument1 = new Drums();
            performer1.AddInstrument(instrument1);
            ISong song1 = new Song("Hey Brother", new TimeSpan(0, 3, 59));

            this.set.AddPerformer(performer);
            this.set.AddSong(song);
            this.set.AddPerformer(performer1);
            this.set.AddSong(song1);

            this.setController.PerformSets();
            this.setController.PerformSets();
            this.setController.PerformSets();
            this.setController.PerformSets();
            this.setController.PerformSets();
            this.setController.PerformSets();
            this.setController.PerformSets();
            this.setController.PerformSets();
            this.setController.PerformSets();
            this.setController.PerformSets();
            var result = this.setController.PerformSets();

            Assert.That(result, Is.EqualTo("1. set1:\r\n-- Did not perform\r\n2. set2:\r\n-- Did not perform"));
        }

        [Test]
        public void TestWithNoSet()
        {
            IStage stage = new Stage();
            this.setController = new SetController(stage);

            var result = this.setController.PerformSets();

            Assert.That(result, Is.EqualTo(""));
        }
    }
}