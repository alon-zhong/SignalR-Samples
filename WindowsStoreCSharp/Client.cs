﻿using System;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Windows.UI.Xaml.Controls;

namespace WindowsStoreCSharp
{
    public class Client
    {
        public MainPage Page { get; set; }
        public SynchronizationContext Context { get; set; }

        public async void RunAsync()
        {
            TextBox textBox = (TextBox)Page.FindName("Messages");
            TextBoxWriter traceWriter = new TextBoxWriter(Context, textBox);

            string url = "http://localhost:22278/";
            HubConnection hubConnection = new HubConnection(url);
            hubConnection.TraceWriter = traceWriter;
            hubConnection.TraceLevel = TraceLevels.All;
            hubConnection.Closed += () => traceWriter.WriteLine("[Closed]");
            hubConnection.ConnectionSlow += () => traceWriter.WriteLine("[ConnectionSlow]");
            hubConnection.Error += (error) => traceWriter.WriteLine("[Error] {0}", error.ToString());
            hubConnection.Received += (payload) => traceWriter.WriteLine("[Received] {0}", payload);
            hubConnection.Reconnected += () => traceWriter.WriteLine("[Reconnected]");
            hubConnection.Reconnecting += () => traceWriter.WriteLine("[Reconnecting]");
            hubConnection.StateChanged += (change) => traceWriter.WriteLine("[StateChanged] {0} {1}", change.OldState, change.NewState);

            IHubProxy hubProxy = hubConnection.CreateHubProxy("TestHub");
            hubProxy.On<string>("received", (data) => traceWriter.WriteLine(data));

            await hubConnection.Start();
            await hubProxy.Invoke("SendToCaller", "Hello!");
        }
    }
}
