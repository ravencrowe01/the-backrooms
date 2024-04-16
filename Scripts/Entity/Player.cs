using Godot;

namespace Backrooms.Entity;

public class Player : Node3D, IMoveableEntity {
    public Vector3 NextDirection { get; set; } = new Vector3 (0, 0, 0);

    [Export]
    private float _speed = 14;

    [Export]
    private float _fallSpeed = 75;

    public override void _PhysicsProcess (double delta) {
        var _targetVelocity = NextDirection * _speed;

        _targetVelocity.X *= _speed;
        _targetVelocity.Y *= _speed;

        if(!IsOnFloor) {
            _targetVelocity -= _fallSpeed * delta;
        }

        _targetVelocity = _targetVelocity;
        MoveAndSlide ();
    }
}
