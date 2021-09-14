﻿using System.Collections.Generic;

namespace WordCounter.Client.DTOs
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
