using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;

public class ConversationAsset : PlayableAsset {

	[Header("Dialogue Info")]
	public ExposedReference<GameObject> canvasObject;
	public ExposedReference<Image> dialogueBoxDisplay;
	public ExposedReference<TMP_Text> dialogueTextDisplay;
	public ExposedReference<TMP_FontAsset> fontAsset;

	public Color dialogueBoxColor;
	[Multiline(3)]
	public string dialogueString;
	public Sprite npcHead;

	public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
	{
		var playable = ScriptPlayable<ConversationPlayable>.Create(graph);
		var conversationPlayable = playable.GetBehaviour();

		var _canvasObject = canvasObject.Resolve(playable.GetGraph().GetResolver());
		var _dialogueBoxDisplay = dialogueBoxDisplay.Resolve (playable.GetGraph ().GetResolver ());
		var _dialogueTextDisplay = dialogueTextDisplay.Resolve (playable.GetGraph ().GetResolver ());
		var _fontAsset = fontAsset.Resolve (playable.GetGraph ().GetResolver ());


		conversationPlayable.Initialize (_canvasObject, _dialogueBoxDisplay, _dialogueTextDisplay, _fontAsset, npcHead, dialogueBoxColor, dialogueString);
		return playable;
	}
}
