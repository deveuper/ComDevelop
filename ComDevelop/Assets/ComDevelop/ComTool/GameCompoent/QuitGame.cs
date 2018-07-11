using UnityEngine;
namespace ComDevelop.ComTool
{
    public class QuitGame : MonoBehaviour
    {
        [Header("退出按键")]
        public KeyCode QuitKey = KeyCode.Escape;
        
        void Update()
        {
            if (Input.GetKeyDown(QuitKey))
            {
                QuitGames();
            }
        }
        public void QuitGames()
        {
            Application.Quit();
        }
    }
}