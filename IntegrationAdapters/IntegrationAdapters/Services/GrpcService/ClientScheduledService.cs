using Grpc.Core;
using IntegrationAdapters.Dtos;
using IntegrationAdapters.Protos;
using System;

namespace IntegrationAdapters.Services.GrpcService
{
    public class ClientScheduledService
    {
        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientScheduledService() { }

        public static Boolean flag;

        public async void SendMessage(MedicineDto medDto)
        {

            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);

            try
            {
                MessageResponseProto response = await client.communicateAsync(new MessageProto() { Name = medDto.Name, Amount = medDto.Amount });
                Console.WriteLine(response.Response + " is response; status: " + response.Status);

                flag = response.Response.Equals("TRUE") ? true : false;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }

        }

    }
}
