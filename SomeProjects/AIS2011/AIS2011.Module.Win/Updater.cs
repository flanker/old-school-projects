using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;

namespace AIS2011.Module.Win
{
    public class Updater : ModuleUpdater
    {
        public Updater(ObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            SimpleUser user = ObjectSpace.FindObject<SimpleUser>(new BinaryOperator("UserName", "Barkol"));
            if (user == null)
            {
                user = ObjectSpace.CreateObject<SimpleUser>();
                user.UserName = "Barkol";
                user.FullName = "Barkol2011";
            }
            // Make the user an administrator
            user.IsAdministrator = true;
            // Set a password if the standard authentication type is used
            user.SetPassword("");
            // Save the user to the database
            user.Save();

        }
    }
}
