using System;
using System.ServiceModel;
using KSR_WCF1;

namespace Client
{
    public class Client
    {
        public static void Main(string[] args)
        {
            var factory = new ChannelFactory<IZadanie1>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/ksr-wcf1-test"));
            var client = factory.CreateChannel();

            Console.WriteLine(client.Test("188701"));

            try
            {
                client.RzucWyjatek(true);
            }
            catch (FaultException<Wyjatek> e)
            {
                Console.WriteLine(client.OtoMagia(e.Detail.magia));
            }

            ((IDisposable)client).Dispose();
            factory.Close();

            Console.ReadLine();
        }
    }
}