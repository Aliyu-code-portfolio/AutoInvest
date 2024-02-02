using AutoInvest.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Infrastructure.Config
{
    public class RolesConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        Name = "SuperAdmin",
                        NormalizedName= "SUPERADMIN"
                    },
                    new IdentityRole
                    {
                        Name = "Dealer",
                        NormalizedName = "DEALER"
                    },
                    new IdentityRole
                    {
                        Name = "Client",
                        NormalizedName = "CLIENT"
                    }
                );
        }
    }
}
