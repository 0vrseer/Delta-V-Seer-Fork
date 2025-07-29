using Content.Shared.Damage;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Shared._DV.CranialFlora;

[RegisterComponent, NetworkedComponent]
public sealed partial class CranialFloraComponent : Component
{
    /// <summary>
    /// Baseline resistance to spore embedding if you have no protective gear
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    public float BaseSporeEmbedResistance = 0.25f;

    /// <summary>
    /// Maximum resistance to spore embedding possible.
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite)]
    public float MaxSporeEmbedResistance = 0.5f;

    /// <summary>
    /// How effective each resistance type on a piece of armor is.
    /// </summary>
    public DamageSpecifier ResistanceEffectiveness = new()
    {
        DamageDict = new()
        {
            {"Piercing", 0.3},
        }
    };

    /// <summary>
    /// The blood reagent of the humanoid to restore in case of cloning
    /// </summary>
    [DataField("beforeInfectedBloodReagent")]
    public string BeforeInfectedBloodReagent = string.Empty;

    [ViewVariables(VVAccess.ReadWrite)]
    public float Stage3MovementSpeedDebuff = 0.70f;

    /// <summary>
    /// The eye color of the humanoid to restore in case of cloning
    /// </summary>
    [DataField("beforeInfectedEyeColor")]
    public Color BeforeInfectedEyeColor;

    [DataField("eyeColor")]
    public Color EyeColor = new(0.992f, 1f, 0f);

    /// <summary>
    /// Damage dealt on stage3 hit
    /// <summary>
    [DataField]
    public DamageSpecifier DamageOnStage3Hit = new()
    {
        DamageDict = new()
        {
            { "Blunt", 15 },
            { "Structural", 10 }
        }
    };

    //TODO: emote

    //TODO: sounds

    //TODO: greatsound

    //TODO: bloodreagent

}
