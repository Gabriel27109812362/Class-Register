namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Auths",
                c => new
                    {
                        StudentAuthId = c.Int(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StudentAuthId)
                .ForeignKey("dbo.Students", t => t.StudentAuthId)
                .Index(t => t.StudentAuthId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        Value = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Auths", "StudentAuthId", "dbo.Students");
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropIndex("dbo.Auths", new[] { "StudentAuthId" });
            DropTable("dbo.Grades");
            DropTable("dbo.Auths");
            DropTable("dbo.Students");
        }
    }
}