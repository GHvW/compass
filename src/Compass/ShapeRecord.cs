using Compass.Shapes;

namespace Compass {

    /// <summary>
    /// </summary>
    /// <typeparam name="A"></typeparam>
    public record ShapeRecord<A>(
        ShapeType ShapeType,
        A Shape);
}
