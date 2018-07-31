
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
public class Wrapper_SQLConnection : ISQLConnection {

    /**
     * 
     */
    public Wrapper_SQLConnection()
    {
        mConnection = new SQLConnection();
    }

    /**
     * 
     */
    public SQLConnection mConnection;

    /**
     * 
     */
    public void Open() {
        mConnection.Open();
        // TODO implement here
    }

}