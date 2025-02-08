using System;
namespace EF_CORE_1
{
	public class Wallet
	{
        

        public  int Id { get; set; }
        public  string Holder { get; set; }
        public   decimal Balance { get; set; }

        public override string ToString()
        {
            return $" id {Id} Holder {Holder} Balance {Balance}";
        }

    }
}

