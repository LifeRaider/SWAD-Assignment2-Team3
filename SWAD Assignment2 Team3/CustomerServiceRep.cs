using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomerServiceRep
{
    private string repID;
    public string repName;
    private string repEmail;
    private List<string> repQueries;

    public string RepID { get; set; }
    public string RepName { get; set; }
    public string RepEmail { get; set; }
    public List<string> RepQueries { get; set; }

    public CustomerServiceRep(string rID, string rName, string rEmail, List<string> rQueries)
    {
        repID = rID;
        repName = rName;
        repEmail = rEmail;
        repQueries = rQueries;
    }

    // Query MULTIPLICITY (1:0..*)
    // ====================
    private List<Query> queries;
    public CustomerServiceRep()
    {
        queries = new List<Query>();
    }
    public void addQuery(Query q)
    {
        if (!queries.Contains(q))
        {
            queries.Add(q);
            q.CustomerServiceRep = this;
        }
    }
}
