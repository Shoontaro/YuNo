using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuNo
{
    internal class SettingsService
    {
        private const string GoalKey = "goal";

        public int GetGoal()
        {
            return Preferences.Default
                .Get(GoalKey, 1000);
        }

        public void SetGoal(int value)
        {
            Preferences.Default
                .Set(GoalKey, value);
        }
    }
}
