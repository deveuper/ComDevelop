using UnityEngine;
using System.Collections;

namespace ComDevelop.Display.Demo
{
    public class DisplayController : MonoBehaviour
    {
        public float xSize;
        public float ySize;
        public float zSize;

        public Color color;

        // Use this for initialization
        void Start()
        {
            xSize = this.GetComponent<MeshFilter>().mesh.bounds.size.x * this.transform.localScale.x;
            ySize = this.GetComponent<MeshFilter>().mesh.bounds.size.y * this.transform.localScale.y;
            zSize = this.GetComponent<MeshFilter>().mesh.bounds.size.z * this.transform.localScale.z;
        }
        public GameObject Cube;
        public float r;
        public float g;
        public float b;
        public void CreateCube()
        {
            float randomX = Random.Range(-xSize / 2 + 0.5f, xSize / 2 - 0.5f);
            float randomZ = Random.Range(-zSize / 2 + 0.5f, zSize / 2 - 0.5f);

            GameObject temp = Instantiate(Cube, new Vector3(randomX, this.transform.position.y + 0.5f, randomZ), Quaternion.identity, this.transform);
            temp.transform.localPosition = new Vector3(randomX, this.transform.position.y + 0.5f, randomZ);
            r = Random.Range(0.0f, 1);
            g = Random.Range(0.0f, 1);
            b = Random.Range(0.0f, 1);
            color = new Color(r, g, b);
            temp.GetComponent<Renderer>().material.color = color;
        }
    }
}