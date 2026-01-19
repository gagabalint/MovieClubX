using Castle.Components.DictionaryAdapter;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieClubX.Data.Helpers
{

    public class AppUser : IdentityUser
    {
        [StringLength(250)]
        public required string FamilyName { get; set; } = string.Empty;

        [StringLength(250)]
        public required string GivenName { get; set; } = string.Empty;

    }

}
