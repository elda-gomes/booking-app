using IdGen;

namespace BookingApp.Core.Generator
{
    public class SnowFlakeIdGenerator
    {
        private static IdGenerator _generator;

        public static void Configure(int generatorId)
        {
            var epoch = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Local);

            var structure = new IdStructure(45, 2, 16);

            var options = new IdGeneratorOptions(structure, new DefaultTimeSource(epoch));

            _generator = new IdGenerator(generatorId, options);
        }

        public static long NewId() => _generator.CreateId();
    }
}
