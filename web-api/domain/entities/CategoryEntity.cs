using domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace domain.entities
{
    public class CategoryEntity
    {
        protected CategoryEntity() { }

        public CategoryEntity(string description, CategoryFinalityEnum finality)
        {
            Description = description;
            Finality = finality;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public CategoryFinalityEnum Finality { get; set; } = CategoryFinalityEnum.Both;
        public List<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();



    }
}
