using AutoMapper;
using MsBanking.Core.Card.Domain.Const;

namespace MsBanking.Core.Card.Domain.Dto
{
    public class CardDto
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CardType { get; set; }
        public string CardVendorType { get; set; }
        public string CardStatus { get; set; }
        public string Cvv { get; set; }
        public decimal CreditLimit { get; set; }
        public string UserId { get; set; }
    }

    public class CardRequestDto : CardDto
    {
    }

    public class CardResponseDto : CardDto
    {
        public int Id { get; set; }
    }

    public class CardDtoProfile : Profile
    {
        public CardDtoProfile()
        {
            CreateMap<MsBanking.Core.Card.Domain.Entity.Card, CardDto>()
                .ForMember(x => x.CardVendorType, opt => opt.MapFrom(src => Enum.GetName(typeof(CardVendorTypeEnum), src.CardVendorType)))
                .ForMember(x => x.CardStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(CardStatusEnum), src.CardStatus)))
                .ForMember(x => x.CardType, opt => opt.MapFrom(src => Enum.GetName(typeof(CardTypeEnum), src.CardType)))
            .ReverseMap();
            CreateMap<MsBanking.Core.Card.Domain.Entity.Card, CardResponseDto>()
                .ForMember(x => x.CardVendorType, opt => opt.MapFrom(src => Enum.GetName(typeof(CardVendorTypeEnum), src.CardVendorType)))
                .ForMember(x => x.CardStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(CardStatusEnum), src.CardStatus)))
                .ForMember(x => x.CardType, opt => opt.MapFrom(src => Enum.GetName(typeof(CardTypeEnum), src.CardType)))
                .ReverseMap();
            CreateMap<MsBanking.Core.Card.Domain.Entity.Card, CardRequestDto>()
                       .ForMember(x => x.CardVendorType, opt => opt.MapFrom(src => Enum.GetName(typeof(CardVendorTypeEnum), src.CardVendorType)))
                .ForMember(x => x.CardStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(CardStatusEnum), src.CardStatus)))
                .ForMember(x => x.CardType, opt => opt.MapFrom(src => Enum.GetName(typeof(CardTypeEnum), src.CardType)))
                .ReverseMap();


        }
    }
}
