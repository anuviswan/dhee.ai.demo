using System.Collections.Generic;

namespace leave_management.server.Dtos
{
    public class DheeResponseDto<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public IEnumerable<string> ResetList { get; set; }
        public string ErrorMessageKey { get; set; }
    }
}
