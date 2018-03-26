using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR.MagicLeap;
using UnityEngine.UI;



public class GestureManger : MonoBehaviour {



    Dictionary<string, Sprite> _gestureImage = new Dictionary<string, Sprite>();

    public Dictionary<string, Sprite> GestureImage
    {
        get
        {
            return _gestureImage;
        }

        set
        {
            _gestureImage = value;
        }
    }



    public Image LeftHandGestureImage;
    public Image RightHandGestureImage;
    public Text GestureIndicatorText;

    void Start()
    {

        Sprite[] images = Resources.LoadAll<Sprite>("GestureImages/") as Sprite[];

        for (int i = 0; i < images.Length; i++)
        {
            GestureImage[images[i].name] = images[i];
        }

        Debug.Log(GestureImage.Count);
    }

    // Update is called once per frame
    void Update()
    {

        if (GestureImage.Count != 0)
        {
            LeftHandGestureImage.sprite = GestureImage[GetGestureHandImage(LeftHandGestureImage.gameObject,
                                                                           MLHands.Left.StaticGesture)];

            RightHandGestureImage.sprite = GestureImage[GetGestureHandImage(RightHandGestureImage.gameObject,
                                                                            MLHands.Right.StaticGesture)];



            GestureIndicatorText.text = string.Format("Left hand has {0} gesture with {1} confidence, \n Right hand has {2} gesture with {3} confidence",
                                                      MLHands.Left.StaticGesture.ToString(), MLHands.Left.GestureConfidence,
                                                      MLHands.Right.StaticGesture.ToString(), MLHands.Right.GestureConfidence);

        }



    }





    string GetGestureHandImage(GameObject Hand,MLStaticGestureType _type){


        switch(_type){
            case MLStaticGestureType.Fist:
                Hand.GetComponent<Animator>().SetTrigger(_type.ToString());
                break;

            case MLStaticGestureType.Pinch:
                Hand.GetComponent<Animator>().SetTrigger(_type.ToString());
                break;

            case MLStaticGestureType.Thumb:
                Hand.GetComponent<Animator>().SetTrigger(_type.ToString());
                break;

            default:
                break;
        }
        return _type.ToString();
    }
}
