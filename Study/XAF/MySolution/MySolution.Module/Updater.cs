using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace MySolution.Module
{
    public class Updater : ModuleUpdater
    {
        public Updater(Session session, Version currentDBVersion)
            : base(session, currentDBVersion)
        {
        }

        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();

            if (Session.FindObject<Contact>(CriteriaOperator.Parse("FirstName == 'Mary' && LastName == 'Tellitson'")) == null)
            {
                Contact contact = new Contact(Session);
                contact.FirstName = "Mary";
                contact.LastName = "Tellitson";
                contact.Email = "mary_tellitson@md.com";
                contact.Birthday = new DateTime(1980, 11, 27);
                contact.Save();
            }

            // If a simple user named 'Sam' doesn't exist in the database, create this simple user
            SimpleUser user = Session.FindObject<SimpleUser>(new BinaryOperator("UserName", "admin"));
            if (user == null)
            {
                user = new SimpleUser(Session);
                user.UserName = "admin";
                user.FullName = "admin";
            }
            // Make the user an administrator
            user.IsAdministrator = true;
            // Set a password if the standard authentication type is used
            user.SetPassword("123456");
            // Save the user to the database
            user.Save();

        }
    }
}
