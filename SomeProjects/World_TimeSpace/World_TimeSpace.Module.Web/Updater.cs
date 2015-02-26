using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;

namespace World_TimeSpace.Module.Web
{
    public class Updater : ModuleUpdater
    {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
        }
    }
}
