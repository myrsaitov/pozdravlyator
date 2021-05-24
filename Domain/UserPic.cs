﻿using SL2021.Domain.General;

namespace SL2021.Domain
{
    public class UserPic : EntityMutable<int>
    {
        public string URL { get; set; }
        public byte[] ImageData { get; set; }
    }
}