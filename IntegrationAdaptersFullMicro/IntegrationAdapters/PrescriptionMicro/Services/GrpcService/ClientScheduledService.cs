using Grpc.Core;
using IntegrationAdapters.Dtos;
using IntegrationAdapters.Protos;
using System;
using System.Collections.Generic;

namespace IntegrationAdapters.Services.GrpcService
{
    public class ClientScheduledService
    {
        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientScheduledService() { }

        public static List<MedAvabDto> pharmacies = new List<MedAvabDto>();

        public async void SendMessage(MedicineDto medDto)
        {

            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);

            try
            {
                MessageResponseProto response = await client.communicateAsync(new MessageProto() { Name = medDto.Name, Amount = medDto.Amount });
                Console.WriteLine(response.Response + " is response; status: " + response.Status);

                pharmacies.Clear();
                String[] parts = response.Response.Split(";");

                foreach (String part in parts)
                {
                    String[] data = part.Split("-");

                    Boolean flag = false;
                    if (data[2].Equals("true"))
                    {
                        flag = true;
                    }

                    MedAvabDto dto = new MedAvabDto(data[0], data[1], flag);
                    pharmacies.Add(dto);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }

        }

    }
}
