namespace Backrooms.Entity {
    public interface IEntity {
        float BaseSpeed { set; }
        float SpeedModifier { set; }
        float ModifiedSpeed { get; }

        float BaseFallSpeed { set; }
        float FallSpeedModifier { set; }
        float ModifiedFallSpeed { get; }
    }
}