//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Miskal_Adam_IndividualPartB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assignment
    {
        public int AssignmentID { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public System.DateTime SubDateTime { get; set; }
        public int OralMark { get; set; }
        public int TotalMark { get; set; }
        public int CourseID { get; set; }
    
        public virtual Course Course { get; set; }
    }
}