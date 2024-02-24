﻿namespace FinancialHub.Auth.Infra.Data.Repositories
{
    public class CredentialRepository : ICredentialRepository
    {
        private readonly FinancialHubAuthContext context;

        public CredentialRepository(FinancialHubAuthContext context)
        {
            this.context = context;
        }

        public async Task<CredentialEntity> CreateAsync(CredentialEntity credential)
        {
            credential.Id = null;
            credential.CreationTime = DateTimeOffset.Now;
            credential.UpdateTime = DateTimeOffset.Now;
            credential.User = default!;

            var entry = await this.context.Credentials.AddAsync(credential);
            await this.context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<CredentialEntity?> GetAsync(string username)
        {
            return await this.context.Credentials.FirstOrDefaultAsync(x => x.Login == username);
        }

        public async Task<CredentialEntity?> GetAsync(string username, string password)
        {
            return await this.context.Credentials.FirstOrDefaultAsync(x => x.Login == username && x.Password == password);
        }

        public async Task<IEnumerable<CredentialEntity>> GetAsync(Guid userId)
        {
            return await this.context.Credentials.Where(x => x.UserId == userId).ToArrayAsync();
        }
    }
}
