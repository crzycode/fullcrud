namespace Api_Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mangal1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.userdatas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.userdatas");
        }
    }
}
