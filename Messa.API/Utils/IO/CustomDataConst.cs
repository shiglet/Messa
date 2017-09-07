﻿using System;

namespace Messa.IO
{
    public class CustomDataConst
    {
        public  static int INT_SIZE = 32;
        public static int SHORT_SIZE = 16;
        public static int SHORT_MIN_VALUE = -32768;
        public static int SHORT_MAX_VALUE = 32767;
        public static int UNSIGNED_SHORT_MAX_VALUE = 65536;
        public static int CHUNCK_BIT_SIZE = 7;
        public static double MAX_ENCODING_LENGTH = Math.Ceiling((double)INT_SIZE / CHUNCK_BIT_SIZE);
        public static int MASK_10000000 = 128;
        public static int MASK_01111111 = 127;
    }
}
