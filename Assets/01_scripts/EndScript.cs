using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public RoomHappyeffect background;
    public new CameraMovement camera;
    public Image img;
    public float fadestep;
    float currentalpha;
    public float zoomstep;
    public float maxzoom;
    public Transform goalpos;
    public SetShaderProp thiss;
    public SetShaderProp player;
    public GameObject outside;
    public string goalscene;
    private void Start()
    {
        img.color = new Vector4(img.color.r, img.color.g, img.color.b, 0);
    }

    private void Update()
    {
        

            outside.SetActive(false);
        player.enabled = false;
        thiss.enabled = true;
            
            background.active = true;
            camera.player = goalpos;
            if (camera.transform.position.z >= -maxzoom)
            {
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z - zoomstep * Time.deltaTime);

            }
            if (background.increaseamount >= background.maxsize)
            {
                currentalpha += fadestep * Time.deltaTime;
                img.color = new Vector4(img.color.r, img.color.g, img.color.b, currentalpha);
            }
            
            if (currentalpha >= 1)
            {
                SceneManager.LoadScene(goalscene);
            }
        
    }
}
