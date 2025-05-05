using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] weapons; // Silah prefablarý sahneye yerleþtirilmiþ ve deaktif olmalý
    private int selectedIndex = 0;

    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            selectedIndex++;
            if (selectedIndex >= weapons.Length) selectedIndex = 0;
            SelectWeapon();
        }
        else if (scroll < 0f)
        {
            selectedIndex--;
            if (selectedIndex < 0) selectedIndex = weapons.Length - 1;
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == selectedIndex);
        }

        Debug.Log("Aktif silah: " + weapons[selectedIndex].name);
    }
}
