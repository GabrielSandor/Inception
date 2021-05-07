using NUnit.Framework;

namespace Inception.Tests
{
    [TestFixture]
    public class DreamDeviceTests
    {
        [Test]
        public void Test1()
        {
            const string stream = "TDTTDTTTTTWTW";

            var dreamDevice = new DreamDevice(2);
            dreamDevice.ExperienceDream(stream);

            var stats = dreamDevice.DreamStats;
            Assert.AreEqual(8, stats.TotalSubjectiveDreamingDuration);
            Assert.AreEqual(3, stats.RealTimeDreamingDuration);
            Assert.AreEqual(2, stats.DreamLevels);
            Assert.AreEqual(6, stats.DurationsPerDreamLevel[1]);
            Assert.AreEqual(5, stats.DurationsPerDreamLevel[2]);
        }

        [Test]
        public void Test2()
        {
            const string stream = "T";

            var dreamDevice = new DreamDevice(2);
            dreamDevice.ExperienceDream(stream);

            var stats = dreamDevice.DreamStats;
            Assert.AreEqual(0, stats.TotalSubjectiveDreamingDuration);
            Assert.AreEqual(0, stats.RealTimeDreamingDuration);
            Assert.AreEqual(0, stats.DreamLevels);
        }

        [Test]
        public void Test3()
        {
            const string stream = "DTWTDTTTW";

            var dreamDevice = new DreamDevice(3);
            dreamDevice.ExperienceDream(stream);

            var stats = dreamDevice.DreamStats;
            Assert.AreEqual(4, stats.TotalSubjectiveDreamingDuration);
            Assert.AreEqual(2, stats.RealTimeDreamingDuration);
            Assert.AreEqual(1, stats.DreamLevels);
            Assert.AreEqual(4, stats.DurationsPerDreamLevel[1]);
        }

        [Test]
        public void Test4()
        {
            const string stream = "DDDTTTTTTTTWWW";

            var dreamDevice = new DreamDevice(2);
            dreamDevice.ExperienceDream(stream);

            var stats = dreamDevice.DreamStats;
            Assert.AreEqual(8, stats.TotalSubjectiveDreamingDuration);
            Assert.AreEqual(1, stats.RealTimeDreamingDuration);
            Assert.AreEqual(3, stats.DreamLevels);
            Assert.AreEqual(2, stats.DurationsPerDreamLevel[1]);
            Assert.AreEqual(4, stats.DurationsPerDreamLevel[2]);
            Assert.AreEqual(8, stats.DurationsPerDreamLevel[3]);
        }

        [Test]
        public void Test5()
        {
            const string stream = "TTTTTT";

            var dreamDevice = new DreamDevice(2);
            dreamDevice.ExperienceDream(stream);

            var stats = dreamDevice.DreamStats;
            Assert.AreEqual(0, stats.TotalSubjectiveDreamingDuration);
            Assert.AreEqual(0, stats.RealTimeDreamingDuration);
            Assert.AreEqual(0, stats.DreamLevels);
        }

        [Test]
        public void Test6()
        {
            const string stream = "TDTTDTTTTTWTW";

            var dreamDevice = new DreamDevice(1);
            dreamDevice.ExperienceDream(stream);

            var stats = dreamDevice.DreamStats;
            Assert.AreEqual(8, stats.TotalSubjectiveDreamingDuration);
            Assert.AreEqual(8, stats.RealTimeDreamingDuration);
            Assert.AreEqual(2, stats.DreamLevels);
            Assert.AreEqual(8, stats.DurationsPerDreamLevel[1]);
            Assert.AreEqual(5, stats.DurationsPerDreamLevel[2]);
        }
    }
}
