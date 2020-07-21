namespace RVAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Betting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BettingTips",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Tip = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.BettingPairs", "BettingTipId", c => c.Int(nullable: false));
            CreateIndex("dbo.BettingPairs", "BettingTipId");
            AddForeignKey("dbo.BettingPairs", "BettingTipId", "dbo.BettingTips", "id", cascadeDelete: true);
            DropColumn("dbo.BettingPairs", "Bet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BettingPairs", "Bet", c => c.String());
            DropForeignKey("dbo.BettingPairs", "BettingTipId", "dbo.BettingTips");
            DropIndex("dbo.BettingPairs", new[] { "BettingTipId" });
            DropColumn("dbo.BettingPairs", "BettingTipId");
            DropTable("dbo.BettingTips");
        }
    }
}
