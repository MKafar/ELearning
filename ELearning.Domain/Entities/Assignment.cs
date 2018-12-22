﻿using System;
using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Assignment
    {
        public Assignment()
        {
            Evaluations = new HashSet<Evaluation>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Solution { get; set; }
        public int? FinalGrade { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }

        public int TaskVariantId { get; set; }
        public TaskVariant TaskVariant { get; set; }

        public ICollection<Evaluation> Evaluations { get; private set; }
    }
}
