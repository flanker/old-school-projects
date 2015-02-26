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

        }
    }
}
