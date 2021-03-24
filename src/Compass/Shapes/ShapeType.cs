
namespace Compass.Shapes {

    public enum ShapeType {
        Null,
        Point,
        PolyLine,
        Polygon,
        MultiPoint,
        PointZ,
        PolyLineZ,
        PolygonZ,
        MultiPointZ,
        PointM,
        PolyLineM,
        PolygonM,
        MultiPointM,
        MultiPatch
    }

    public static class ShapeTypeExtensions {

        public static ShapeType ToShapeType(this int @this) => @this switch {
            0 => ShapeType.Null,
            5 => ShapeType.Polygon,
            _ => throw new System.Exception($"Invalid ShapeType index: {@this}")
        };
    }
}
