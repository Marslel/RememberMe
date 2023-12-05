using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Gives a GameObject (and it's Children the Possibility to hide its Renderers and Light Sources 
///  Hides an Object at the beginning of a Game depending on the 
/// </summary>
public class HideObject : MonoBehaviour
{
    [Tooltip("Make the Gameobject visible at the start")]
    [SerializeField]
    bool visibleAtStart;
    public Renderer customRenderer;

    [SerializeField]
    public bool chooseVisibleInGame;
    // Start is called before the first frame update
    void Start()
    {   
        if(!chooseVisibleInGame){
            customRenderer = GetComponent<Renderer>();
            customRenderer.enabled = visibleAtStart;
            var renderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r  in renderers) {
                r.enabled = visibleAtStart;
            }
            var lights = gameObject.GetComponentsInChildren<Light>();
            foreach (Light l  in lights) {
                l.enabled = visibleAtStart;
            }
        }

        
    }

    /// <summary>
    /// Makes a Gameobject and it's children visible
    /// </summary>
    public void makeVisible(){
        customRenderer.enabled = true;
        var renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in renderers) {
            r.enabled = true;
        }
        var lights = gameObject.GetComponentsInChildren<Light>();
        foreach (Light l  in lights) {
            l.enabled = true;
        }
           
    }

    /// <summary>
    /// Makes a Gameobject and it's children invisible
    /// </summary>
    public void makeInvisible(){
        customRenderer.enabled = false;
        var renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r  in renderers) {
            r.enabled = false;
        }
        var lights = gameObject.GetComponentsInChildren<Light>();
        foreach (Light l  in lights) {
            l.enabled = false;
        }

    }


}
