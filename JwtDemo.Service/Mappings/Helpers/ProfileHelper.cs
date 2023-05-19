using AutoMapper;
using JwtDemo.Service.Mappings.AutoMapper;

namespace JwtDemo.Service.Mappings.Helpers;

public class ProfileHelper
{
    public static List<Profile> GetProfiles()
    {
        return new List<Profile>()
        {
            new ProductProfile()
        };
    }
}
