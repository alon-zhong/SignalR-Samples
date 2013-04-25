using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            StreamWriter traceWriter = new StreamWriter("HubConnection.log.txt");
            traceWriter.AutoFlush = true;

            string url = "http://localhost:8080";

            HubConnection hubConnection = new HubConnection(url);
            hubConnection.TraceWriter = traceWriter;
            hubConnection.TraceLevel = TraceLevels.All;
            hubConnection.Closed += () => Console.WriteLine("[Closed]");
            hubConnection.ConnectionSlow += () => Console.WriteLine("[ConnectionSlow]");
            hubConnection.Error += (error) => Console.WriteLine("[Error] {0}", error.ToString());
            hubConnection.Received += (payload) => Console.WriteLine("[Received] {0}", payload);
            hubConnection.Reconnected += () => Console.WriteLine("[Reconnected]");
            hubConnection.Reconnecting += () => Console.WriteLine("[Reconnecting]");
            hubConnection.StateChanged += (change) => Console.WriteLine("[StateChanged] {0} {1}", change.OldState, change.NewState);

            var hubProxy = hubConnection.CreateHubProxy("TestHub");
            hubProxy.On<string>("Received", (message) => Console.WriteLine(message));
            hubConnection.Start().Wait();
            hubProxy.Invoke("SendToCaller", "Hello!");

            Console.ReadLine();
        }

        static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception);
            throw e.Exception;
        }
    }
}
