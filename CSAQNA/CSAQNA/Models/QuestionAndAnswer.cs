﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSAQNA.Models
{
    public class QuestionAndAnswer
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string subject { get; set; }

        public QuestionAndAnswer()
        {

        }
    }
}
