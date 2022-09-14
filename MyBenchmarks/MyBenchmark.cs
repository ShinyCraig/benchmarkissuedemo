using System.Security.Principal;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace MyBenchmarks;

[SimpleJob]
public class MyBenchmark
{
    [Benchmark]
    public void SomeBenchmark()
    {
        var aaa = ExeProjectWindows.GetName();
    }
}