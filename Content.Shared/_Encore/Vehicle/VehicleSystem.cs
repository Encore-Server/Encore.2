using Content.Shared.Actions;
using Content.Shared.Vehicle;
using Content.Shared.Vehicle.Components;
using Robust.Shared.Audio.Systems;


namespace Content.Shared._Encore.Vehicle;


public sealed class VehicleSystem : EntitySystem
{
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    public override void Initialize()
    {
        SubscribeLocalEvent<VehicleComponent, HornActionEvent>(OnHorn);
    }

    private void OnHorn(EntityUid uid, VehicleComponent component, InstantActionEvent args)
    {
        if (args.Handled == true || component.Driver != args.Performer || component.HornSound == null)
            return;

        _audio.PlayPvs(component.HornSound, uid);
        args.Handled = true;
    }

}

// public sealed partial class HornActionEvent : InstantActionEvent;
//
// public sealed partial class SirenActionEvent : InstantActionEvent;
