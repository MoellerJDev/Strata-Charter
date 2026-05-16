using Godot;
using StrataCharter.Sim.World;

namespace StrataCharter.Game;

public partial class LayeredWorldDebugView : Node2D
{
  private const int GridWidth = 14;
  private const int GridHeight = 9;
  private const int LayerCount = 4;
  private const float TileSize = 34.0f;
  private const float TileGap = 2.0f;

  private static readonly Vector2 GridOrigin = new(48.0f, 96.0f);
  private static readonly Vector2 TileExtent = new(TileSize, TileSize);
  private static readonly Color BackgroundColor = new(0.035f, 0.043f, 0.055f);
  private static readonly Color GridLineColor = new(0.13f, 0.15f, 0.17f);
  private static readonly Color OpenTileColor = new(0.45f, 0.62f, 0.56f);
  private static readonly Color SolidTileColor = new(0.36f, 0.32f, 0.31f);
  private static readonly Color BlockedTileColor = new(0.68f, 0.18f, 0.16f);
  private static readonly Color UnknownTileColor = new(0.22f, 0.22f, 0.24f);

  private LayeredWorldGrid _grid = null!;
  private Label _statusLabel = null!;
  private int _activeLayer;

  public override void _Ready()
  {
    _grid = LayeredWorldGridFactory.CreateSurfaceAndUnderground(GridWidth, GridHeight, LayerCount);
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
        var tileOrigin = GridOrigin + new Vector2(x * (TileSize + TileGap), y * (TileSize + TileGap));
        var tileRect = new Rect2(tileOrigin, TileExtent);

        DrawRect(tileRect, GetTileColor(tile));
        DrawRect(tileRect, GridLineColor, filled: false, width: 1.0f);
      }
    }
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
    _statusLabel.Text = $"Layer {_activeLayer + 1}/{_grid.LayerCount}: {GetLayerName(_activeLayer)} | Q/E switch layers";
    QueueRedraw();
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
}
