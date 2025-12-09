using UnityEngine;

namespace FallenWing.Module.Abstraction
{
    public class AbstractionDebugger : MonoBehaviour
    {
        private void DebugAbstractClasses()
        {
            Debug.Log("Create Abstract Class as Player Class");
            BaseAbstractClass _abtractClass = new PlayerClass();
            _abtractClass.Initialize();
            Debug.Log("Change Abstract Class to Enemy Class");
            _abtractClass = new EnemyClass();
            _abtractClass.Initialize();

        }


        private void DebugInterfaceClasses()
        {
            Debug.Log("Create Interface Class as Cow Class");
            IBaseFunc _abtractClass = new Cow();
            _abtractClass.Initialize();
            Debug.Log("Change Interface Class to Sheep Class");
            _abtractClass = new Sheep();
            _abtractClass.Initialize();
        }
    }
}