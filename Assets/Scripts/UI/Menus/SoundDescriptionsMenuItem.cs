using UnityEngine;
using UnityEngine.UI;

public class SoundDescriptionsMenuItem : MonoBehaviour
{
    private string _desc;


    // Use this for initialization
    private void Start()
    {
        _desc = transform.Find("DescriptionField").GetComponent<InputField>().text;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Find("SelectButton").GetComponent<Button>().interactable =
            AudioTextLoader.GetSelectedDescription(GameObject.Find("DescriptionsMenu(Clone)")
                .GetComponent<SoundDescriptionsMenu>().Clip.Name) !=
            transform.Find("DescriptionField").GetComponent<InputField>().text;
    }


    public void Select()
    {
        AudioTextLoader.SetSelectedDescription(
            GameObject.Find("DescriptionsMenu(Clone)").GetComponent<SoundDescriptionsMenu>().Clip.Name,
            transform.Find("DescriptionField").GetComponent<InputField>().text);
        UpdateSetting();
    }


    public void Remove()
    {
        UpdateSetting();
        AudioTextLoader.RemoveDescription(GameObject.Find("DescriptionsMenu(Clone)")
            .GetComponent<SoundDescriptionsMenu>().Clip.Name, _desc);
        Destroy(gameObject);
    }


    public void UpdateSetting()
    {
        AudioTextLoader.ChangeDescription(GameObject.Find("DescriptionsMenu(Clone)")
            .GetComponent<SoundDescriptionsMenu>().Clip.Name, _desc, transform.Find("DescriptionField").GetComponent<InputField>().text);
        _desc = transform.Find("DescriptionField").GetComponent<InputField>().text;
    }
}