using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuNo
{
    public class SettingsService
    {
        private const string GoalKey = "goal";

        public event Action? SettingsChanged;

        private int _goal;

        public int Goal
        {
            get => _goal;
            private set => _goal = value;
        }

        public SettingsService()
        {
            _goal =
                Preferences.Default
                    .Get(GoalKey, 100);
        }

        public void SetGoal(int goal)
        {
            Goal = goal;

            Preferences.Default.Set(
                GoalKey,
                goal);

            SettingsChanged?.Invoke();
        }
    }
}
