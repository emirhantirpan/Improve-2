using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;

    public GameObject[] weaponPrefabs;

    private GameObject currentWeapon;
    private int currentWeaponIndex = 0;

    void Start()
    {
        EquipWeapon(currentWeaponIndex);
    }

    void Update()
    {
        // Scroll ile silah de�i�tirme
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            // �leri silaha ge�
            currentWeaponIndex++;
            if (currentWeaponIndex >= weaponPrefabs.Length)
                currentWeaponIndex = 0;
            EquipWeapon(currentWeaponIndex);
        }
        else if (scroll < 0f)
        {
            // Geri silaha ge�
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
                currentWeaponIndex = weaponPrefabs.Length - 1;
            EquipWeapon(currentWeaponIndex);
        }
    }

    public void EquipWeapon(int weaponIndex)
    {
        if (weaponIndex < 0 || weaponIndex >= weaponPrefabs.Length)
        {
            Debug.LogWarning("Ge�ersiz silah indeksi!");
            return;
        }

        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        currentWeapon = Instantiate(weaponPrefabs[weaponIndex], weaponHolder);
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;
    }
}
