using Health_Clinic_Integration.Models;
//using Health_Clinic_Integration.Services.RabbitMqService;
using IntegrationAdapters.Services.TestServices;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Health_Clinic_Integration_Tests
{
    public class ActionBenefitTests
    {

        [Fact]
        public void Find_all_actions()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetActionsBenefits()).Returns(new List<ActionBenefit> { new ActionBenefit() { pharmacy = "Benu", message = "Poruka iz Benu apoteke" },
                                                                           new ActionBenefit() { pharmacy = "Zegin", message = "Poruka iz Zegin apoteke" }
                                                                         });

            ActionBenefitServiceTest service = new ActionBenefitServiceTest();
            service.GetNumberOfActionBenefits(mockDBContext.Object).ShouldBe(2);
        }

        [Fact]
        public void Save_actionBenefit()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetActionsBenefits()).Returns(new List<ActionBenefit> { new ActionBenefit() { pharmacy = "Benu", message = "Poruka iz Benu apoteke" },
                                                                           new ActionBenefit() { pharmacy = "Zegin", message = "Poruka iz Zegin apoteke" }
                                                                         });

            ActionBenefitServiceTest service = new ActionBenefitServiceTest();
            service.SaveActionBenefit(mockDBContext.Object, new ActionBenefit() { pharmacy = "StudenstkaApoteka", message = "Poruka iz StudenstkeApoteke apoteke" }).ShouldBe(3);
        }

        [Fact]
        public void Find_last_actionBenefit()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetActionsBenefits()).Returns(new List<ActionBenefit> { new ActionBenefit() { pharmacy = "Benu", message = "Poruka iz Benu apoteke" },
                                                                           new ActionBenefit() { pharmacy = "Zegin", message = "Poruka iz Zegin apoteke" }
                                                                         });

            ActionBenefitServiceTest service = new ActionBenefitServiceTest();
            service.GetLastActionBenefit(mockDBContext.Object).ShouldBe("Poruka iz Zegin apoteke");
        }

        [Fact]
        public void Find_actionbenefit_by_pharmacy()
        {
            Mock<IMyDbContext> mockDBContext = new Mock<IMyDbContext>();
            mockDBContext.Setup(t => t.GetActionsBenefits()).Returns(new List<ActionBenefit> { new ActionBenefit() { pharmacy = "Benu", message = "Poruka iz Benu apoteke" },
                                                                           new ActionBenefit() { pharmacy = "Zegin", message = "Poruka iz Zegin apoteke" }
                                                                         });

            ActionBenefitServiceTest service = new ActionBenefitServiceTest();
            service.GetActionBenefit(mockDBContext.Object, "Benu").ShouldBe("Poruka iz Benu apoteke");
        }
    }
}
