using UnityEngine;
using System.Collections;
//using UnityEditor;

public class CreateMesh : MonoBehaviour {
	public Vector3[] vertices;
	public Vector2[] uv;
	public int[] triangles;
	public Material[] materials;

	// Use this for initialization
	void Start () 
	{
		GameObject g = new GameObject("hex");
		g.AddComponent("MeshFilter");
		g.AddComponent("MeshRenderer");
		g.AddComponent("MeshCollider");
		
		Mesh mesh = new Mesh();
		g.GetComponent<MeshFilter>().mesh = mesh;
		mesh.name = "hex";
		mesh.Clear();
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.triangles = triangles;
		mesh.RecalculateNormals();	
		
		g.GetComponent<MeshCollider>().sharedMesh = mesh;


		g.GetComponent<MeshRenderer>().materials = this.materials;
		

		//string guid = AssetDatabase.CreateFolder("Assets", "My Folder");
		//string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
		//AssetDatabase.AddObjectToAsset(mesh , newFolderPath);

		//string filePath = EditorUtility.SaveFilePanelInProject("Save Procedural Mesh", "Procedural Mesh", "asset", "");
		//if (filePath == "") return;
		//AssetDatabase.CreateAsset(mesh, filePath);    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
