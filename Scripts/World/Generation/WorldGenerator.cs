using System;

namespace Backrooms.World.Generation;

public class WorldGenerator {
    private int GenerateSeed (int seed, int x, int y) => seed ^ ShiftLeftWithWrap (x, 8) ^ ShiftRightWithWrap (y, 8);

    private int ShiftRightWithWrap (int num, int bits) {
        if (bits <= 0) {
            return num;
        }

        int flag = (int) Math.Pow (2, bits) - 1;

        var flagged = num & flag;

        flagged <<= 32 - bits;

        num >>= bits;

        num |= flagged;

        return num;
    }

    private int ShiftLeftWithWrap (int num, int bits) {
        if (bits <= 0) {
            return num;
        }

        int flag = (int) Math.Pow (2, bits) - 1;

        var flagged = num & (flag << 32 - bits);

        flagged >>= 32 - bits;

        num <<= bits;

        num |= flagged;

        return num;
    }
}
