using EF_CORE_1;
using Microsoft.Extensions.Configuration;
using System;
Console.WriteLine("Hello, World!");


using (var context  = new AppDbContext())
{

    foreach (var wallet  in context.wallets)
    {
        Console.WriteLine(wallet);
    }


}