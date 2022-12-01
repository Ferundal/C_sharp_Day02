using System;
using d02_ex00;
using d02_ex00.Models;

if (args.Length != 2)
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return (-1);
}
    
Exchanger exchanger = new Exchanger(args[1]);
if (!ExchangeSum.TryParse(args[0], out var exchangeSum))
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return (-1);
}
Console.WriteLine($"Amount in the original currency: {exchangeSum}");
bool noConvertions = true;
foreach (var exchangeSumResult in exchanger.Convert(exchangeSum))
{
    noConvertions = false;
    Console.WriteLine($"Amount in {exchangeSumResult.Id}: {exchangeSumResult}");
}
if (noConvertions) 
{
    Console.WriteLine("Input error. Check the input data and repeat the request.");
    return (-1);
}
return (0);
