using EF_CORE_1;
using Microsoft.Extensions.Configuration;
using System;
Console.WriteLine("Hello, World!");

// read all data in table 
using (var context  = new AppDbContext())
{
    foreach (var wallet  in context.wallets)
    {
        Console.WriteLine(wallet);

    }
    Console.WriteLine();

}

// retrive one item in db

using (var context = new AppDbContext())
{
    var item = context.wallets.FirstOrDefault(x => x.Id == 3);
    Console.WriteLine(item);
    Console.WriteLine();


    var itemDefault = context.wallets.FirstOrDefault(x => x.Id == 100  ) ?? new Wallet { Id = 0,Holder= "10000000", Balance = 0.0m };
    Console.WriteLine(itemDefault);
    Console.WriteLine();
}

// add item to db

var walletToInsert = new Wallet
{
    Id = 0 ,
    Holder = "mody",
    Balance = 166.0m
};
using (var context = new AppDbContext())
{

    try
    {
        context.wallets.Add(walletToInsert);
        int rowsAffected = context.SaveChanges();

        if (rowsAffected > 0)
        {
            Console.WriteLine( $"Insertion successful!11111111 {rowsAffected}");
        }
        else
        {
            Console.WriteLine($"Insertion failed: No rows affected.!{rowsAffected}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Insertion failed: {ex.Message}");

       
    }

}

// Delete wallet 

using (var context = new AppDbContext())
{
    try
    {
        Console.WriteLine();

        Console.WriteLine("Deleting wallet...");

        var walletToDelete = context.wallets.SingleOrDefault(w => w.Id == 3);

        if (walletToDelete != null)
        {
            context.wallets.Remove(walletToDelete);
            int rowsAffected = context.SaveChanges();

            Console.WriteLine(rowsAffected > 0 ? "Wallet deleted successfully." : "Failed to delete wallet.");
        }
        else
        {
            Console.WriteLine("Wallet not found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deleting wallet: {ex.Message}");
    }
}


// retrieve wallets based on condition
using (var context = new AppDbContext())
{

    //var walletBasedOnCondition = context.wallets.Where(w=>w.Balance > 500);

    Console.WriteLine();
    Console.WriteLine(" retrieve wallets based on condition");

    foreach (var wallet in context.wallets.Where(w => w.Balance > 500))
    {
        Console.WriteLine(wallet);

    }
    Console.WriteLine();

}

//Transaction//Transaction//Transaction//Transaction
//Transaction
//Transaction//Transaction//Transaction//Transaction

using (var context = new AppDbContext())
{

    using (var transaction = context.Database.BeginTransaction())
    {
        //transfer $500 from wallet id = 5 to wallet to id 6 
        var walletFrom = context.wallets.Single(x=>x.Id == 5);
        var walletTo = context.wallets.Single(x => x.Id == 6);
        decimal amountToTransfer = 500m;

        walletFrom.Balance -= amountToTransfer;
        context.SaveChanges();

        walletTo.Balance += amountToTransfer;
        context.SaveChanges();

        transaction.Commit();
    }

}