using Microsoft.EntityFrameworkCore;
using RestAPI_TESTE.Models;

namespace RestAPI_TESTE.Data {
    public class BancoContext : DbContext {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options) {

        }

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
