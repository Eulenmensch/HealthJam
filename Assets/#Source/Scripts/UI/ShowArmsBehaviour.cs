using System;
using DG.Tweening;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Source.Scripts
{
	public class ShowArmsBehaviour : MonoBehaviour
	{
		[SerializeField] private RectTransform RightArm;
		[SerializeField] private RectTransform LeftArm;
		[SerializeField] private RectTransform SpaceBar;

		[SerializeField] private float RightArmHiddenPosition;
		[SerializeField] private float RightArmShownPosition;
		[SerializeField] private float LeftArmHiddenPosition;
		[SerializeField] private float LeftArmShownPosition;
		[SerializeField] private float SpaceBarHiddenPosition;
		[SerializeField] private float SpaceBarShownPosition;

		[SerializeField] private float RightArmTiming;
		[SerializeField] private float LeftArmTiming;
		[SerializeField] private float SpaceBarTiming;

		private void Start()
		{
			var rightArmPosition = RightArm.localPosition;
			rightArmPosition.y = RightArmHiddenPosition;
			RightArm.localPosition = rightArmPosition;

			var leftArmPosition = LeftArm.localPosition;
			leftArmPosition.y = LeftArmHiddenPosition;
			LeftArm.localPosition = leftArmPosition;

			var spaceBarPosition = SpaceBar.localPosition;
			spaceBarPosition.y = SpaceBarShownPosition;
			SpaceBar.localPosition = spaceBarPosition;
		}

		public void ToggleArms (InputAction.CallbackContext context)
		{
			if (context.started)
			{
				ShowArms();
				HideSpaceBar();
			}

			if (context.canceled)
			{
				HideArms();
				ShowSpaceBar();
			}
		}

		private void ShowArms()
		{
			RightArm.DOLocalMoveY( RightArmShownPosition, RightArmTiming).SetEase(Ease.OutBounce);
			LeftArm.DOLocalMoveY(LeftArmShownPosition, LeftArmTiming).SetEase(Ease.OutBounce);
		}

		private void ShowSpaceBar()
		{
			SpaceBar.DOLocalMoveY(SpaceBarShownPosition, SpaceBarTiming).SetEase(Ease.OutCirc);
		}

		private void HideArms()
		{
			RightArm.DOLocalMoveY(RightArmHiddenPosition, RightArmTiming).SetEase(Ease.InOutCirc);
			LeftArm.DOLocalMoveY(LeftArmHiddenPosition, LeftArmTiming).SetEase(Ease.InCirc);
		}

		private void HideSpaceBar()
		{
			SpaceBar.DOLocalMoveY(SpaceBarHiddenPosition, SpaceBarTiming).SetEase(Ease.InCubic);
		}
	}
}