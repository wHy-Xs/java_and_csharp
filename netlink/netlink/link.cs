using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolfram.NETLink;

namespace netlink
{
    /* XDisp[a_ ,b_] :={{1,0,0,a},{0,Cos[b Degree],-Sin[b Degree],0},{0,Sin[b Degree],Cos[b Degree],0},{0,0,0,1}}
     * ZDisp[c_ ,d_] :={{Cos[d Degree],-Sin[d Degree],0,0},{Sin[d Degree],Cos[d Degree],0,0},{0,0,1,c Degree},{0,0,0,1}}
     * DHTable={{a Degree,b Degree,c Degree,d Degree},{a1 Degree,b1 Degree,c1 Degree,d1 Degree},{a2 Degree,b2 Degree,c2 Degree,d2 Degree},{a3 Degree,b3 Degree,c3 Degree,d3 Degree}}
     * Expand[ZDisp[DHTable[[1,3]],DHTable[[1,4] ].XDisp[ DHTable[[1,2]],DHTable[[1,1]]]]
     * 
     * 
     *                
     *
     *                
     *              
     *         
     *               
     *             
     *             
     *                 
     *                 
     *                          
     *                    
     *             
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */
    class link
    {
        //无参数DH矩阵
        /*
        public static String DHTable = @"{  {a Degree,b,c,d Degree},{a1 Degree,b1,c1,d1 Degree},
                                            {a2 Degree,b2,c2,d2 Degree},{a3 Degree,b3,c3,d3 Degree},
                                            {a4 Degree,b4,c4,d4 Degree},{a5 Degree,b5,c5,d5 Degree}
                                            }";
        */
         
        //有参数的DH矩阵
        /*
         public static String DHTable = @"{ {-90 Degree,1.555,2.005,33 Degree},{180 Degree,0,0.66,-70 Degree},
                                            {-90 Degree,0,0.66,-130 Degree},{-90 Degree,0,3.14,20 Degree},
                                            {90 Degree,0,0,-25 Degree},{0 Degree,0,0,32 Degree}
                                         }";
        
        */

        //绕x轴的变换矩阵
        public String MatriXDisp(String a, String b)
        {
            //    String XDisp = "{{1,0,0,"+a+"},{0,Cos["+b+" Degree],-Sin["+b+" Degree],0},{0,Sin["+b+" Degree],Cos["+b+" Degree],0},{0,0,0,1}}";
            String XDisp = "{{1,0,0," + a + "},{0," + b + "," + b + ",0},{0," + b + "," + b + ",0},{0,0,0,1}}";
            return XDisp;
        }
        
        //绕z轴的变换矩阵
        public String MatriZDisp(String c, String d) {
           // String ZDisp = "{{Cos[" + d + " Degree],-Sin[" + d + " Degree],0,0},{Sin[" + d + " Degree],Cos[" + d + " Degree],0,0},{0,0,1," + c + " Degree},{0,0,0,1}}";
            String ZDisp = "{{" + d + "," + d + ",0,0},{" + d + "," + d + ",0,0},{0,0,1," + c + "},{0,0,0,1}}";
            return ZDisp;
        }
        //取得DH矩阵中某一个固定位置的值
        public Expr DHTableValue(int row,int col) {
            String dh;
            if (row > 6 || col > 4)
            {
                Console.WriteLine("DHMatrix out of index");             
            }
         
            dh = "{ {-90 Degree,1.555,2.005,33 Degree},{180 Degree,0,0.66,-70 Degree},{-90 Degree,0,0.66,-130 Degree},{-90 Degree,0,3.14,20 Degree},{90 Degree,0,0,-25 Degree},{0 Degree,0,0,32 Degree}}[["+row+"]][["+col+"]]";
            link l = new link();
            Expr value = l.compute(dh);

            return value;
        }

        //用mathematica语句进行计算通用的函数方法
        public Expr compute(string s)
        {
            string mlArgs = "-linkmode launch -linkname 'D:/vscoding/netlink/netlink/bin/Debug/MathKernel.exe -mathlink'";
            IKernelLink ml = MathLinkFactory.CreateKernelLink(mlArgs);
            ml.WaitAndDiscardAnswer();
            ml.Evaluate(s);
            ml.EndPacket();
            ml.WaitForAnswer();
            Expr intResult = ml.GetExpr();
            ml.Close();
            return intResult;

        }
        //在控制台输出显示的方法
        public void winPrinf(Expr commandline)
        {
            Console.WriteLine(commandline);
            Console.ReadLine();
        }
        //构造expand命令行的方法
        public String expand(String a,String b) {
            String epand = "Expand[" + a + "*" + b + "]";
            return epand;   
        }


