using System.Collections.Generic;

namespace FinalGame
{
    interface IStats
    {
        List<int> GetStats();
        int GetStat(string key);
    }
}
