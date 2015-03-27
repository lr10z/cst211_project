using System;
using System.Windows.Forms;
using CST211ADTLibrary;

namespace CST211GradeMe
{
    public partial class GradeMeForm : Form
    {
        public GradeMeForm()
        {
            InitializeComponent();
        }

        private void AddStatusLine(string status)
        {
            txtStatus.Text += status + "\r\n";
        }

        private class TestException : Exception
        {
        }

        private void Verify(bool condition, string description)
        {
            AddStatusLine("        " + description + ":  " + (condition ? "Passed" : "Failed"));
            if (!condition)
            {
                throw new TestException();
            }
        }

        private delegate void ExceptionTest();

        private void VerifyException(ExceptionTest test, string description, Type expectedExceptionType = null)
        {
            bool passed = false;

            try
            {
                test();
            }
            catch (Exception ex)
            {
                // expecting an exception for this test
                AddStatusLine("        Received: " + ex.GetType().ToString() + ": " + ex.Message);
                if (expectedExceptionType != null)
                {
                    passed = ex.GetType() == expectedExceptionType;
                    if (!passed)
                    {
                        AddStatusLine("        Expected: " + expectedExceptionType.ToString());
                    }
                }
                else
                {
                    // no particular exception expected, anything will do
                    passed = true;
                }
            }

            AddStatusLine("        " + description + ":  " + (passed ? "Passed" : "Failed"));
            if (!passed)
            {
                throw new TestException();
            }
        }

        private class Test
        {
            public delegate void TestProcedure();

            public GradeMeForm form;
            public string name;
            public string description;
            public int pointsAvail;
            public bool passed;
            public int pointsAwarded;
            public TestProcedure proc;

            public Test(GradeMeForm form, string name, string description, int points, TestProcedure proc)
            {
                this.form = form;
                this.name = name;
                this.description = description;
                this.pointsAvail = points;
                this.proc = proc;
                this.passed = true;         // assumed true unless specifically fail
                this.pointsAwarded = 0;
            }

            public void Run()
            {
                form.AddStatusLine("    Test " + name + ": " + description + "...");

                try
                {
                    proc();
                    pointsAwarded = pointsAvail;
                }
                catch (TestException)
                {
                    passed = false;
                }
                catch (Exception ex)
                {
                    passed = false;
                    form.AddStatusLine("        Exception: " + ex.Message);
                }

                form.AddStatusLine("    Test " + name + " " + (passed ? "Passed" : "Failed"));
                form.AddStatusLine("");
            }
        }

        class TestSet
        {
            public GradeMeForm form;
            public string name;
            public string description;
            public int pointsAvail;
            public int pointsAwarded;
            private System.Collections.Generic.LinkedList<Test> tests = new System.Collections.Generic.LinkedList<Test>();

            public TestSet(GradeMeForm form, string name, string description)
            {
                this.form = form;
                this.name = name;
                this.description = description;
                this.pointsAvail = 0;
                this.pointsAwarded = 0;
            }

            public void Run()
            {
                form.AddStatusLine("Test Set " + name + ": " + description + "...");
                form.AddStatusLine("");

                pointsAwarded = 0;
                foreach (Test t in tests)
                {
                    t.Run();
                    pointsAwarded += t.pointsAwarded;
                }
                
                form.AddStatusLine("Test Set " + name + " Score: " + ((pointsAwarded*100.0)/pointsAvail).ToString("0.00") + "%");
                form.AddStatusLine("");
            }

            public void Add(Test t)
            {
                tests.AddLast(t);
                pointsAvail += t.pointsAvail;
            }
        }

        private void GradeMeForm_Load(object sender, EventArgs e)
        {
            txtStatus.Text = "";
            AddStatusLine("Student: " + Library.Student);
            AddStatusLine("Term: " + Library.Term);
            AddStatusLine("Grading...");
            AddStatusLine("");

            System.Collections.Generic.LinkedList<TestSet> testSets = new System.Collections.Generic.LinkedList<TestSet>();

            testSets.AddLast(CreateListTests("ArrayList", () => { return new ArrayList(); }));
            testSets.AddLast(CreateListTests("LinkedList", () => { return new LinkedList(); }));
            testSets.AddLast(CreateStackTests("Stack", () => { return new ArrayListStack(); }));
            testSets.AddLast(CreatePostfixTests("PostfixEvaluator"));
            testSets.AddLast(CreateQueueTests("Queue", () => { return new CircularArrayQueue(); }));
            testSets.AddLast(CreateBankSimulatorTests("BankSimulator"));
            testSets.AddLast(CreateOrderedListTests("OrderedArrayList", () => { return new OrderedArrayList(); }));
            testSets.AddLast(CreateOrderedListTests("OrderedTreeList", () => { return new OrderedTreeList(); }));

            // TODO: separate tests and test infrastructure
            // TODO: allow tests to be run separately or all together
            // TDOO: create a dashboard where you can see score result of each test set and assignment

            // run all test sets
            foreach (TestSet ts in testSets)
            {
                ts.Run();
            }

            AddStatusLine("Grading Done");
        }

