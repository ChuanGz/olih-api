using Olih.Domain.DTOs;

namespace Olih.MockupData.Memory;

public static class BusinessPartnerMockSvc
{

    public static List<BusinessPartnerDto> GetAllBusinessPartner()
    {
        return _businessPartners;
    }

    public static BusinessPartnerDto? GetOneBusinessPartner(string cardCode)
    {
        return _businessPartners.SingleOrDefault(x => x.CardCode == cardCode);
    }

    public static BusinessPartnerDto CreateBusinessPartner(string cardCode, string CardName)
    {
        _businessPartners.Add(new BusinessPartnerDto { CardCode = cardCode, CardName = CardName, CardNumber = "" });
        return _businessPartners.Single(x => x.CardCode == cardCode);
    }

    public static void UpdateBusinessPartner(string cardCode, string newCardName, string newCardNumber)
    {
        var existed = _businessPartners.Single(x => x.CardCode == cardCode);
        existed.CardName = newCardName;
        existed.CardNumber = newCardNumber;
    }

    public static void DeleteBusinessPartner(string cardCode)
    {
        var existed = _businessPartners.SingleOrDefault(x => x.CardCode == cardCode);
        _businessPartners.RemoveAll(x => x.CardCode == cardCode);
    }

    private static List<BusinessPartnerDto> _businessPartners =
    [
        new BusinessPartnerDto()
            {
                CardCode = "970000" + new Random().Next(1000,9999).ToString(),
                    CardName = $"Random name {new Random().Next(1000,9999)}",
                    CardNumber = $"{new Random().Next(1000,9999)}",
                    Addresses = new List<AddressDto>()
                    {
                        new AddressDto()
                        {
                            StreetNo = "18 abc",
                            Ward = "test ward",
                            District = "test district",
                            City = "HCM",
                        },
                        new AddressDto()
                        {
                            StreetNo = "27 xyz",
                            Ward = "demo ward",
                            District = "demo district",
                            City = "HCM",
                        }
                    }
            },
            new BusinessPartnerDto(){
            CardCode = "970000" + new Random().Next(1000,9999).ToString(),
                    CardName = $"Random name {new Random().Next(1000,9999)}",
                    CardNumber = $"{new Random().Next(1000,9999)}",
                    Addresses = new List<AddressDto>()
                    {
                        new AddressDto()
                        {
                            StreetNo = "18 abc",
                            Ward = "test ward",
                            District = "test district",
                            City = "HCM",
                        },
                        new AddressDto()
                        {
                            StreetNo = "27 xyz",
                            Ward = "demo ward",
                            District = "demo district",
                            City = "HCM",
                        }
                    }
        },new BusinessPartnerDto(){
            CardCode = "970000" + new Random().Next(1000,9999).ToString(),
                    CardName = $"Random name {new Random().Next(1000,9999)}",
                    CardNumber = $"{new Random().Next(1000,9999)}",
                    Addresses = new List<AddressDto>()
                    {
                        new AddressDto()
                        {
                            StreetNo = "18 abc",
                            Ward = "test ward",
                            District = "test district",
                            City = "HCM",
                        },
                        new AddressDto()
                        {
                            StreetNo = "27 xyz",
                            Ward = "demo ward",
                            District = "demo district",
                            City = "HCM",
                        }
                    }
        },new BusinessPartnerDto(){
            CardCode = "970000" + new Random().Next(1000,9999).ToString(),
                    CardName = $"Random name {new Random().Next(1000,9999)}",
                    CardNumber = $"{new Random().Next(1000,9999)}",
                    Addresses = new List<AddressDto>()
                    {
                        new AddressDto()
                        {
                            StreetNo = "18 abc",
                            Ward = "test ward",
                            District = "test district",
                            City = "HCM",
                        },
                        new AddressDto()
                        {
                            StreetNo = "27 xyz",
                            Ward = "demo ward",
                            District = "demo district",
                            City = "HCM",
                        }
                    }
        },new BusinessPartnerDto(){
            CardCode = "970000" + new Random().Next(1000,9999).ToString(),
                    CardName = $"Random name {new Random().Next(1000,9999)}",
                    CardNumber = $"{new Random().Next(1000,9999)}",
                    Addresses = new List<AddressDto>()
                    {
                        new AddressDto()
                        {
                            StreetNo = "18 abc",
                            Ward = "test ward",
                            District = "test district",
                            City = "HCM",
                        },
                        new AddressDto()
                        {
                            StreetNo = "27 xyz",
                            Ward = "demo ward",
                            District = "demo district",
                            City = "HCM",
                        }
                    }
        },new BusinessPartnerDto(){
            CardCode = "970000" + new Random().Next(1000,9999).ToString(),
                    CardName = $"Random name {new Random().Next(1000,9999)}",
                    CardNumber = $"{new Random().Next(1000,9999)}",
                    Addresses = new List<AddressDto>()
                    {
                        new AddressDto()
                        {
                            StreetNo = "18 abc",
                            Ward = "test ward",
                            District = "test district",
                            City = "HCM",
                        },
                        new AddressDto()
                        {
                            StreetNo = "27 xyz",
                            Ward = "demo ward",
                            District = "demo district",
                            City = "HCM",
                        }
                    }
        },new BusinessPartnerDto(){
            CardCode = "970000" + new Random().Next(1000,9999).ToString(),
                    CardName = $"Random name {new Random().Next(1000,9999)}",
                    CardNumber = $"{new Random().Next(1000,9999)}",
                    Addresses = new List<AddressDto>()
                    {
                        new AddressDto()
                        {
                            StreetNo = "18 abc",
                            Ward = "test ward",
                            District = "test district",
                            City = "HCM",
                        },
                        new AddressDto()
                        {
                            StreetNo = "27 xyz",
                            Ward = "demo ward",
                            District = "demo district",
                            City = "HCM",
                        }
                    }
        },
        new BusinessPartnerDto()
        {
            CardCode = "970000" + new Random().Next(1000,9999).ToString(),
                    CardName = $"Random name {new Random().Next(1000,9999)}",
                    CardNumber = $"{new Random().Next(1000,9999)}",
                    Addresses = new List<AddressDto>()
                    {
                        new AddressDto()
                        {
                            StreetNo = "18 abc",
                            Ward = "test ward",
                            District = "test district",
                            City = "HCM",
                        },
                        new AddressDto()
                        {
                            StreetNo = "27 xyz",
                            Ward = "demo ward",
                            District = "demo district",
                            City = "HCM",
                        }
                    }
        },
        new BusinessPartnerDto()
        {
            CardCode = "970000" + new Random().Next(1000,9999).ToString(),
            CardName = $"Random name {new Random().Next(1000,9999)}",
            CardNumber = $"{new Random().Next(1000,9999)}",
                    Addresses = new List<AddressDto>()
                    {
                        new AddressDto()
                        {
                            StreetNo = "18 abc",
                            Ward = "test ward",
                            District = "test district",
                            City = "HCM",
                        },
                        new AddressDto()
                        {
                            StreetNo = "27 xyz",
                            Ward = "demo ward",
                            District = "demo district",
                            City = "HCM",
                        }
                    }
        },
        new BusinessPartnerDto()
        {
            CardCode = "970000" + new Random().Next(1000,9999).ToString(),
                    CardName = $"Random name {new Random().Next(1000,9999)}",
                    CardNumber = $"{new Random().Next(1000,9999)}",
                    Addresses = new List<AddressDto>()
                    {
                        new AddressDto()
                        {
                            StreetNo = "18 abc",
                            Ward = "test ward",
                            District = "test district",
                            City = "HCM",
                        },
                        new AddressDto()
                        {
                            StreetNo = "27 xyz",
                            Ward = "demo ward",
                            District = "demo district",
                            City = "HCM",
                        }
                    }
        }
];

}
