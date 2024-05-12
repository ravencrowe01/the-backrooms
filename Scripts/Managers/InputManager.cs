using Backrooms.Common;
using Godot;

namespace Backrooms.Scripts.Managers;

internal partial class InputManager : Node {
    public bool ProcessCharacterInput { get; set; } = false;

    public override void _UnhandledKeyInput (InputEvent @event) {
        if(ProcessCharacterInput) {
            if(@event.IsAction(InputCodes.MoveForward)) {

            }

            if (@event.IsAction (InputCodes.MoveBackward)) {

            }

            if (@event.IsAction (InputCodes.MoveLeft)) {

            }

            if (@event.IsAction (InputCodes.MoveRight)) {

            }
        }

        base._UnhandledKeyInput (@event);
    }
}
