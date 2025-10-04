using Robust.Shared.Audio;


namespace Content.Shared.Vehicle.Components;

public sealed partial class VehicleComponent : Component
{
    [ViewVariables]
    public EntityUid? HornAction;

    [ViewVariables]
    public EntityUid? SirenAction;

    public bool SirenEnabled = false;

    public EntityUid? SirenStream;

    /// <summary>
    /// What sound to play when the driver presses the horn action (plays once)
    /// </summary>
    [DataField]
    public SoundSpecifier? HornSound;

    /// <summary>
    /// What sound to play when the driver presses the siren action (loops)
    /// </summary>
    [DataField]
    public SoundSpecifier? SirenSound;

    //  /// <summary>
    // /// What sound to play when the driver presses the horn action (plays once)
    // /// </summary>
    // [DataField]
    // public SoundSpecifier? HornSound = new SoundPathSpecifier("/Audio/Animals/goose_honk.ogg");
    //
    // /// <summary>
    // /// What sound to play when the driver presses the siren action (loops)
    // /// </summary>
    // [DataField]
    // public SoundSpecifier? SirenSound = new SoundPathSpecifier("/Audio/Animals/goose_honk.ogg");
}
