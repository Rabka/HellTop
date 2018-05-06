using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = true;
    public GameObject PauseMenuUI;
    public MusikPlayerScript MusikPlayer;
    public float MusikMax = .6f;
    public float MusikMin = .3f;
    public Text MuteText;
    public RectTransform Cursor;
    public float CursorMove = 40f;

    private int _button = 0;
    private float _lastButton = 0;
    private float _waitButton = 0.2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("AllPause") || Input.GetKeyDown(KeyCode.Escape))
	    {
	        if (GameIsPaused)
	        {
	            Resume();
	        }
	        else
	        {
	            PauseMenuUI.SetActive(true);
	            MusikPlayer.Volume = MusikMin;
                //Time.timeScale = 0f;
	            GameIsPaused = true;
	        }
	    }

	    if ((Input.GetButtonDown("AllA") || Input.GetKeyDown(KeyCode.Space)) && Time.time > _lastButton + _waitButton)
	    {
	        _lastButton = Time.time;
	        if (_button == 0)
                Resume();
	        if (_button == 1)
	            Mute();
	        if (_button == 2)
	            Restart();
        }

	    if ((Input.GetAxis("AllVertical") < -0.8 || Input.GetKeyDown(KeyCode.UpArrow)) &&
	        Time.time > _lastButton + _waitButton)
	    {
	        _lastButton = Time.time;
	        if (_button > 0)
	        {
	            _button--;
	            Cursor.position += new Vector3(0f, CursorMove);

	        }
	    }

	    if ((Input.GetAxis("AllVertical") > 0.8 || Input.GetKeyDown(KeyCode.DownArrow)) &&
	        Time.time > _lastButton + _waitButton)
	    {
	        _lastButton = Time.time;
	        if (_button < 2)
	        {
	            _button++;
	            Cursor.position += new Vector3(0f, -CursorMove);
            }
	    }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        MusikPlayer.Volume = MusikMax;
        //Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Mute()
    {
        MuteText.text = MusikPlayer.MuteFlip() ? "Mute [v]" : "Mute [ ]";
    }

    public void Restart()
    {

    }
}
