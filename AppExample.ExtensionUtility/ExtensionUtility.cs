using MongoDB.Bson;
using System;

namespace AppExample
{
    public static class ExtensionUtility
    {
        public static ObjectId ParseID(string id)
        {
            try
            {
                return ObjectId.Parse(id);
            }
            catch (Exception e)
            {
                return ObjectId.Empty;
            }
        }

        public static ObjectId GenerateID()
        {
            return ObjectId.GenerateNewId();
        }

    }
}
