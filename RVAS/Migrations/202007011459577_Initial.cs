namespace RVAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Matches",
                c => new
                {
                    Id = c.Long(nullable: false),
                    UtcDate = c.DateTime(),
                    Status = c.String(),
                    Venue = c.String(),
                    Matchday = c.Long(nullable: false),
                    Stage = c.String(),
                    Group = c.String(),
                    LastUpdated = c.DateTime(),
                    AwayTeam_Id = c.Int(),
                    Competition_Id = c.Long(),
                    HomeTeam_Id = c.Int(),
                    Score_Id = c.Int(),
                    Season_Id = c.Long(),
                    HeadMatchListByCompetition_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeam_Id)
                .ForeignKey("dbo.Competitions", t => t.Competition_Id)
                .ForeignKey("dbo.Teams", t => t.HomeTeam_Id)
                .ForeignKey("dbo.Scores", t => t.Score_Id)
                .ForeignKey("dbo.Seasons", t => t.Season_Id)
                .ForeignKey("dbo.HeadMatchListByCompetitions", t => t.HeadMatchListByCompetition_Id)
                .Index(t => t.AwayTeam_Id)
                .Index(t => t.Competition_Id)
                .Index(t => t.HomeTeam_Id)
                .Index(t => t.Score_Id)
                .Index(t => t.Season_Id)
                .Index(t => t.HeadMatchListByCompetition_Id);

            CreateTable(
               "dbo.Referees",
               c => new
               {
                   Id = c.Long(nullable: false),
                   Name = c.String(),
                   Nationality = c.String(),
               })
               .PrimaryKey(t => t.Id);

            CreateTable(
              "dbo.RefereeMatches",
              c => new
              {
                  Referee_Id = c.Long(nullable: false),
                  Match_Id = c.Long(nullable: false),
              })
              .PrimaryKey(t => new { t.Referee_Id, t.Match_Id })
              .ForeignKey("dbo.Referees", t => t.Referee_Id, cascadeDelete: true)
              .ForeignKey("dbo.Matches", t => t.Match_Id, cascadeDelete: true)
              .Index(t => t.Referee_Id)
              .Index(t => t.Match_Id);
            return;

            CreateTable(
                "dbo.BettingPairs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bet = c.String(),
                        Match_Id = c.Long(),
                        BettingTicket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.Match_Id)
                .ForeignKey("dbo.BettingTickets", t => t.BettingTicket_Id)
                .Index(t => t.Match_Id)
                .Index(t => t.BettingTicket_Id);
            
            
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Wins = c.Long(nullable: false),
                        Draws = c.Long(nullable: false),
                        Losses = c.Long(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        Tla = c.String(),
                        CrestUrl = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        Founded = c.Int(nullable: false),
                        ClubColors = c.String(),
                        Venue = c.String(),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        CountryOfBirth = c.String(),
                        Nationality = c.String(),
                        Position = c.String(),
                        LastUpdated = c.DateTime(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Plan = c.String(),
                        LastUpdated = c.DateTime(precision: 7, storeType: "datetime2"),
                        CurrentSeason_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seasons", t => t.CurrentSeason_Id)
                .Index(t => t.CurrentSeason_Id);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        CurrentMatchday = c.Long(),
                        Winner_Id = c.Int(),
                        Competition_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Winner_Id)
                .ForeignKey("dbo.Competitions", t => t.Competition_Id)
                .Index(t => t.Winner_Id)
                .Index(t => t.Competition_Id);
            
           
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Winner = c.String(),
                        Duration = c.String(),
                        ExtraTime_Id = c.Int(),
                        FullTime_Id = c.Int(),
                        HalfTime_Id = c.Int(),
                        Penalties_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HomeTeamAwayTeams", t => t.ExtraTime_Id)
                .ForeignKey("dbo.HomeTeamAwayTeams", t => t.FullTime_Id)
                .ForeignKey("dbo.HomeTeamAwayTeams", t => t.HalfTime_Id)
                .ForeignKey("dbo.HomeTeamAwayTeams", t => t.Penalties_Id)
                .Index(t => t.ExtraTime_Id)
                .Index(t => t.FullTime_Id)
                .Index(t => t.HalfTime_Id)
                .Index(t => t.Penalties_Id);
            
            CreateTable(
                "dbo.HomeTeamAwayTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeTeam = c.Long(),
                        AwayTeam = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BettingTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Head2Head",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfMatches = c.Long(nullable: false),
                        TotalGoals = c.Long(nullable: false),
                        AwayTeam_Id = c.Int(),
                        HomeTeam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeam_Id)
                .ForeignKey("dbo.Teams", t => t.HomeTeam_Id)
                .Index(t => t.AwayTeam_Id)
                .Index(t => t.HomeTeam_Id);
            
            CreateTable(
                "dbo.HeadMatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Head2Head_Id = c.Int(),
                        Match_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Head2Head", t => t.Head2Head_Id)
                .ForeignKey("dbo.Matches", t => t.Match_Id)
                .Index(t => t.Head2Head_Id)
                .Index(t => t.Match_Id);
            
            CreateTable(
                "dbo.HeadMatchListByCompetitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Long(nullable: false),
                        Competition_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Competitions", t => t.Competition_Id)
                .Index(t => t.Competition_Id);
            
            CreateTable(
                "dbo.HeadStandings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Competition_Id = c.Long(),
                        Season_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Competitions", t => t.Competition_Id)
                .ForeignKey("dbo.Seasons", t => t.Season_Id)
                .Index(t => t.Competition_Id)
                .Index(t => t.Season_Id);
            
            CreateTable(
                "dbo.Standings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stage = c.String(),
                        Type = c.String(),
                        HeadStanding_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HeadStandings", t => t.HeadStanding_Id)
                .Index(t => t.HeadStanding_Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.Long(nullable: false),
                        PlayedGames = c.Long(nullable: false),
                        Won = c.Long(nullable: false),
                        Draw = c.Long(nullable: false),
                        Lost = c.Long(nullable: false),
                        Points = c.Long(nullable: false),
                        GoalsFor = c.Long(nullable: false),
                        GoalsAgainst = c.Long(nullable: false),
                        GoalDifference = c.Long(nullable: false),
                        Team_Id = c.Int(),
                        Standing_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .ForeignKey("dbo.Standings", t => t.Standing_Id)
                .Index(t => t.Team_Id)
                .Index(t => t.Standing_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
          
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Standings", "HeadStanding_Id", "dbo.HeadStandings");
            DropForeignKey("dbo.Tables", "Standing_Id", "dbo.Standings");
            DropForeignKey("dbo.Tables", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.HeadStandings", "Season_Id", "dbo.Seasons");
            DropForeignKey("dbo.HeadStandings", "Competition_Id", "dbo.Competitions");
            DropForeignKey("dbo.Matches", "HeadMatchListByCompetition_Id", "dbo.HeadMatchListByCompetitions");
            DropForeignKey("dbo.HeadMatchListByCompetitions", "Competition_Id", "dbo.Competitions");
            DropForeignKey("dbo.HeadMatches", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.HeadMatches", "Head2Head_Id", "dbo.Head2Head");
            DropForeignKey("dbo.Head2Head", "HomeTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Head2Head", "AwayTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.BettingTickets", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BettingPairs", "BettingTicket_Id", "dbo.BettingTickets");
            DropForeignKey("dbo.BettingPairs", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.Matches", "Season_Id", "dbo.Seasons");
            DropForeignKey("dbo.Matches", "Score_Id", "dbo.Scores");
            DropForeignKey("dbo.Scores", "Penalties_Id", "dbo.HomeTeamAwayTeams");
            DropForeignKey("dbo.Scores", "HalfTime_Id", "dbo.HomeTeamAwayTeams");
            DropForeignKey("dbo.Scores", "FullTime_Id", "dbo.HomeTeamAwayTeams");
            DropForeignKey("dbo.Scores", "ExtraTime_Id", "dbo.HomeTeamAwayTeams");
            DropForeignKey("dbo.RefereeMatches", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.RefereeMatches", "Referee_Id", "dbo.Referees");
            DropForeignKey("dbo.Matches", "HomeTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Competition_Id", "dbo.Competitions");
            DropForeignKey("dbo.Seasons", "Competition_Id", "dbo.Competitions");
            DropForeignKey("dbo.Competitions", "CurrentSeason_Id", "dbo.Seasons");
            DropForeignKey("dbo.Seasons", "Winner_Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "AwayTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Players", "Team_Id", "dbo.Teams");
            DropIndex("dbo.RefereeMatches", new[] { "Match_Id" });
            DropIndex("dbo.RefereeMatches", new[] { "Referee_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tables", new[] { "Standing_Id" });
            DropIndex("dbo.Tables", new[] { "Team_Id" });
            DropIndex("dbo.Standings", new[] { "HeadStanding_Id" });
            DropIndex("dbo.HeadStandings", new[] { "Season_Id" });
            DropIndex("dbo.HeadStandings", new[] { "Competition_Id" });
            DropIndex("dbo.HeadMatchListByCompetitions", new[] { "Competition_Id" });
            DropIndex("dbo.HeadMatches", new[] { "Match_Id" });
            DropIndex("dbo.HeadMatches", new[] { "Head2Head_Id" });
            DropIndex("dbo.Head2Head", new[] { "HomeTeam_Id" });
            DropIndex("dbo.Head2Head", new[] { "AwayTeam_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BettingTickets", new[] { "User_Id" });
            DropIndex("dbo.Scores", new[] { "Penalties_Id" });
            DropIndex("dbo.Scores", new[] { "HalfTime_Id" });
            DropIndex("dbo.Scores", new[] { "FullTime_Id" });
            DropIndex("dbo.Scores", new[] { "ExtraTime_Id" });
            DropIndex("dbo.Seasons", new[] { "Competition_Id" });
            DropIndex("dbo.Seasons", new[] { "Winner_Id" });
            DropIndex("dbo.Competitions", new[] { "CurrentSeason_Id" });
            DropIndex("dbo.Players", new[] { "Team_Id" });
            DropIndex("dbo.Matches", new[] { "HeadMatchListByCompetition_Id" });
            DropIndex("dbo.Matches", new[] { "Season_Id" });
            DropIndex("dbo.Matches", new[] { "Score_Id" });
            DropIndex("dbo.Matches", new[] { "HomeTeam_Id" });
            DropIndex("dbo.Matches", new[] { "Competition_Id" });
            DropIndex("dbo.Matches", new[] { "AwayTeam_Id" });
            DropIndex("dbo.BettingPairs", new[] { "BettingTicket_Id" });
            DropIndex("dbo.BettingPairs", new[] { "Match_Id" });
            DropTable("dbo.RefereeMatches");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tables");
            DropTable("dbo.Standings");
            DropTable("dbo.HeadStandings");
            DropTable("dbo.HeadMatchListByCompetitions");
            DropTable("dbo.HeadMatches");
            DropTable("dbo.Head2Head");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BettingTickets");
            DropTable("dbo.HomeTeamAwayTeams");
            DropTable("dbo.Scores");
            DropTable("dbo.Referees");
            DropTable("dbo.Seasons");
            DropTable("dbo.Competitions");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
            DropTable("dbo.BettingPairs");
        }
    }
}
