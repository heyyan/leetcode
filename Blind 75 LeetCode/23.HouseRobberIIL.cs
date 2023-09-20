using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Blind_75_LeetCode
{
    public class HouseRobberIII
    {
        //the thief has found himself a new place for his theievery again. There is only one entrance to
        // this area,called the root. Beside the root,each house has one and only one parent house.
        // After a tour the smart theif realized that "all housed in the place form a binary tree". it will
        // automatically contact the police if two directly-linied houses were broken into on the sanme night
        // determin the maximum amount of money the thief can rob tonight without altering the polise
        // input [3,2,3,null,3,null,1]
        //          3
        //      2       3
        //          3       1
        // output 7
        // explanation Maximum amout of money the thief can rob = 3+3+1=7

        public void RunSolution()
        {
            TreeNode root = new TreeNode(3);
            TreeNode root1 = new TreeNode(2);
            TreeNode root2 = new TreeNode(3);
            TreeNode root3 = new TreeNode(3);
            TreeNode root4 = new TreeNode(1);
            root.Left = root1;
            root.Right = root2;
            root1.Right = root3;
            root2.Right = root4;

            var result = GetHouseRobberIII(root);
        }

        private int GetHouseRobberIII(TreeNode root)
        {
            (int, int) Dfs(TreeNode root)
            {
                if (root == null)
                    return (0, 0);

                var leftPair = Dfs(root.Left);
                var rightPair = Dfs(root.Right);
                var withRoot = root.val + leftPair.Item2 + rightPair.Item2;
                var withOutRoot = Math.Max( leftPair.Item1, leftPair.Item1) + Math.Max(rightPair.Item1, rightPair.Item1);
                return (withRoot, withOutRoot);
            }
            var res = Dfs(root);
            return Math.Max(res.Item1, res.Item2);
        }

        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode(int val)
            {
                this.val = val;
            }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }
    }
}
