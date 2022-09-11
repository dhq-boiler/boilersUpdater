﻿using Homura.ORM;
using Homura.ORM.Mapping;
using Homura.ORM.Migration;
using update.Domain.Data.Dao;
using update.Models;

namespace update.Data.Dao.Migration.Plan
{
    internal class ChangePlan_VC_VersionControl_VersionOrigin : ChangePlanByTable<VersionControl, VersionOrigin>
    {
        public override void CreateTable(IConnection connection)
        {
            var dao = new VersionControlDao(typeof(VersionOrigin));
            dao.CurrentConnection = connection;
            dao.CreateTableIfNotExists();
            ++ModifiedCount;
            dao.CreateIndexIfNotExists();
            ++ModifiedCount;
        }

        public override void DropTable(IConnection connection)
        {
            var dao = new VersionControlDao(typeof(VersionOrigin));
            dao.CurrentConnection = connection;
            dao.DropTable();
            ++ModifiedCount;
        }

        public override void UpgradeToTargetVersion(IConnection connection)
        {
            CreateTable(connection);
        }
    }
}