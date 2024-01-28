using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rocketText;

    private void Awake()
    {
        if(_rocketText == null)
        {
            Debug.LogError("MISSING ROCKET TEXT");
        }
    }

    public void SetRocketAmmo(int ammo)
    {
        _rocketText.text = ammo.ToString();
    }
}
