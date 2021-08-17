using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "New Data",menuName = "Data/Business Card")]
public class CardData : ScriptableObject
{
    [Header("Profile")]
    public int ID;
    public Sprite avatar;
    public Sprite nameCard;

    [Header("Video")]
    public VideoClip clip;

    [Header("Reference")]
    public string phoneNumber;
    public string website;
    public string email;
}
