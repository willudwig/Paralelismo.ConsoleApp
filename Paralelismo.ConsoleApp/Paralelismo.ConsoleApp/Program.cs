using Paralelismo;
using Paralelismo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

string[] ceps = new string[5];
ceps[0] = "89778000";
ceps[1] = "88390000";
ceps[2] = "89665000";
ceps[3] = "89110000";
ceps[4] = "88735000";

var parallelOptions = new ParallelOptions();
parallelOptions.MaxDegreeOfParallelism = 8;

var stopWatch = new Stopwatch();

stopWatch.Start();
var listaCep = new List<CepModel>();

Parallel.ForEach(ceps, parallelOptions, cep =>
{    
    listaCep.Add(new ViaCepService().GetCep(cep));    
});

// foreach(var cep in ceps)
// {
//     listaCep.Add(new ViaCepService().GetCep(cep));
// }
stopWatch.Stop();

Console.WriteLine($"O Tempo de processamento total é de {stopWatch.ElapsedMilliseconds} ms");

listaCep.ToList().ForEach(cep => Console.WriteLine(cep));



