using System;


namespace CST211ADTLibrary
{
    public class BankSimulator
    {
        // member variables
        private CircularArrayQueue m_customers;

        private double m_arrivalRate;
        private int m_processingTime;
        private int m_tellerCount;

        private List m_customersDone;
        private int m_totalWAITtime;
        private int m_avgWAITtime;
        private int m_numOFcustomers;
        

        // BankSimulator() - constructor for class, takes simulation parameters as input...
        //   arrivalRate - The arrival rate for the customers in customers/hour
        //   processingTime - The average processing time for a customer in minutes
        //   tellerCount - The number of tellers serving customers over the simulation
        public BankSimulator(int arrivalRate, int processingTime, int tellerCount)
        {
            m_customers = new CircularArrayQueue();

            m_arrivalRate = arrivalRate;
            m_processingTime = processingTime;
            m_tellerCount = tellerCount;

            m_customersDone = new ArrayList();
            m_totalWAITtime = 0;
            m_avgWAITtime = 0;
            m_numOFcustomers = 0;
        }




        // properties showing results of last simulation run
        //   customersServed - number of customers successfully served over simulation
        //   customersWaiting - number of customers still waiting at end of simulation
        //   avgWaitTime - average number of minutes customers waited for service over simulation
        public int customersServed { get { return m_customersDone.size(); } }
        public int customersWaiting { get { return m_numOFcustomers; } }//m_customers.size(); } }
        public int avgWaitTime { get { return m_avgWAITtime; } } 




        // run() - performs the simulation for runTime minutes
        // rand - Instance of System.Random to use for random number generation
        // runTime - number of minutes to simulate
        public void run(Random rand, int runTime)
        {

            // initialization
            double arrivedCusts = 0.0;
            List numOFtellers = new ArrayList();


            // loop through # of tellers, and each time through create a teller and add to list
            for (int i = 0; i < m_tellerCount; i++)
            {
                numOFtellers.add(new Teller());
            }


            // simulation loop
            for (int time = 0; time < runTime; time++)
            {

                // number of incoming customers
                // arrivedCusts = rand.NextDouble() * 2.0; 
                arrivedCusts += rand.NextDouble() * 2.0 * m_arrivalRate/60.0;


                // checks for customers who have completed their transactions
                for (int i = 0; i < numOFtellers.size(); i++)
                {
                    Teller currentTell = (Teller)numOFtellers.get(i);

                    // checks if current teller has a customer assigned
                    if (currentTell.m_assigned != null)
                    {

                        // checks if customer assigned is done
                        if( time - currentTell.m_assigned.m_timeAssignedTeller == m_processingTime )
                        {
                            currentTell.m_assigned.isDone(time);

                            m_customersDone.add(currentTell.unassign());
                        }
                    }
                }
                

                // incoming customers
                if (arrivedCusts >= 1.0)
                {
                    // normalize customer count
                    arrivedCusts -= 1.0;

                    // create customer
                    Customer c = new Customer();

                    // add to Q
                    m_customers.insert(c);

                    // keep track of time when customer entered queue
                    c.m_timeEnteredQ = time;
                }


                // assign customers to available tellers
                for (int i = 0; i < numOFtellers.size(); i++)
                {
                    // get available teller( teller )
                    Teller aTeller = (Teller)numOFtellers.get(i);

                    // check if teller is available and if someone is in Q
                    if (aTeller.isAvail() == true && !m_customers.empty() )
                    {
                        // assign customer in Q to teller
                        aTeller.assign((Customer)m_customers.remove(), time);
                    }

                }               
                
            }


            // calculate total wait time of total # of customers
            if (m_customersDone.size() + m_customers.size() == 0)
            {
                return;
            }
            else
            {

                m_numOFcustomers = m_customers.size();

                // calculate total wait time of customers still in queue when bank closes
                for (int i = 0; i < m_numOFcustomers; i++)
                {
                    Customer tempCust = (Customer)m_customers.remove();

                    tempCust.m_timeINq = runTime - tempCust.m_timeEnteredQ;

                    m_totalWAITtime += tempCust.m_timeINq;
                }
                
                // calculate total wait time of customers that have left the bank
                for (int i = 0; i < m_customersDone.size(); i++)
                {
                    Customer tempCust = (Customer)m_customersDone.get(i);

                    m_totalWAITtime += tempCust.m_timeINq;
                }
                

                // calculate average waiting time for all customers
                m_avgWAITtime = m_totalWAITtime / (m_customersDone.size() + m_numOFcustomers);
            }

        }


        // a single customer
        private class Customer
        {
            // member variables
            public int m_timeEnteredQ;
            public int m_timeAssignedTeller;
            public int m_timeleftBank;
            public int m_timeINq;
            

            // notes time customer leaves bank
            public void isDone(int time)
            {
                m_timeleftBank = time;
            }

        }


        // a single teller
        private class Teller
        {
            // customer assigned to teller
            public Customer m_assigned;

            // checks if teller is available
            public bool isAvail()
            {
                if (m_assigned == null)
                {
                    return true;
                }

                return false;
            }
             
            // customer is assigned to teller
            public void assign( Customer cust, int time ) 
            { 
                m_assigned = cust;

                m_assigned.m_timeAssignedTeller = time;

                m_assigned.m_timeINq = m_assigned.m_timeAssignedTeller - m_assigned.m_timeEnteredQ;
            }

            // customer is done and unassigned from teller
            public Customer unassign()
            {
                Customer c = m_assigned;

                m_assigned = null;

                return c;
            }
        }

    }
}
