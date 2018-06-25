using UnityEngine;
using UnityEngine.Events;

//使用Serializable序列化IdolEvent, 否则无法在Editor中显示
[System.Serializable]
public class IdolEvent : UnityEvent<string>
{

}

public class Idol_event : MonoBehaviour
{
    public UnityEvent event1 = new UnityEvent();
    //public delegate void IdolBehaviour(string behaviour);
    //public event IdolBehaviour IdolDoSomethingHandler;
    public IdolEvent idolEvent;

    private void Start()
    {
        //Idol 决定搞事了, 如果他还有粉丝的话, 就必须全部都通知到
        if (idolEvent == null)
        {
            idolEvent = new IdolEvent();
        }
        idolEvent.Invoke("Idol give up writing.");

        event1.AddListener(stringWrite);

        event1.Invoke();

    }
    public void stringWrite()
    {
        print("偶像主播+  ");
    }


}