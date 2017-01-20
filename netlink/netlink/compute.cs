using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolfram.NETLink;
namespace netlink
{
    class compute
    {
        link link = new link();
        public compute() {
            //DHTable中每个位置上的值
          
        }
        
        public Expr T01() {
            //DHTable中每个位置的值
            String a1 = link.DHTableValue(1, 1).ToString();
            String a2 = link.DHTableValue(1, 2).ToString();
            String a3 = link.DHTableValue(1, 3).ToString();
            String a4 = link.DHTableValue(1, 4).ToString();
 
            //每个关节的值
            String expand01= link.expand(link.MatriZDisp(a3,a4),link.MatriXDisp(a2,a1) );
            Expr T01 = link.compute(expand01);

            return T01;
        }
        public Expr T12(){
            String b1 = link.DHTableValue(2, 1).ToString();
            String b2 = link.DHTableValue(2, 2).ToString();
            String b3 = link.DHTableValue(2, 3).ToString();
            String b4 = link.DHTableValue(2, 4).ToString();

            String expand12 = link.expand(link.MatriZDisp(b3, b4), link.MatriXDisp(b2, b1));
            Expr T12 = link.compute(expand12);

            return T12;
        }

        public Expr T23()
        {
            String c1 = link.DHTableValue(3, 1).ToString();
            String c2 = link.DHTableValue(3, 2).ToString();
            String c3 = link.DHTableValue(3, 3).ToString();
            String c4 = link.DHTableValue(3, 4).ToString();

            String expand23 = link.expand(link.MatriZDisp(c3, c4), link.MatriXDisp(c2, c1));
            Expr T23 = link.compute(expand23);

            return T23;
        }

        public Expr T34()
        {
            String d1 = link.DHTableValue(4, 1).ToString();
            String d2 = link.DHTableValue(4, 2).ToString();
            String d3 = link.DHTableValue(4, 3).ToString();
            String d4 = link.DHTableValue(4, 4).ToString();


            String expand34 = link.expand(link.MatriZDisp(d3, d4), link.MatriXDisp(d2, d1));
            Expr T34 = link.compute(expand34);

            return T34;
        }

        public Expr T45()
        {
            String e1 = link.DHTableValue(5, 1).ToString();
            String e2 = link.DHTableValue(5, 2).ToString();
            String e3 = link.DHTableValue(5, 3).ToString();
            String e4 = link.DHTableValue(5, 4).ToString();

            String expand45 = link.expand(link.MatriZDisp(e3, e4), link.MatriXDisp(e2, e1));
            Expr T45 = link.compute(expand45);

            return T45;
        }

        public Expr T56()
        {
            String f1 = link.DHTableValue(6, 1).ToString();
            String f2 = link.DHTableValue(6, 2).ToString();
            String f3 = link.DHTableValue(6, 3).ToString();
            String f4 = link.DHTableValue(6, 4).ToString();

            String expand56 = link.expand(link.MatriZDisp(f3, f4), link.MatriXDisp(f2, f1));
            Expr T56 = link.compute(expand56);
            
            return T56;
        }



        public String ArcTan2(float x,float y) {
            String arctan2 = @"{x="+x+",y="+y+"};which[Abs[x]>10^-6&&Abs[y]>10^-6&&Sign[x]==1&&Sign[y]==1,z=1,Abs[x]>10^-6&&Abs[y]>10^-6&&Sign[x]==1&&Sign[y]==-1,z=2,Abs[x]>10^-6&&Abs[y]>10^-6&&Sign[x]==-1&&Sign[y]==-1,z=3,Abs[x]>10^-6&&Abs[y]>10^-6&&Sign[x]==-1&&Sign[y]==1,z=3]";
            return arctan2;
        }
    }
}
