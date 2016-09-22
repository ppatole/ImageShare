using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Project.Entity
{
    public class DbResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> ResponseMessage { get; set; }
        public DataSet ResponseData { get; set; }

        public DbResponse()
        {
            ResponseMessage = new List<string>();
            ResponseData = new DataSet();
        }
    }
}
