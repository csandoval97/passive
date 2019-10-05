using System.DirectoryServices;

namespace passive.ACMAD {
    public class OU {
        public OU(string name, string path)
        {
            try
            {
                DirectoryEntry ouEntry = new DirectoryEntry(AD.Host + "/" + name + "," + path, AD.User, AD.Password);
                var test = ouEntry.Guid;
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException)
            {
                DirectoryEntry baseEntry = new DirectoryEntry(AD.Host + "/" + path, AD.User, AD.Password);
                baseEntry = baseEntry.Children.Add(name, "OrganizationalUnit");
                baseEntry.CommitChanges();
                baseEntry.Close();
            }
        }
    }
}