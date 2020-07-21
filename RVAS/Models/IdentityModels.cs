using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RVAS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Head2Head> Head2Heads { get; set; }
        public DbSet<HeadMatch> HeadMatches { get; set; }
        public DbSet<HeadStanding> HeadStandings { get; set; }
        public DbSet<HomeTeamAwayTeam> HomeTeamAwayTeams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Standing> Standings { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<HeadMatchListByCompetition> HeadMatchListByCompetitions { get; set; }
        public DbSet<BettingPair> BettingPairs { get; set; }
        public DbSet<BettingTicket> BettingTickets { get; set; }
        public DbSet<BettingTip> BettingTips { get; set; }














        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}