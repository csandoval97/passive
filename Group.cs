using System.DirectoryServices;

namespace passive.ACMAD
{
    public class Group
    {
        public Group()
        {

        }

        public static void AddMember(string userDn, string groupDn)
        {
            try
            {
                DirectoryEntry dirEntry = AD.GetObjectDirectoryEntry(groupDn);
                dirEntry.Properties["member"].Add(userDn);
                
                dirEntry.CommitChanges();
                dirEntry.Close();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                throw E;
            }
        }

        public static void RemoveMember(string userDn, string groupDn)
        {
            try
            {
                DirectoryEntry dirEntry = AD.GetObjectDirectoryEntry(groupDn);
                dirEntry.Properties["member"].Remove(userDn);

                dirEntry.CommitChanges();
                dirEntry.Close();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                throw E;
            }
        }
    }
}