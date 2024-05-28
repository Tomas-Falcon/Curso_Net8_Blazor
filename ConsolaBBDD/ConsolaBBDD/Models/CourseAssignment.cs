﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolebdd.Models
{
    public class CourseAssignment
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }

        // Propiedades de navegación
        public Instructor? Instructor { get; set; }
        public Course? Course { get; set; }
    }
}
