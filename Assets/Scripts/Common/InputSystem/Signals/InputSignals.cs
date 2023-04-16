namespace Common.InputSystem.Signals
{
    public static class InputSignals
    {
        public sealed class Shot{}
        public sealed class Reload{}
        
        public sealed class ChangeWeapon
        {
            public WeaponState State { get; }

            public ChangeWeapon(WeaponState state)
            {
                State = state;
            }
        }
    }
}