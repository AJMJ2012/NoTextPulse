using Terraria;
using Terraria.ModLoader;

namespace NoTextPulse {
	public class NoTextPulse : Mod {
		public override void Load() {
			if (Main.netMode == 2) { return; }
			Main.mouseTextColor = 254;
			On.Terraria.Main.DoUpdate_AnimateCursorColors += (DoUpdate_AnimateCursorColors) => {
				Main.CursorColor();
				Main.masterColor += (float)Main.masterColorDir * 0.05f;
				if (Main.masterColor > 1f)
				{
					Main.masterColor = 1f;
					Main.masterColorDir = -1;
				}
				if (Main.masterColor < 0f)
				{
					Main.masterColor = 0f;
					Main.masterColorDir = 1;
				}
				return;
			};
			On.Terraria.Main.CursorColor += (CursorColor) => {
				Main.cursorColor = Main.mouseColor;
				return;
			};
		}
	}
}
