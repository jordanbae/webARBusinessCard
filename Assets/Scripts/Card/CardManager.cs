using UnityEngine;
using UnityEngine.UI;
using Zappar;

public class CardManager : MonoBehaviour
{
    [Header("AssetBundle")]
    [SerializeField] CardAssetLoader card;

    [Header("Profile")]
    [SerializeField] Image myFace;
    [SerializeField] Image myName;



    void Start()
    {
        myFace.sprite = card.GetFacePic();
        myName.sprite = card.GetNamePic();
    }

    //    public void GoToWebsite() => Z.device.launchUrl("https://www.yvr-group.com", false);

    //    public void GoToPhone()
    //    {
    //#if UNITY_IOS
    //            Z.device.launchUrl($"tel:{card.GetPhoneNumber()}", false);
    //#else
    //        Z.device.launchUrl($"tel:{card.GetPhoneNumber()}", false);
    //#endif
    //    }

    //    public void GoToMail()
    //    {
    //#if UNITY_IOS
    //                Z.device.launchUrl($"mailto:{card.GetEmail()}", false);
    //#else
    //        Z.device.launchUrl($"mailto:{card.GetEmail()}", false);
    //#endif
    //    }

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
