using IntegrationAdapters.Models;
using IntegrationAdapters.Services.TestServices;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAdaptersTests.UnitTests
{
    public class ApiKeyTests
    {
        [Fact]
        public void Find_all_api_keys()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();

            mockDBContext.Setup(t => t.GetApis()).Returns( new List<Api> { new Api() { api_key = "key1", name = "name1" },
                                                                           new Api() { api_key = "key2", name = "name2" }
                                                                         });

            ApiKeyServiceTest service = new ApiKeyServiceTest();        
            service.GetNumberOfApiKeys(mockDBContext.Object).ShouldBe(2);
        }
        [Fact]
        public void Save_key_without_name()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();

            mockDBContext.Setup(t => t.GetApis()).Returns( new List<Api> { new Api() { api_key = "key1", name = "name1" },
                                                                           new Api() { api_key = "key2", name = "name2" }
                                                                         });

            ApiKeyServiceTest service = new ApiKeyServiceTest();
            service.SaveKey(mockDBContext.Object, new Api() { api_key = "key", name = "" }).ShouldBe(2);
        }
        
        [Fact]
        public void Save_key_with_name()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();

            mockDBContext.Setup(t => t.GetApis()).Returns( new List<Api> { new Api() { api_key = "key1", name = "name1" },
                                                                           new Api() { api_key = "key2", name = "name2" }
                                                                         });

            ApiKeyServiceTest service = new ApiKeyServiceTest();
            service.SaveKey(mockDBContext.Object, new Api() { api_key = "key", name = "Danilo" }).ShouldBe(3);
        }

        [Fact]
        public void Get_existing_key()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();

            mockDBContext.Setup(t => t.GetApis()).Returns( new List<Api> { new Api() { api_key = "key1", name = "name1" },
                                                                           new Api() { api_key = "key2", name = "name2" }
                                                                         });

            ApiKeyServiceTest service = new ApiKeyServiceTest();
            service.GetKey(mockDBContext.Object, "name1").api_key.ShouldBe("key1");
        }

        [Fact]
        public void Get_none_existing_key()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();

            mockDBContext.Setup(t => t.GetApis()).Returns( new List<Api> { new Api() { api_key = "key1", name = "name1" },
                                                                           new Api() { api_key = "key2", name = "name2" }
                                                                         });

            ApiKeyServiceTest service = new ApiKeyServiceTest();
            service.GetKey(mockDBContext.Object, "name3").ShouldBeNull();
        }
    }
}
