using System;

namespace Backrooms.Common;

public static class Utility {
    public static int ShiftRightWithWrap (int num, int bits) {
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

    public static int ShiftLeftWithWrap (int num, int bits) {
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
