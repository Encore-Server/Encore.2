using Content.Server.Cargo.Components;
using Content.Server.DeviceLinking.Systems;
using Content.Server.Popups;
using Content.Server.Shuttles.Systems;
using Content.Server.Stack;
using Content.Server.Station.Systems;
using Content.Shared.Access.Systems;
using Content.Shared.Administration.Logs;
using Content.Server.Radio.EntitySystems;
using Content.Shared.Cargo;
using Content.Shared.Cargo.Components;
using Content.Shared.Containers.ItemSlots;
using Content.Shared.Mobs.Components;
using Content.Shared.Paper;
using JetBrains.Annotations;
using Robust.Server.GameObjects;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Configuration;
using Robust.Shared.EntitySerialization.Systems;
using Robust.Shared.Map;
using Robust.Shared.EntitySerialization;
using Robust.Shared.EntitySerialization.Systems;
using Robust.Shared.Prototypes;
using Robust.Shared.Timing;
using Robust.Shared.Random;

namespace Content.Server.Cargo.Systems;

public sealed partial class CargoSystem : SharedCargoSystem
{
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly IPrototypeManager _protoMan = default!;
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly ISharedAdminLogManager _adminLogger = default!;
    [Dependency] private readonly AccessReaderSystem _accessReaderSystem = default!;
    [Dependency] private readonly DeviceLinkSystem _linker = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly ItemSlotsSystem _slots = default!;
    [Dependency] private readonly PaperSystem _paperSystem = default!;
    [Dependency] private readonly PopupSystem _popup = default!;
    [Dependency] private readonly PricingSystem _pricing = default!;
    [Dependency] private readonly SharedAppearanceSystem _appearance = default!;
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    [Dependency] private readonly ShuttleConsoleSystem _console = default!;
    [Dependency] private readonly StackSystem _stack = default!;
    [Dependency] private readonly StationSystem _station = default!;
    [Dependency] private readonly UserInterfaceSystem _uiSystem = default!;
    [Dependency] private readonly MetaDataSystem _metaSystem = default!;
    [Dependency] private readonly RadioSystem _radio = default!;
    [Dependency] private readonly IConfigurationManager _cfgManager = default!;
    [Dependency] private readonly SharedMapSystem _sharedMapSystem = default!;
    [Dependency] private readonly MapSystem _mapSystem = default!;
    [Dependency] private readonly IMapManager _mapManager = default!;
    [Dependency] private readonly IEntityManager _entityManager = default!;
    [Dependency] private readonly IComponentFactory _factory = default!;
    [Dependency] private readonly MapLoaderSystem _mapLoader = default!;
    [Dependency] private readonly SharedIdCardSystem _idCardSystem = default!;

    private EntityQuery<TransformComponent> _xformQuery;
    private EntityQuery<CargoSellBlacklistComponent> _blacklistQuery;
    private EntityQuery<MobStateComponent> _mobQuery;
    private EntityQuery<TradeStationComponent> _tradeQuery;

    private HashSet<EntityUid> _setEnts = new();
    private List<EntityUid> _listEnts = new();
    private List<(EntityUid, CargoPalletComponent, TransformComponent)> _pads = new();

    public override void Initialize()
    {
        base.Initialize();

        _xformQuery = GetEntityQuery<TransformComponent>();
        _blacklistQuery = GetEntityQuery<CargoSellBlacklistComponent>();
        _mobQuery = GetEntityQuery<MobStateComponent>();
        _tradeQuery = GetEntityQuery<TradeStationComponent>();

        InitializeConsole();
        InitializeShuttle();
        InitializeTelepad();
        InitializeBounty();
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);
        UpdateConsole(frameTime);
        UpdateTelepad(frameTime);
        UpdateBounty();
    }

    [PublicAPI]
    public void UpdateBankAccount(EntityUid uid, StationBankAccountComponent component, int balanceAdded)
    {
        component.Balance += balanceAdded;
        var query = EntityQueryEnumerator<BankClientComponent, TransformComponent>();

        var ev = new BankBalanceUpdatedEvent(uid, component.Balance);
        while (query.MoveNext(out var client, out var comp, out var xform))
        {
            var station = _station.GetOwningStation(client, xform);
            if (station != uid)
                continue;

            comp.Balance = component.Balance;
            Dirty(client, comp);
            RaiseLocalEvent(client, ref ev);
        }
    }
}
