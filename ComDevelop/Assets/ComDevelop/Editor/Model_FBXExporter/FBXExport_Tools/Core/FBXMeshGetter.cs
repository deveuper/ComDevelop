using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ComDevelop.EditorTool.FBXTool
{
    internal class FBXMeshGetter
    {
        public static long GetMeshToString(GameObject gameObj, Material[] materials, ref StringBuilder objects, ref StringBuilder connections, GameObject parentObject = null, long parentModelId = 0L)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            long randomFBXId = FBXWriter.GetRandomFBXId();
            long randomFBXId2 = FBXWriter.GetRandomFBXId();
            MeshFilter component = gameObj.GetComponent<MeshFilter>();
            string name = gameObj.name;
            string text = "Null";
            bool flag = component != null;
            if (flag)
            {
                name = component.sharedMesh.name;
                text = "Mesh";
            }
            bool flag2 = parentModelId == 0L;
            if (flag2)
            {
                stringBuilder2.AppendLine("\t;Model::" + name + ", Model::RootNode");
            }
            else
            {
                stringBuilder2.AppendLine("\t;Model::" + name + ", Model::USING PARENT");
            }
            stringBuilder2.AppendLine(string.Concat(new object[]
            {
                "\tC: \"OO\",",
                randomFBXId2,
                ",",
                parentModelId
            }));
            stringBuilder2.AppendLine();
            stringBuilder.AppendLine(string.Concat(new object[]
            {
                "\tModel: ",
                randomFBXId2,
                ", \"Model::",
                gameObj.name,
                "\", \"",
                text,
                "\" {"
            }));
            stringBuilder.AppendLine("\t\tVersion: 232");
            stringBuilder.AppendLine("\t\tProperties70:  {");
            stringBuilder.AppendLine("\t\t\tP: \"RotationOrder\", \"enum\", \"\", \"\",4");
            stringBuilder.AppendLine("\t\t\tP: \"RotationActive\", \"bool\", \"\", \"\",1");
            stringBuilder.AppendLine("\t\t\tP: \"InheritType\", \"enum\", \"\", \"\",1");
            stringBuilder.AppendLine("\t\t\tP: \"ScalingMax\", \"Vector3D\", \"Vector\", \"\",0,0,0");
            stringBuilder.AppendLine("\t\t\tP: \"DefaultAttributeIndex\", \"int\", \"Integer\", \"\",0");
            Vector3 localPosition = gameObj.transform.localPosition;
            stringBuilder.Append("\t\t\tP: \"Lcl Translation\", \"Lcl Translation\", \"\", \"A+\",");
            stringBuilder.AppendFormat("{0},{1},{2}", localPosition.x * -1f, localPosition.y, localPosition.z);
            stringBuilder.AppendLine();
            Vector3 localEulerAngles = gameObj.transform.localEulerAngles;
            stringBuilder.AppendFormat("\t\t\tP: \"Lcl Rotation\", \"Lcl Rotation\", \"\", \"A+\",{0},{1},{2}", localEulerAngles.x, localEulerAngles.y * -1f, -1f * localEulerAngles.z);
            stringBuilder.AppendLine();
            Vector3 localScale = gameObj.transform.localScale;
            stringBuilder.AppendFormat("\t\t\tP: \"Lcl Scaling\", \"Lcl Scaling\", \"\", \"A\",{0},{1},{2}", localScale.x, localScale.y, localScale.z);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t\t\tP: \"currentUVSet\", \"KString\", \"\", \"U\", \"map1\"");
            stringBuilder.AppendLine("\t\t}");
            stringBuilder.AppendLine("\t\tShading: T");
            stringBuilder.AppendLine("\t\tCulling: \"CullingOff\"");
            stringBuilder.AppendLine("\t}");
            bool flag3 = component != null;
            if (flag3)
            {
                Mesh sharedMesh = component.sharedMesh;
                stringBuilder.AppendLine("\tGeometry: " + randomFBXId + ", \"Geometry::\", \"Mesh\" {");
                Vector3[] vertices = sharedMesh.vertices;
                int num = sharedMesh.vertexCount * 3;
                stringBuilder.AppendLine("\t\tVertices: *" + num + " {");
                stringBuilder.Append("\t\t\ta: ");
                for (int i = 0; i < vertices.Length; i++)
                {
                    bool flag4 = i > 0;
                    if (flag4)
                    {
                        stringBuilder.Append(",");
                    }
                    stringBuilder.AppendFormat("{0},{1},{2}", vertices[i].x * -1f, vertices[i].y, vertices[i].z);
                }
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("\t\t} ");
                int num2 = sharedMesh.triangles.Length;
                int[] triangles = sharedMesh.triangles;
                stringBuilder.AppendLine("\t\tPolygonVertexIndex: *" + num2 + " {");
                stringBuilder.Append("\t\t\ta: ");
                for (int j = 0; j < num2; j += 3)
                {
                    bool flag5 = j > 0;
                    if (flag5)
                    {
                        stringBuilder.Append(",");
                    }
                    stringBuilder.AppendFormat("{0},{1},{2}", triangles[j], triangles[j + 2], triangles[j + 1] * -1 - 1);
                }
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("\t\t} ");
                stringBuilder.AppendLine("\t\tGeometryVersion: 124");
                stringBuilder.AppendLine("\t\tLayerElementNormal: 0 {");
                stringBuilder.AppendLine("\t\t\tVersion: 101");
                stringBuilder.AppendLine("\t\t\tName: \"\"");
                stringBuilder.AppendLine("\t\t\tMappingInformationType: \"ByPolygonVertex\"");
                stringBuilder.AppendLine("\t\t\tReferenceInformationType: \"Direct\"");
                Vector3[] normals = sharedMesh.normals;
                stringBuilder.AppendLine("\t\t\tNormals: *" + num2 * 3 + " {");
                stringBuilder.Append("\t\t\t\ta: ");
                for (int k = 0; k < num2; k += 3)
                {
                    bool flag6 = k > 0;
                    if (flag6)
                    {
                        stringBuilder.Append(",");
                    }
                    Vector3 vector = normals[triangles[k]];
                    stringBuilder.AppendFormat("{0},{1},{2},", vector.x * -1f, vector.y, vector.z);
                    vector = normals[triangles[k + 2]];
                    stringBuilder.AppendFormat("{0},{1},{2},", vector.x * -1f, vector.y, vector.z);
                    vector = normals[triangles[k + 1]];
                    stringBuilder.AppendFormat("{0},{1},{2}", vector.x * -1f, vector.y, vector.z);
                }
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("\t\t\t}");
                stringBuilder.AppendLine("\t\t}");
                int num3 = sharedMesh.uv.Length;
                Vector2[] array = sharedMesh.uv;
                stringBuilder.AppendLine("\t\tLayerElementUV: 0 {");
                stringBuilder.AppendLine("\t\t\tVersion: 101");
                stringBuilder.AppendLine("\t\t\tName: \"map1\"");
                stringBuilder.AppendLine("\t\t\tMappingInformationType: \"ByPolygonVertex\"");
                stringBuilder.AppendLine("\t\t\tReferenceInformationType: \"IndexToDirect\"");
                stringBuilder.AppendLine("\t\t\tUV: *" + num3 * 2 + " {");
                stringBuilder.Append("\t\t\t\ta: ");
                for (int l = 0; l < num3; l++)
                {
                    bool flag7 = l > 0;
                    if (flag7)
                    {
                        stringBuilder.Append(",");
                    }
                    stringBuilder.AppendFormat("{0},{1}", array[l].x, array[l].y);
                }
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("\t\t\t\t}");
                stringBuilder.AppendLine("\t\t\tUVIndex: *" + num2 + " {");
                stringBuilder.Append("\t\t\t\ta: ");
                for (int m = 0; m < num2; m += 3)
                {
                    bool flag8 = m > 0;
                    if (flag8)
                    {
                        stringBuilder.Append(",");
                    }
                    int num4 = triangles[m];
                    int num5 = triangles[m + 2];
                    int num6 = triangles[m + 1];
                    stringBuilder.AppendFormat("{0},{1},{2}", num4, num5, num6);
                }
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("\t\t\t}");
                stringBuilder.AppendLine("\t\t}");
                bool flag9 = sharedMesh.uv2.Length != 0;
                if (flag9)
                {
                    num3 = sharedMesh.uv2.Length;
                    array = sharedMesh.uv2;
                    stringBuilder.AppendLine("\t\tLayerElementUV: 1 {");
                    stringBuilder.AppendLine("\t\t\tVersion: 101");
                    stringBuilder.AppendLine("\t\t\tName: \"map2\"");
                    stringBuilder.AppendLine("\t\t\tMappingInformationType: \"ByPolygonVertex\"");
                    stringBuilder.AppendLine("\t\t\tReferenceInformationType: \"IndexToDirect\"");
                    stringBuilder.AppendLine("\t\t\tUV: *" + num3 * 2 + " {");
                    stringBuilder.Append("\t\t\t\ta: ");
                    for (int n = 0; n < num3; n++)
                    {
                        bool flag10 = n > 0;
                        if (flag10)
                        {
                            stringBuilder.Append(",");
                        }
                        stringBuilder.AppendFormat("{0},{1}", array[n].x, array[n].y);
                    }
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine("\t\t\t\t}");
                    stringBuilder.AppendLine("\t\t\tUVIndex: *" + num2 + " {");
                    stringBuilder.Append("\t\t\t\ta: ");
                    for (int num7 = 0; num7 < num2; num7 += 3)
                    {
                        bool flag11 = num7 > 0;
                        if (flag11)
                        {
                            stringBuilder.Append(",");
                        }
                        int num8 = triangles[num7];
                        int num9 = triangles[num7 + 2];
                        int num10 = triangles[num7 + 1];
                        stringBuilder.AppendFormat("{0},{1},{2}", num8, num9, num10);
                    }
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine("\t\t\t}");
                    stringBuilder.AppendLine("\t\t}");
                }
                stringBuilder.AppendLine("\t\tLayerElementMaterial: 0 {");
                stringBuilder.AppendLine("\t\t\tVersion: 101");
                stringBuilder.AppendLine("\t\t\tName: \"\"");
                stringBuilder.AppendLine("\t\t\tMappingInformationType: \"ByPolygon\"");
                stringBuilder.AppendLine("\t\t\tReferenceInformationType: \"IndexToDirect\"");
                int num11 = 0;
                int subMeshCount = sharedMesh.subMeshCount;
                StringBuilder stringBuilder3 = new StringBuilder();
                bool flag12 = subMeshCount == 1;
                if (flag12)
                {
                    int num12 = triangles.Length / 3;
                    for (int num13 = 0; num13 < num12; num13++)
                    {
                        stringBuilder3.Append("0,");
                        num11++;
                    }
                }
                else
                {
                    List<int[]> list = new List<int[]>();
                    for (int num14 = 0; num14 < subMeshCount; num14++)
                    {
                        list.Add(sharedMesh.GetIndices(num14));
                    }
                    for (int num15 = 0; num15 < triangles.Length; num15 += 3)
                    {
                        for (int num16 = 0; num16 < list.Count; num16++)
                        {
                            bool flag13 = false;
                            for (int num17 = 0; num17 < list[num16].Length; num17 += 3)
                            {
                                bool flag14 = triangles[num15] == list[num16][num17] && triangles[num15 + 1] == list[num16][num17 + 1] && triangles[num15 + 2] == list[num16][num17 + 2];
                                if (flag14)
                                {
                                    stringBuilder3.Append(num16.ToString());
                                    stringBuilder3.Append(",");
                                    num11++;
                                    break;
                                }
                                bool flag15 = flag13;
                                if (flag15)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                stringBuilder.AppendLine("\t\t\tMaterials: *" + num11 + " {");
                stringBuilder.Append("\t\t\t\ta: ");
                stringBuilder.AppendLine(stringBuilder3.ToString());
                stringBuilder.AppendLine("\t\t\t} ");
                stringBuilder.AppendLine("\t\t}");
                stringBuilder.AppendLine("\t\tLayer: 0 {");
                stringBuilder.AppendLine("\t\t\tVersion: 100");
                stringBuilder.AppendLine("\t\t\tLayerElement:  {");
                stringBuilder.AppendLine("\t\t\t\tType: \"LayerElementNormal\"");
                stringBuilder.AppendLine("\t\t\t\tTypedIndex: 0");
                stringBuilder.AppendLine("\t\t\t}");
                stringBuilder.AppendLine("\t\t\tLayerElement:  {");
                stringBuilder.AppendLine("\t\t\t\tType: \"LayerElementMaterial\"");
                stringBuilder.AppendLine("\t\t\t\tTypedIndex: 0");
                stringBuilder.AppendLine("\t\t\t}");
                stringBuilder.AppendLine("\t\t\tLayerElement:  {");
                stringBuilder.AppendLine("\t\t\t\tType: \"LayerElementTexture\"");
                stringBuilder.AppendLine("\t\t\t\tTypedIndex: 0");
                stringBuilder.AppendLine("\t\t\t}");
                stringBuilder.AppendLine("\t\t\tLayerElement:  {");
                stringBuilder.AppendLine("\t\t\t\tType: \"LayerElementUV\"");
                stringBuilder.AppendLine("\t\t\t\tTypedIndex: 0");
                stringBuilder.AppendLine("\t\t\t}");
                stringBuilder.AppendLine("\t\t}");
                bool flag16 = sharedMesh.uv2.Length != 0;
                if (flag16)
                {
                    stringBuilder.AppendLine("\t\tLayer: 1 {");
                    stringBuilder.AppendLine("\t\t\tVersion: 100");
                    stringBuilder.AppendLine("\t\t\tLayerElement:  {");
                    stringBuilder.AppendLine("\t\t\t\tType: \"LayerElementUV\"");
                    stringBuilder.AppendLine("\t\t\t\tTypedIndex: 1");
                    stringBuilder.AppendLine("\t\t\t}");
                    stringBuilder.AppendLine("\t\t}");
                }
                stringBuilder.AppendLine("\t}");
                stringBuilder2.AppendLine("\t;Geometry::, Model::" + sharedMesh.name);
                stringBuilder2.AppendLine(string.Concat(new object[]
                {
                    "\tC: \"OO\",",
                    randomFBXId,
                    ",",
                    randomFBXId2
                }));
                stringBuilder2.AppendLine();
                MeshRenderer component2 = gameObj.GetComponent<MeshRenderer>();
                bool flag17 = component2 != null;
                if (flag17)
                {
                    Material[] sharedMaterials = component2.sharedMaterials;
                    for (int num18 = 0; num18 < sharedMaterials.Length; num18++)
                    {
                        Material material = sharedMaterials[num18];
                        int num19 = Mathf.Abs(material.GetInstanceID());
                        bool flag18 = material == null;
                        if (flag18)
                        {
                            Debug.LogError("ERROR: the game object " + gameObj.name + " has an empty material on it. This will export problematic files. Please fix and reexport");
                        }
                        else
                        {
                            stringBuilder2.AppendLine("\t;Material::" + material.name + ", Model::" + sharedMesh.name);
                            stringBuilder2.AppendLine(string.Concat(new object[]
                            {
                                "\tC: \"OO\",",
                                num19,
                                ",",
                                randomFBXId2
                            }));
                            stringBuilder2.AppendLine();
                        }
                    }
                }
            }
            for (int num20 = 0; num20 < gameObj.transform.childCount; num20++)
            {
                GameObject gameObject = gameObj.transform.GetChild(num20).gameObject;
                FBXMeshGetter.GetMeshToString(gameObject, materials, ref stringBuilder, ref stringBuilder2, gameObj, randomFBXId2);
            }
            objects.Append(stringBuilder.ToString());
            connections.Append(stringBuilder2.ToString());
            return randomFBXId2;
        }
    }
}
