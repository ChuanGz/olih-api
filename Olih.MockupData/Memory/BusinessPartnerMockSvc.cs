using Olih.Domain.DTOs;

namespace Olih.MockupData.Memory;

public static class BusinessPartnerMockSvc
{
    public static void GenerateSampleBusinessPartners(int count)
    {
        List<BusinessPartnerDto> partners = new List<BusinessPartnerDto>();

        for (int i = 1; i <= count; i++)
        {
            BusinessPartnerDto partner = new BusinessPartnerDto
            {
                CardCode = $"BP_{i.ToString("000")}",
                CardName = $"Business Partner {i}",
                CardNumber = $"CN{i}",
                Addresses = new List<AddressDto>
                {
                    new AddressDto { StreetNo = $"Street {i}", Ward = $"Ward {i}", District = $"District {i}", City = $"City {i}", Country = $"Country {i}" }
                },
                CurrentBalance = 1000.0 + i,
                CreditLimit = 2000.0 + i
            };
            partners.Add(partner);
        }
        _businessPartners = partners;
    }
    public static List<BusinessPartnerDto> GetAllBusinessPartner()
    {
        GenerateSampleBusinessPartners(100);
        return _businessPartners!;
    }

    public static BusinessPartnerDto? GetOneBusinessPartner(string cardCode)
    {
        return _businessPartners!.SingleOrDefault(x => x.CardCode == cardCode);
    }

    public static BusinessPartnerDto CreateBusinessPartner(string cardCode, string CardName)
    {
        _businessPartners!.Add(new BusinessPartnerDto { CardCode = cardCode, CardName = CardName, CardNumber = "" });
        return _businessPartners.Single(x => x.CardCode == cardCode);
    }

    public static void UpdateBusinessPartner(string cardCode, string newCardName, string newCardNumber)
    {
        var existed = _businessPartners!.Single(x => x.CardCode == cardCode);
        existed.CardName = newCardName;
        existed.CardNumber = newCardNumber;
    }

    public static void DeleteBusinessPartner(string cardCode)
    {
        var existed = _businessPartners!.SingleOrDefault(x => x.CardCode == cardCode);
        _businessPartners!.RemoveAll(x => x.CardCode == cardCode);
    }

    private static List<BusinessPartnerDto>? _businessPartners;

}
