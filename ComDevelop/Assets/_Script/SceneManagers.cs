using UnityEngine;
using System.Collections;

public class SceneManagers : MonoBehaviour
{
	Object Prefab_Wall = null;
	bool isMouseDown = false;
	bool isDraging = false;
	bool isDrawingBeging = false, isNewBegin = false;
	GameObject currentWall = null;
	GameObject door = null;

	// Use this for initialization
	void Start()
	{
		door = GameObject.Find("Door");
		Prefab_Wall = Resources.Load("Prefab_Wall");

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1")) {
			if (!isDrawingBeging) isDrawingBeging = true;
			isNewBegin = !isNewBegin;
			//CreateNewWall();
		}
	
		if (isDrawingBeging) {

		}
	}

	void OnMouseDown()
	{

	}

	private void CreateNewWall()
	{
		Vector3 mousePos = GetMousePos();

		GameObject wallObject = (GameObject)Instantiate(Prefab_Wall);
		wallObject.transform.position = mousePos;
		currentWall = wallObject;
	}

	public static Vector3 GetMousePos()
	{
		Vector3 mousePos = Vector3.zero;
		RaycastHit hit;//
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))//函数是对射线碰撞的检测，这个out是什么意思？
		{
			mousePos = hit.point;//得到碰撞点的坐标
			//print(Point);//输出一下
			//print("I'm looking at " + hit.transform.name);//输出碰到的物体名字
		}

		return mousePos;
	}
}
