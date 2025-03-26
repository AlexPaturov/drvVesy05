// cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319
// дев.\InstallUtil.exe D:\repos\cSharp\job\pipeComToIp\drvVesy05\bin\Release\drvVesy05.exe
// .\InstallUtil.exe /u D:\repos\cSharp\job\pipeComToIp\drvVesy05\bin\Release\drvVesy05.exe



using System;
using System.ServiceProcess;
using System.Text;

namespace drvVesy05
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
#if (!DEBUG)
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
#else
            Service1 myServ = new Service1();
            myServ.RunAsConsole(args);
            // here Process is my Service function
            // that will run when my service onstart is call
            // you need to call your own method or function name here instead of Process();
#endif
        }
    }
}
