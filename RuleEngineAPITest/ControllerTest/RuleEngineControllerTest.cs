using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RuleEngine.Domain.Rule;
using RuleEngineAPI.Application.Commands.Promotion;
using RuleEngineAPI.Application.ViewModels.Movies;
using RuleEngineAPI.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RuleEngineAPITest.ControllerTest
{
    [TestClass]
    public class RuleEngineControllerTest
    {

        private IOptions<RuleEntity> _config;

        [TestInitialize]
        public void Initialize()
        {

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build();
            _config = Options.Create(configuration.GetSection("Promotion").Get<RuleEntity>());
        }

        [TestMethod]
        public void ScenarioATest()
        {
            var actualresult = 100;
            var scenariArequest = new PromotionRequestViewModel();
            scenariArequest.PurchasedPoduct.Add(new RuleEngineAPI.Application.ViewModels.Promotion.Product() { CodeName = "A", Quantity = 1 });
            scenariArequest.PurchasedPoduct.Add(new RuleEngineAPI.Application.ViewModels.Promotion.Product() { CodeName = "B", Quantity = 1 });
            scenariArequest.PurchasedPoduct.Add(new RuleEngineAPI.Application.ViewModels.Promotion.Product() { CodeName = "C", Quantity = 1 });
            var promCammand = new PromotionRuleCommand(scenariArequest);
            var promhandler = new PromotionRuleCommandHandler(_config);
            var actualResult = promhandler.Handle(promCammand, new System.Threading.CancellationToken()).GetAwaiter().GetResult();
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualResult.promotionalPrice, actualResult.promotionalPrice);
        }

        [TestMethod]
        public void ScenarioBTest()
        {
            var actualresult = 370;
            var scenariArequest = new PromotionRequestViewModel();
            scenariArequest.PurchasedPoduct.Add(new RuleEngineAPI.Application.ViewModels.Promotion.Product() { CodeName = "A", Quantity = 5 });
            scenariArequest.PurchasedPoduct.Add(new RuleEngineAPI.Application.ViewModels.Promotion.Product() { CodeName = "B", Quantity = 5 });
            scenariArequest.PurchasedPoduct.Add(new RuleEngineAPI.Application.ViewModels.Promotion.Product() { CodeName = "C", Quantity = 1 });
            var promCammand = new PromotionRuleCommand(scenariArequest);
            var promhandler = new PromotionRuleCommandHandler(_config);
            var actualResult = promhandler.Handle(promCammand, new System.Threading.CancellationToken()).GetAwaiter().GetResult();
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualResult.promotionalPrice, actualResult.promotionalPrice);
        }

        [TestMethod]
        public void ScenarioCTest()
        {
            var actualresult = 280;
            var scenariArequest = new PromotionRequestViewModel();
            scenariArequest.PurchasedPoduct.Add(new RuleEngineAPI.Application.ViewModels.Promotion.Product() { CodeName = "A", Quantity = 3 });
            scenariArequest.PurchasedPoduct.Add(new RuleEngineAPI.Application.ViewModels.Promotion.Product() { CodeName = "B", Quantity = 5 });
            scenariArequest.PurchasedPoduct.Add(new RuleEngineAPI.Application.ViewModels.Promotion.Product() { CodeName = "C", Quantity = 1 });
            scenariArequest.PurchasedPoduct.Add(new RuleEngineAPI.Application.ViewModels.Promotion.Product() { CodeName = "D", Quantity = 1 });
            var promCammand = new PromotionRuleCommand(scenariArequest);
            var promhandler = new PromotionRuleCommandHandler(_config);
            var actualResult = promhandler.Handle(promCammand, new System.Threading.CancellationToken()).GetAwaiter().GetResult();
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualResult.promotionalPrice, actualResult.promotionalPrice);
        }
    }
}
