using domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace comunication.responses
{
    public class CategoryJsonResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public CategoryFinalityEnum Finality { get; set; } = CategoryFinalityEnum.Both;

    }
}
