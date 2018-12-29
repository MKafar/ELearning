﻿using System;
using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Assignment
    {
        public Assignment()
        {
            EvaluationsReceived = new HashSet<Evaluation>();
            EvaluationsGiven = new HashSet<Evaluation>();
        }

        public int AssignmentId { get; set; }
        public DateTime Date { get; set; }
        public string Solution { get; set; }
        public string Output { get; set; }
        public decimal? FinalGrade { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }

        public int VariantId { get; set; }
        public Variant Variant { get; set; }

        public ICollection<Evaluation> EvaluationsReceived { get; private set; }
        public ICollection<Evaluation> EvaluationsGiven { get; private set; }
    }
}
