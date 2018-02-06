using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
	Mesh myMesh = null;
	// Use this for initialization
	void Start()
	{
		myMesh = this.GetComponent<MeshFilter>().mesh;
		DrawMesh();
	}

	private void DrawMesh()
	{
		float x = 1f;
		float y = 1f;
		float z = 1f;
		Vector3[] vectors = new Vector3[3];
		int index = 0;
		//上
		vectors[index++] = new Vector3(x, y, z);//0
		vectors[index++] = new Vector3(-x, y, z);//1
		vectors[index++] = new Vector3(-x, y, -z);//2

		myMesh.vertices = vectors;
		myMesh.triangles = new int[] { 
			0, 2,1
		};
	}

	// Update is called once per frame
	void Update()
	{

	}
}
