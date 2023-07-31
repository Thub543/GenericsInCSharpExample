namespace NodeApplication;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
public class Program
{ 
    static void Main(string[] args) => BenchmarkRunner.Run<NodeBenchmarks>();
}