using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class YoungestCommonAncestor
    {
        public void RunSolution()
        {
            var a = new AnsertorNode("A");
            var b = new AnsertorNode("B");
            var c = new AnsertorNode("C");
            var d = new AnsertorNode("D");
            var e = new AnsertorNode("E");
            var f = new AnsertorNode("F");
            var g = new AnsertorNode("G");
            var h = new AnsertorNode("H");
            var i = new AnsertorNode("I");
            var j = new AnsertorNode("J");
            var k = new AnsertorNode("K");
            var l = new AnsertorNode("L");
            var m = new AnsertorNode("M");
            var n = new AnsertorNode("N");
            var o = new AnsertorNode("O");
            var p = new AnsertorNode("P");
            var q = new AnsertorNode("Q");
            var r = new AnsertorNode("R");
            var s = new AnsertorNode("S");
            var t = new AnsertorNode("T");
            var u = new AnsertorNode("U");
            var v = new AnsertorNode("V");
            var w = new AnsertorNode("W");
            var x = new AnsertorNode("X");
            var y = new AnsertorNode("Y");
            var z = new AnsertorNode("Z");
            z.Ancestor = x;
            w.Ancestor = v;
            x.Ancestor = v;
            y.Ancestor = v;
            t.Ancestor = p;
            u.Ancestor = p;
            r.Ancestor = h;
            q.Ancestor = h;
            p.Ancestor = h;
            o.Ancestor = h;
            m.Ancestor = f;
            n.Ancestor = f;
            k.Ancestor = d;
            l.Ancestor = d;
            j.Ancestor = c;
            i.Ancestor = b;
            h.Ancestor = b;
            g.Ancestor = b;
            f.Ancestor = a;
            e.Ancestor = a;
            d.Ancestor = a;
            c.Ancestor = a;
            b.Ancestor = a;
            var rest = GetYoungestCommonAncestor(a, i, t);
        }

        private string GetYoungestCommonAncestor(AnsertorNode topAncestor, AnsertorNode descendantOne, AnsertorNode descendantTwo)
        {
            var depthOne = getDescendantDepth(descendantOne, topAncestor);
            var depthTwo = getDescendantDepth(descendantTwo, topAncestor);
            if (depthOne > depthTwo)
            {
                return backTrackAncestralTree(descendantOne, descendantTwo, depthOne - depthTwo);
            }
            else
            {
                return backTrackAncestralTree(descendantTwo, descendantOne, depthTwo - depthOne);
            }
        }

        private string backTrackAncestralTree(AnsertorNode lowerDescendant, AnsertorNode highterDescendantOne, int diff)
        {
            while(diff > 0)
            {
                lowerDescendant = lowerDescendant.Ancestor;
                diff--;
            }

            while(lowerDescendant != highterDescendantOne)
            {
                lowerDescendant= lowerDescendant.Ancestor;
                highterDescendantOne = highterDescendantOne.Ancestor;   
            }
            return lowerDescendant.value;
        }

        private int getDescendantDepth(AnsertorNode descendantOne, AnsertorNode topAncestor)
        {
            int depth = 0;
            var current = descendantOne;
            while (current != topAncestor)
            {
                depth++;
                current = current.Ancestor;
            }
            return depth;
        }
    }

    public class AnsertorNode
    {
        public AnsertorNode(string value)
        {
            this.value = value;
        }
        public string value { get; set; }
        public AnsertorNode Ancestor { get; set; }
    }
}
