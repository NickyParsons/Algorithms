using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_6_1
{
    public class Node
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; }
        public bool IsVisited { get; set; }
        public Node()
        {
            this.IsVisited = false;
            Edges = new List<Edge>();
        }
        public void InverseVisit()
        {
            if (this.IsVisited)
            {
                this.IsVisited = false;
            }
            else
            {
                this.IsVisited = true;
            }
        }
    }
}
