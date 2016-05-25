using UnityEngine;
using System.Collections;

public class ColorCycle : MonoBehaviour {

    Renderer render;

	// Use this for initialization
	void Start () {
        render = this.GetComponent<MeshRenderer> ();
        InvokeRepeating ("ColorChange", 0f, 4f);
	}
	
	void ColorChange () {
        Debug.Log ("change");
        Color colorRandom = new Color (Random.Range(0f,1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1f);
        render.material.color = Color.Lerp (render.material.color, colorRandom, 0.5f);

    }

}