        public void add(Expr e ,Expr m)
        {
            string mlArgs = "-linkmode launch -linkname 'D:/vscoding/netlink/netlink/bin/Debug/MathKernel.exe -mathlink'";
            IKernelLink ml = MathLinkFactory.CreateKernelLink(mlArgs);
            ml.WaitAndDiscardAnswer();
            ml.PutFunction("EnterExpressionPacket", 1);
            ml.PutFunction("Plus", 2);
            ml.Put(e);
            ml.Put(m);
            ml.EndPacket();
            ml.WaitForAnswer();
            Expr intResult = ml.GetExpr();
           // Console.WriteLine("sum = " + intResult);
            ml.Close();    
        }
        //βαθ
        public Expr matrix(int b, double α)
        {
            string mlArgs = "-linkmode launch -linkname 'D:/vscoding/netlink/netlink/bin/Debug/MathKernel.exe -mathlink'";
            IKernelLink ml = MathLinkFactory.CreateKernelLink(mlArgs);
            ml.WaitAndDiscardAnswer();
            ml.PutFunction("EvaluatePacket", 1);
            
            ml.PutFunction("List", 2);
                 ml.PutFunction("List",2);
               
                     ml.Put(1);
                     ml.Put(2);
                ml.PutFunction("List",2);
                    ml.Put(b);
                    ml.Put(Math.Cos(α));
            ml.EndPacket();
            ml.WaitForAnswer();
            Expr e = ml.GetExpr();
     //       Console.WriteLine(e);
            ml.Close();
            return e;

        }

        public Expr epand() {
            string mlArgs = "-linkmode launch -linkname 'D:/vscoding/netlink/netlink/bin/Debug/MathKernel.exe -mathlink'";
            IKernelLink ml = MathLinkFactory.CreateKernelLink(mlArgs);
            ml.WaitAndDiscardAnswer();
            ml.Evaluate("a b c d /. a d -> x");
            ml.EndPacket();
            ml.WaitForAnswer();
            Expr intResult = ml.GetExpr();
     //       Console.WriteLine("sum = " + intResult);
            ml.Close();
            return intResult;
        }

        public void table() {
            string mlArgs = "-linkmode launch -linkname 'D:/vscoding/netlink/netlink/bin/Debug/MathKernel.exe -mathlink'";
            IKernelLink ml = MathLinkFactory.CreateKernelLink(mlArgs);
            ml.WaitAndDiscardAnswer();

          //   string result = ml.EvaluateToOutputForm("Table[1,3]", 0);
         //   ml.Evaluate("Solve[x^2 + 2 y^3 == 3681 && x > 0 && y > 0, {x, y}, Integers]");
            ml.PutFunction("EvaluatePacket",1);
            ml.PutFunction("Append",2);
            ml.PutFunction("List",4);
            ml.PutSymbol("a");
            ml.PutSymbol("b");
            ml.PutSymbol("c");
            ml.PutSymbol("d");

            ml.PutSymbol("e");
            ml.EndPacket();
            ml.WaitForAnswer();
            Expr intResult = ml.GetExpr();
            ml.Close();    
            
        }


       ///////////////////////////////////////
        /*
        public void dd()
        {
                     /* Init MathLink */
        /*
            IKernelLink ml = MathLinkFactory.CreateKernelLink();

            MathKernel mathKernel;
            mathKernel = new MathKernel(ml);
            mathKernel.AutoCloseLink = true;
            mathKernel.CaptureMessages = true;
            mathKernel.CapturePrint = true;
            mathKernel.Input = null;
            mathKernel.LinkArguments = null;
            mathKernel.ResultFormat = MathKernel.ResultFormatType.InputForm;
            mathKernel.UseFrontEnd = true;

            /* Run */
        /*
            mathKernel.Compute("XDisp[a_ ,b_] :={{1,0,0,a},{0,1,2,b},{0,1,1,a},{b,1,1,2}}");

            /* Results */
            //    strMLOutResult = (string) mathKernel.Result;
        /*
            foreach (string msg in mathKernel.Messages) strMLOutMessage += msg;
            foreach (string p in mathKernel.PrintOutput) strMLOutPrint += p;
            /* Close MathLink */
        /*
            mathKernel.Dispose();
            Console.WriteLine("ddddd" + strMLOutMessage);

        } 
         */
      
    }
}
