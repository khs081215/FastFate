using UnityEngine;
using System.Collections;
/**
 * 플레이어와 최근 공격한 적의 status를 GUI에 표시합니다.
 */
public class CharacterStatusGui : MonoBehaviour
{
	public GUIStyle nameLabelStyle;
	public Texture backLifeBarTexture;
	public Texture frontLifeBarTexture;

	#region private member
    private float baseWidth = 1600f;
    private float baseHeight = 900f;
    private CharacterStatus playerStatus;
    private Vector2 playerStatusOffset = new Vector2(8f, 80f);
    private Rect nameRect = new Rect(0f, 0f, 1200f, 24f);
    private float frontLifeBarOffsetX = 2f;
    private float lifeBarTextureWidth = 128f;
    private Rect playerLifeBarRect = new Rect(0f, 0f, 500f, 32f);
    private Color playerFrontLifeBarColor = Color.green;
    private Rect enemyLifeBarRect = new Rect(0f, 0f, 1400f, 20f);
    private Color enemyFrontLifeBarColor = Color.red;
    #endregion private member
    
    void Awake()
    {
	    PlayerMovemnetController playerMovemnetController = GameObject.FindObjectOfType(typeof(PlayerMovemnetController)) as PlayerMovemnetController;
	    playerStatus =playerMovemnetController.GetComponent<CharacterStatus>();
    }
    void DrawPlayerStatus()
    {
        float x = playerStatusOffset.x;
        float y = baseHeight-playerStatusOffset.y;
        DrawCharacterStatus(
            x, y,
            playerStatus,
            playerLifeBarRect,
            playerFrontLifeBarColor);
    }
	
    void DrawEnemyStatus()
    {
		if (playerStatus.lastAttackTarget != null)
        {
			CharacterStatus target_status = playerStatus.lastAttackTarget.GetComponent<CharacterStatus>();
            DrawCharacterStatus(
                (baseWidth - enemyLifeBarRect.width) / 2.0f, 0f,
				target_status,
                enemyLifeBarRect,
                enemyFrontLifeBarColor);
        }
    }
	
    void DrawCharacterStatus(float x, float y, CharacterStatus status, Rect bar_rect, Color front_color)
    {
        // 이름.
        GUI.Label(
            new Rect(x, y, nameRect.width, nameRect.height),
			status.characterName,
            nameLabelStyle);
		
		float life_value = (float)status.HP / status.MaxHP;
		if(backLifeBarTexture != null)
		{
			y += nameRect.height;
			GUI.DrawTexture(new Rect(x, y, bar_rect.width, bar_rect.height), backLifeBarTexture);
		}
		
		if(frontLifeBarTexture != null)
		{
			float resize_front_bar_offset_x = frontLifeBarOffsetX * bar_rect.width / lifeBarTextureWidth;
			float front_bar_width = bar_rect.width - resize_front_bar_offset_x * 2;
			var gui_color = GUI.color;
			GUI.color = front_color;
			GUI.DrawTexture(new Rect(x + resize_front_bar_offset_x, y, front_bar_width * life_value, bar_rect.height), frontLifeBarTexture);
			GUI.color = gui_color;
		}
    }

    

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(
            Vector3.zero,
            Quaternion.identity,
            new Vector3(Screen.width / baseWidth, Screen.height / baseHeight, 1f));
        
        DrawPlayerStatus();
        DrawEnemyStatus();
    }
}