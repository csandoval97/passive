using System;
using System.Collections.Generic;
using System.Linq;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;

namespace passive.ACMAD
{
    public class AD
    {
        public static AD singleton;
        public AD()
        {
            AD.Host = System.Environment.GetEnvironmentVariable("PASSIVE_AD_HOST");
            AD.User = System.Environment.GetEnvironmentVariable("PASSIVE_AD_USER");
            AD.Password = System.Environment.GetEnvironmentVariable("PASSIVE_AD_PASSWORD");
            AD.Domain = new List<string>() {System.Environment.GetEnvironmentVariable("PASSIVE_AD_DOMAIN"), "acm.cs"}.FirstOrDefault(e => e != String.Empty);
            AD.BaseDN = new List<string>() {System.Environment.GetEnvironmentVariable("PASSIVE_AD_BASEDN"), "DC=acm,DC=cs"}.FirstOrDefault(e => e != String.Empty) ;
            AD.UsersOU = "OU=" + new List<string>() {System.Environment.GetEnvironmentVariable("PASSIVE_AD_USERSOU"), "ACMUsers" }.FirstOrDefault(e => e != String.Empty) + "," + AD.BaseDN;
            AD.GroupsOU = "OU=" + new List<string>() {System.Environment.GetEnvironmentVariable("PASSIVE_AD_GROUPSOU"), "ACMGroups"}.FirstOrDefault(e => e != String.Empty)  + "," + AD.BaseDN;
            AD.PaidGroup = "CN=" + new List<string>() {System.Environment.GetEnvironmentVariable("PASSIVE_AD_PAIDGROUP"), "ACMPaid"}.FirstOrDefault(e => e != String.Empty) + "," + AD.GroupsOU;
            AD.NotPaidGroup = "CN=" + new List<string>() {System.Environment.GetEnvironmentVariable("PASSIVE_AD_NOTPAIDGOUP"), "ACMNotPaid"}.FirstOrDefault(e => e != String.Empty)  + "," + AD.GroupsOU;
            AD.DefunctGroup = "CN=" + new List<string>() {System.Environment.GetEnvironmentVariable("PASSIVE_AD_DEFUNCTGOUP"), "ACMDefunct"}.FirstOrDefault(e => e != String.Empty)  + "," + AD.GroupsOU;
            AD.AlumniGroup = "CN=" + new List<string>() {System.Environment.GetEnvironmentVariable("PASSIVE_AD_ALUMNIGROUP"), "ACMAlumni"}.FirstOrDefault(e => e != String.Empty)  + "," + AD.GroupsOU;
        }
        public static string Host;
        public static string Domain;
        public static string User;
        public static string Password;
        public static string BaseDN;
        public static string UsersOU;
        public static string GroupsOU;
        public static string PaidGroup;
        public static string NotPaidGroup;
        public static string DefunctGroup;
        public static string AlumniGroup;

        public static string GetObjectDistinguishedName(string objectName, objectClass objectCls = objectClass.user, returnType returnValue = returnType.distinguishedName)
        {
            DirectoryEntry directoryObject = GetObjectDirectoryEntry(objectName, objectCls, returnValue);
            string distinguishedName = String.Empty;
            if (returnValue.Equals(returnType.distinguishedName))
            {
                distinguishedName = directoryObject.Properties["distinguishedName"].Value.ToString();
            }
            if (returnValue.Equals(returnType.ObjectGUID))
            {
                distinguishedName = directoryObject.Guid.ToString();
            }
            return distinguishedName;
        }
        public static DirectoryEntry GetObjectDirectoryEntry(string objectName, objectClass objectCls = objectClass.user, returnType returnValue = returnType.distinguishedName)
        {
            string distinguishedName = string.Empty;
            string connectionString = AD.Host + "/" + AD.BaseDN;
            DirectoryEntry entry = new DirectoryEntry(connectionString, AD.User, AD.Password);
            DirectorySearcher mySearcher = new DirectorySearcher(entry);

            switch (objectCls)
            {
                case objectClass.user:
                    mySearcher.Filter = "(&(objectClass=user)(| (cn = " + objectName + ")(sAMAccountName = " + objectName + ")))";
                    break;
                case objectClass.group:
                    mySearcher.Filter = "(&(objectClass=group)(| (cn = " + objectName + ")(dn = " + objectName + ")))";
                    break;
                case objectClass.computer:
                    mySearcher.Filter = "(&(objectClass=computer)(| (cn = " + objectName + ")(dn = " + objectName + ")))";
                    break;
            }
            SearchResult result = mySearcher.FindOne();

            if (result == null)
            {
                throw new NullReferenceException
                ("unable to locate the distinguishedName for the object " +
                objectName + " in the " + AD.Domain + " domain");
            }
            DirectoryEntry ret = result.GetDirectoryEntry();
            mySearcher.Dispose();
            entry.Close();
            entry.Dispose();
            return ret;
        }
        public static DirectoryEntry GetObjectDirectoryEntry(string distinguishedName)
        {
            DirectoryEntry entry;
            string connectionString = ((AD.Host != String.Empty) ? (AD.Host + "/") : "") + distinguishedName;
            if (AD.User != String.Empty && AD.Password != String.Empty)
            {
                entry = new DirectoryEntry(connectionString, AD.User, AD.Password);
            }
            else
            {
                entry = new DirectoryEntry(connectionString);
            }
            try
            {
                var _ = entry.Guid;
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException)
            {
                throw (new System.Exception("Cannot find object. distinguishedName: " + distinguishedName));
            }
            return entry;
        }
    }
}
