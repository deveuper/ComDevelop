using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshCreater : MonoBehaviour
{
	float Height = 3f;
	float Width =1f;
	float Length =6f;
	Vector2 uv00 = new Vector2(0, 0);
	Vector2 uv01 = new Vector2(0, 1);
	Vector2 uv10 = new Vector2(1, 0);
	Vector2 uv11 = new Vector2(1, 1);
	Mesh myMesh = null;
	bool isDraging = false;
	GameObject door = null;
	List<Transform> lstDoors = new List<Transform>();
	// Use this for initialization
	void Start()
	{
	
		door = GameObject.Find("Door");
		myMesh = this.GetComponent<MeshFilter>().mesh;
		DrawMesh();
        //this.GetComponent<MeshCollider>().mesh = myMesh;
        this.GetComponent<MeshCollider>().sharedMesh = myMesh;
	}

	// Update is called once per frame
	void Update()
	{
		//this.transform.localScale = new Vector3(1f, 3f, 1f);
		if (Input.GetButtonDown("Fire2")) {
			isDraging = true;
		}
		if (Input.GetButtonUp("Fire2")) {
			isDraging = false;
		}
		if (isDraging) {
			Vector3 screenpos = Camera.main.WorldToScreenPoint(door.transform.position);
			Vector3 e = Input.mousePosition;
			e.z = screenpos.z;
			Vector3 wordPos = Camera.main.ScreenToWorldPoint(e);
			door.transform.position = new Vector3(wordPos.x, door.transform.position.y, wordPos.z);
		}
	}

	private void DrawMesh()
	{
		float x = Length / 2f;
		float y = Height / 2f;
		float z = Width / 2f;
		Vector3[] vertices = new Vector3[24];
		Vector2[] uvs = new Vector2[24];
		int index = 0, uvIndex = 0;
		//上下 8个基本顶点
		vertices[index++] = new Vector3(-x, y, z);//0
		vertices[index++] = new Vector3(-x, y, -z); //1
		vertices[index++] = new Vector3(x, y, -z);//2
		vertices[index++] = new Vector3(x, y, z);//3
		vertices[index++] = new Vector3(-x, -y, z);//4
		vertices[index++] = new Vector3(-x, -y, -z);//5
		vertices[index++] = new Vector3(x, -y, -z);//6
		vertices[index++] = new Vector3(x, -y, z);//7
//
		vertices[index++] = new Vector3(-x, y, z);//8
		vertices[index++] = new Vector3(-x, y, -z); //9
		vertices[index++] = new Vector3(x, y, -z);//10
		vertices[index++] = new Vector3(x, y, z);//11
		vertices[index++] = new Vector3(-x, -y, z);//12
		vertices[index++] = new Vector3(-x, -y, -z);//13
		vertices[index++] = new Vector3(x, -y, -z);//14
		vertices[index++] = new Vector3(x, -y, z);//15
		vertices[index++] = new Vector3(-x, y, z);//16
		vertices[index++] = new Vector3(-x, y, -z); //17
		vertices[index++] = new Vector3(x, y, -z);//18
		vertices[index++] = new Vector3(x, y, z);//19
		vertices[index++] = new Vector3(-x, -y, z);//20
		vertices[index++] = new Vector3(-x, -y, -z);//21
		vertices[index++] = new Vector3(x, -y, -z);//22
		vertices[index++] = new Vector3(x, -y, z);//23
//
		uvs[0] = uv01;
		uvs[1] = uv00;
		uvs[2] = uv10;
		uvs[3] = uv11;

		uvs[5] = uv10;	
		uvs[9] = uv11;
		uvs[8] = uv01;
		uvs[4] = uv00;
		uvs[7] =  uv10;
		uvs[11] =  uv11;
		uvs[6] =uv00;
		uvs[10] =uv01;
		uvs[13] = uv01;	
		uvs[12] = uv00;
		uvs[14] = uv11;
		uvs[15] = uv10;
		uvs[16] = uv00;  
		uvs[17] = uv01;
		uvs[18] = uv11;
		uvs[19] = uv10;
		uvs[20] = uv01;
		uvs[21] = uv00;
		uvs[22] = uv10;
		uvs[23] = uv11;

		myMesh.vertices = vertices;
		myMesh.triangles = new int[] {
			0, 2, 1, 0, 3, 2,
			4, 9, 5, 4, 8, 9,
			11, 7, 6, 11, 6, 10,
			12, 14, 15, 12, 13, 14,
			16, 23, 19, 16, 20, 23,
			17, 22, 21, 17, 18, 22
		};
		myMesh.uv = uvs;
	}

	void OnTriggerEnter(Collider other)
	{
		print("OnTriggerEnter");
		if (lstDoors.Count > 0) return;
		isDraging = false;
		Transform newDoor = other.gameObject.transform;
		newDoor.position = new Vector3(newDoor.position.x,
			newDoor.transform.position.y, transform.position.z);

		lstDoors.Add(newDoor);
		CalcMesh();
	}

	private void CalcMesh()
	{
		Transform newDoor = lstDoors[lstDoors.Count - 1];
		Vector3[] vertices = new Vector3[myMesh.vertices.Length + 16];
		Vector2[] uvs = new Vector2[vertices.Length];
		int[] triangles = new int[myMesh.triangles.Length + 24];
		int verticeIndex = 0, triangleIndex = 0, uvIndex = 0;

		CalcNormalVertice(vertices, ref verticeIndex, triangles, ref triangleIndex,uvs,ref uvIndex);
		foreach (Transform door in lstDoors) {
			CalcDoorVertice(door, vertices, ref verticeIndex, triangles, ref triangleIndex,uvs,ref uvIndex);
		}

		CalcUnfinishedVertice (verticeIndex,triangles, ref triangleIndex, uvs, ref uvIndex);

		myMesh.vertices = vertices;
		myMesh.triangles = triangles;
		myMesh.uv = uvs;
	}

	private void CalcNormalVertice(Vector3[] vertices, ref int verticeIndex,
		int[] triangles, ref int triangleIndex,Vector2[] uvs,ref int uvIndex)
	{
			float x = Length / 2f;
			float y = Height / 2f;
			float z = Width / 2f;
			//上下 8个基本顶点
			vertices [verticeIndex++] = new Vector3 (-x, y, z);//0
			vertices [verticeIndex++] = new Vector3 (-x, y, -z); //1
			vertices [verticeIndex++] = new Vector3 (x, y, -z);//2
			vertices [verticeIndex++] = new Vector3 (x, y, z);//3
			vertices [verticeIndex++] = new Vector3 (-x, -y, z);//4
			vertices [verticeIndex++] = new Vector3 (-x, -y, -z);//5
			vertices [verticeIndex++] = new Vector3 (x, -y, -z);//6
			vertices [verticeIndex++] = new Vector3 (x, -y, z);//7
			//
			vertices [verticeIndex++] = new Vector3 (-x, y, z);//8
			vertices [verticeIndex++] = new Vector3 (-x, y, -z); //9
			vertices [verticeIndex++] = new Vector3 (x, y, -z);//10
			vertices [verticeIndex++] = new Vector3 (x, y, z);//11
			vertices [verticeIndex++] = new Vector3 (-x, -y, z);//12
			vertices [verticeIndex++] = new Vector3 (-x, -y, -z);//13
			vertices [verticeIndex++] = new Vector3 (x, -y, -z);//14
			vertices [verticeIndex++] = new Vector3 (x, -y, z);//15
			vertices [verticeIndex++] = new Vector3 (-x, y, z);//16
			vertices [verticeIndex++] = new Vector3 (-x, y, -z); //17
			vertices [verticeIndex++] = new Vector3 (x, y, -z);//18
			vertices [verticeIndex++] = new Vector3 (x, y, z);//19
			vertices [verticeIndex++] = new Vector3 (-x, -y, z);//20
			vertices [verticeIndex++] = new Vector3 (-x, -y, -z);//21
			vertices [verticeIndex++] = new Vector3 (x, -y, -z);//22
			vertices [verticeIndex++] = new Vector3 (x, -y, z);//23
			triangles [triangleIndex++] = 0;
			triangles [triangleIndex++] = 2;
			triangles [triangleIndex++] = 1;
			triangles [triangleIndex++] = 0;
			triangles [triangleIndex++] = 3;
			triangles [triangleIndex++] = 2;
			triangles [triangleIndex++] = 4;
			triangles [triangleIndex++] = 9;
			triangles [triangleIndex++] = 5;
			triangles [triangleIndex++] = 4;
			triangles [triangleIndex++] = 8;
			triangles [triangleIndex++] = 9;
			triangles [triangleIndex++] = 11;
			triangles [triangleIndex++] = 7;
			triangles [triangleIndex++] = 6;
			triangles [triangleIndex++] = 11;
			triangles [triangleIndex++] = 6;
			triangles [triangleIndex++] = 10;
		uvs[uvIndex++]= uv01;	
		uvs[uvIndex++]= uv00;
		uvs[uvIndex++]= uv10;
		uvs[uvIndex++]= uv11;
		uvs[uvIndex++] =  uv00;//4
		uvs[uvIndex++] = uv10;//5;
		uvs[uvIndex++] =uv00;
		uvs[uvIndex++] =uv10;//7
		uvs[uvIndex++] = uv01;	
		uvs[uvIndex++]= uv11;//9
		uvs[uvIndex++] = uv01;	
		uvs[uvIndex++]= uv11;//11

		uvs[uvIndex++]= Vector2.zero;//12
		uvs[uvIndex++]=  Vector2.zero;//13
		uvs[uvIndex++]= Vector2.zero;//14
		uvs[uvIndex++]= Vector2.zero;//15	
		uvs[uvIndex++]= uv00;//16
		uvs[uvIndex++]= uv01;//17

		uvs[uvIndex++]= uv11;//18
		uvs[uvIndex++]= uv10;//19
		uvs[uvIndex++]= uv01;//20
		uvs[uvIndex++]= uv00;//21

		uvs[uvIndex++]= uv10;//22
		uvs[uvIndex++]= uv11;//23

	}

	private void CalcDoorVertice(Transform door, Vector3[] vertices, ref int verticeIndex,
	                             int[] triangles, ref int triangleIndex,Vector2[] uvs,ref int uvIndex)
	{
		int startPos = verticeIndex;
		Vector3 doorSize = door.GetComponent<BoxCollider>().size;
		float xDistance = door.position.x - transform.position.x;
		float yDistance = door.position.y - transform.position.y;
		// 后面
		Vector3 topL = new Vector3(-doorSize.x / 2 + xDistance, Height / 2f, Width / 2f);
		Vector3 topR = new Vector3(topL.x + doorSize.x, topL.y, topL.z);
		Vector3 leftTop = new Vector3(topL.x, doorSize.y / 2 + yDistance, topL.z);
		Vector3 leftBottom = new Vector3(topL.x, -topL.y, topL.z);
		Vector3 rightTop = new Vector3(topR.x, leftTop.y, topL.z);
		Vector3 rightBottom = new Vector3(topR.x, leftBottom.y, topL.z);
		vertices[verticeIndex++] = topL;//24
		vertices[verticeIndex++] = leftTop;//25
		vertices[verticeIndex++] = leftBottom;//26
		vertices[verticeIndex++] = topR;//27
		vertices[verticeIndex++] = rightTop;//28
		vertices[verticeIndex++] = rightBottom;//29
		vertices[verticeIndex++] = topL;//30
		vertices[verticeIndex++] = topR;//31
		// 连三角形
		triangles[triangleIndex++] = 16;
		triangles[triangleIndex++] = startPos + 2;
		triangles[triangleIndex++] = startPos;
		triangles[triangleIndex++] = 16;
		triangles[triangleIndex++] = 20;
		triangles[triangleIndex++] = startPos + 2;
		triangles[triangleIndex++] = verticeIndex-2;
		triangles[triangleIndex++] = startPos + 4;
		triangles[triangleIndex++] = startPos + 3;
		triangles[triangleIndex++] =  verticeIndex-2;
		triangles[triangleIndex++] = startPos + 1;
		triangles[triangleIndex++] = startPos + 4;
		float uvXValue =  (leftTop.x - vertices[0].x) / Length;
		float uvYValue =  (vertices[0].y-leftTop.y ) / Height;
		uvs [uvIndex++] = new Vector2 (uvXValue, 0f);
		uvs [uvIndex++] = new Vector2 (uvXValue, uvYValue);
		uvs [uvIndex++] = new Vector2 (uvXValue, 1f);
		float uvXValue1 =  (rightTop.x - vertices[0].x) / Length;
		uvs [uvIndex++] = new Vector2 (uvXValue1, 0f);
		uvs [uvIndex++] = new Vector2 (uvXValue1, uvYValue);
		uvs [uvIndex++] = new Vector2 (uvXValue1, 1f);

		uvs [uvIndex++] = new Vector2 (uvXValue, 0f);
		uvs [uvIndex++] = new Vector2 (uvXValue1, 0f);
		// 前面
		Vector3 topL1 = new Vector3(topL.x, topL.y, -topL.z);
		Vector3 topR1 = new Vector3(topR.x, topR.y, -topL.z);
		Vector3 leftTop1 = new Vector3(leftTop.x, leftTop.y, -topL.z);
		Vector3 leftBottom1 = new Vector3(leftBottom.x, leftBottom.y, -topL.z);
		Vector3 rightTop1 = new Vector3(rightTop.x, rightTop.y, -topL.z);
		Vector3 rightBottom1 = new Vector3(rightBottom.x, rightBottom.y, -topL.z);
		startPos = verticeIndex;
		vertices[verticeIndex++] = topL1;//32
		vertices[verticeIndex++] = leftTop1;//33
		vertices[verticeIndex++] = leftBottom1;//34
		vertices[verticeIndex++] = topR1;//35
		vertices[verticeIndex++] = rightTop1;//36
		vertices[verticeIndex++] = rightBottom1;//37
		vertices[verticeIndex++] = topL1;//38
		vertices[verticeIndex++] = topR1;//39
		// 连三角形
		triangles[triangleIndex++] = 17;
		triangles[triangleIndex++] = startPos + 2;
		triangles[triangleIndex++] = 21;
		triangles[triangleIndex++] = 17;
		triangles[triangleIndex++] = startPos ;
		triangles[triangleIndex++] = startPos + 2;
		triangles[triangleIndex++] = startPos ;
		triangles[triangleIndex++] = startPos + 4;
		triangles[triangleIndex++] = startPos + 1;
		triangles[triangleIndex++] = startPos;
		triangles[triangleIndex++] = startPos + 3;
		triangles[triangleIndex++] = startPos + 4;

		uvs [uvIndex++] = new Vector2 (uvXValue, 1f);
		uvs [uvIndex++] = new Vector2 (uvXValue,1f- uvYValue);
		uvs [uvIndex++] = new Vector2 (uvXValue, 0f);
		uvs [uvIndex++] = new Vector2 (uvXValue1, 1f);
		uvs [uvIndex++] = new Vector2 (uvXValue1,1f- uvYValue);
		uvs [uvIndex++] = new Vector2 (uvXValue1, 0f);

		uvs [uvIndex++] = new Vector2 (uvXValue, 1f);
		uvs [uvIndex++] = new Vector2 (uvXValue1, 1f);
	}
	
	private void CalcUnfinishedVertice(int verticeIndex, int[] triangles, ref int triangleIndex,Vector2[] uvs,ref int uvIndex)
	{
		if (lstDoors.Count > 0) {
						int startPos = verticeIndex - 9;
						triangles [triangleIndex++] = startPos;
						triangles [triangleIndex++] = 23;
						triangles [triangleIndex++] = 19;
						triangles [triangleIndex++] = startPos;
						triangles [triangleIndex++] = startPos - 2;
						triangles [triangleIndex++] = 23;
//		uvs [uvIndex++] = new Vector2 (uvXValue, 1f);
//		uvs [uvIndex++] = new Vector2 (uvXValue,1f- uvYValue);
//		uvs [uvIndex++] = new Vector2 (uvXValue, 0f);
//		uvs [uvIndex++] = new Vector2 (uvXValue1, 1f);

						startPos = verticeIndex - 1;
						triangles [triangleIndex++] = startPos;
						triangles [triangleIndex++] = 22;
						triangles [triangleIndex++] = startPos - 2;
						triangles [triangleIndex++] = startPos;
						triangles [triangleIndex++] = 18;
						triangles [triangleIndex++] = 22;
				}
	}

}
