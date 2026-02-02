using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace domain.entities
{
    public class PersonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }  

        public List<TransactionEntity> Transactions { get; set;  } = new List<TransactionEntity>(); 
    }
}