        private delegate List ListCreator();

        private TestSet CreateListTests(string name, ListCreator creator)
        {
            TestSet ts = new TestSet(this, name, "All List methods");

            ts.Add(new Test(this, "add/get", "add(obj), get(index)", 1, () =>
            {
                List l1 = creator();
                l1.add("a");
                Verify(((string)l1.get(0)) == "a", "add('a'), get(0) == 'a'");
                l1.add("b");
                Verify(((string)l1.get(1)) == "b", "add('b'), get(1) == 'b'");
                l1.add("c");
                Verify(((string)l1.get(2)) == "c", "add('c'), get(2) == 'c'");
            }));

            ts.Add(new Test(this, "get error", "add(obj), get(index)", 1, () =>
            {
                List l1 = creator();
                VerifyException(() => { Object o = l1.get(0); }, "get(0)");
                l1.add("a");
                VerifyException(() => { Object o = l1.get(1); }, "add('a'), get(1)");
            }));

            ts.Add(new Test(this, "Iterator", "add(obj), iterator(), iter.hasNext(), iter.next()", 1, () =>
            {
                List l1 = creator();
                l1.add("a");
                l1.add("b");
                l1.add("c");
                Iterator ii = l1.iterator();
                Verify(ii.hasNext() == true, "add('a'), add('b'), add('c'), iterator(), iter.hasNext() == true");
                Verify(((string)ii.next()) == "a", "iter.next() == 'a'");
                Verify(((string)ii.next()) == "b", "iter.next() == 'b'");
                Verify(((string)ii.next()) == "c", "iter.next() == 'c'");
                Verify(ii.hasNext() == false, "iter.hasNext() == false");
            }));

            ts.Add(new Test(this, "add/size", "add(obj), size()", 1, () =>
            {
                List l1 = creator();
                Verify(l1.size() == 0, "size() == 0");
                l1.add("a");
                Verify(l1.size() == 1, "add('a'), size() == 1");
                l1.add("b");
                Verify(l1.size() == 2, "add('b'), size() == 2");
            }));

            ts.Add(new Test(this, "big list", "add(obj), size(), get(index)", 1, () =>
            {
                List l1 = creator();
                for (int i = 0; i < 100; i++)
                {
                    l1.add(i.ToString());
                }
                Verify(l1.size() == 100, "add numbers 1 thru 100, size() == 100");
                Verify(((string)l1.get(1)) == "1", "get(1) == '1'");
                Verify(((string)l1.get(42)) == "42", "get(42) == '42'");
                Verify(((string)l1.get(99)) == "99", "get(99) == '99'");
            }));

            ts.Add(new Test(this, "set/get", "add(obj), set(index, obj), get(index)", 1, () =>
            {
                List l1 = creator();
                l1.add("a");
                l1.add("b");
                l1.set(0, "e");
                Verify(((string)l1.get(0)) == "e", "add('a'), add('b'), set(0, 'e'), get(0) == 'e'");
                l1.set(1, "f");
                Verify(((string)l1.get(1)) == "f", "set(1, 'f'), get(1) == 'f'");
            }));

            ts.Add(new Test(this, "insert", "add(obj), add(index, obj), get(index)", 1, () =>
            {
                List l1 = creator();
                l1.add("a");
                l1.add("c");
                l1.add(1, "b");
                Verify(((string)l1.get(1)) == "b", "add('a'), add('c'), add(1, 'b'), get(1) == 'b'");
                Verify(((string)l1.get(0)) == "a", "get(0) == 'a'");
                Verify(((string)l1.get(2)) == "c", "get(2) == 'c'");
                l1.add(0, "e");
                Verify(((string)l1.get(0)) == "e", "add(0, 'e'), get(0) == 'e'");
                Verify(((string)l1.get(1)) == "a", "get(1) == 'a'");
                l1.add(3, "f");
                Verify(((string)l1.get(3)) == "f", "add(3, 'f'), get(3) == 'f'");
                Verify(((string)l1.get(4)) == "c", "get(4) == 'c'");
            }));

            ts.Add(new Test(this, "indexOf", "add(obj), indexOf(obj)", 1, () =>
            {
                List l1 = creator();
                l1.add("a");
                l1.add("b");
                l1.add("c");
                Verify(l1.indexOf("a") == 0, "add('a'), add('b'), add('c'), indexOf('a') == 0");
                Verify(l1.indexOf("b") == 1, "indexOf('b') == 1");
                Verify(l1.indexOf("c") == 2, "indexOf('c') == 2");
                Verify(l1.indexOf("d") == -1, "indexOf('d') == -1");
            }));

            ts.Add(new Test(this, "remove", "add(obj), remove(index), size(), get(index)", 1, () =>
            {
                List l1 = creator();
                l1.add("a");
                l1.add("b");
                l1.add("c");
                Verify(l1.size() == 3, "add('a'), add('b'), add('c'), size() == 3");
                l1.remove(2);
                Verify(l1.size() == 2, "remove(2), size() == 2");
                Verify(((string)l1.get(0)) == "a", "get(0) == 'a'");
                Verify(((string)l1.get(1)) == "b", "get(1) == 'b'");
                l1.remove(0);
                Verify(l1.size() == 1, "remove(0), size() == 1");
                Verify(((string)l1.get(0)) == "b", "get(0) == 'b'");
                l1.remove(0);
                Verify(l1.size() == 0, "remove(0), size() == 0");
                l1.add("e");
                Verify(l1.size() == 1 && ((string)l1.get(0)) == "e", "add('e'), size() == 1 && get(0) == 'e'");
                l1.remove(0);
                Verify(l1.size() == 0, "remove(0), size() == 0");
            }));

            ts.Add(new Test(this, "Iterator.remove", "add(obj), iterator(), iter.remove(), iter.next(), size(), get(index)", 1, () =>
            {
                List l1 = creator();
                l1.add("a");
                l1.add("b");
                l1.add("c");
                Verify(l1.size() == 3, "add('a'), add('b'), add('c'), size() == 3");
                Iterator iter = l1.iterator();
                iter.next();
                iter.remove();
                Verify(l1.size() == 2, "iterator(), iter.next(), iter.remove(), size() == 2");
                Verify(((string)l1.get(0)) == "a", "get(0) == 'a'");
                Verify(((string)l1.get(1)) == "c", "get(1) == 'c'");
                iter.remove();
                Verify(l1.size() == 1, "iter.remove(), size() == 1");
                Verify(((string)l1.get(0)) == "a", "get(0) == 'a'");
                Verify(iter.hasNext() == false, "iter.hasNext() == false");
                iter = l1.iterator();
                Verify(iter.hasNext() == true, "iterator(), iter.hasNext() == true");
                iter.remove();
                Verify(iter.hasNext() == false, "iter.remove(), iter.hasNext() == false");
                Verify(l1.size() == 0, "size() == 0");
            }));

            ts.Add(new Test(this, "ListIterator", "add(obj), listIterator(), iter.hasNext(), iter.next(), iter.nextIndex(), iter.hasPrevious(), previous(), iter.previousIndex()", 1, () =>
            {
                List l1 = creator();
                l1.add("a");
                l1.add("b");
                l1.add("c");
                ListIterator ii = l1.listIterator();
                Verify(ii.hasNext() == true, "add('a'), add('b'), add('c'), listIterator(), iter.hasNext() == true");
                Verify(ii.hasPrevious() == false, "iter.hasPrevious() == false");
                Verify(ii.nextIndex() == 0, "iter.nextIndex() == 0");
                Verify(ii.previousIndex() == -1, "iter.previousIndex() == -1");
                Verify(((string)ii.next()) == "a", "iter.next() == 'a'");
                Verify(ii.nextIndex() == 1, "iter.nextIndex() == 1");
                Verify(ii.previousIndex() == 0, "iter.previousIndex() == 0");
                Verify(((string)ii.next()) == "b", "iter.next() == 'b'");
                Verify(ii.nextIndex() == 2, "iter.nextIndex() == 2");
                Verify(ii.previousIndex() == 1, "iter.previousIndex() == 1");
                Verify(((string)ii.next()) == "c", "iter.next() == 'c'");
                Verify(ii.hasNext() == false, "iter.hasNext() == false");
                Verify(ii.hasPrevious() == true, "iter.hasPrevious() == true");
                Verify(ii.nextIndex() == 3, "iter.nextIndex() == 3");
                Verify(ii.previousIndex() == 2, "iter.previousIndex() == 2");
                Verify(((string)ii.previous()) == "c", "iter.previous() == 'c'");
                Verify(ii.nextIndex() == 2, "iter.nextIndex() == 2");
                Verify(ii.previousIndex() == 1, "iter.previousIndex() == 1");
                Verify(((string)ii.previous()) == "b", "iter.previous() == 'b'");
                Verify(ii.nextIndex() == 1, "iter.nextIndex() == 1");
                Verify(ii.previousIndex() == 0, "iter.previousIndex() == 0");
                Verify(((string)ii.previous()) == "a", "iter.previous() == 'a'");
                Verify(ii.hasPrevious() == false, "iter.hasPrevious() == false");
                Verify(ii.hasNext() == true, "iter.hasNext() == true");
                Verify(ii.nextIndex() == 0, "iter.nextIndex() == 0");
                Verify(ii.previousIndex() == -1, "iter.previousIndex() == -1");
            }));

            ts.Add(new Test(this, "ListIterator.add/set", "add(obj), listIterator(), iter.add(obj), iter.set(index, obj), iter.next(), size(), get(index)", 1, () =>
            {
                List l1 = creator();
                Verify(l1.size() == 0, "size() == 0");
                ListIterator iter = l1.listIterator();
                iter.add("a");
                Verify(l1.size() == 1, "iter.add('a'), size() == 1");
                Verify(((string)l1.get(0)) == "a", "get(0) == 'a'");
                Verify(iter.hasNext() == true, "iter.hasNext() == true");
                Verify(((string)iter.next()) == "a", "iter.next() == 'a'");
                iter.add("b");
                Verify(l1.size() == 2, "iter.add('b'), size() == 2");
                Verify(((string)l1.get(1)) == "b", "get(1) == 'b'");
                Verify(((string)iter.previous()) == "a", "iter.previous() == 'a'");
                iter.set("e");
                Verify(((string)l1.get(0)) == "e", "iter.set('e'), get(0) == 'e'");
            }));

            // TODO: add tests that can distinguish between array and linked list performance
            // TODO: add more tests for exceptions
            // TODO: add tets that call listIterator(index)

            return ts;
        }

