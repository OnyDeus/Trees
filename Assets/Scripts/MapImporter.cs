using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

//[ExecuteInEditMode]
public class MapImporter : MonoBehaviour {
	
	public string fileNameToLoad;
	
	public int mapWidth;
	public int mapHeight;
	
	public GameObject Floor;
	public GameObject Bricks;
	public GameObject Wall;
	public GameObject WallWithTorch;
	public GameObject Roof;
	private Transform _ground; 

	
	private int[,] tiles;
	
	void Awake () {
		tiles = Load (Application.dataPath + "\\" + fileNameToLoad);
		BuildMap();
	}
	
	void BuildMap () {
		Debug.Log("Building Map...");
		_ground = GameObject.Find("Ground").transform;
		
		for(int i = 0; i < tiles.GetLength(0); i++) {
			for(int j = 0; j < tiles.GetLength(1); j++) {
				if(tiles[i,j] == 0) {
					GameObject _motherTree = Instantiate(Resources.Load("Prefabs/MotherTree"),new Vector3( j - mapWidth, 0, mapHeight - i),Quaternion.identity) as GameObject;
					_motherTree.name = "MotherTree";

					GameObject _node = Instantiate(Resources.Load("Prefabs/Node(Locked)"),new Vector3( j - mapWidth , 0, mapHeight - i),Quaternion.LookRotation(Vector3.up)) as GameObject;
					_node.transform.parent = _ground;
					
				} else
				if(tiles[i,j] == 1) {
					GameObject _node = Instantiate(Resources.Load("Prefabs/Node"),new Vector3( j- mapWidth, 0, mapHeight - i),Quaternion.LookRotation(Vector3.up)) as GameObject;
					_node.transform.parent = _ground;
					
				} else
				if(tiles[i,j] == 2) {
					GameObject _node = Instantiate(Resources.Load("Prefabs/Node(Locked)"),new Vector3( j -mapWidth, 0, mapHeight - i),Quaternion.LookRotation(Vector3.up)) as GameObject;
					_node.transform.parent = _ground;

				} else
				if(tiles[i,j] == 3) {

				} else
				if(tiles[i,j] == 4) {

				} else
				if(tiles[i,j] == 5) {


				}
			}
		}
		Debug.Log("Building Completed!");
	}
	
	private int[,] Load(string filePath) {
		try {
			Debug.Log("Loading File...");
			using(StreamReader sr = new StreamReader(filePath) ) {
				string input = sr.ReadToEnd();
				string[] lines = input.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
				int[,] tiles = new int[lines.Length, mapWidth];
				Debug.Log("Parsing...");
				for(int i = 0; i < lines.Length; i++) {
					string st = lines[i];
					string[] nums = st.Split(new[] {',' });
					if(nums.Length != mapWidth) {
						
					}
					for(int j = 0; j < Mathf.Min(nums.Length, mapWidth); j++) {
						int val;
						if(int.TryParse(nums[j], out val )) {
							tiles[i,j] = val;
						} else {
							tiles[i,j] = 1;
						}
					}
				}
				Debug.Log("Parsing Completed!");
				return tiles;
			}
		}
		catch(IOException e) {
			Debug.Log(e.Message);
		}
		return null;
	}
}