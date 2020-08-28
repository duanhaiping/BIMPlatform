using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;

namespace BIMPlatform.Users
{
    public class BIMPlatformAdministratorUserDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        protected IdentityUserManager UserManager { get; }
        protected IIdentityUserRepository UserRepository { get; }
        private readonly IGuidGenerator _guidGenerator;

        public BIMPlatformAdministratorUserDataSeederContributor(IdentityUserManager identityUserManager , IGuidGenerator generator , IIdentityUserRepository userRepository)
        {
            this.UserManager = identityUserManager;
            this._guidGenerator = generator;
            UserRepository = userRepository;


        }
        public async Task SeedAsync(DataSeedContext context)
        {
            var  admnistrator = UserManager.FindByNameAsync("admin");
            if (admnistrator != null)
            {
                return;
             
               
            }

            var user = new Volo.Abp.Identity.IdentityUser(
                 _guidGenerator.Create(),
                 "admin",
                 "bim@bimEmail.com"
             );
            user.Name = "administrator";
            await UserRepository.InsertAsync(user) ;
           
            return; 
        }
    }
}
