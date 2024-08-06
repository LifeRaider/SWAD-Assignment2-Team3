using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CODI, S10241842
public class User
{
    // Private Attributes
    private string userName;
    private string userContact;
    private DateTime userDOB;
    private string userDriversLicense;
    private string userStatus;
    private string userID;
    private string userAddress;

    // Public Properties
    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    public string UserContact
    {
        get { return userContact; }
        set { userContact = value; }
    }

    public DateTime UserDOB
    {
        get { return userDOB; }
        set { userDOB = value; }
    }

    public string UserDriversLicense
    { 
        get { return userDriversLicense; }
        set { userDriversLicense = value; }
    }

    public string UserStatus
    {
        get { return userStatus; }
        set { userStatus = value; }
    }

    public string UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    public string UserAddress
    {
        get { return userAddress; }
        set { userAddress = value; }
    }

    public User() { }
    public User(string userName, string userContact, DateTime userDOB, string userDriversLicense, string userStatus, string userID, string userAddress)
    {
        this.userName = userName;
        this.userContact = userContact;
        this.userDOB = userDOB;
        this.userDriversLicense = userDriversLicense;
        this.userStatus = userStatus;
        this.userID = userID;
        this.userAddress = userAddress;
    }

    // ADMIN MULTIPLICITY (0..*:1)
    private Admin admin;
    public Admin Admin {
        set {
            if (admin != value) {
                admin = value;
                value.addUser(this);
            }
        }
    }

    // QUERY MULTIPLICITY (1:0..*)
    private List<Query> queries;
    public void addQuery(Query q) {
        if (!queries.Contains(q)) {
            queries.Add(q);
            q.User = this;
        }
    }
}