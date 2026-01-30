using System;
using System.Collections.Generic;
using System.Text;

namespace domain.entities
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }  

        public List<TransactionEntity> Transactions { get; set;  } = new List<TransactionEntity>(); 
    }
}
