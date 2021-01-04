using System.Linq;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Stravaig.ShortCode.Benchmarks
{
    public abstract class EncoderParamColumnBase : IColumn
    {
        public abstract string GetValue(Summary summary, BenchmarkCase benchmarkCase);

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
        {
            return GetValue(summary, benchmarkCase);
        }

        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

        public bool IsAvailable(Summary summary) => true;

        public string Id { get; protected set; }
        public string ColumnName { get; protected set; }
        public bool AlwaysShow => true;
        public ColumnCategory Category => ColumnCategory.Params;
        public int PriorityInCategory => 0;
        public bool IsNumeric => false;
        public UnitType UnitType => UnitType.Dimensionless;
        public abstract string Legend { get; }
    }
    public class CharacterSpaceColumn : EncoderParamColumnBase
    {
        public CharacterSpaceColumn()
        {
            Id = nameof(CharacterSpaceColumn);
            ColumnName = "Char Space";
        }

        public override string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            var encoderParam = (IEncoder) benchmarkCase.Parameters.Items
                .First(p => p.Name == nameof(EncoderBenchmarks.Encoder))
                .Value;
            return encoderParam.NamedCharacterSpace ?? $"\"{encoderParam.CharacterSpace}\"";
        }

        public override string Legend => "The Character Space the code is made up from.";
    }

    public class EncoderColumn : EncoderParamColumnBase
    {
        public EncoderColumn()
        {
            Id = nameof(EncoderColumn);
            ColumnName = "Encoder Class";
        }

        public override string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            var encoderParam = (IEncoder) benchmarkCase.Parameters.Items
                .First(p => p.Name == nameof(EncoderBenchmarks.Encoder))
                .Value;
            return encoderParam.GetType().Name;
        }

        public override string Legend => "The encoder class name.";
    }
}