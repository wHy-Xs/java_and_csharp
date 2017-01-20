using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolfram.NETLink;
using System.IO;
using System.Windows.Forms;
namespace netlink
{
    class Program
    {
        private Wolfram.NETLink.MathKernel mathKernel;
        static void Main(string[] args)
        {
          
               // compute result = new compute();
               // Console.WriteLine( result.T01());
               // Console.WriteLine(result.T12());
              //  Console.WriteLine(result.T23());
              //  Console.WriteLine(result.T34());
              //  Console.WriteLine(result.T45());
              //  Console.WriteLine(result.T56());
             //    compute a = new compute();

            string mlArgs = "-linkmode launch -linkname 'D:/vscoding/netlink/netlink/bin/Debug/MathKernel.exe -mathlink'";
            IKernelLink ml = MathLinkFactory.CreateKernelLink(mlArgs);
            MathKernel mathKernel= new Wolfram.NETLink.MathKernel(ml);


            // mathKernel
            // 
            mathKernel.AutoCloseLink = true;
           mathKernel.CaptureGraphics = true;
            mathKernel.CaptureMessages = true;
           mathKernel.CapturePrint = true;
           mathKernel.GraphicsFormat = "Automatic";
           mathKernel.GraphicsHeight = 0;
           mathKernel.GraphicsResolution = 0;
            mathKernel.GraphicsWidth = 0;
           mathKernel.HandleEvents = true;
           mathKernel.Input = null;
           mathKernel.LinkArguments = null;
           mathKernel.PageWidth = 60;
           mathKernel.ResultFormat = Wolfram.NETLink.MathKernel.ResultFormatType.OutputForm;
           mathKernel.UseFrontEnd = true;
            // 
           if (mathKernel.IsComputing)
           {
               Console.WriteLine("error");
           }
           else
           {
               string a = "Do[2+2, {200000000}]";
               mathKernel.Compute(a);

               Console.WriteLine(mathKernel.Result);
               mathKernel.Dispose();
           }
            Console.ReadLine();
        }
    }
}
