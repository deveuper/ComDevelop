using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    //���µ�ʱ����
    public float UpdateInterval = 0.5F;
    //����ʱ����
    private float _lastInterval;
    //֡[�м���� ����
    private int _frames = 0;
    //��ǰ��֡��
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
