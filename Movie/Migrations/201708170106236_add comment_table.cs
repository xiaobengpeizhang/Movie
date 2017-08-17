namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcomment_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        commentID = c.Int(nullable: false, identity: true),
                        userID = c.Int(nullable: false),
                        filmID = c.Int(nullable: false),
                        commentTitle = c.String(),
                        commentBody = c.String(),
                        create_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.commentID)
                .ForeignKey("dbo.Film", t => t.filmID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID)
                .Index(t => t.filmID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        email = c.String(),
                        password = c.String(),
                        create_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.userID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "userID", "dbo.User");
            DropForeignKey("dbo.Comment", "filmID", "dbo.Film");
            DropIndex("dbo.Comment", new[] { "filmID" });
            DropIndex("dbo.Comment", new[] { "userID" });
            DropTable("dbo.User");
            DropTable("dbo.Comment");
        }
    }
}
