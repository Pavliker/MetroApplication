namespace MetroApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Операторы",
                c => new
                    {
                        КодОператора = c.Int(nullable: false, identity: true),
                        Логин = c.String(),
                        Пароль = c.String(),
                    })
                .PrimaryKey(t => t.КодОператора);
            
            CreateTable(
                "dbo.Роли",
                c => new
                    {
                        КодРоли = c.Int(nullable: false, identity: true),
                        НазваниеРоли = c.String(),
                    })
                .PrimaryKey(t => t.КодРоли);
            
            CreateTable(
                "dbo.Работники",
                c => new
                    {
                        КодРаботника = c.Int(nullable: false, identity: true),
                        ДатаДобавления = c.DateTime(nullable: false),
                        Логин = c.String(),
                        Пароль = c.String(),
                        ХэшированныйПароль = c.String(),
                    })
                .PrimaryKey(t => t.КодРаботника);
            
            CreateTable(
                "dbo.РолиОператоры",
                c => new
                    {
                        Роли_КодРоли = c.Int(nullable: false),
                        Операторы_КодОператора = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Роли_КодРоли, t.Операторы_КодОператора })
                .ForeignKey("dbo.Роли", t => t.Роли_КодРоли, cascadeDelete: true)
                .ForeignKey("dbo.Операторы", t => t.Операторы_КодОператора, cascadeDelete: true)
                .Index(t => t.Роли_КодРоли)
                .Index(t => t.Операторы_КодОператора);
            
            CreateTable(
                "dbo.РолиРаботники",
                c => new
                    {
                        Роли_КодРоли = c.Int(nullable: false),
                        Работники_КодРаботника = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Роли_КодРоли, t.Работники_КодРаботника })
                .ForeignKey("dbo.Роли", t => t.Роли_КодРоли, cascadeDelete: true)
                .ForeignKey("dbo.Работники", t => t.Работники_КодРаботника, cascadeDelete: true)
                .Index(t => t.Роли_КодРоли)
                .Index(t => t.Работники_КодРаботника);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.РолиРаботники", "Работники_КодРаботника", "dbo.Работники");
            DropForeignKey("dbo.РолиРаботники", "Роли_КодРоли", "dbo.Роли");
            DropForeignKey("dbo.РолиОператоры", "Операторы_КодОператора", "dbo.Операторы");
            DropForeignKey("dbo.РолиОператоры", "Роли_КодРоли", "dbo.Роли");
            DropIndex("dbo.РолиРаботники", new[] { "Работники_КодРаботника" });
            DropIndex("dbo.РолиРаботники", new[] { "Роли_КодРоли" });
            DropIndex("dbo.РолиОператоры", new[] { "Операторы_КодОператора" });
            DropIndex("dbo.РолиОператоры", new[] { "Роли_КодРоли" });
            DropTable("dbo.РолиРаботники");
            DropTable("dbo.РолиОператоры");
            DropTable("dbo.Работники");
            DropTable("dbo.Роли");
            DropTable("dbo.Операторы");
        }
    }
}
