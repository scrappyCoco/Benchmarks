using BenchmarkDotNet.Running;
using Benchmarks;

BenchmarkSwitcher.FromAssembly(typeof (DataTableAddColumn).Assembly).Run(args);