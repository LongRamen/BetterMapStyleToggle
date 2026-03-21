using MonoMod.Cil;
using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace BetterMapStyleToggle;

public class BetterMapStyleToggle : Mod
{
    private static FieldInfo mapStyle;

    public override void Load()
    {
        mapStyle = typeof(Main).GetField(nameof(Main.mapStyle), BindingFlags.Public | BindingFlags.Static);

        if (mapStyle is null) Logger.Error("Couldn't find Main.mapStyle FieldInfo");
        else IL_Player.Update += Hook_Player_Update;
    }

    private void Hook_Player_Update(ILContext il)
    {
        try
        {
            ILCursor c = new(il);

            c.GotoNext(MoveType.Before, i => i.MatchLdsfld(mapStyle), i => i.MatchLdcI4(2), i => i.MatchBle(out _));
            c.Index++;
            c.Remove();
            c.EmitLdcI4(1);
        }
        catch (Exception e)
        {
            throw new ILPatchFailureException(ModContent.GetInstance<BetterMapStyleToggle>(), il, e);
        }
    }
}
