using Content.Shared._Encore.Actions;
using Content.Shared.Actions;
using Content.Shared.Buckle.Components;
using Content.Shared.Vehicle.Components;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Prototypes;


namespace Content.Shared._Encore.Vehicle;


public sealed class VehicleSystem : EntitySystem
{
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    [Dependency] private readonly SharedActionsSystem _actions = default!;

    public static readonly EntProtoId HornActionId = "ActionHorn";
    public static readonly EntProtoId SirenActionId = "ActionSiren";
    public override void Initialize()
    {
        SubscribeLocalEvent<VehicleComponent, HornActionEvent>(OnHorn);
        SubscribeLocalEvent<VehicleComponent, SirenActionEvent>(OnSiren);
        SubscribeLocalEvent<VehicleComponent, StrappedEvent>(OnEnteredVehicle);
        SubscribeLocalEvent<VehicleComponent, UnstrappedEvent>(OnExitVehicle);
    }

    private void OnHorn(EntityUid uid, VehicleComponent component, InstantActionEvent args)
    {
        if (args.Handled || component.Operator != args.Performer || component.HornSound == null)
            return;

        _audio.PlayPvs(component.HornSound, uid);
        args.Handled = true;
    }

    private void OnSiren(EntityUid uid, VehicleComponent component, InstantActionEvent args)
    {
        if (args.Handled || component.Operator != args.Performer || component.SirenSound == null)
            return;

        if (component.SirenEnabled)
        {
            #pragma warning disable RA0002
            component.SirenStream = _audio.Stop(component.SirenStream);
        }
        else
        {
            component.SirenStream = _audio.PlayPvs(component.SirenSound, uid)?.Entity;
        }

        component.SirenEnabled = !component.SirenEnabled;
        args.Handled = true;
    }

    private void OnEnteredVehicle(Entity<VehicleComponent> ent, ref StrappedEvent args)
    {
        if (ent.Comp.Operator != null)
        {
            AddHorns(ent);
        }
    }

    private void OnExitVehicle(Entity<VehicleComponent> ent, ref UnstrappedEvent args)
    {
        var vehicleComp = ent.Comp;
        var driver = args.Buckle.Owner;

        if (vehicleComp.HornAction != null)
            _actions.RemoveAction((EntityUid)driver, vehicleComp.HornAction);

        if (vehicleComp.SirenAction != null)
            _actions.RemoveAction((EntityUid)driver, vehicleComp.SirenAction);
    }

    private void AddHorns(Entity<VehicleComponent> entity)
    {
        var vehicleComp = entity.Comp;
        var driver = entity.Comp.Operator;
        if (driver == null)
        {
            return;
        }

        if (vehicleComp.HornSound != null)
            _actions.AddAction((EntityUid)driver, ref vehicleComp.HornAction, HornActionId, entity);

        if (vehicleComp.SirenSound != null)
            _actions.AddAction((EntityUid)driver, ref vehicleComp.SirenAction, SirenActionId, entity);
    }

}
