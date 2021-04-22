namespace MovieApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieRequiredConstraint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Kind", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Price", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Price", c => c.String());
            AlterColumn("dbo.Movies", "Kind", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String());
        }
    }
}
