using UnityEngine;

public class Sub_B : MonoBehaviour
{
    public Idol_event myIdol;

    /// <summary>
    /// OnEnable在该脚本被启用时调用,你可以把它看做路转粉的开端
    /// </summary>
    private void OnEnable()
    {
        //粉丝通过订阅偶像来获取偶像的咨询, 并在得到讯息后执行相应的动作
        myIdol.idolEvent.AddListener(HateIdol);
    }

    /// <summary>
    /// OnEnable在该脚本被禁用时调用,你可以把它看做粉转路的开端
    /// </summary>
    private void OnDisable()
    {
        myIdol.idolEvent.RemoveListener(HateIdol);
    }

    /// <summary>
    /// 粉丝B是一个无脑黑
    /// </summary>
    /// <param name="idolAction"></param>
    public void HateIdol(string idolAction)
    {
        print(idolAction + " I will hate you forever!");
    }
}