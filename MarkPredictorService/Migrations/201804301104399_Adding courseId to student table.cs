namespace MarkPredictor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingcourseIdtostudenttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "CourseId", c => c.Long(nullable: true));
            CreateIndex("dbo.Students", "CourseId");
            AddForeignKey("dbo.Students", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "CourseId" });
            DropColumn("dbo.Students", "CourseId");
        }
    }
}
