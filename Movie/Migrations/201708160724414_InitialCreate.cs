namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        filmID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        director = c.String(),
                        description = c.String(),
                        show_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.filmID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Film");
        }
    }
}
