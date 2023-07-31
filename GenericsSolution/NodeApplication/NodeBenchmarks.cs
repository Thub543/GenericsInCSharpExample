using BenchmarkDotNet.Attributes;

namespace NodeApplication;

[MemoryDiagnoser]
public class NodeBenchmarks
{

    private const int COUNT = 100;
    private readonly int[] _numbers = new int[COUNT];
    private readonly int[] _orderedAsc = new int[COUNT];
    private readonly int[] _orderedDesc = new int[COUNT];
    
    public NodeBenchmarks()
    {
        var rnd = new Random(2150);         
        for(var i = 0; i < COUNT; i++) {
            _numbers[i] = rnd.Next();
        }
        for(var i = 1; i < COUNT; i++) {
            _orderedAsc[i] = i;
        }
        for(var i = COUNT; i < 1; i--) {
            _orderedDesc[i] = i;
        }
    }
    
    [Benchmark]
    public void AscendingBenchmark()
    {
        var node = new Node<int>(COUNT);
        for(var i = 0; i < COUNT; i++) {
            node.Add(_orderedAsc[i]);
        }
    } 
    
    [Benchmark]
    public void DescendingBenchmark()
    {
        var node = new Node<int>(COUNT);
        for(var i = 0; i < COUNT; i++) {
            node.Add(_orderedDesc[i]);
        }
    } 
    
    [Benchmark]
    public void RandomOrder()
    {
        var node = new Node<int>(COUNT);
        for(var i = 0; i < COUNT; i++) {
            node.Add(_numbers[i]);
        }
    } 
}