﻿using AutoMapper;
using FinancialHub.Core.Domain.Interfaces.Mappers;
using FinancialHub.Core.Domain.Interfaces.Repositories;
using FinancialHub.Core.Domain.Interfaces.Services;
using FinancialHub.Core.Domain.Tests.Builders.Entities;
using FinancialHub.Core.Application.Mappers;
using FinancialHub.Core.Application.Services;

namespace FinancialHub.Core.Application.Tests.Services
{
    public partial class BalancesServiceTests
    {
        protected Random random;
        protected BalanceEntityBuilder balanceEntityBuilder;
        protected BalanceModelBuilder balanceModelBuilder;

        private IBalancesService service;

        private IMapper mapper;
        private Mock<IMapperWrapper> mapperWrapper;
        private Mock<IBalancesRepository> repository;
        private Mock<IAccountsRepository> accountsRepository;

        private void MockMapper()
        {
            mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FinancialHubAutoMapperProfile());
            }
            ).CreateMapper();

            this.mapperWrapper = new Mock<IMapperWrapper>();
        }

        [SetUp]
        public void Setup()
        {
            this.MockMapper();

            this.repository         = new Mock<IBalancesRepository>();
            this.accountsRepository = new Mock<IAccountsRepository>();
            this.service            = new BalancesService(
                mapperWrapper.Object, 
                repository.Object, 
                accountsRepository.Object
            );

            this.random = new Random();

            this.balanceEntityBuilder = new BalanceEntityBuilder();
            this.balanceModelBuilder = new BalanceModelBuilder();
        }

        private void SetUpMapper()
        {
            this.mapperWrapper
                .Setup(x => x.Map<BalanceModel>(It.IsAny<BalanceEntity>()))
                .Returns<BalanceEntity>((ent) => this.mapper.Map<BalanceModel>(ent))
                .Verifiable();

            this.mapperWrapper
                .Setup(x => x.Map<BalanceEntity>(It.IsAny<BalanceModel>()))
                .Returns<BalanceModel>((model) => this.mapper.Map<BalanceEntity>(model))
                .Verifiable();
        }

        public ICollection<BalanceEntity> GenerateBalances()
        {
            return this.balanceEntityBuilder.Generate(random.Next(5, 10));
        }
    }
}