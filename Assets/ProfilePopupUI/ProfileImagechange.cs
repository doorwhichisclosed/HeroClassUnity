using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ProfileImagechange : MonoBehaviour
{
    public Image profileImage;

    private void Awake()
    {
		LoadImage();
    }
    public void OnClicked()
    {
		PickImage(500);
    }

	public void PickImage(int maxSize)//이미지를 가져오는 함수
	{
		NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
		{
			Debug.Log("Image path: " + path);
			if (path != null)
			{
				// Create Texture from selected image
				Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
				if (texture == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}
				Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);
				profileImage.sprite = sprite;
				StartCoroutine(SaveImage(texture));

			}
		}, "Select a PNG image", "image/png");

		Debug.Log("Permission result: " + permission);
		if (permission == NativeGallery.Permission.Denied)
		{
			NativeGallery.OpenSettings();
		}
	}

	public IEnumerator SaveImage(Texture2D texture)//이미지 저장하는 함수
    {
		yield return new WaitForEndOfFrame();
		Vector3[] v = new Vector3[4];
		profileImage.GetComponent<RectTransform>().GetWorldCorners(v);
		Texture2D readableTexture = new Texture2D((int)(v[2].x-v[1].x),(int)(v[2].y - v[3].y), TextureFormat.ARGB32, false);
		readableTexture.ReadPixels(new Rect(v[0].x,v[0].y, Screen.width, Screen.height), 0, 0);
		readableTexture.Apply();
		byte[] saveBytes = readableTexture.EncodeToPNG();
		DestroyImmediate(readableTexture);
		string tempPath = Path.Combine(Application.persistentDataPath, "ProfileImage");
		File.WriteAllBytes(tempPath, saveBytes);
	}

	public void LoadImage()//이미지 불러오는 함수
    {
		if (File.Exists(Application.persistentDataPath + "/ProfileImage"))
		{
			byte[] fileData;
			fileData = File.ReadAllBytes(Application.persistentDataPath + "/ProfileImage"); // ERROR: The name 'File' does not exist in the current context?
			Texture2D texture = new Texture2D(2, 2);
			texture.LoadImage(fileData);
			Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);
			profileImage.sprite = sprite;
		}
		else return;
	}
}