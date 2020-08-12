using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class GuaranteeItemDTO
    {
        public int ID;
        public int createdUser;
        public int itemID;
        public string provider;
        public string stats;
        public string reason;
        public bool isApproved;
        public bool isDeleted;

        public GuaranteeItemDTO(int id, int createdUser, int itemID, string provider, string stats, string reason, bool isApproved, bool isDeleted)
        {
            this.ID = id;
            this.createdUser = createdUser;
            this.itemID = itemID;
            this.provider = provider;
            this.stats = stats;
            this.reason = reason;
            this.isApproved = isApproved;
            this.isDeleted = isDeleted;
        }

        public GuaranteeItemDTO(int createdUser, int itemID, string provider, string stats, string reason, bool isApproved)
        {
            this.createdUser = createdUser;
            this.itemID = itemID;
            this.provider = provider;
            this.stats = stats;
            this.reason = reason;
            this.isApproved = isApproved;
        }
    }
}
