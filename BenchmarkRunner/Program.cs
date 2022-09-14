using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using MyBenchmarks;


// With just SelfContained=True it complains
// 'error NETSDK1031: It is not supported to build or publish a self-contained application without specifying a RuntimeIdentifier. You must either specify a RuntimeIdentifier or set SelfContained to false.'
// This isn't necessarily a problem, but just to demonstrate
var jobOneArgs = Job.Default.WithArguments(new Argument[]
{
	new MsBuildArgument("/p:SelfContained=TRUE")
});


// With Both it complains
// 'error NETSDK1151: The referenced project '..\..\..\..\..\..\ExeProject\ExeProject.csproj' is a self-contained executable.  A self-contained executable cannot be referenced by a non self-contained executable.'
var jobTwoArgs = Job.Default.WithArguments(new Argument[]
{
	new MsBuildArgument("/p:SelfContained=TRUE"),
	new MsBuildArgument("/p:RuntimeIdentifier=win-x64")
});

// With both in one MsBuildArgument  it's the same error as with the 2 separate ones
var jobCombinedArg = Job.Default.WithArguments(new Argument[]
{
	new MsBuildArgument("/p:RuntimeIdentifier=win-x64,SelfContained=TRUE")
});

// Also, not as pressing but you should be able to separate separate /p flags with ; but if you try that here you get 'error NETSDK1083: The specified RuntimeIdentifier 'win-x64;SelfContained=TRUE' is not recognized.' 
var jobCombinedArgSemicolon = Job.Default.WithArguments(new Argument[]
{
	new MsBuildArgument("/p:RuntimeIdentifier=win-x64;SelfContained=TRUE")
});

var config = DefaultConfig.Instance
	.AddJob(jobTwoArgs)
	.WithOptions(ConfigOptions.DisableOptimizationsValidator);

BenchmarkSwitcher
	.FromAssembly(typeof(MyBenchmark).Assembly)
	.Run(args, config);


