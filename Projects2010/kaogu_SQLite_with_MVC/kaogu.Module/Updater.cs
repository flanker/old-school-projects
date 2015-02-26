using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace kaogu.Module
{
    public class Updater : ModuleUpdater
    {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            SimpleUser user = Session.FindObject<SimpleUser>(new BinaryOperator("UserName", "szzz"));
            if (user == null)
            {
                user = new SimpleUser(Session);
                user.UserName = "szzz";
                user.FullName = "szzz-admin";
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