        private delegate Stack StackCreator();

        private TestSet CreateStackTests(string name, StackCreator creator)
        {
            TestSet ts = new TestSet(this, name, "All Stack methods");

            ts.Add(new Test(this, "push/peek", "push(obj), peek()", 1, () =>
            {
                Stack s1 = creator();
                s1.push("a");
                Verify(((string)s1.peek()) == "a", "push('a'), peek() == 'a'");
                s1.push("b");
                Verify(((string)s1.peek()) == "b", "push('b'), peek() == 'b'");
                s1.push("c");
                Verify(((string)s1.peek()) == "c", "push('c'), peek() == 'c'");
            }));

            ts.Add(new Test(this, "push/pop", "push(obj), pop()", 1, () =>
            {
                Stack s1 = creator();
                s1.push("a");
                Verify(((string)s1.pop()) == "a", "push('a'), pop() == 'a'");
                s1.push("b");
                s1.push("c");
                Verify(((string)s1.pop()) == "c", "push('b'), push('c'), pop() == 'c'");
                Verify(((string)s1.pop()) == "b", "pop() == 'b'");
            }));

            ts.Add(new Test(this, "empty", "push(obj), pop(), empty()", 1, () =>
            {
                Stack s1 = creator();
                Verify(s1.empty() == true, "empty() == true");
                s1.push("a");
                Verify(s1.empty() == false, "push('a'), empty() == false");
                s1.pop();
                Verify(s1.empty() == true, "pop(), empty() == true");
            }));

            ts.Add(new Test(this, "pop/peek error", "push(obj), pop(), peek()", 1, () =>
            {
                Stack s1 = creator();
                VerifyException(() => { s1.peek(); }, "peek()", typeof(StackEmptyException));
                VerifyException(() => { s1.pop(); }, "pop()", typeof(StackEmptyException));
                s1.push("a");
                s1.pop();
                VerifyException(() => { s1.peek(); }, "push('a'), pop(), peek()", typeof(StackEmptyException));
                VerifyException(() => { s1.pop(); }, "pop()", typeof(StackEmptyException));
                s1.push("b");
                s1.pop();
                VerifyException(() => { s1.pop(); }, "push('b'), pop(), pop()", typeof(StackEmptyException));
                VerifyException(() => { s1.peek(); }, "peek()", typeof(StackEmptyException));
            }));

            return ts;
        }

