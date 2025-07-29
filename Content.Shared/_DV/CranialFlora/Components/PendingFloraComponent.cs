using Content.Shared.Damage;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Shared._DV.CranialFlora;

/// <summary>
/// Stage 0. At this point you may not even know that you are infected.
/// The infection will, however, actively kill you.
/// <summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class PendingFloraComponent : Component
{
    /// <summary>
    /// Damage dealt every second to infected individuals.
    /// </summary>
    [DataField("damage")]
    public DamageSpecifier Damage = new()
    {
        DamageDict = new()
        {
            { "Poison", 0.3},
        }
    };

    /// <summary>
    /// A multiplier for <see cref="Damage"/> applied when the entity is in critical condition.
    /// </summary>
    [DataField("critDamageMultiplier")]
    public float CritDamageMultiplier = 6.67f;

    [DataField("nextTick", customTypeSerializer:typeof(TimeOffsetSerializer))]
    public TimeSpan NextTick;

    /// <summary>
    /// The amount of time left before the infected begin to take damage.
    /// </summary>
    [DataField("gracePeriod"), ViewVariables(VVAccess.ReadWrite)]
    public TimeSpan GracePeriod = TimeSpan.Zero;

    /// <summary>
    /// The minimum amount of time initial infected have before they start taking infection damage.
    /// </summary>
    [DataField]
    public TimeSpan MinInitialInfectedGrace = TimeSpan.FromMinutes(2f);

    /// <summary>
    /// The maximum amount of time initial infected have before they start taking damage.
    /// </summary>
    [DataField]
    public TimeSpan MaxInitialInfectedGrace = TimeSpan.FromMinutes(4f);

    /// <summary>
    /// The chance each second that a warning will be shown.
    /// </summary>
    [DataField("infectionWarningChance")]
    public float InfectionWarningChance = 0.0166f;

    /// <summary>
    /// Infection warnings shown as popups
    /// </summary>
    [DataField("infectionWarnings")]
    public List<string> InfectionWarnings = new()
    {
        "cranialflora-infection-warning",
        "cranialflora-infection-underway"
    };
}
