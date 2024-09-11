using System.Collections.Generic;
using UnityEngine;

public class PreBombGroup : MonoBehaviour
{
    public List<GameObject> preBombs = new();
    public GameObject arrow;
    public bool showing;
    GamepadControls gamepadControls;

    private void Start()
    {
        gamepadControls = GameObject.FindGameObjectWithTag("GamepadController").GetComponent<GamepadControls>();
    }

    public void ShowGroup()
    {
        arrow.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (gamepadControls.gunDirection == Vector2.zero)
        {
            if (arrow.transform.localRotation.eulerAngles.y < 180)
            {
                if (!this.GetComponentInParent<SpriteRenderer>().flipX)
                {
                    this.transform.localScale = Vector3.one;
                    this.transform.localRotation = Quaternion.Euler(0, 0, -arrow.transform.localRotation.eulerAngles.x);
                }
                else
                {
                    this.transform.localScale = Vector3.one - Vector3.right * 2;

                    if (this.transform.position.y > Camera.main.ScreenToWorldPoint(Input.mousePosition).y)
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    }
                    else
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, 270);
                    }
                }

            }
            else
            {
                if (this.GetComponentInParent<SpriteRenderer>().flipX)
                {
                    this.transform.localScale = Vector3.one - Vector3.right * 2;
                    this.transform.localRotation = Quaternion.Euler(0, 0, arrow.transform.localRotation.eulerAngles.x);
                }
                else
                {
                    this.transform.localScale = Vector3.one;

                    if (this.transform.position.y > Camera.main.ScreenToWorldPoint(Input.mousePosition).y)
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, 270);
                    }
                    else
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    }
                }
            }
        }
        else
        {
            if ((gamepadControls.gunDirection.x / Mathf.Abs(gamepadControls.gunDirection.x)) == 1)
            {
                if (!this.GetComponentInParent<SpriteRenderer>().flipX)
                {
                    this.transform.localScale = Vector3.one;
                    
                    if ((gamepadControls.gunDirection.y / Mathf.Abs(gamepadControls.gunDirection.y)) == 1)
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Acos(gamepadControls.gunDirection.x) * Mathf.Rad2Deg);
                    }
                    else
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, -Mathf.Acos(gamepadControls.gunDirection.x) * Mathf.Rad2Deg);
                    }
                }
                else
                {
                    this.transform.localScale = Vector3.one - Vector3.right * 2;

                    if ((gamepadControls.gunDirection.y / Mathf.Abs(gamepadControls.gunDirection.y)) == 1)
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, 270);
                    }
                    else
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    }
                }

            }
            else
            {
                if (this.GetComponentInParent<SpriteRenderer>().flipX)
                {
                    this.transform.localScale = Vector3.one - Vector3.right * 2;

                    if ((gamepadControls.gunDirection.y / Mathf.Abs(gamepadControls.gunDirection.y)) == 1)
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Acos(gamepadControls.gunDirection.x) * Mathf.Rad2Deg - 180);
                    }
                    else
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, -Mathf.Acos(gamepadControls.gunDirection.x) * Mathf.Rad2Deg - 180);
                    }
                }
                else
                {
                    this.transform.localScale = Vector3.one;

                    if ((gamepadControls.gunDirection.y / Mathf.Abs(gamepadControls.gunDirection.y)) == 1)
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, 270);
                    }
                    else
                    {
                        this.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    }
                }
            }
        }
    }

    public void SetBomb(GameObject bomb)
    {
        preBombs.Add(bomb);
    }

    private void Update()
    {
        if (showing)
        {
            ShowGroup();
        }
    }
}