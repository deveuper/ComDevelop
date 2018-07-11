using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    //更新的时间间隔
    public float UpdateInterval = 0.5F;
    //最后的时间间隔
    private float _lastInterval;
    //帧[中间变量 辅助
    private int _frames = 0;
    //当前的帧率
    private float _fps;

    void Start()
    {
        //Application.targetFrameRate=40;

        UpdateInterval = Time.realtimeSinceStartup;

        _frames = 0;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 200, 200), "FPS:" + _fps.ToString("f2"));
    }

    void Update()
    {
        ++_frames;

        if (Time.realtimeSinceStartup > _lastInterval + UpdateInterval)
        {
            _fps = _frames / (Time.realtimeSinceStartup - _lastInterval);

            _frames = 0;

            _lastInterval = Time.realtimeSinceStartup;
        }
    }
}
