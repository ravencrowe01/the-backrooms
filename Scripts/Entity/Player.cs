using Godot;

namespace Backrooms.Entity;

internal partial class Player : CharacterBody3D, IEntity {
    public Vector3 NextDirection { get; set; } = new Vector3 (0f, 0f, 0f);

    public float BaseSpeed { private get; set; } = 14f;

    public float SpeedModifier { private get; set; } = 1f;

    public float ModifiedSpeed => BaseSpeed * SpeedModifier;

    public float BaseFallSpeed { private get; set; } = 75f;

    public float FallSpeedModifier { private get; set; } = 1f;

    public float ModifiedFallSpeed => BaseFallSpeed * FallSpeedModifier;

    public override void _PhysicsProcess (double delta) {
        var _targetVelocity = NextDirection * BaseSpeed;

        _targetVelocity.X *= BaseSpeed;
        _targetVelocity.Y *= BaseSpeed;

        if (!IsOnFloor ()) {
            _targetVelocity -= new Vector3 (0f, (float) (BaseFallSpeed * delta), 0f);
        }

        Velocity = _targetVelocity;

        MoveAndSlide ();
    }
}
