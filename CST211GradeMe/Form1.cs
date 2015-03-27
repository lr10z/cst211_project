using System;
using System.Windows.Forms;
using CST211ADTLibrary;

namespace CST211GradeMe
{
    public partial class Form1 : Form
    {
        List list = null;
        Stack stack = null;
        Queue queue = null;
        OrderedList ordered = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // title bar
            this.Text = "GradeMe! " + Library.Student + ", " + Library.Term;

            // List types
            comboListType.Items.Clear();
            comboListType.Items.Add("ArrayList");
            comboListType.Items.Add("LinkedList");
            comboListType.SelectedIndex = 0;

            // initialize stack
            stack = new ArrayListStack();
            RefreshStack();

            // initialize queue
            queue = new CircularArrayQueue();
            RefreshQueue();

            // List types
            comboOrderedType.Items.Clear();
            comboOrderedType.Items.Add("OrderedArrayList");
            comboOrderedType.Items.Add("OrderedTreeList");
            comboOrderedType.SelectedIndex = 0;
        }

        private void comboListType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboListType.Text == "ArrayList")
            {
                list = new ArrayList();
                RefreshList();
            }
            else if (comboListType.Text == "LinkedList")
            {
                list = new LinkedList();
                RefreshList();
            }
        }

        private void RefreshList()
        {
            txtListContents.Text = "";
            txtListSize.Text = "";

            try
            {
                Iterator it = list.iterator();
                while (it.hasNext())
                {
                    txtListContents.Text += it.next();
                    txtListContents.Text += "\r\n";
                }
                txtListSize.Text = list.size().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListAddToEnd_Click(object sender, EventArgs e)
        {
            try
            {
                list.add(txtListValue.Text);
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListAddAt_Click(object sender, EventArgs e)
        {
            try
            {
                list.add(System.Convert.ToInt32(txtListIndex.Text), txtListValue.Text);
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListRemove_Click(object sender, EventArgs e)
        {
            try
            {
                list.remove(System.Convert.ToInt32(txtListIndex.Text));
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListSetAt_Click(object sender, EventArgs e)
        {
            try
            {
                list.set(System.Convert.ToInt32(txtListIndex.Text), txtListValue.Text);
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetAt_Click(object sender, EventArgs e)
        {
            try
            {
                txtListValue.Text = list.get(System.Convert.ToInt32(txtListIndex.Text)).ToString();
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIndexOf_Click(object sender, EventArgs e)
        {
            try
            {
                txtListIndex.Text = list.indexOf(txtListValue.Text).ToString();
                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGradeMe_Click(object sender, EventArgs e)
        {
            GradeMeForm dlg = new GradeMeForm();
            dlg.ShowDialog();
        }

        private void btnStackPeek_Click(object sender, EventArgs e)
        {
            try
            {
                txtStackValue.Text = stack.peek().ToString();
                RefreshStack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStackPop_Click(object sender, EventArgs e)
        {
            try
            {
                txtStackValue.Text = stack.pop().ToString();
                RefreshStack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStackPush_Click(object sender, EventArgs e)
        {
            try
            {
                stack.push(txtStackValue.Text);
                RefreshStack();
                txtStackValue.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshStack()
        {
            try
            {
                txtStackEmpty.Text = (stack.empty() ? "true" : "false");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            try
            {
                PostfixEvaluator ev = new PostfixEvaluator(txtPostfixExpression.Text);
                int result = ev.eval();
                txtExpressionValue.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQueuePeek_Click(object sender, EventArgs e)
        {
            try
            {
                txtQueueValue.Text = queue.peek().ToString();
                RefreshQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQueueRemove_Click(object sender, EventArgs e)
        {
            try
            {
                txtQueueValue.Text = queue.remove().ToString();
                RefreshQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQueueInsert_Click(object sender, EventArgs e)
        {
            try
            {
                queue.insert(txtQueueValue.Text);
                RefreshQueue();
                txtQueueValue.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshQueue()
        {
            try
            {
                txtQueueEmpty.Text = (queue.empty() ? "true" : "false");
                txtQueueSize.Text = queue.size().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBankRun_Click(object sender, EventArgs e)
        {
            try
            {
                BankSimulator sim = new BankSimulator(
                    System.Convert.ToInt32(txtBankArrivalRate.Text),
                    System.Convert.ToInt32(txtBankProcessingTime.Text),
                    System.Convert.ToInt32(txtBankTellerCount.Text));

                Random rand = null;
                try
                {
                    rand = new Random(System.Convert.ToInt32(txtBankSeed.Text));
                }
                catch (Exception)
                {
                    rand = new Random();
                }
                sim.run(rand, System.Convert.ToInt32(txtBankRunTime.Text));

                txtBankCustsServed.Text = sim.customersServed.ToString();
                txtBankCustsWaiting.Text = sim.customersWaiting.ToString();
                txtBankAvgWaitTime.Text = sim.avgWaitTime.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private class ComparableString : Comparable
        {
            string m_str;

            public ComparableString(string s)
            {
                m_str = s;
            }

            public int compareTo(object target)
            {
                string targetStr = ((ComparableString)target).m_str;
                int result = m_str.CompareTo(targetStr);
                return result;
            }

            public override string ToString()
            {
                return m_str;
            }
        }

        private void btnOrderedAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ordered.add(new ComparableString(txtOrderedValue.Text));
                RefreshOrdered();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshOrdered()
        {
            txtOrderedContents.Text = "";
            txtOrderedSize.Text = "";

            try
            {
                Iterator it = ordered.iterator();
                while (it.hasNext())
                {
                    txtOrderedContents.Text += it.next();
                    txtOrderedContents.Text += "\r\n";
                }
                txtOrderedSize.Text = ordered.size().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOrderedFind_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;
                Iterator iter = ordered.find(new ComparableString(txtOrderedValue.Text));
                if (iter != null)
                {
                    if (iter.hasNext())
                    {
                        ComparableString cs = (ComparableString)iter.next();
                        if (cs != null)
                        {
                            if (cs.ToString() == txtOrderedValue.Text)
                            {
                                found = true;
                            }
                        }
                    }
                }
                
                MessageBox.Show(found ? "Found!" : "Not found!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboOrderedType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboOrderedType.Text == "OrderedArrayList")
            {
                ordered = new OrderedArrayList();
                RefreshOrdered();
            }
            else if (comboOrderedType.Text == "OrderedTreeList")
            {
                ordered = new OrderedTreeList();
                RefreshOrdered();
            }
        }

        private void btnOrderedRemove_Click(object sender, EventArgs e)
        {
            try
            {
                Iterator iter = ordered.find(new ComparableString(txtOrderedValue.Text));
                if (iter != null)
                {
                    iter.remove();
                    RefreshOrdered();
                }
                else
                {
                    MessageBox.Show("Not found in list");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
