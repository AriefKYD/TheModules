using UnityEngine;

namespace FallenWing.Module.Abstraction
{
    public class Cow : IBaseFunc
    {

        public void Initialize()
        {
            Debug.Log("Moooo!");
        }

    }
}