        private TestSet CreatePostfixTests(string name)
        {
            TestSet ts = new TestSet(this, name, "Various postfix expressions");

            ts.Add(new Test(this, "constant", "try each digit as a constant", 1, () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    PostfixEvaluator ev = new PostfixEvaluator(i.ToString());
                    Verify(ev.eval() == i, "'" + i.ToString() + "' == " + i.ToString());
                }
            }));

            ts.Add(new Test(this, "operator", "try each operator with two operands", 1, () =>
            {
                PostfixEvaluator ev1 = new PostfixEvaluator("6 2 +");
                Verify(ev1.eval() == 8, "'6 2 +' == 8");

                PostfixEvaluator ev2 = new PostfixEvaluator("6 2 -");
                Verify(ev2.eval() == 4, "'6 2 -' == 4");

                PostfixEvaluator ev3 = new PostfixEvaluator("6 2 *");
                Verify(ev3.eval() == 12, "'6 2 *' == 12");

                PostfixEvaluator ev4 = new PostfixEvaluator("6 2 /");
                Verify(ev4.eval() == 3, "'6 2 /' == 3");
            }));

            ts.Add(new Test(this, "twos", "expressions with two operations", 1, () =>
            {
                PostfixEvaluator ev1 = new PostfixEvaluator("3 2 1 + -");
                Verify(ev1.eval() == 0, "'3 2 1 + -' == 0");

                PostfixEvaluator ev2 = new PostfixEvaluator("3 2 1 - +");
                Verify(ev2.eval() == 4, "'3 2 1 - +' == 4");

                PostfixEvaluator ev3 = new PostfixEvaluator("3 2 1 + *");
                Verify(ev3.eval() == 9, "'3 2 1 + *' == 9");

                PostfixEvaluator ev4 = new PostfixEvaluator("3 2 1 * +");
                Verify(ev4.eval() == 5, "'3 2 1 * +' == 5");

                PostfixEvaluator ev5 = new PostfixEvaluator("3 2 1 + /");
                Verify(ev5.eval() == 1, "'3 2 1 + /' == 1");

                PostfixEvaluator ev6 = new PostfixEvaluator("3 2 1 / +");
                Verify(ev6.eval() == 5, "'3 2 1 / +' == 5");
            }));

