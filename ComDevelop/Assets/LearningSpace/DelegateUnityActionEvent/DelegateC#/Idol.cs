using UnityEngine;

public class Idol : MonoBehaviour
{
    public delegate void IdolBehaviour(string behaviour);
    public static event IdolBehaviour IdolDoSomethingHandler;

    private void Start()
    {
        //Idol 决定搞事了, 如果他还有粉丝的话, 就必须全部都通知到
        if (IdolDoSomethingHandler != null)
        {
            IdolDoSomethingHandler("Idol give up writing.");
        }
    }
}