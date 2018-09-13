using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MVP.Model
{
    [System.Serializable]
    public class UserInfo : AbstractData
    {
        public int userID;
        public string userName;
        public int userScore;
    }
}