            ts.Add(new Test(this, "syntax errors", "expressions with various syntax errors", 1, () =>
            {
                PostfixEvaluator ev1 = new PostfixEvaluator("");
                VerifyException(() => { ev1.eval(); }, "empty string", typeof(SyntaxErrorException));

                PostfixEvaluator ev2 = new PostfixEvaluator("3 +");
                VerifyException(() => { ev2.eval(); }, "'3 +' insufficient operands", typeof(SyntaxErrorException));

                PostfixEvaluator ev3 = new PostfixEvaluator("3 2 1 +");
                VerifyException(() => { ev3.eval(); }, "'3 2 1 +' too many operands", typeof(SyntaxErrorException));

                PostfixEvaluator ev4 = new PostfixEvaluator("x y +");
                VerifyException(() => { ev4.eval(); }, "'x y +' invalid operands", typeof(SyntaxErrorException));

                PostfixEvaluator ev5 = new PostfixEvaluator("3 2 &");
                VerifyException(() => { ev5.eval(); }, "'3 2 &' invalid operator", typeof(SyntaxErrorException));
            }));

            return ts;
        }

        private delegate Queue QueueCreator();

        private TestSet CreateQueueTests(string name, QueueCreator creator)
        {
            TestSet ts = new TestSet(this, name, "All Queue methods");

            ts.Add(new Test(this, "insert/peek", "insert(obj), peek()", 1, () =>
            {
                Queue q1 = creator();
                q1.insert("a");
                Verify(((string)q1.peek()) == "a", "insert('a'), peek() == 'a'");
                q1.insert("b");
                Verify(((string)q1.peek()) == "a", "insert('b'), peek() == 'a'");
                q1.insert("c");
                Verify(((string)q1.peek()) == "a", "insert('c'), peek() == 'a'");
                
            }));
            
            ts.Add(new Test(this, "insert/remove", "insert(obj), remove()", 1, () =>
            {
                Queue q1 = creator();
                q1.insert("a");
                Verify(((string)q1.remove()) == "a", "insert('a'), remove() == 'a'");
                q1.insert("b");
                q1.insert("c");
                Verify(((string)q1.remove()) == "b", "insert('b'), insert('c'), remove() == 'b'");
                Verify(((string)q1.remove()) == "c", "remove() == 'c'");
            }));
            
            ts.Add(new Test(this, "empty", "insert(obj), remove(), empty()", 1, () =>
            {
                Queue q1 = creator();
                Verify(q1.empty() == true, "empty() == true");
                q1.insert("a");
                Verify(q1.empty() == false, "insert('a'), empty() == false");
                q1.remove();
                Verify(q1.empty() == true, "remove(), empty() == true");
            }));

            ts.Add(new Test(this, "size", "insert(obj), remove(), size()", 1, () =>
            {
                Queue q1 = creator();
                Verify(q1.size() == 0, "size() == 0");
                q1.insert("a");
                Verify(q1.size() == 1, "insert('a'), size() == 1");
                q1.insert("b");
                Verify(q1.size() == 2, "insert('b'), size() == 2");
                q1.remove();
                Verify(q1.size() == 1, "remove(), size() == 1");
                q1.remove();
                Verify(q1.size() == 0, "remove(), size() == 0");
            }));

            ts.Add(new Test(this, "insert/remove error", "insert(obj), remove(), peek()", 1, () =>
            {
                Queue q1 = creator();
                VerifyException(() => { q1.peek(); }, "peek()", typeof(QueueEmptyException));
                VerifyException(() => { q1.remove(); }, "remove()", typeof(QueueEmptyException));
                q1.insert("a");
                q1.remove();
                VerifyException(() => { q1.peek(); }, "push('a'), pop(), peek()", typeof(QueueEmptyException));
                VerifyException(() => { q1.remove(); }, "remove()", typeof(QueueEmptyException));
                q1.insert("b");
                q1.remove();
                VerifyException(() => { q1.remove(); }, "push('b'), remove(), remove()", typeof(QueueEmptyException));
                VerifyException(() => { q1.peek(); }, "peek()", typeof(QueueEmptyException));
            }));

            // TODO: add "big queue" test where expanded capacity is required, including expanding a queue that has wrapped around

            // TODO: add test that causes the circular feature to be used (wraps around)

            /*
            ////////////////////////////////
            ////////////////////////////////
            ts.Add(new Test(this, "big queue", "insert(obj), remove()", 1, () =>
            {
                Queue q1 = creator();
                for (int i = 0; i < 100; i++)
                {
                    q1.insert(i);
                    Verify(q1.size() == i + 1, "insert(" + i.ToString() + "), size() == " + (i + 1).ToString());
                }

                for (int i = 0; i < 100; i++)
                {
                    Verify((int)q1.remove() == i, "remove() == " + i.ToString());
                }
            }));

            
            ts.Add(new Test(this, "circulate", "insert(obj), remove()", 1, () =>
            {
                Queue q1 = creator();
                q1.insert("a");
                q1.insert("b");
                q1.insert("c");
                q1.insert("d");
                q1.insert("e");
                Verify((string)q1.remove() == "a", "insert(a), insert(b), insert(c), insert(d), insert(e), remove() == a");
                Verify((string)q1.remove() == "b", "remove() == b");
                Verify((string)q1.remove() == "c", "remove() == c");
                q1.insert("f");
                q1.insert("g");
                Verify((string)q1.remove() == "d", "insert(f), insert(g), remove() == d");
                Verify((string)q1.remove() == "e", "remove() == e");
                q1.insert("h");
                q1.insert("i");
                Verify((string)q1.remove() == "f", "insert(h), insert(i), remove() == f");
                Verify((string)q1.remove() == "g", "remove() == g");
                q1.insert("j");
                q1.insert("k");
                Verify((string)q1.remove() == "h", "insert(j), insert(k), remove() == h");
                Verify((string)q1.remove() == "i", "remove() == i");
                q1.insert("l");
                q1.insert("m");
                Verify((string)q1.remove() == "j", "insert(l), insert(m), remove() == j");
                Verify((string)q1.remove() == "k", "remove() == k");
                q1.insert("n");
                q1.insert("o");
                Verify((string)q1.remove() == "l", "insert(n), insert(o), remove() == l");
                Verify((string)q1.remove() == "m", "remove() == m");

            }));
            

            ts.Add(new Test(this, "circulate", "insert(obj), remove()", 1, () =>
            {
                Queue q1 = creator();
                q1.insert("a");
                q1.insert("b");
                q1.insert("c");
                q1.insert("d");
                q1.insert("e");
                Verify((string)q1.remove() == "a", "insert(a), insert(b), insert(c), insert(d), insert(e), remove() == a");
                Verify((string)q1.remove() == "b", "remove() == b");
                Verify((string)q1.remove() == "c", "remove() == c");
                q1.insert("f");
                q1.insert("g");
                Verify((string)q1.remove() == "d", "insert(f), insert(g), remove() == d");
                Verify((string)q1.remove() == "e", "remove() == e");
                q1.insert("h");
                q1.insert("i");
                Verify((string)q1.remove() == "f", "insert(h), insert(i), remove() == f");
                Verify((string)q1.remove() == "g", "remove() == g");
                q1.insert("j");
                Verify(q1.size() == 3, "insert(j), size() == " + (3).ToString());
                q1.insert("k");
                Verify(q1.size() == 4, "insert(k), size() == " + (4).ToString());
                Verify((string)q1.remove() == "h", "remove() == h");
                Verify((string)q1.remove() == "i", "remove() == i");
                Verify(q1.size() == 2, "size() == " + (2).ToString());
                q1.insert("l");
                q1.insert("m");
                Verify((string)q1.remove() == "j", "insert(l), insert(m), remove() == j");
                Verify(q1.size() == 3, "size() == " + (3).ToString());
                Verify((string)q1.remove() == "k", "remove() == k");
                Verify(q1.size() == 2, "size() == " + (2).ToString());
                q1.insert("n");
                q1.insert("o");
                Verify((string)q1.remove() == "l", "insert(n), insert(o), remove() == l");
                Verify((string)q1.remove() == "m", "remove() == m");
                q1.insert("p");
                q1.insert("q");
                q1.insert("r");
                q1.insert("s");
                q1.insert("t");
                q1.insert("u");
                q1.insert("v");
                q1.insert("w");
                Verify(q1.size() == 10, "insert(8 more), size() == " + (10).ToString());
                q1.insert("x");
                Verify(q1.size() == 11, "insert(x), size() == " + (11).ToString());


            }));
            ////////////////////////////////
            ////////////////////////////////
            */

            return ts;
        }

        private TestSet CreateBankSimulatorTests(string name)
        {
            TestSet ts = new TestSet(this, name, "A simulation scenario");

            ts.Add(new Test(this, "no customers", "incoming rate zero", 1, () =>
            {
                BankSimulator sim = new BankSimulator(0, 5, 1);
                Random rand = new Random(0);
                sim.run(rand, 120);

                Verify(sim.customersServed == 0, "sim.customersServed of " + sim.customersServed + " == 0");
                Verify(sim.customersWaiting == 0, "sim.customersWaiting of " + sim.customersWaiting + " == 0");
                Verify(sim.avgWaitTime == 0, "sim.avgWaitTime of " + sim.avgWaitTime + " == 0");
            }));

            ts.Add(new Test(this, "1 teller happy", "Enough for one teller", 1, () =>
            {
                BankSimulator sim = new BankSimulator(10, 5, 1);
                Random rand = new Random(0);
                sim.run(rand, 120);

                Verify(sim.customersServed == 21, "sim.customersServed of " + sim.customersServed + " == 21");
                Verify(sim.customersWaiting == 0, "sim.customersWaiting of " + sim.customersWaiting + " == 0");
                Verify(sim.avgWaitTime == 0, "sim.avgWaitTime of " + sim.avgWaitTime + " == 0");
            }));

            ts.Add(new Test(this, "1 teller sad", "Too much for one teller", 1, () =>
            {
                BankSimulator sim = new BankSimulator(20, 5, 1);
                Random rand = new Random(0);
                sim.run(rand, 120);

                Verify(sim.customersServed == 23, "sim.customersServed of " + sim.customersServed + "  == 23");
                Verify(sim.customersWaiting == 20, "sim.customersWaiting of " + sim.customersWaiting + " == 20");
                Verify(sim.avgWaitTime == 27, "sim.avgWaitTime of " + sim.avgWaitTime + " == 27");
            }));

            ts.Add(new Test(this, "2 teller happy", "Enough for two tellers", 1, () =>
            {
                BankSimulator sim = new BankSimulator(20, 5, 2);
                Random rand = new Random(0);
                sim.run(rand, 120);

                Verify(sim.customersServed == 42, "sim.customersServed of " + sim.customersServed + " == 42");
                Verify(sim.customersWaiting == 0, "sim.customersWaiting of " + sim.customersWaiting + " == 0");
                Verify(sim.avgWaitTime == 0, "sim.avgWaitTime of " + sim.avgWaitTime + " == 0");
            }));

            // TODO: add more cases

            return ts;
        }

        private delegate OrderedList OrderedListCreator();

        private class OrderedInt : Comparable
        {
            // the integer value itself
            private int m_value;
            public OrderedInt(int i) { m_value = i; }
            public int value() { return m_value; }
            public int compareTo(object target)
            {
                m_comparisons++;
                int other = ((OrderedInt)target).m_value;
                if (m_value < other)
                    return -1;
                else if (m_value > other)
                    return 1;
                return 0;
            }

            // for use in keeping stats
            private static int m_comparisons = 0;
            public static void resetStats() { m_comparisons = 0; }
            public static int comparisons { get { return m_comparisons; } }
        }

        private TestSet CreateOrderedListTests(string name, OrderedListCreator creator)
        {
            TestSet ts = new TestSet(this, name, "All OrderedList methods");

            ts.Add(new Test(this, "add/size", "add(obj), size()", 1, () =>
            {
                OrderedList l1 = creator();

                Verify(l1.size() == 0, "size() == 0");
                l1.add(new OrderedInt(1));
                Verify(l1.size() == 1, "add(1), size() == 1");
                l1.add(new OrderedInt(2));
                Verify(l1.size() == 2, "add(2), size() == 2");
                l1.add(new OrderedInt(3));
                Verify(l1.size() == 3, "add(3), size() == 3");
            }));

            ts.Add(new Test(this, "add/iterator", "add(obj), iterator(), iterator.hasNext(), iterator.next()", 1, () =>
            {
                OrderedList l1 = creator();

                l1.add(new OrderedInt(1));
                l1.add(new OrderedInt(2));
                l1.add(new OrderedInt(3));
                Verify(l1.size() == 3, "add(1), add(2), add(3), size() == 3");
                Iterator iter = l1.iterator();
                for (int i = 1; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }
            }));

            ts.Add(new Test(this, "add reverse order", "add(obj), iterator(), iterator.hasNext(), iterator.next()", 1, () =>
            {
                OrderedList l1 = creator();

                l1.add(new OrderedInt(3));
                l1.add(new OrderedInt(2));
                l1.add(new OrderedInt(1));
                Verify(l1.size() == 3, "add(3), add(2), add(1), size() == 3");
                Iterator iter = l1.iterator();
                for (int i = 1; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }
            }));

            ts.Add(new Test(this, "add out of order", "add(obj), iterator(), iterator.hasNext(), iterator.next()", 1, () =>
            {
                OrderedList l1 = creator();

                l1.add(new OrderedInt(2));
                l1.add(new OrderedInt(1));
                l1.add(new OrderedInt(4));
                l1.add(new OrderedInt(3));
                Verify(l1.size() == 4, "add(2), add(1), add(4), add(3), size() == 4");
                Iterator iter = l1.iterator();
                for (int i = 1; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }
            }));

            ts.Add(new Test(this, "add already exists", "add(obj), iterator(), iterator.hasNext(), iterator.next()", 1, () =>
            {
                OrderedList l1 = creator();

                l1.add(new OrderedInt(2));
                l1.add(new OrderedInt(1));
                l1.add(new OrderedInt(3));
                l1.add(new OrderedInt(2));
                Verify(l1.size() == 4, "add(2), add(1), add(3), add(2), size() == 4");
                Iterator iter = l1.iterator();
                int i, j;
                for (i = j = 1; iter.hasNext(); i++, j++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == j, "iter.next() == " + j.ToString());
                    if (i == 2)
                        j--;    // because we have two 2's
                }
            }));

            ts.Add(new Test(this, "find 4 items", "add(obj), iterator(), iterator.hasNext(), iterator.next(), find()", 1, () =>
            {
                OrderedList l1 = creator();

                l1.add(new OrderedInt(2));
                l1.add(new OrderedInt(1));
                l1.add(new OrderedInt(4));
                l1.add(new OrderedInt(3));
                Verify(l1.size() == 4, "add(2), add(1), add(4), add(3), size() == 4");
                
                Iterator iter = l1.find(new OrderedInt(1));
                Verify(iter != null, "find(1), iter != null");
                for (int i = 1; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }
                
                iter = l1.find(new OrderedInt(2));
                Verify(iter != null, "find(2), iter != null");
                for (int i = 2; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }
                
                iter = l1.find(new OrderedInt(3));
                Verify(iter != null, "find(3), iter != null");
                for (int i = 3; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }
                
                iter = l1.find(new OrderedInt(4));
                Verify(iter != null, "find(4), iter != null");
                for (int i = 4; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }

                iter = l1.find(new OrderedInt(5));
                Verify(iter == null, "find(5), iter == null");
            }));

            ts.Add(new Test(this, "find 3 items", "add(obj), iterator(), iterator.hasNext(), iterator.next(), find()", 1, () =>
            {
                OrderedList l1 = creator();

                l1.add(new OrderedInt(2));
                l1.add(new OrderedInt(1));
                l1.add(new OrderedInt(3));
                Verify(l1.size() == 3, "add(2), add(1), add(3), size() == 3");

                Iterator iter = l1.find(new OrderedInt(1));
                Verify(iter != null, "find(1), iter != null");
                for (int i = 1; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }

                iter = l1.find(new OrderedInt(2));
                Verify(iter != null, "find(2), iter != null");
                for (int i = 2; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }

                iter = l1.find(new OrderedInt(3));
                Verify(iter != null, "find(3), iter != null");
                for (int i = 3; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }

                iter = l1.find(new OrderedInt(4));
                Verify(iter == null, "find(4), iter == null");
            }));

            ts.Add(new Test(this, "find 2 items", "add(obj), iterator(), iterator.hasNext(), iterator.next(), find()", 1, () =>
            {
                OrderedList l1 = creator();

                l1.add(new OrderedInt(2));
                l1.add(new OrderedInt(1));
                Verify(l1.size() == 2, "add(2), add(1), size() == 2");

                Iterator iter = l1.find(new OrderedInt(1));
                Verify(iter != null, "find(1), iter != null");
                for (int i = 1; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }

                iter = l1.find(new OrderedInt(2));
                Verify(iter != null, "find(2), iter != null");
                for (int i = 2; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }

                iter = l1.find(new OrderedInt(3));
                Verify(iter == null, "find(3), iter == null");
            }));

            ts.Add(new Test(this, "find 1 item", "add(obj), iterator(), iterator.hasNext(), iterator.next(), find()", 1, () =>
            {
                OrderedList l1 = creator();

                l1.add(new OrderedInt(1));
                Verify(l1.size() == 1, "add(1), size() == 1");

                Iterator iter = l1.find(new OrderedInt(1));
                Verify(iter != null, "find(1), iter != null");
                for (int i = 1; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }

                iter = l1.find(new OrderedInt(2));
                Verify(iter == null, "find(2), iter == null");
            }));

            ts.Add(new Test(this, "find 0 items", "add(obj), iterator(), iterator.hasNext(), iterator.next(), find()", 1, () =>
            {
                OrderedList l1 = creator();

                Verify(l1.size() == 0, "size() == 0");

                Iterator iter = l1.find(new OrderedInt(1));
                Verify(iter == null, "find(1), iter == null");
            }));

            ts.Add(new Test(this, "iterator remove", "add(obj), iterator(), iterator.next(), iterator.remove()", 1, () =>
            {
                OrderedList l1 = creator();

                l1.add(new OrderedInt(2));
                l1.add(new OrderedInt(1));
                l1.add(new OrderedInt(4));
                l1.add(new OrderedInt(3));
                Verify(l1.size() == 4, "add(2), add(1), add(4), add(3), size() == 4");

                Iterator iter = l1.iterator();
                iter.remove();
                Verify(l1.size() == 3, "iterator(), iter.remove(), size() == 3");
                for (int i = 2; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }

                iter = l1.iterator();
                iter.remove();
                Verify(l1.size() == 2, "iterator(), iter.remove(), size() == 2");
                for (int i = 3; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }

                iter = l1.iterator();
                iter.remove();
                Verify(l1.size() == 1, "iterator(), iter.remove(), size() == 1");
                for (int i = 4; iter.hasNext(); i++)
                {
                    OrderedInt oi = (OrderedInt)(iter.next());
                    Verify(oi.value() == i, "iter.next() == " + i.ToString());
                }

                iter = l1.iterator();
                iter.remove();
                Verify(l1.size() == 0, "iterator(), iter.remove(), size() == 0");
            }));

            // TODO: add tests that stress add() and find() to demonstrate O(log n) using ComparableInt's statistics

            return ts;
        }
    }
}
