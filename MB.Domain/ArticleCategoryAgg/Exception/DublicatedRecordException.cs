using System;
namespace MB.Domain.ArticleCategoryAgg.Exception
{
    public class DublicatedRecordException: System.Exception
    {
        public DublicatedRecordException()
        {
            
        }

        public DublicatedRecordException(string message):base(message)
        {
            
        }
    }
}
