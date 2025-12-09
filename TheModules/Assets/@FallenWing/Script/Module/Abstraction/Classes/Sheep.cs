using UnityEngine;

namespace FallenWing.Module.Abstraction
{
    public class Sheep : IBaseFunc
    {

        public void Initialize()
        {
            Debug.Log("Baaa!");
        }
    }
}