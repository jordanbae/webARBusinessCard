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

    public void GoToWebsite() => Application.OpenURL("https://www.yvr-group.com/");

    public void GoToPhone()
    {
#if UNITY_IOS
        Application.OpenURL("tel://0827900218");
#else
        Application.OpenURL("tel://0827900218");
#endif
    }

    public void GoToMail()
    {
#if UNITY_IOS
        Application.OpenURL("mailto://yvr.studio.official@gmail.com");
#else
        Application.OpenURL("mailto:yvr.studio.official@gmail.com");
#endif
    }
}
