param(
    [string]
    [ValidateSet("EncoderBenchmarks", "CodeGeneratorBenchmarks", "EncoderVariantBenchmarks", "*")]
    $Benchmarks
)

dotnet run --project ./src/Stravaig.ShortCode.Benchmarks/Stravaig.ShortCode.Benchmarks.csproj -c Release -- --exporters GitHub CSV --filter $Benchmarks

Copy-Item -Path "$PSScriptRoot/BenchmarkDotNet.Artifacts/results/*.csv" -Destination "$PSScriptRoot/Benchmarks/" -Verbose
Copy-Item -Path "$PSScriptRoot/BenchmarkDotNet.Artifacts/results/*.md" -Destination "$PSScriptRoot/Benchmarks/" -Verbose