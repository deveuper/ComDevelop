using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshPrinter : MonoBehaviour
{

	private string text_name;
	private string text_vertices;
	private string text_normals;
	private string text_triangles;
	private string text_uv;
	private string text_tangents;

	public MeshFilter mCurrentFilter;

	public List<MeshFilter> targets;

	void Start()
	{

		targets = new List<MeshFilter>();
		AddAllTargets();

		mCurrentFilter = null;

	}

	void Update()
	{

		if (Input.GetKeyUp(KeyCode.Tab)) {
			TargetMesh();
			FillText();
		}
	}

	void OnGUI()
	{


		float _x = 10;
		Vector2 textSize = GUI.skin.label.CalcSize(new GUIContent(text_name));
		GUI.Label(new Rect(_x, 10, textSize.x, textSize.y), text_name);

		textSize = GUI.skin.label.CalcSize(new GUIContent(text_triangles));
		GUI.Label(new Rect(_x, 30, textSize.x, textSize.y), text_triangles);

		_x += textSize.x + 20;
		textSize = GUI.skin.label.CalcSize(new GUIContent(text_vertices));
		GUI.Label(new Rect(_x, 30, textSize.x, textSize.y), text_vertices);

		_x += textSize.x + 20;
		textSize = GUI.skin.label.CalcSize(new GUIContent(text_normals));
		GUI.Label(new Rect(_x, 30, textSize.x, textSize.y), text_normals);

		_x += textSize.x + 20;
		textSize = GUI.skin.label.CalcSize(new GUIContent(text_tangents));
		GUI.Label(new Rect(_x, 30, textSize.x, textSize.y), text_tangents);

		_x += textSize.x + 20;
		textSize = GUI.skin.label.CalcSize(new GUIContent(text_uv));
		GUI.Label(new Rect(_x, 30, textSize.x, textSize.y), text_uv);

	}

	public void AddAllTargets()
	{

		GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		foreach (GameObject go in gos)
			if (go.GetComponent<MeshFilter>() != null)
				AddTarget(go.GetComponent<MeshFilter>());
	}

	public void AddTarget(MeshFilter target)
	{

		targets.Add(target);
	}

	private void TargetMesh()
	{

		if (mCurrentFilter == null) {
			mCurrentFilter = targets[0];
		}
		else {
			int index = targets.IndexOf(mCurrentFilter);
			if (index < targets.Count - 1) {
				index++;
			}
			else {
				index = 0;
			}
			mCurrentFilter = targets[index];
		}
	}

	private void FillText()
	{

		text_name = "Name: " + mCurrentFilter.gameObject.name;

		Mesh mesh = mCurrentFilter.mesh;

		int size = mesh.vertexCount;
		text_vertices = "vertices: " + size + "\n";
		for (int i = 0; i < size; i++) {
			text_vertices += i + ": " + mesh.vertices[i][0] + "," + mesh.vertices[i][1] + "," + mesh.vertices[i][2] + ";\n";
		}

		size = mesh.normals.Length;
		text_normals = "normals: " + size + "\n";
		for (int i = 0; i < size; i++) {
			text_normals += mesh.normals[i].x + "," + mesh.normals[i].y + "," + mesh.normals[i].z + ";\n";
		}

		size = mesh.triangles.Length;
		text_triangles = "triangles: " + size + "\n";
		for (int i = 0; i < size / 3; i++) {
			text_triangles += mesh.triangles[3 * i] + "," + mesh.triangles[3 * i + 1] + "," + mesh.triangles[3 * i + 2] + ";\n";
		}

		size = mesh.uv.Length;
		text_uv = "uv: " + size + "\n";
		for (int i = 0; i < size; i++) {
			text_uv += mesh.uv[i][0] + "," + mesh.uv[i][1] + ";\n";

		}
		size = mesh.tangents.Length; text_tangents = "tangents: " + size + "\n";
		for (int i = 0; i < size; i++) {
			text_tangents += mesh.tangents[i][0] + ", " + mesh.tangents[i][1] + ", " + mesh.tangents[i][2] + ", " + mesh.tangents[i][3] + ";\n";
		}
	}
}
