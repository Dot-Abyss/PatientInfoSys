using System;
using System.Collections.Generic;
using System.Text;

namespace PatientInfoSys.Application.Common.Pagination
{
    public class PaginationData
    {
        public PaginationData(int totalItems, int currentPage, int itemsPerPage)
        {
            this.totalItems = totalItems;
            this.currentPage = currentPage;
            this.itemsPP = itemsPerPage;
            this.totalPages = (int)Math.Ceiling((double)totalItems/(double)itemsPP);
        }
        public int itemsPP { get; set; }
        public int currentPage { get; private set; }
        public int totalItems { get; private set; }
        public int totalPages { get; private set; }
        public bool hasPrevious => currentPage > 1;
        public bool hasNext => currentPage < totalPages;
    }
}