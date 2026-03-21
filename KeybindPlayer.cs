using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterMapStyleToggle;

public class KeybindPlayer : ModPlayer
{
    public static ModKeybind MapStyle0Keybind { get; private set; }
    public static ModKeybind MapStyle1Keybind { get; private set; }
    public static ModKeybind MapStyle2Keybind { get; private set; }

    public override void Load()
    {
        MapStyle0Keybind = KeybindLoader.RegisterKeybind(Mod, "MapStyle0", Keys.None);
        MapStyle1Keybind = KeybindLoader.RegisterKeybind(Mod, "MapStyle1", Keys.None);
        MapStyle2Keybind = KeybindLoader.RegisterKeybind(Mod, "MapStyle2", Keys.None);
    }

    public override void Unload()
    {
        MapStyle0Keybind = null;
        MapStyle1Keybind = null;
        MapStyle2Keybind = null;
    }

    public override void ProcessTriggers(TriggersSet triggersSet)
    {
        if (MapStyle0Keybind.JustPressed)
        {
            Main.mapStyle = 0;
            SoundEngine.PlaySound(SoundID.MenuTick);
        }
        if (MapStyle1Keybind.JustPressed)
        {
            Main.mapStyle = 1;
            SoundEngine.PlaySound(SoundID.MenuTick);
        }
        if (MapStyle2Keybind.JustPressed)
        {
            Main.mapStyle = 2;
            SoundEngine.PlaySound(SoundID.MenuTick);
        }
    }
}
