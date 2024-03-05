using System.Collections.Generic;

namespace HotelAppLibrary.Databases
{
    public interface ISqlDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement,
                               U parametres,
                               string connectionStringName,
                               bool isStoredProcedure = false);
        void SaveData<T>(string sqlStatement,
                         T parametres,
                         string connectionStringName,
                         bool isStoredProcedure = false);
    }
}