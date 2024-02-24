﻿using FinancialHub.Auth.Domain.Interfaces.Helpers;

namespace FinancialHub.Auth.Infra.Mappers
{
    public class FinancialHubAuthCredentialProfile : Profile
    {
        public FinancialHubAuthCredentialProfile(IPasswordHelper helper) : base()
        {
            this.CreateMap<CredentialEntity, CredentialModel>().ReverseMap();

            this.CreateMap<SignupModel, UserModel>();
            this.CreateMap<SignupModel, CredentialModel>()
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Password, y => y.MapFrom(z => helper.Encrypt(z.Password)));

            this.CreateMap<SigninModel, CredentialModel>()
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.Password, y => y.MapFrom(z => helper.Encrypt(z.Password)));
        }
    }
}
