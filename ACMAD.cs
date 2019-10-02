using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;

namespace passive.ACMAD
{
    public class AD
    {
        public AD()
        {
            AD.Host = System.Environment.GetEnvironmentVariable("PASSIVE_AD_HOST");
            AD.User = System.Environment.GetEnvironmentVariable("PASSIVE_AD_USER");
            AD.Password = System.Environment.GetEnvironmentVariable("PASSIVE_AD_PASSWORD");
            AD.Domain = "acm.cs";
            AD.BaseDN = "DC=acm,DC=cs";
            AD.UsersOU = "OU=ACMUsers";
            AD.PaidGroup = "CN=ACMPaid,OU=ACMGroups";
            AD.NotPaidGroup = "CN=ACMNotPaid,OU=ACMGroups";
            AD.DefunctGroup = "CN=ACMDefunct,OU=ACMGroups";
        }
        public static string Host;
        public static string Domain;
        public static string User;
        public static string Password;
        public static string BaseDN;
        public static string UsersOU;
        public static string PaidGroup;
        public static string NotPaidGroup;
        public static string DefunctGroup;
    }
    public class User
    {
        private enum objectClass
        {
            user, group, computer
        }
        private enum returnType
        {
            distinguishedName, ObjectGUID
        }

        private static string GetObjectDistinguishedName(string objectName, objectClass objectCls = objectClass.user, returnType returnValue = returnType.distinguishedName)
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
            DirectoryEntry directoryObject = result.GetDirectoryEntry();
            if (returnValue.Equals(returnType.distinguishedName))
            {
                distinguishedName = directoryObject.Properties["distinguishedName"].Value.ToString();
            }
            if (returnValue.Equals(returnType.ObjectGUID))
            {
                distinguishedName = directoryObject.Guid.ToString();
            }
            entry.Close();
            entry.Dispose();
            mySearcher.Dispose();
            return distinguishedName;
        }

        private static void AddToGroup(string userDn, string groupDn)
        {
            try
            {
                string connectionString = AD.Host + "/" + groupDn + "," + AD.BaseDN;
                DirectoryEntry dirEntry = new DirectoryEntry(connectionString, AD.User, AD.Password);
                dirEntry.Properties["member"].Add(userDn);
                dirEntry.CommitChanges();
                dirEntry.Close();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                throw E;
            }
        }

        private static void RemoveFromGroup(string userDn, string groupDn)
        {
            try
            {
                string connectionString = AD.Host + "/" + groupDn + "," + AD.BaseDN;
                DirectoryEntry dirEntry = new DirectoryEntry(connectionString, AD.User, AD.Password);
                dirEntry.Properties["member"].Remove(userDn);
                dirEntry.CommitChanges();
                dirEntry.Close();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                throw E;
            }
        }

        public bool Authenticate(string username, string password)
        {
            bool authentic = false;
            try
            {
                DirectoryEntry entry = new DirectoryEntry(AD.Host, username, password);
                object nativeObject = entry.NativeObject;
                authentic = true;
            }
            catch (DirectoryServicesCOMException E)
            {
                throw E;
            }
            return authentic;
        }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string UIN { get; set; }
        public string major { get; set; }
        public string college { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string phoneNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string membershipNumber { get; set; }
        public string memberType { get; set; }
        public string otherData { get; set; }

        public static void createOU(string name, string path)
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

        public static string NewMember(User user)
        {
            string userDn = string.Empty;
            try
            {
                string[] months = new string[] { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                string month = "OU=" + months[DateTime.Now.Month];
                string year = "OU=" + DateTime.Now.Year.ToString();

                string connectionString = AD.Host + "/" + AD.UsersOU + "," + AD.BaseDN;
                string monthString = year + "," + AD.UsersOU + "," + AD.BaseDN;
                string yearString = AD.UsersOU + "," + AD.BaseDN;

                DirectoryEntry testing = new DirectoryEntry(connectionString, AD.User, AD.Password);
                Console.WriteLine(testing.Path);
                foreach (DirectoryEntry e in testing.Children) {
                    Console.WriteLine(e.Path);
                }

                createOU(year, yearString);
                createOU(month, monthString);


                string userPath = AD.Host + "/" + month + "," + year + "," + AD.UsersOU + "," + AD.BaseDN;
                DirectoryEntry dirEntry = new DirectoryEntry(userPath, AD.User, AD.Password);
                DirectoryEntry newUser = dirEntry.Children.Add("CN=" + user.userName, "user");

                newUser.Properties["sAMAccountName"].Value = user.userName;
                newUser.Properties["employeeID"].Value = user.UIN;
                newUser.Properties["department"].Value = user.major;
                newUser.Properties["company"].Value = user.college;
                newUser.Properties["title"].Value = user.title;
                newUser.Properties["mail"].Value = user.email;
                newUser.Properties["telephoneNumber"].Value = user.phoneNumber;
                newUser.Properties["givenName"].Value = user.firstName;
                newUser.Properties["sn"].Value = user.lastName;
                newUser.Properties["employeeNumber"].Value = user.membershipNumber;
                newUser.Properties["employeeType"].Value = user.memberType;
                newUser.Properties["description"].Value = user.otherData;
                newUser.CommitChanges();

                userDn = newUser.Properties["distinguishedName"].Value.ToString();

                string userPassword = user.userPassword;
                // set password
                newUser.Invoke("SetPassword", new object[] { userPassword });
                newUser.CommitChanges();

                // unlock account
                newUser.Properties["LockOutTime"].Value = 0;
                newUser.CommitChanges();

                // enable account
                int val = (int)newUser.Properties["userAccountControl"].Value;
                newUser.Properties["userAccountControl"].Value = val & ~0x2;
                newUser.CommitChanges();

                dirEntry.Close();
                User.AddToGroup(userDn, AD.PaidGroup);
                newUser.Close();

            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                throw E;
            }
            return userDn;
        }

        public static string RenewMember(string userName)
        {
            string userDn = string.Empty;
            try
            {
                userDn = GetObjectDistinguishedName(userName);
                string connectionString = AD.Host + "/" + userDn;

                DirectoryEntry user = new DirectoryEntry(connectionString, AD.User, AD.Password);

                User.AddToGroup(user.Properties["distinguishedName"].Value.ToString(), AD.PaidGroup);
                User.RemoveFromGroup(user.Properties["distinguishedName"].Value.ToString(), AD.NotPaidGroup);
                User.RemoveFromGroup(user.Properties["distinguishedName"].Value.ToString(), AD.DefunctGroup);

                user.Close();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                throw E;
            }
            return userDn;
        }


    }

    public class Group
    {

    }

    public class OU
    {

    }

}
