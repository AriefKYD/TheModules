using FallenWing.Example.Abstraction.WeaponSystemSO;
namespace FallenWing.Example.ObserverPattern
{
    public class PlayerController_Obs : Example.Global.PlayerController
    {
        public override void OnEnable()
        {
            base.OnEnable();

            EventManager.onSwapWeapon += EventManager_onSwapWeapon;
        }
        public override void OnDisable()
        {
            base.OnDisable();
            EventManager.onSwapWeapon -= EventManager_onSwapWeapon;
        }
        private void EventManager_onSwapWeapon(SO_BaseWeapon weapon)
        {
            SwapWeapon(weapon);
        }
    }
}