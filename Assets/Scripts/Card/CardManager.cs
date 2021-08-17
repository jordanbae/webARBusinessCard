using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [Header("AssetBundle")]
    [SerializeField] CardAssetLoader card;

    [Header("Profile")]
    [SerializeField] Image myFace;
    [SerializeField] Image myName;

    // Start is called before the first frame update
    void Start()
    {
        myFace.sprite = card.GetFacePic();
        myName.sprite = card.GetNamePic();
    }

    public void GoToWebsite() => Application.OpenURL($"{card.GetWebsite()}");

    public void GoToPhone()
    {
#if UNITY_IOS
        Application.OpenURL($"tel://{card.GetPhoneNumber()}");
#else
        Application.OpenURL($"tel:{card.GetPhoneNumber()}");
#endif
    }

    public void GoToMail()
    {
#if UNITY_IOS
        Application.OpenURL($"mailto://{card.GetEmail()}");
#else
        Application.OpenURL($"mailto:{card.GetEmail()}");
#endif
    }
}
