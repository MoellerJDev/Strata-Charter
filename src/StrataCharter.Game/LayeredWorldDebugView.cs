using Godot;
using StrataCharter.Sim.Pathfinding;
using StrataCharter.Sim.World;

namespace StrataCharter.Game;

public partial class LayeredWorldDebugView : Node2D
{
  private const int GridWidth = 14;
  private const int GridHeight = 9;
  private const int LayerCount = 4;
  private const float TileSize = 34.0f;
  private const float TileGap = 2.0f;
  private const float PathTileInset = 9.0f;
  private const float EndpointTileInset = 5.0f;

  private static readonly Vector2 GridOrigin = new(48.0f, 96.0f);
  private static readonly Vector2 TileExtent = new(TileSize, TileSize);
  private static readonly Color BackgroundColor = new(0.035f, 0.043f, 0.055f);
  private static readonly Color GridLineColor = new(0.13f, 0.15f, 0.17f);
  private static readonly Color OpenTileColor = new(0.45f, 0.62f, 0.56f);
  private static readonly Color SolidTileColor = new(0.36f, 0.32f, 0.31f);
  private static readonly Color BlockedTileColor = new(0.68f, 0.18f, 0.16f);
  private static readonly Color UnknownTileColor = new(0.22f, 0.22f, 0.24f);
  private static readonly Color PathTileColor = new(1.0f, 0.78f, 0.22f, 0.68f);
  private static readonly Color PathStartColor = new(0.12f, 0.52f, 0.95f, 0.9f);
  private static readonly Color PathDestinationColor = new(0.95f, 0.22f, 0.36f, 0.9f);
  private static readonly Color PathEndpointOutlineColor = new(0.98f, 0.96f, 0.88f);
  private static readonly MapPosition DebugPathStart = new(X: 1, Y: 1, Z: 0);
  private static readonly MapPosition DebugPathDestination = new(X: 12, Y: 7, Z: 0);

  private LayeredWorldGrid _grid = null!;
  private PathfindingResult _debugPathResult = null!;
  private Label _statusLabel = null!;
  private int _activeLayer;

  public override void _Ready()
  {
    _grid = LayeredWorldGridFactory.CreateSurfaceAndUnderground(GridWidth, GridHeight, LayerCount);
    _debugPathResult = GridPathfinder.FindPath(_grid, DebugPathStart, DebugPathDestination);
    _statusLabel = new Label
    {
      Name = "LayerStatus",
      Position = new Vector2(24.0f, 20.0f),
      ZIndex = 10,
    };

    AddChild(_statusLabel);
    UpdateLayerStatus();
  }

  public override void _UnhandledInput(InputEvent @event)
  {
    if (@event is not InputEventKey { Pressed: true, Echo: false } keyEvent)
    {
      return;
    }

    switch (keyEvent.Keycode)
    {
      case Key.Q:
        SetActiveLayer(_activeLayer - 1);
        GetViewport().SetInputAsHandled();
        break;
      case Key.E:
        SetActiveLayer(_activeLayer + 1);
        GetViewport().SetInputAsHandled();
        break;
    }
  }

  public override void _Draw()
  {
    if (_grid is null)
    {
      return;
    }

    DrawRect(new Rect2(Vector2.Zero, GetViewportRect().Size), BackgroundColor);

    for (var y = 0; y < _grid.Height; y++)
    {
      for (var x = 0; x < _grid.Width; x++)
      {
        var position = new MapPosition(x, y, _activeLayer);
        var tile = _grid.GetTile(position);
        var tileRect = GetTileRect(position);

        DrawRect(tileRect, GetTileColor(tile));
        DrawRect(tileRect, GridLineColor, filled: false, width: 1.0f);
      }
    }

    DrawDebugPathOverlay();
  }

  private void SetActiveLayer(int layer)
  {
    var nextLayer = Mathf.Clamp(layer, 0, _grid.LayerCount - 1);
    if (nextLayer == _activeLayer)
    {
      return;
    }

    _activeLayer = nextLayer;
    UpdateLayerStatus();
    QueueRedraw();
  }

  private void UpdateLayerStatus()
  {
    _statusLabel.Text =
        $"Layer {_activeLayer + 1}/{_grid.LayerCount}: {GetLayerName(_activeLayer)} | Q/E switch layers | {GetDebugPathStatus()}";
    QueueRedraw();
  }

  private void DrawDebugPathOverlay()
  {
    if (_debugPathResult is null || _activeLayer != DebugPathStart.Z)
    {
      return;
    }

    if (_debugPathResult.Succeeded)
    {
      foreach (var position in _debugPathResult.Path)
      {
        DrawPathTile(position, PathTileColor, PathTileInset, drawOutline: false);
      }
    }

    DrawPathTile(DebugPathStart, PathStartColor, EndpointTileInset, drawOutline: true);
    DrawPathTile(DebugPathDestination, PathDestinationColor, EndpointTileInset, drawOutline: true);
  }

  private void DrawPathTile(MapPosition position, Color color, float inset, bool drawOutline)
  {
    var markerRect = InsetTileRect(GetTileRect(position), inset);
    DrawRect(markerRect, color);

    if (drawOutline)
    {
      DrawRect(markerRect, PathEndpointOutlineColor, filled: false, width: 2.0f);
    }
  }

  private string GetDebugPathStatus()
  {
    if (_debugPathResult is null)
    {
      return "Debug path pending";
    }

    if (!_debugPathResult.Succeeded)
    {
      return $"Debug path unavailable: {_debugPathResult.FailureReason}";
    }

    if (_activeLayer != DebugPathStart.Z)
    {
      return $"Debug path on {GetLayerName(DebugPathStart.Z)}";
    }

    return $"Debug path {DebugPathStart.X},{DebugPathStart.Y} to {DebugPathDestination.X},{DebugPathDestination.Y}";
  }

  private static string GetLayerName(int layer)
  {
    return layer == 0 ? "Surface" : $"Underground {layer}";
  }

  private static Color GetTileColor(Tile tile)
  {
    if (tile == Tile.Blocked)
    {
      return BlockedTileColor;
    }

    if (tile.IsSolid)
    {
      return SolidTileColor;
    }

    if (tile.IsWalkable)
    {
      return OpenTileColor;
    }

    return UnknownTileColor;
  }

  private static Rect2 GetTileRect(MapPosition position)
  {
    var tileOrigin = GridOrigin + new Vector2(position.X * (TileSize + TileGap), position.Y * (TileSize + TileGap));
    return new Rect2(tileOrigin, TileExtent);
  }

  private static Rect2 InsetTileRect(Rect2 tileRect, float inset)
  {
    var insetVector = new Vector2(inset, inset);
    return new Rect2(tileRect.Position + insetVector, tileRect.Size - (insetVector * 2.0f));
  }
}
