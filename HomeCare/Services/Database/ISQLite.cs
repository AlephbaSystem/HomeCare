using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Services.Database
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
