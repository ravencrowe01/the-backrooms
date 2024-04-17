using System;

namespace Backrooms.World;

[Flags]
public enum NeighborSearchFlags {
    None = 0,
    SameAxisOnly = 0x1,
    NotOnSameAxis = 0x2
}
