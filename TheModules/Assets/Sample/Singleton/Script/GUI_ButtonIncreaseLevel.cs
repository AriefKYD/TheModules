using UnityEngine;
namespace FallenWing.Example.Singleton
{
    /// <summary>
    /// Actually we can just bind with inspector button event but
    /// due to show the accessability of singleton, these way is preferable
    /// </summary>
    public class GUI_ButtonIncreaseLevel : MonoBehaviour
    {
        public void IncreasePlayerlevel()
        {
            GameManager.Instance.IncreasePlayerLevel();
        }
    }
}
